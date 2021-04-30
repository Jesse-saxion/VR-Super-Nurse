using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsManager : MonoBehaviour
{
    public List<StepHandler> steps;
    List<StepHandler> completedSteps;

    void Start()
    {
        completedSteps = new List<StepHandler>();
    }

    public void StepCompleted(StepHandler step)
    {
        int completedStepIndex = steps.IndexOf(step);
        steps[completedStepIndex++].ActivateStep();

        if (!completedSteps.Contains(step))
        {
            completedSteps.Add(step);
        }
    }   
}
