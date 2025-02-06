using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Animates an object's transform over time to a new position, rotation and/or scale.
    /// </summary>
    [DataContract(IsReference = true)]
    [HelpLink("https://www.mindport.co/vr-builder-tutorials/")] // TODO: Add tutorial and tutorial link
    public class AppearBehavior : Behavior<AppearBehavior.EntityData>
    {
        /// <summary>
        /// The "appear" behavior's data.
        /// </summary>
        [DisplayName("Appear")]
        [DataContract(IsReference = true)]
        public class EntityData : IBehaviorData
        {
            /// <summary>
            /// Target scene object to appear.
            /// </summary>
            [DataMember]
            [DisplayName("Object")]
            public MultipleSceneObjectReference TargetObjects { get; set; }


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
            public AnimationCurve ScaleCurve { get; set; }

            /// <inheritdoc />
            public Metadata Metadata { get; set; }

            /// <inheritdoc />
            [IgnoreDataMember]
            public string Name => $"Let {TargetObjects} appear";
        }

        private class ActivatingProcess : StageProcess<EntityData>
        {
            private float startingTime;
            private Dictionary<ISceneObject, Vector3> targetScales;

            public ActivatingProcess(EntityData data) : base(data)
            {
                targetScales = new Dictionary<ISceneObject, Vector3>();
            }

            /// <inheritdoc /> GameObject.transform.localScale
            public override void Start()
            {
                foreach (ISceneObject sceneObject in Data.TargetObjects.Values)
                {
                    RuntimeConfigurator.Configuration.SceneObjectManager.RequestAuthority(sceneObject);
               
                    startingTime = Time.time;
                    targetScales[sceneObject] = sceneObject.GameObject.transform.localScale;
                    sceneObject.GameObject.transform.localScale = Vector3.zero;
                    sceneObject.GameObject.SetActive(true);
                }
            }

            /// <inheritdoc />
            public override IEnumerator Update()
            {
                foreach (ISceneObject sceneObject in Data.TargetObjects.Values)
                {
                    Transform appearingTransform = sceneObject.GameObject.transform;

                    if (appearingTransform == null || appearingTransform.Equals(null))
                    {
                        string warningFormat =
                            "The process scene object's game object is null, appearing is not completed, behavior activation is forcefully finished.";
                        warningFormat += "Target object unique name: {0}, Transform provider Guid: {1}";
                        Debug.LogWarningFormat(warningFormat, sceneObject.Guid);
                        yield break;
                    }

                    while (Time.time - startingTime < Data.Duration)
                    {
                        RuntimeConfigurator.Configuration.SceneObjectManager.RequestAuthority(sceneObject);

                        appearingTransform.localScale = Vector3.Lerp(Vector3.zero, targetScales[sceneObject],
                            GetAnimationProgress(Data.ScaleCurve, false));
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

                    sceneObject.GameObject.transform.localScale = targetScales[sceneObject];
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
        public AppearBehavior() : this(Guid.Empty, 0f, null)
        {
            Data.Duration = 1;
            Data.ScaleCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }

        public AppearBehavior(ISceneObject target, float duration, AnimationCurve scaleCurve) : this(ProcessReferenceUtils.GetUniqueIdFrom(target), duration, scaleCurve)
        {
        }

        public AppearBehavior(Guid targetObjectId, float duration, AnimationCurve scaleCurve)
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
