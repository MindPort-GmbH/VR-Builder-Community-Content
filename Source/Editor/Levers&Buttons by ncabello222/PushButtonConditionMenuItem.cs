#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class PushButtonConditionMenuItem : MenuItem<ICondition>
{
    public override string DisplayedName => "Custom/Push Button";

    public override ICondition GetNewItem()
    {
        return new PushButtonCondition();
    }
}
#endif
