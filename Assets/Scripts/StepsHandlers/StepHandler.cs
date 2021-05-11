using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    [Header("Step Handler")]
    public bool completed;
    public bool active = true;
    public AudioClip successSound;
    public float audioVolume = 10f;

    private StepsManager stepsManager;
    private AudioSource audioSource;

    void Start()
    {
        stepsManager = GameObject.FindWithTag("StepsManager").GetComponent<StepsManager>();
        SetAudio();       
    }

    public void CompleteStep()
    {
        completed = true;
        audioSource.Play();
        stepsManager.StepCompleted(this);
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public void ActivateStep()
    {
        active = true;
    }

    public bool IsActive()
    {
        return active;
    }

    private void SetAudio()
    {
        TryGetComponent<AudioSource>(out audioSource);
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = successSound;
        audioSource.volume = audioVolume;
    }
}
