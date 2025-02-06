#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class JoystickValueConditionMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName => "Button+Levers/Joystick Value";

        public override ICondition GetNewItem()
        {
            return new JoystickValueCondition();
        }
    }
}
#endif