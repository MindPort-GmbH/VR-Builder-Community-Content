using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;
using System.Runtime.Serialization;

[DataContract(IsReference = true)]
public class GripButtonConditionData : IConditionData
{
    [DataMember]
    public SceneObjectReference Target { get; set; }

    [DataMember]
    public bool PressedState { get; set; }

    public Metadata Metadata { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public GripButtonConditionData()
    {
        Target = new SceneObjectReference("");
        PressedState = true; // Estado objetivo por defecto (true para presionado, false para liberado).
    }
}
