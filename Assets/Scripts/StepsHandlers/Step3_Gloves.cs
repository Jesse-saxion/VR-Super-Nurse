using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3_Gloves : SubStep
{
    [SerializeField] private AudioClip gloveSound;
    public GameObject Step4Handler;
    public GameObject InformPatientScript;
    [SerializeField] public QuestionHandler questionStep3;
    AudioSource audio;
    public float volume;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnObjectClicked()
    {
        Debug.Log("Activated gloves box");
        Step4Handler.GetComponent<Step4Tissue>().isGlove = true;
        audio.PlayOneShot(gloveSound, volume);
        InformPatientScript.GetComponent<InformPatientDialog>().alreadyPlayedStep3 = true;
        CompleteSubStep();
        ActivateQuestion(questionStep3);
    }
}
