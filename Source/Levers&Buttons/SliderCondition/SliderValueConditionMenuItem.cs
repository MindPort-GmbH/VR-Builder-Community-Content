#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class SliderValueConditionMenuItem : MenuItem<ICondition>
{
    public override string DisplayedName => "Custom/Slider Value";

    public override ICondition GetNewItem()
    {
        return new SliderValueCondition();
    }
}
#endif
