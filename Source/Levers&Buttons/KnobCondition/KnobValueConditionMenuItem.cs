#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class KnobValueConditionMenuItem : MenuItem<ICondition>
{
    public override string DisplayedName => "Custom/Knob Value";

    public override ICondition GetNewItem()
    {
        return new KnobValueCondition();
    }
}
#endif
