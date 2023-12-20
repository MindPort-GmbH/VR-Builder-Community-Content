using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;
using System.Runtime.Serialization;

[DataContract(IsReference = true)]
public class LeverSetValueConditionData : IConditionData
{
    [DataMember]
    public SceneObjectReference Target { get; set; }

    [DataMember]
    // Cambiado de bool a float para representar un ángulo.
    public float TargetValue { get; set; }

    public Metadata Metadata { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public LeverSetValueConditionData()
    {
        Target = new SceneObjectReference("");
        TargetValue = 0f; // Valor inicial por defecto.
    }
}
