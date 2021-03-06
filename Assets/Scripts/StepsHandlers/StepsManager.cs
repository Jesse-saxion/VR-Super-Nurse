using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsManager : MonoBehaviour
{
    public CheckList checkList;
    List<StepHandler> completedSteps;

    void Start()
    {
        completedSteps = new List<StepHandler>();
    }

    public void StepCompleted(StepHandler step)
    {
        //int completedStepIndex = steps.IndexOf(step);

        if (!completedSteps.Contains(step))
        {
            Debug.Log("Fully completed a step (StepManager)");
            completedSteps.Add(step);
            checkList.UpdateCheckList(step.StepNumber - 1); // Notice the "- 1"
        }
    }
}
