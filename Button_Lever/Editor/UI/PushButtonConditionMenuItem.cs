#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class PushButtonConditionMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName => "Button+Levers/Push Button";

        public override ICondition GetNewItem()
        {
            return new PushButtonCondition();
        }
    }
}
#endif
