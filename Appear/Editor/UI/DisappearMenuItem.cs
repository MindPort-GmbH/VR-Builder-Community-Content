using VRBuilder.Core.Behaviors;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class DisappearMenuItem : MenuItem<IBehavior>
    {
        /// <inheritdoc />
        public override string DisplayedName { get; } = "Environment/Disappear Object";

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new DisappearBehavior();
        }
    }
}
