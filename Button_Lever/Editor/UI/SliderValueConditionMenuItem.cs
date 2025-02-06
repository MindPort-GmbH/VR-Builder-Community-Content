#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class SliderValueConditionMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName => "Button+Levers/Slider Value";

        public override ICondition GetNewItem()
        {
            return new SliderValueCondition();
        }
    }
}
#endif
