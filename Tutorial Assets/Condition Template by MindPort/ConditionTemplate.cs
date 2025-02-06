using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using UnityEngine.Scripting;
using VRBuilder.BasicInteraction.Properties;
using VRBuilder.Core;
using VRBuilder.Core.Attributes;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;

// It is recommended you put your code in a namespace.
namespace MindPort.Examples
{
    /// <summary>
    /// This is a non-functional example condition.
    /// </summary>
    [DataContract(IsReference = true)]
    [HelpLink("https://www.mindport.co/vr-builder-tutorials/creating-custom-conditions")] // You can add this link if you have online documentation.
    public class ConditionTemplate : Condition<ConditionTemplate.EntityData>
    {
        /// <summary>
        /// Data class for this condition.
        /// </summary>
        [DisplayName("Example Condition")]
        public class EntityData : IConditionData
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

            /// <summary>
            /// This is used by VR Builder to know when the condition is completed.
            /// Usually there's no need to set it manually.
            /// </summary>
            public bool IsCompleted { get; set; }
        }

        /// <summary>
        /// Stage process containing the logic of the condition.
        /// </summary>
        private class ConditionTemplateProcess : BaseActiveProcessOverCompletable<EntityData>
        {
            /// <summary>
            /// You need this constructor in order to pass the data class to the stage process.
            /// </summary> 
            public ConditionTemplateProcess(EntityData data) : base(data)
            {
            }

            /// <summary>
            /// Override this to establish when the condition is completed.
            /// </summary>
            protected override bool CheckIfCompleted()
            {
                // This condition will complete when the grabbable property is grabbed.
                return Data.GrabbableProperty.Value.IsGrabbed;
            }
   
            // It is usually not necessary to override the other stage process methods
            // (Start, Update, End) for conditions, but it is possible to do so if needed.
        }

        /// <summary>
        /// This class defines how the condition should be autocompleted in case the step
        /// is fast forwarded.
        /// </summary>
        private class ConditionTemplateAutocompleter : Autocompleter<EntityData>
        {
            /// <summary>
            /// You need this constructor in order to pass the data class to the autocompleter.
            /// </summary> 
            public ConditionTemplateAutocompleter(EntityData data) : base(data)
            {
            }

            /// <summary>
            /// Override this to simulate the condition being completed.
            /// </summary>
            public override void Complete()
            {
                // This autocompleter will tell the grabbable property to simulate a grab.
                // This will cause the condition to complete.
                Data.GrabbableProperty.Value.FastForwardGrab();
            }
        }

        /// <summary>
        /// Every VR Builder entity needs an empty constructor.
        /// </summary>
        [JsonConstructor, Preserve]
        public ConditionTemplate()
        {
            // Every value in the data class needs to be initialized, or bad things will happen.
            Data.SceneObjectReference = new SingleSceneObjectReference(Guid.Empty);
            Data.GrabbableProperty = new SingleScenePropertyReference<IGrabbableProperty>(Guid.Empty);
            Data.FloatValue = 0.0f;
            Data.Name = "Condition Template";
        }

        /// <summary>
        /// Conditions are activated while the step is active.
        /// Therefore, the condition's stage process is returned by the active process getter.
        /// </summary>        
        public override IStageProcess GetActiveProcess()
        {
            return new ConditionTemplateProcess(Data);
        }

        /// <summary>
        /// Here we return the autocompleter for this condition.
        /// </summary>        
        protected override IAutocompleter GetAutocompleter()
        {
            return new ConditionTemplateAutocompleter(Data);
        }
    }
}