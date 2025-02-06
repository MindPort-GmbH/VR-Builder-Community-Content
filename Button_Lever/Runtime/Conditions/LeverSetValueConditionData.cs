using System;
using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;

namespace VRBuilder.Community
{
    [DataContract(IsReference = true)]

    public class LeverSetValueConditionData : IConditionData
    {
        [DataMember] public SingleSceneObjectReference Target { get; set; }

        [DataMember]
        // Cambiado de bool a float para representar un ángulo.
        public float TargetValue { get; set; }

        public Metadata Metadata { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public LeverSetValueConditionData()
        {
            Target = new SingleSceneObjectReference(Guid.Empty);
            TargetValue = 0f; // Valor inicial por defecto.
        }
    }

}