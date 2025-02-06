using System;
using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;

namespace VRBuilder.Community
{
    [DataContract(IsReference = true)]

    public class KnobValueConditionData : IConditionData
    {
        [DataMember] public SingleSceneObjectReference Target { get; set; }

        [DataMember] public float TargetValue { get; set; }

        public Metadata Metadata { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public KnobValueConditionData()
        {
            Target = new SingleSceneObjectReference(Guid.Empty);
            TargetValue = 0f; // Valor inicial por defecto.
        }
    }
}