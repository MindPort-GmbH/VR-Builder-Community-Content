using System.Collections;
using UnityEngine;
using VRBuilder.Core;
using UnityEngine.XR.Content.Interaction;

public class KnobValueConditionActiveProcess : StageProcess<KnobValueConditionData>
{
    private const float SomeThreshold = 0.1f; // Un margen de error, como 1 grado o un porcentaje adecuado.

    public override void Start() { }

    public override IEnumerator Update()
    {
        while (true)
        {
            XRKnob knob = Data.Target.Value.GameObject.GetComponent<XRKnob>();
            if (knob != null)
            {
                float currentValue = knob.value; // Obtiene el valor actual del knob.

                // Comprueba si el valor actual está dentro del margen de error del valor objetivo.
                if (Mathf.Abs(currentValue - Data.TargetValue) < SomeThreshold)
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

    public KnobValueConditionActiveProcess(KnobValueConditionData data) : base(data) { }
}
