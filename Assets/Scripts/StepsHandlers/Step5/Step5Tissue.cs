using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5Tissue : SubStep
{
    [SerializeField] private AudioClip A41;

    [SerializeField] private AudioClip TissueSound;
    public bool isGlove = false;

    [SerializeField] private GameObject tissue;
    [SerializeField] private GameObject triggerBlowNose;

    private void Start()
    {
        InstantiateSubStep();
    }


    public void ActivateTissue()
    {
        if (isGlove == false)
        {
            PlayAudioClip(A41);
        }
        else
        {
            PlayTissueSound();
            tissue.SetActive(true);
            triggerBlowNose.SetActive(true);
            CompleteSubStep();
            Debug.Log("Activated tissue box");
        }
    }

    public void PlayTissueSound()
    {
        PlayAudioClip(TissueSound);
    }
}
