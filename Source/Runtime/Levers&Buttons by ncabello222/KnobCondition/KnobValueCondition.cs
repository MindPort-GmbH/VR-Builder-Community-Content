using VRBuilder.Core.Conditions;
using System.Runtime.Serialization;
using VRBuilder.Core;

[DataContract(IsReference = true)]
public class KnobValueCondition : Condition<KnobValueConditionData>
{
    public override IStageProcess GetActiveProcess()
    {
        return new KnobValueConditionActiveProcess(Data);
    }

    protected override IAutocompleter GetAutocompleter()
    {
        // Retorna null si no es necesario un autocompletador, o implementa uno si es necesario.
        return null;
    }

    public KnobValueCondition()
    {
        Data.Name = "Knob Value";
    }
}
