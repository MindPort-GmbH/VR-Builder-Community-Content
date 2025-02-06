#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class KnobValueConditionMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName => "Button+Levers/Knob Value";

        public override ICondition GetNewItem()
        {
            return new KnobValueCondition();
        }
    }
}
#endif
