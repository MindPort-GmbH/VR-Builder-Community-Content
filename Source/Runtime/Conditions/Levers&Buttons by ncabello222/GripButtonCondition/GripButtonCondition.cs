using VRBuilder.Core.Conditions;
using System.Runtime.Serialization;
using VRBuilder.Core;


[DataContract(IsReference = true)]
public class GripButtonCondition : Condition<GripButtonConditionData>
{
    public override IStageProcess GetActiveProcess()
    {
        return new GripButtonConditionActiveProcess(Data);
    }

    protected override IAutocompleter GetAutocompleter()
    {
        // Retorno null si no es necesario un autocompletador
        return null;
    }

    public GripButtonCondition()
    {
        Data.Name = "Grip Button";
    }
}
