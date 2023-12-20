using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;
using System.Runtime.Serialization;

[DataContract(IsReference = true)]
public class PushButtonConditionData : IConditionData
{
    [DataMember]
    public SceneObjectReference Target { get; set; }

    [DataMember]
    public bool TargetState { get; set; }

    public Metadata Metadata { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public PushButtonConditionData()
    {
        Target = new SceneObjectReference("");
        TargetState = false; // Estado objetivo por defecto.
    }
}
