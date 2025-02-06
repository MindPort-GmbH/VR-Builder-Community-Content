using VRBuilder.Core.Behaviors;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class AppearMenuItem : MenuItem<IBehavior>
    {
        /// <inheritdoc />
        public override string DisplayedName { get; } = "Environment/Appear Object";

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new AppearBehavior();
        }
    }
}
