using System;
using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;

namespace VRBuilder.Community
{
    [DataContract(IsReference = true)]

    public class PushButtonConditionData : IConditionData
    {
        [DataMember] public SingleSceneObjectReference Target { get; set; }

        [DataMember] public bool TargetState { get; set; }

        public Metadata Metadata { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public PushButtonConditionData()
        {
            Target = new SingleSceneObjectReference(Guid.Empty);
            TargetState = false; // Estado objetivo por defecto.
        }
    }

}