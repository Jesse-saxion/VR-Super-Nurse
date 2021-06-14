using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4Tissue : StepHandler
{
    [SerializeField] private AudioClip A41;

    [SerializeField] private AudioClip TissueSound;
    [SerializeField] private AudioClip A52;
    AudioSource audio;
    public float Volume;
    public bool isGlove = false;
    // public bool isPlayed = false;
    public bool isTalk = false;

    [SerializeField] private GameObject tissue;
    [SerializeField] private GameObject triggerBlowNose;

    // Start is called before the first frame update

    private void Start()
    {
        audio = target.GetComponent<AudioSource>();
    }


    public void ActivateTissue()
    {
        if (isGlove == false)
        {
            audio.PlayOneShot(A41, Volume);
        }
        else
        {
            PlayTissueSound();
            tissue.SetActive(true);
            triggerBlowNose.SetActive(true);
            Debug.Log("Activated tissue box");
        }
    }

    public void PlayTissueSound()
    {
        audio.PlayOneShot(TissueSound, Volume);
    }

    public void Talking()
    {
        isTalk = true;
    }

}
