using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    [Header("Step Handler")]
    public string stepName;
    public bool completed;
    public bool active = true;
    [Header("Substeps")]
    public int subSteps;
    //[Header("Questions")]
    //public List<GameObject> questionsList;
    [Header("Audio")]
    public AudioClip successSound;
    public float audioVolume = 10f;

    private bool[] subStepsList;
    private StepsManager stepsManager;
    private AudioSource audioSource;
    private CheckList checkList;

    protected virtual void Start()
    {
        if (subSteps >= 1)
        {
            subStepsList = new bool[subSteps];
        }

        stepsManager = GameObject.FindWithTag("StepsManager").GetComponent<StepsManager>();
        checkList = GameObject.Find("CheckList").GetComponent<CheckList>();
        SetAudio();
    }

    public void CompleteStep()
    {
        completed = true;
        audioSource.Play();
        stepsManager.StepCompleted(this);
        checkList.UpdateCheckList(stepName);
    }

    public void CompleteSubStep(int index)
    {
        if (subStepsList == null)
        {
            CompleteStep();
        }

        subStepsList[index - 1] = true;
        audioSource.Play();

        //Check if all the substeps are completed, if so complete the step
        for (int i = 0; i < subSteps; i++)
        {
            if (!subStepsList[i])
            {
                return;
            }
        }

        //Called only when all the substeps are TRUE
        CompleteStep(); 
    }

    // Method overloading so we don't have to give questions a substep number
    public void CompleteSubStep()
    {
        for (int i = 0; i < subSteps; i++)
        {
            if (!subStepsList[i])
            {
                subStepsList[i] = true;
                return;
            }
        }
        CompleteStep();
    }

    public bool CheckIfSubstepComplete(int index) {
        return subStepsList[index-1];
    }

    public void ActivateQuestion(QuestionHandler question)
    {
        if (question == null)
            return;

        question.gameObject.SetActive(true);
    }

    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, audioVolume);
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
