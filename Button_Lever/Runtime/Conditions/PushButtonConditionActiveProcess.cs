using System.Collections;
using UnityEngine;
using VRBuilder.Core;
using UnityEngine.XR.Content.Interaction;

namespace VRBuilder.Community
{
    public class PushButtonConditionActiveProcess : StageProcess<PushButtonConditionData>
    {
        private bool buttonPressed = false;

        public override void Start()
        {
            XRPushButton button = Data.Target.Value.GameObject.GetComponent<XRPushButton>();
            if (button != null)
            {
                button.onPress.AddListener(OnButtonPressed);
                button.onRelease.AddListener(OnButtonReleased);
                Debug.Log("Listeners for XRPushButton added successfully.");
            }
            else
            {
                Debug.LogError("XRPushButton component not found on the target object.");
            }
        }

        private void OnButtonPressed()
        {
            buttonPressed = true;
            CheckCondition();
        }

        private void OnButtonReleased()
        {
            buttonPressed = false;
            CheckCondition();
        }

        private void CheckCondition()
        {
            if (buttonPressed == Data.TargetState)
            {
                Data.IsCompleted = true;
            }
        }

        public override IEnumerator Update()
        {
            while (!Data.IsCompleted)
            {
                CheckCondition();
                yield return null;
            }
        }

        public override void End()
        {
            XRPushButton button = Data.Target.Value.GameObject.GetComponent<XRPushButton>();
            if (button != null)
            {
                button.onPress.RemoveListener(OnButtonPressed);
                button.onRelease.RemoveListener(OnButtonReleased);
            }
        }

        public override void FastForward()
        {
        }

        public PushButtonConditionActiveProcess(PushButtonConditionData data) : base(data)
        {
        }
    }

}