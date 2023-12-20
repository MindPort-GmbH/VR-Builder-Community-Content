#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class LeverSetValueConditionMenuItem : MenuItem<ICondition>
{
    public override string DisplayedName => "Custom/Lever Set To Value";

    public override ICondition GetNewItem()
    {
        return new LeverSetValueCondition();
    }
}
#endif
