using System.Collections;
using UnityEngine;
using VRBuilder.Core;
using UnityEngine.XR.Content.Interaction;


namespace VRBuilder.Community
{
    

    public class JoystickValueConditionActiveProcess : StageProcess<JoystickValueConditionData>
    {
        private float elapsedTime = 0f;

        public override void Start()
        {
            elapsedTime = 0f;
        }

        public override IEnumerator Update()
        {
            while (true)
            {
                XRJoystick joystick = Data.Target.Value.GameObject.GetComponent<XRJoystick>();
                if (joystick != null)
                {
                    Vector2 joystickValue = joystick.value;
                    bool conditionXMet = Data.UseGreaterThanOrEqualX
                        ? joystickValue.x >= Data.TargetValueX
                        : joystickValue.x <= Data.TargetValueX;
                    bool conditionYMet = Data.UseGreaterThanOrEqualY
                        ? joystickValue.y >= Data.TargetValueY
                        : joystickValue.y <= Data.TargetValueY;

                    if (conditionXMet && conditionYMet)
                    {
                        elapsedTime += Time.deltaTime;
                        if (elapsedTime >= Data.TimeThreshold)
                        {
                            Data.IsCompleted = true;
                            yield break;
                        }
                    }
                    else
                    {
                        elapsedTime = 0f;
                    }
                }

                yield return null;
            }
        }

        public override void End()
        {
        }

        public override void FastForward()
        {
        }

        public JoystickValueConditionActiveProcess(JoystickValueConditionData data) : base(data)
        {
        }
    }

}