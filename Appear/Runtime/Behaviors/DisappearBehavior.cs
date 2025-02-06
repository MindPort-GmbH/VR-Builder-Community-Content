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
using VRBuilder.Core.SceneObjects;
using VRBuilder.Core.Utils;

namespace VRBuilder.Community
{
    /// <summary>
    /// Let's an object disappear
    /// </summary>
    [DataContract(IsReference = true)]
    [HelpLink("https://www.mindport.co/vr-builder-tutorials/")] // TODO: Add tutorial and tutorial link
    public class DisappearBehavior : Behavior<DisappearBehavior.EntityData>
    {
        /// <summary>
        /// The "disappear" behavior's data.
        /// </summary>
        [DisplayName("Disappear")]
        [DataContract(IsReference = true)]
        public class EntityData : IBehaviorData
        {
            /// <summary>
            /// Target scene object to disappear.
            /// </summary>
            [DataMember]
            [DisplayName("Object")]
            public MultipleSceneObjectReference TargetObjects { get; set; }


            /// <summary>
            /// Duration of the disappering. If duration is equal or less than zero, the object will disappear immediately.
            /// </summary>
            [DataMember]
            [DisplayName("Duration (in seconds)")]
            public float Duration { get; set; }

            /// <summary>
            /// Determines the scale of the object at a given time. The curve is normalized, the duration of the disappearing can be set in the <see cref="Duration"/> field.
            /// </summary>
            [DataMember]
            [DisplayName("Disappear curve")]
            public AnimationCurve ScaleCurve { get; set; }

            /// <inheritdoc />
            public Metadata Metadata { get; set; }

            /// <inheritdoc />
            [IgnoreDataMember]
            public string Name => $"Let {TargetObjects} disappear";
        }

        private class ActivatingProcess : StageProcess<EntityData>
        {
            private float startingTime;
            private Vector3 initialScale;

            public ActivatingProcess(EntityData data) : base(data)
            {
            }

            /// <inheritdoc />
            public override void Start()
            {
                foreach (ISceneObject sceneObject in Data.TargetObjects.Values)
                {
                    RuntimeConfigurator.Configuration.SceneObjectManager.RequestAuthority(sceneObject);

                    startingTime = Time.time;
                    initialScale = sceneObject.GameObject.transform.localScale;
                }
            }

            /// <inheritdoc />
            public override IEnumerator Update()
            {
                foreach (ISceneObject sceneObject in Data.TargetObjects.Values)
                {

                    Transform disappearingTransform = sceneObject.GameObject.transform;

                    if (disappearingTransform == null || disappearingTransform.Equals(null))
                    {
                        string warningFormat =
                            "The process scene object's game object is null, disappearing is not completed, behavior activation is forcefully finished.";
                        warningFormat += "Target object unique name: {0}, Transform provider Guid: {1}";
                        Debug.LogWarningFormat(warningFormat, sceneObject.Guid);
                        yield break;
                    }

                    while (Time.time - startingTime < Data.Duration)
                    {
                        RuntimeConfigurator.Configuration.SceneObjectManager.RequestAuthority(sceneObject);

                        disappearingTransform.localScale = Vector3.Lerp(initialScale, Vector3.zero,
                            GetAnimationProgress(Data.ScaleCurve, true));
                        yield return null;
                    }
                }
            }

            /// <inheritdoc />
            public override void End()
            {
                foreach (ISceneObject sceneObject in Data.TargetObjects.Values)
                {

                    RuntimeConfigurator.Configuration.SceneObjectManager.RequestAuthority(sceneObject);

                    sceneObject.GameObject.SetActive(false);
                    sceneObject.GameObject.transform.localScale = initialScale;
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
        public DisappearBehavior() : this(Guid.Empty, 0f, null)
        {
            Data.Duration = 1;
            Data.ScaleCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);
        }

        public DisappearBehavior(ISceneObject target, float duration, AnimationCurve scaleCurve) : this(ProcessReferenceUtils.GetUniqueIdFrom(target), duration, scaleCurve)
        {
        }

        public DisappearBehavior(Guid targetObjectId, float duration, AnimationCurve scaleCurve)
        {
            Data.TargetObjects = new MultipleSceneObjectReference(targetObjectId);
            Data.Duration = duration;
            Data.ScaleCurve = scaleCurve;
        }

        /// <inheritdoc />
        public override IStageProcess GetActivatingProcess()
        {
            return new ActivatingProcess(Data);
        }
    }
}
