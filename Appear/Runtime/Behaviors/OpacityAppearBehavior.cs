using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;
using VRBuilder.Core;
using VRBuilder.Core.Attributes;
using VRBuilder.Core.Behaviors;
using VRBuilder.Core.Configuration;
using VRBuilder.Core.Properties;
using VRBuilder.Core.SceneObjects;
using VRBuilder.Core.Utils;

namespace VRBuilder.Community
{
    /// <summary>
    /// Let's on object appear by raising its opacity over time form 0 to 1
    /// </summary>
    [DataContract(IsReference = true)]
    [HelpLink("https://www.mindport.co/vr-builder-tutorials/")] // TODO: Add tutorial and tutorial link
    public class OpacityAppearBehavior : Behavior<OpacityAppearBehavior.EntityData>
    {
        /// <summary>
        /// The "appear" behavior's data.
        /// </summary>
        [DisplayName("OpacityAppear")]
        [DataContract(IsReference = true)]
        public class EntityData : IBehaviorData
        {

            /// <summary>
            /// Target scene object to appear.
            /// </summary>
            [DataMember]
            [DisplayName("Object")]
            public MultipleScenePropertyReference<OpaqueProperty> TargetObject { get; set; }

            /// <summary>
            /// Duration of the appearing. If duration is equal or less than zero, the object will appear immediately.
            /// </summary>
            [DataMember]
            [DisplayName("Duration (in seconds)")]
            public float Duration { get; set; }

            /// <summary>
            /// Determines the scale of the object at a given time. The curve is normalized, the duration of the appearing can be set in the <see cref="Duration"/> field.
            /// </summary>
            [DataMember]
            [DisplayName("Appear curve")]
            public AnimationCurve OpacityCurve { get; set; }

            /// <inheritdoc />
            public Metadata Metadata { get; set; }

            /// <inheritdoc />
            [IgnoreDataMember]
            public string Name => $"Let {TargetObject} appear";
        }

        private class ActivatingProcess : StageProcess<EntityData>
        {
            private float startingTime;

            public ActivatingProcess(EntityData data) : base(data)
            {
            }

            /// <inheritdoc />
            public override void Start()
            { 
                foreach (OpaqueProperty opaqueProperty in Data.TargetObject.Values)
                {
                    RuntimeConfigurator.Configuration.SceneObjectManager.RequestAuthority(opaqueProperty
                        .SceneObject);

                    startingTime = Time.time;
                    opaqueProperty.SetValue(0);
                    opaqueProperty.SceneObject.GameObject.SetActive(true);
                }
            }

            /// <inheritdoc />
            public override IEnumerator Update()
            {

                while (Time.time - startingTime < Data.Duration)
                {
                    foreach (OpaqueProperty opaqueProperty in Data.TargetObject.Values)
                    {
                        opaqueProperty.SetValue(GetAnimationProgress(Data.OpacityCurve, false));
                        yield return null;
                    }
                }
            }

            /// <inheritdoc />
            public override void End()
            {
                foreach (OpaqueProperty opaqueProperty in Data.TargetObject.Values)
                {
                    opaqueProperty.SetValue(1);
                }
            }

            public override void FastForward()
            {
            }


            private float GetAnimationProgress(AnimationCurve curve, bool isReversed)
            {
                if (isReversed)
                {
                    return Mathf.Clamp01(curve.Evaluate((Data.Duration - (Time.time - startingTime)) / Data.Duration * curve.keys.Last().time));
                }
                else
                {
                    return Mathf.Clamp01(curve.Evaluate((Time.time - startingTime) / Data.Duration * curve.keys.Last().time));
                }
            }
        }

        [JsonConstructor, Preserve]
        public OpacityAppearBehavior() : this(Guid.Empty, 0f, null)
        {
            Data.Duration = 1;
            Data.OpacityCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }

        public OpacityAppearBehavior(OpaqueProperty target, float duration, AnimationCurve opacityCurve) : this(ProcessReferenceUtils.GetUniqueIdFrom(target), duration, opacityCurve)
        {
        }

        public OpacityAppearBehavior(Guid targetObjectId, float duration, AnimationCurve opacityCurve)
        {
            Data.TargetObject = new MultipleScenePropertyReference<OpaqueProperty> (targetObjectId);
            Data.Duration = duration;
            Data.OpacityCurve = opacityCurve;
        }

        /// <inheritdoc />
        public override IStageProcess GetActivatingProcess()
        {
            return new ActivatingProcess(Data);
        }
    }
}
