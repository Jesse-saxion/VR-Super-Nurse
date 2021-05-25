using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField]
    private bool[] answerList;
    [SerializeField]
    private StepHandler stepHandler;
    private AudioSource audioSource;
    [Header("Audio")]
    public AudioClip wrongAnswer;
    public float audioVolume = 10f;
    [Header("Animation")]
    [SerializeField]
    public Animator nurseAnimator;

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
        stepHandler.CompleteSubStep();

        // Play the Yes animation 
        nurseAnimator.SetTrigger("Yes");
    }

    public void PlayAnimation()
    {

    }

    private void WrongAnswer()
    {
        // Play wrong answer soundclip
        audioSource.Play();

        // play the No Animation
        nurseAnimator.SetTrigger("No");
    }

    private void setQuestionCanvasInactive()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetAudio();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, audioVolume);
    }

    private void SetAudio()
    {
        TryGetComponent<AudioSource>(out audioSource);
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = wrongAnswer;
        audioSource.volume = audioVolume;
    }
}