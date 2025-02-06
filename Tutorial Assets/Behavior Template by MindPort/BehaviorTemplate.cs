using System;
using Newtonsoft.Json;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.Scripting;
using VRBuilder.BasicInteraction.Properties;
using VRBuilder.Core;
using VRBuilder.Core.Attributes;
using VRBuilder.Core.Behaviors;
using VRBuilder.Core.SceneObjects;

// It is recommended you put your code in a namespace.
namespace MindPort.Examples
{
    /// <summary>
    /// This is a non-functional example behavior.
    /// </summary>
    [DataContract(IsReference = true)]
    [HelpLink("https://www.mindport.co/vr-builder-tutorials/creating-custom-behaviors")] // You can add this link if you have online documentation.
    public class BehaviorTemplate : Behavior<BehaviorTemplate.EntityData>
    {
        /// <summary>
        /// Data class for this behavior.
        /// </summary>
        [DisplayName("Example Behavior")]
        [DataContract(IsReference = true)]
        public class EntityData : IBehaviorData
        {
            /// <summary>
            /// This is a reference to a <see cref="ProcessSceneObject"/>.
            /// </summary>
            [DataMember]
            [DisplayName("Object")]
            public SingleSceneObjectReference SceneObjectReference { get; set; }

            /// <summary>
            /// This is a reference to a specific property on a <see cref="ProcessSceneObject"/>.
            /// If the property is not present on the object, the user will have the option to add it after
            /// dragging an object in the field.
            /// </summary>
            [DataMember]
            [DisplayName("Property Reference")]
            public SingleScenePropertyReference<IGrabbableProperty> GrabbableProperty { get; set; }

            /// <summary>
            /// This is a simple serializable value. All data in this class need to be serializable,
            /// or it won't be saved in the process JSON.
            /// </summary>
            [DataMember]
            public float FloatValue { get; set; }

            // The following properties are required by interfaces and internal to VR Builder.

            /// <inheritdoc />
            public Metadata Metadata { get; set; }

            /// <inheritdoc />
            public string Name { get; set; }
        }

        /// <summary>
        /// This is the class containing the behavior logic.
        /// </summary>
        private class BehaviorTemplateProcess : StageProcess<EntityData>
        {
            /// <summary>
            /// You need this constructor in order to pass the data class to the stage process.
            /// </summary>            
            public BehaviorTemplateProcess(EntityData data) : base(data)
            {
            }

            /// <summary>
            /// Start of the stage process. Can be used to initialize stuff and execute instant behaviors.
            /// </summary>
            public override void Start()
            {
                // How to access the data class:
                IGrabbableProperty myGrabbableProperty = Data.GrabbableProperty.Value;
                float myFloat = Data.FloatValue;
            }

            /// <summary>
            /// Update is called every frame. Don't forget to yield after every frame.
            /// Note that this update cycle should end at some point.
            /// </summary>            
            public override IEnumerator Update()
            {
                yield return null;
            }

            /// <summary>
            /// Called when the update cycle ends.
            /// Can be used to tidy up things or execute instant behaviors.
            /// </summary>
            public override void End()
            {
            }

            /// <summary>
            /// Instantly simulates the update cycle. Used when skipping a behavior.
            /// </summary>
            public override void FastForward()
            {
            }
        }

        /// <summary>
        /// Every VR Builder entity needs an empty constructor.
        /// </summary>
        [JsonConstructor, Preserve]
        public BehaviorTemplate()
        {
            // Every value in the data class needs to be initialized, or bad things will happen.
            Data.SceneObjectReference = new SingleSceneObjectReference(Guid.Empty);
            Data.GrabbableProperty = new SingleScenePropertyReference<IGrabbableProperty>(Guid.Empty);
            Data.FloatValue = 0.0f;
            Data.Name = "Behavior Template";
        }

        /// <summary>
        /// The activating process is executed when a step starts.
        /// </summary>       
        public override IStageProcess GetActivatingProcess()
        {
            // If we return the behavior's stage process here, it will execute as soon as the step is activated.
            return new BehaviorTemplateProcess(Data);
        }

        /// <summary>
        /// The deactivating process is executed when the step is completed.
        /// </summary>        
        public override IStageProcess GetDeactivatingProcess()
        {
            // If we return the behavior's stage process here, it will execute after the step is completed.
            // The step will end after the behavior has completed.
            // Since in this example we are returning both an activating and deactivating process, the behavior
            // will execute both at the beginning and at the end of a step. If you want to execute it only at
            // the beginning, delete this function, or viceversa.
            return new BehaviorTemplateProcess(Data);
        }
    }
}