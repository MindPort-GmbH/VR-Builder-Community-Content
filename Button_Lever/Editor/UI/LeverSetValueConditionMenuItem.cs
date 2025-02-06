#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class LeverSetValueConditionMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName => "Button+Levers/Lever Set To Value";

        public override ICondition GetNewItem()
        {
            return new LeverSetValueCondition();
        }
    }
}
#endif
