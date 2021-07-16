using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStep : MonoBehaviour
{
    [Header("SubStep")]
    public bool completed;

    [Header("Audio")]
    public AudioClip successSound;
    public float audioVolume = 10f;

    private AudioSource audioSource;
    [SerializeField] private StepHandler stepHandler;

    private void Start()
    {
        InstantiateSubStep();
    }

    protected void InstantiateSubStep()
    {
        SetAudio();
    }

    public void CompleteSubStep()
    {
        completed = true;
        // Not a very good structure. Probably should not have a double dependency with a stephandler 
        stepHandler.CheckIfAllSubStepsCompleted();
    }

    public void ActivateQuestion(QuestionHandler question)
    {
        if (question == null)
            return;

        question.gameObject.SetActive(true);
        question.PlayAnimation();
    }

    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, audioVolume);
    }

    private void SetAudio()
    {      
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
           gameObject.AddComponent<AudioSource>();
           audioSource =  GetComponent<AudioSource>();
        }
    }
}
