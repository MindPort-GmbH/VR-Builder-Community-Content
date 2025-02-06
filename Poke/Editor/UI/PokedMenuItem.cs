﻿using VRBuilder.BasicInteraction.Conditions;
using VRBuilder.Core.Conditions;
using VRBuilder.Core.Editor.UI.StepInspector.Menu;

namespace VRBuilder.Community
{
    public class PokedMenuItem : MenuItem<ICondition>
    {
        public override string DisplayedName { get; } = "Interaction/Poke Object";

        public override ICondition GetNewItem()
        {
            return new PokedCondition();
        }
    }
}
