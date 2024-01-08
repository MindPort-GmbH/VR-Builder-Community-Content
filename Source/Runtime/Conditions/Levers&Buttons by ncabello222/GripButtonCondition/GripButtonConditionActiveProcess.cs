using System.Collections;
using UnityEngine;
using VRBuilder.Core;
using UnityEngine.XR.Content.Interaction;

public class GripButtonConditionActiveProcess : StageProcess<GripButtonConditionData>
{
    private bool buttonPressed = false;

    public override void Start()
    {
       
        XRGripButton button = Data.Target.Value.GameObject.GetComponent<XRGripButton>();
    if (button != null)
    {
        button.onPress.AddListener(OnButtonPressed);
        button.onRelease.AddListener(OnButtonReleased);
    }
    else
    {
        Debug.LogError("XRGripButton component not found on the target object.");
    }
       
    }

    private void OnButtonPressed()
{
    Debug.Log("Button Pressed");
    buttonPressed = true;
    CheckCondition();
}

private void OnButtonReleased()
{
    Debug.Log("Button Released");
    buttonPressed = false;
    CheckCondition();
}

    private void CheckCondition()
    {
        if (buttonPressed == Data.PressedState)
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
        XRGripButton button = Data.Target.Value.GameObject.GetComponent<XRGripButton>();
        if (button != null)
        {
            button.onPress.RemoveListener(OnButtonPressed);
            button.onRelease.RemoveListener(OnButtonReleased);
        }
    }

    public override void FastForward()
    {
    }

    public GripButtonConditionActiveProcess(GripButtonConditionData data) : base(data) { }
}
