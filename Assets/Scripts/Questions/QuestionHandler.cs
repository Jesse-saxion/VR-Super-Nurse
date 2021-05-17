using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField]
    private bool[] answerList;
    [SerializeField]
    private StepHandler stepHandler;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<Animation> animations;

    public void CheckAnswer(int index)
    {
        // Check if correct button press was done to answer the question.
        if (answerList[index])
        {
            CorrectAnswer();
        } else
        {
            WrongAnswer();
        }
    }

    private void CorrectAnswer()
    {
        // Make sure to disable the question canvas so the new question can appear.
        setQuestionCanvasInactive(); 

        // Play no audio because the StepHandler already does by completing the step.
        stepHandler.CompleteSubStep(); 
    }

    public void PlayAnimation()
    {
        
    }

    private void WrongAnswer()
    {
        // Play audio fail 
    }

    private void setQuestionCanvasInactive()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
