using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProgressBarManual : MonoBehaviour
{
    public float TimeToFill = 1;

    private float currentProgress = 0;

    private bool inProgress = false;

    public void StartProgressBar()
    {
        inProgress = true;
    }
    public void StopProgressBar()
    {
        inProgress = false;
        currentProgress = 0;
    }

    private void Update()
    {
        if (inProgress)
        {
            currentProgress += Time.deltaTime;
            if (currentProgress > TimeToFill) currentProgress = TimeToFill;
        }

        gameObject.transform.localScale = new Vector3(1f, 1f, currentProgress / TimeToFill);
    }
}
