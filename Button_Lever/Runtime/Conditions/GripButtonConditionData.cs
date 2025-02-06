using System;
using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;

namespace VRBuilder.Community
{
    
    [DataContract(IsReference = true)]
    public class GripButtonConditionData : IConditionData
    {
        [DataMember] public SingleSceneObjectReference Target { get; set; }

        [DataMember] public bool PressedState { get; set; }

        public Metadata Metadata { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public GripButtonConditionData()
        {
            Target = new SingleSceneObjectReference(Guid.Empty);
            PressedState = true; // Estado objetivo por defecto (true para presionado, false para liberado).
        }
    }

}