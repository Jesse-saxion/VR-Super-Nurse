using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStep : MonoBehaviour
{
    public GameObject target;
    public bool isComplete;

    public void CompleteSubStep()
    {
        isComplete = true;
    }

    public void ActivateQuestion(QuestionHandler question)
    {
        if (question == null)
            return;

        question.gameObject.SetActive(true);
        question.PlayAnimation();
    }
}
