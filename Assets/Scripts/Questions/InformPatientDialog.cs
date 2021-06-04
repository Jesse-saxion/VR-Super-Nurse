using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformPatientDialog : StepHandler
{
    [SerializeField] private AudioClip soundToPlayStep2;
    [SerializeField] private AudioClip soundToPlayStep4;
    [SerializeField] private AudioClip soundToPlayStep12;
    [SerializeField] public QuestionHandler questionStep2;
    [SerializeField] public QuestionHandler questionStep4;
    AudioSource audio;
    public float volume;
    public bool alreadyPlayedStep2 = false;
    public bool alreadyPlayedStep4 = false;
    public bool alreadyPlayedStep12 = false;

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
            ActivateQuestion(questionStep2);
        }
        else if (alreadyPlayedStep4==true)
        {
            Debug.Log("Activating question 4.");
            alreadyPlayedStep4 = false;
            audio.PlayOneShot(soundToPlayStep4, volume);
            ActivateQuestion(questionStep4);
        }
        else if (alreadyPlayedStep12 == true)
        {
            Debug.Log("Informing patient about step 12: Secure bandaid.");
            alreadyPlayedStep12 = false;
            audio.PlayOneShot(soundToPlayStep12, volume);
            CompleteSubStep();
        }
    }
}
