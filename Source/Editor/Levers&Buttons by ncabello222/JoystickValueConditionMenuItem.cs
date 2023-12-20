#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class JoystickValueConditionMenuItem : MenuItem<ICondition>
{
    public override string DisplayedName => "Custom/Joystick Value";

    public override ICondition GetNewItem()
    {
        return new JoystickValueCondition();
    }
}
#endif
