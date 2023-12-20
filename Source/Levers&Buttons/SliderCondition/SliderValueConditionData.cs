using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;
using System.Runtime.Serialization;

[DataContract(IsReference = true)]
public class SliderValueConditionData : IConditionData
{
    [DataMember]
    public SceneObjectReference Target { get; set; }

    [DataMember]
    public float TargetValue { get; set; }

    public Metadata Metadata { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public SliderValueConditionData()
    {
        Target = new SceneObjectReference("");
        TargetValue = 0.5f; // Valor por defecto
    }
}

