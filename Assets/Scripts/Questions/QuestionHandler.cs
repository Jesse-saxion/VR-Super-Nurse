using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField]
    private bool[] answerList;
    [Header("Animation")]
    [SerializeField] public Animator nurseAnimator;
    [SerializeField] private AudioClip tvHoist;
    [SerializeField] private GameObject TV;
    [SerializeField] private AudioClip wrongAnswer;
    [SerializeField] private AudioClip correctAnswer;

    Animator tvAnimator;
    AudioSource audio;
    public float volume;
    public float volumeTvHoist;
    private SubStep subStep;

    private void Start()
    {
        audio = TV.GetComponent<AudioSource>();
        tvAnimator = TV.GetComponent<Animator>();
        tvAnimator.SetTrigger("QuestionAsked");
        subStep = GetComponent<SubStep>();
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


        // TV animation and hoist sound.
        audio.PlayOneShot(tvHoist, volumeTvHoist);
        tvAnimator.SetTrigger("QuestionAnsweredCorrect");

        // Play the Yes animation.
        nurseAnimator.SetTrigger("Yes");
        Debug.Log("Yes Animation plays");
        //audio.PlayOneShot(correctAnswer, volume);
        Debug.Log("Correct answer plays");

        // Play no audio because the StepHandler already does by completing the step.
        subStep.CompleteSubStep();
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