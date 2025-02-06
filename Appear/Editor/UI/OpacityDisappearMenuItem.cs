using VRBuilder.Core.Behaviors;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class OpacityDisappearMenuItem : MenuItem<IBehavior>
    {
        /// <inheritdoc />
        public override string DisplayedName { get; } = "Environment/Opacity Disappear Object";

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new OpacityDisappearBehavior();
        }
    }
}
