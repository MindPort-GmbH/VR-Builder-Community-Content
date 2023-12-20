using VRBuilder.Core.Conditions;
using System.Runtime.Serialization;
using VRBuilder.Core;


[DataContract(IsReference = true)]
public class SliderValueCondition : Condition<SliderValueConditionData>
{
    public override IStageProcess GetActiveProcess()
    {
        return new SliderValueConditionActiveProcess(Data);
    }

    protected override IAutocompleter GetAutocompleter()
    {
        // Retorna null si no es necesario un autocompletador
        return null;
    }

    public SliderValueCondition()
    {
        Data.Name = "Slider Value";
    }
}

