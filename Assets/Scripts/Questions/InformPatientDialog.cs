using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class is used in several steps, hense it is not listed as a step in the Step Manager. Posssibly could be improved
public class InformPatientDialog : MonoBehaviour
{
    [SerializeField] private AudioClip soundToPlayStep2;
    [SerializeField] private AudioClip soundToPlayStep3;
    [SerializeField] private AudioClip soundToPlayStep11;
    [SerializeField] public QuestionHandler questionStep2;
    [SerializeField] public QuestionHandler questionStep3;
    AudioSource audio;
    [SerializeField] public Animator tvAnimator;

    public float volume;
    public bool alreadyPlayedStep2 = false;
    public bool alreadyPlayedStep3 = false;
    public bool alreadyPlayedStep11 = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Play an audiofragment to inform the patient about what is happening next.
    public void ClickonPatient()
    {
        if (!alreadyPlayedStep2)
        {
            Debug.Log("Activating question 2.");
            alreadyPlayedStep2 = true;
            audio.PlayOneShot(soundToPlayStep2, volume);
            tvAnimator.SetTrigger("QuestionAsked");
            ActivateQuestion(questionStep2);
        }
        else if (alreadyPlayedStep3==true)
        {
            Debug.Log("Activating question 3.");
            alreadyPlayedStep3 = false;
            audio.PlayOneShot(soundToPlayStep3, volume);
            tvAnimator.SetTrigger("QuestionAsked");
            ActivateQuestion(questionStep3);
        }
        else if (alreadyPlayedStep11 == true)
        {
            Debug.Log("Informing patient about step 11: Secure bandaid.");
            alreadyPlayedStep11 = false;
            audio.PlayOneShot(soundToPlayStep11, volume);
            // CompleteSubStep();
        }
    }

    // (May the god forgive me for resusing "ActivateQuestion" method from SubStep)
    public void ActivateQuestion(QuestionHandler question)
    {
        if (question == null)
            return;

        question.gameObject.SetActive(true);
        question.PlayAnimation();
    }
}