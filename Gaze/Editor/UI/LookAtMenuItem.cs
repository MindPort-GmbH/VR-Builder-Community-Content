using VRBuilder.BasicInteraction.Conditions;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class LookAtMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName { get; } = "VR User/Look At";

        public override ICondition GetNewItem()
        {
            return new LookAtCondition();
        }
    }
}
