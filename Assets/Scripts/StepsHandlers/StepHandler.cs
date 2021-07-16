using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    [Header("Step Handler")]
    public int StepNumber;
    public bool completed;
    public List<SubStep> subSteps;
    public StepsManager stepsManager;


    public void CompleteStep()
    {
        completed = true;
        stepsManager.StepCompleted(this);
        Debug.Log("Step completed! (Step)");
    }

    public void CompleteSubStep(int index)
    {
        if (subSteps == null)
        {
            Debug.Log("subSteps is null!");
        }

        if (subSteps.Count > 0)
        {
            Debug.Log("subSteps count:" + subSteps);
            CompleteStep();
        }

        subSteps[index].completed = true;

        CheckIfAllSubStepsCompleted();   
    }

    public void CheckIfAllSubStepsCompleted()
    {
        for (int i = 0; i < subSteps.Count; i++)
        {
            if (!subSteps[i].completed)
            {
                return;
            }
        }

        CompleteStep();
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public bool IsSubStepCompleted(int index)
    {
        return subSteps[index - 1].completed;
    }
}
