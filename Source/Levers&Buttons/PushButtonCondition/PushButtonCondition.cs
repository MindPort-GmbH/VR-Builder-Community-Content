using VRBuilder.Core.Conditions;
using System.Runtime.Serialization;
using VRBuilder.Core;


[DataContract(IsReference = true)]
public class PushButtonCondition : Condition<PushButtonConditionData>
{
    public override IStageProcess GetActiveProcess()
    {
        return new PushButtonConditionActiveProcess(Data);
    }

    protected override IAutocompleter GetAutocompleter()
    {
        // Implementación del autocompletador o retorno de null si no es necesario
        return null;
    }

    public PushButtonCondition()
    {
        Data.Name = "Push Button";
    }
}
