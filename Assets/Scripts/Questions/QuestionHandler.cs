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
    private int subStepIndex;
    [Header("Animation")]
    [SerializeField] public Animator nurseAnimator;
    [SerializeField] public Animator tvAnimator;

    [SerializeField] private AudioClip tvHoist;
    [SerializeField] private AudioClip wrongAnswer;
    AudioSource audio;
    public float volume;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        tvAnimator.SetTrigger("QuestionAsked");
    }
    
    public void CheckAnswer(int index)
    {
        // Check if correct button press was done to answer the question.
        if (answerList[index])
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }

    private void CorrectAnswer()
    {
        // Make sure to disable the question canvas so the new question can appear.
        setQuestionCanvasInactive();

        // Play no audio because the StepHandler already does by completing the step.
        stepHandler.CompleteSubStep(subStepIndex);

        // Play the Yes animation 
        nurseAnimator.SetTrigger("Yes");
        Debug.Log("Yes Animation Plays");
        audio.PlayOneShot(tvHoist, volume);
        tvAnimator.SetTrigger("QuestionAnsweredCorrect");
        
    }

    public void PlayAnimation()
    {

    }

    private void WrongAnswer()
    {
        // Play wrong answer soundclip
        audio.PlayOneShot(wrongAnswer, volume);

        // play the No Animation
        nurseAnimator.SetTrigger("No");
        Debug.Log("No Animation Plays");
    }

    private void setQuestionCanvasInactive()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}