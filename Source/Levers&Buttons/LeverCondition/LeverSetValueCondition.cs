using System.Runtime.Serialization;
using VRBuilder.Core;
using VRBuilder.Core.Conditions;

[DataContract(IsReference = true)]
public class LeverSetValueCondition : Condition<LeverSetValueConditionData>
{
    public override IStageProcess GetActiveProcess()
    {
        return new LeverSetValueConditionActiveProcess(Data);
    }

    protected override IAutocompleter GetAutocompleter()
    {
        // Aquí se puede implementar un autocompletador si es necesario.
        return null;
    }

    public LeverSetValueCondition()
    {
        Data.Name = "Lever Set To Value";
    }
}
