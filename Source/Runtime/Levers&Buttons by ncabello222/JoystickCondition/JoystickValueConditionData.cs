using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.SceneObjects;

[DataContract(IsReference = true)]
public class JoystickValueConditionData : IConditionData
{
    [DataMember]
    public SceneObjectReference Target { get; set; }

    [DataMember]
    public float TargetValueX { get; set; }

    [DataMember]
    public float TargetValueY { get; set; }

    [DataMember]
    public float TimeThreshold { get; set; }

    [DataMember]
    public bool UseGreaterThanOrEqualX { get; set; } // Variable para X

    [DataMember]
    public bool UseGreaterThanOrEqualY { get; set; } // Variable para Y

    public Metadata Metadata { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public JoystickValueConditionData()
    {
        Target = new SceneObjectReference("");
        TargetValueX = 0f;
        TargetValueY = 0f;
        TimeThreshold = 1f;
        UseGreaterThanOrEqualX = true; // Valor inicial para X
        UseGreaterThanOrEqualY = true; // Valor inicial para Y
    }
}
