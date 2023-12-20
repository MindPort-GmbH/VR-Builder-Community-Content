#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Editor.UI.StepInspector.Menu;

public class GripButtonConditionMenuItem : MenuItem<ICondition>
{
    public override string DisplayedName => "Custom/Grip Button";

    public override ICondition GetNewItem()
    {
        return new GripButtonCondition();
    }
}
#endif
