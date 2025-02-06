using VRBuilder.Core.Behaviors;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class OpacityAppearMenuItem : MenuItem<IBehavior>
    {
        /// <inheritdoc />
        public override string DisplayedName { get; } = "Environment/Opacity Appear Object";

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new OpacityAppearBehavior();
        }
    }
}
