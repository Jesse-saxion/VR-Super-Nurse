using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStep : MonoBehaviour
{
    [Header("SubStep")]
    [Tooltip("The object that this script is related to (as if this script is its component)")]
    public GameObject target;
    public bool completed;

    [Header("Audio")]
    public AudioClip successSound;
    public float audioVolume = 10f;

    private AudioSource audioSource;

    public void CompleteSubStep()
    {
        completed = true;
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
        target.TryGetComponent<AudioSource>(out audioSource);
        if (audioSource == null)
        {
            audioSource = target.AddComponent<AudioSource>();
        }

        audioSource.clip = successSound;
        audioSource.volume = audioVolume;
    }
}
