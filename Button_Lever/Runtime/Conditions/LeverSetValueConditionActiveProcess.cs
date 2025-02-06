using System.Collections;
using UnityEngine;
using VRBuilder.Core;
using UnityEngine.XR.Content.Interaction;

namespace VRBuilder.Community
{
    public class LeverSetValueConditionActiveProcess : StageProcess<LeverSetValueConditionData>
    {
        private const float AngleThreshold = 1.0f; // Margen de error de 1 grado para la comparación del ángulo

        public override void Start()
        {
            // Implementación vacía
        }

        public override IEnumerator Update()
        {
            while (true)
            {
                XRLever lever = Data.Target.Value.GameObject.GetComponent<XRLever>();
                if (lever != null && lever.handle != null)
                {
                    // Obtiene el ángulo actual del knob
                    float currentAngle = lever.handle.localEulerAngles.x;

                    // Ajusta el ángulo a un rango de -90 a 90 grados
                    if (currentAngle > 180f)
                    {
                        currentAngle -= 360f;
                    }

                    // Comprueba si el ángulo actual está dentro del margen de error del valor objetivo
                    if (Mathf.Abs(currentAngle - Data.TargetValue) <= AngleThreshold)
                    {
                        Data.IsCompleted = true;
                        yield break;
                    }
                }

                yield return null;
            }
        }

        public override void End()
        {
            // Implementación vacía
        }

        public override void FastForward()
        {
            // Implementación vacía
        }

        public LeverSetValueConditionActiveProcess(LeverSetValueConditionData data) : base(data)
        {
        }
    }

}