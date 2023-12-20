using VRBuilder.Core.Conditions;
using System.Runtime.Serialization;
using VRBuilder.Core;


[DataContract(IsReference = true)]
public class JoystickValueCondition : Condition<JoystickValueConditionData>
{
    public override IStageProcess GetActiveProcess()
    {
        return new JoystickValueConditionActiveProcess(Data);
    }

    protected override IAutocompleter GetAutocompleter()
    {
        return null;
    }

    public JoystickValueCondition()
    {
        Data.Name = "Joystick Value";
    }
}
