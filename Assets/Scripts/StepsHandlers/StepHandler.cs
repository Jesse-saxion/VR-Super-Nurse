using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    [Header("Step Handler")]
    public bool completed;
    public bool active = true;

    private StepsManager stepsManager;

    void Start()
    {
        stepsManager = GameObject.FindWithTag("StepsManager").GetComponent<StepsManager>();
    }

    public void CompleteStep()
    {
        completed = true;
        stepsManager.StepCompleted(this);
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public void ActivateStep()
    {
        active = true;
    }

    public bool IsActive()
    {
        return active;
    }
}
