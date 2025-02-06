#if UNITY_EDITOR
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    internal class GripButtonConditionMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName => "Button+Levers/Grip Button";

        public override ICondition GetNewItem()
        {
            return new GripButtonCondition();
        }
    }    
}
#endif
