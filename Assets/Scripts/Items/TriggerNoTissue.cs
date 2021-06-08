using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNoTissue : StepHandler
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
        audio = GetComponent<AudioSource>();
    }


    public void NoTissue()
    {
        if (isGlove == false)
        {
            audio.PlayOneShot(A41, Volume);
        }
        else
        {
            //if (isTalk == false)
            //{
            //    audio.PlayOneShot(A52, Volume);
            //}
            //else
            //{
            //}
            Debug.Log("Completed Subtep 1 of Step 3");
            CompleteSubStep(1); // Or 2?
            Debug.Log("Activated tissue box");
            Tissue();
            tissue.SetActive(true);
            triggerBlowNose.SetActive(true);
        }
    }

    public void Tissue()
    {
        audio.PlayOneShot(TissueSound, Volume);
    }

    public void Talking()
    {
        isTalk = true;
    }

}
