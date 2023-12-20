using System.Collections;
using UnityEngine;
using VRBuilder.Core;
using UnityEngine.XR.Content.Interaction;

public class SliderValueConditionActiveProcess : StageProcess<SliderValueConditionData>
{
    private const float Threshold = 0.1f; // Margen de error para comparar el valor del slider

    public override void Start() { }

    public override IEnumerator Update()
    {
        while (true)
        {
            XRSlider slider = Data.Target.Value.GameObject.GetComponent<XRSlider>();
            if (slider != null)
            {
                float currentValue = slider.value;

                if (Mathf.Abs(currentValue - Data.TargetValue) < Threshold)
                {
                    Data.IsCompleted = true;
                    yield break;
                }
            }
            yield return null;
        }
    }

    public override void End() { }
    public override void FastForward() { }

    public SliderValueConditionActiveProcess(SliderValueConditionData data) : base(data) { }
}
