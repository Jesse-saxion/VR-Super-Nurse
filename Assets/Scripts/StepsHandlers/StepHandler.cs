using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    public GameObject target;

    [Header("Step Handler")]
    public string stepName;
    public bool completed;
    public bool active = true;

    [Header("Audio")]
    public AudioClip successSound;
    public float audioVolume = 10f;

    public List<SubStep> subSteps;
    private StepsManager stepsManager;
    private AudioSource audioSource;
    private CheckList checkList;

    protected virtual void Start()
    {
        Instantiate();
    }

    protected void Instantiate()
    {
        stepsManager = GameObject.FindWithTag("StepsManager").GetComponent<StepsManager>();
        // checkList = GameObject.FindWithTag("CheckList").GetComponent<CheckList>(); unused for now
        SetAudio();
    }

    public void CompleteStep()
    {
        completed = true;
        // audioSource.Play();
        stepsManager.StepCompleted(this);
        checkList.UpdateCheckList(stepName);
        Debug.Log("Step completed! (Step)");
    }

    public void CompleteSubStep(int index)
    {
        if (subSteps == null)
        {
            Debug.Log("subSteps is null!");
        }

        if (subSteps.Count > 0)
        {
            Debug.Log("subSteps count:" + subSteps);
            CompleteStep();
        }
        
        subSteps[index].isComplete = true;
        audioSource.Play();

        //Check if all the substeps are completed, if so complete the step
        for (int i = 0; i < subSteps.Count; i++)
        {
            if (!subSteps[i].isComplete)
            {
                return;
            }
        }

        //Called only when all the substeps are TRUE
        Debug.Log("All substeps are complete, completing step.");
        CompleteStep(); 
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
        target.TryGetComponent<AudioSource>(out audioSource);
        if (audioSource == null)
        {
            audioSource = target.AddComponent<AudioSource>();
        }

        audioSource.clip = successSound;
        audioSource.volume = audioVolume;
    }

    public bool CheckIfSubstepComplete(int index)
    {
        return subSteps[index - 1].isComplete;
    }
}
