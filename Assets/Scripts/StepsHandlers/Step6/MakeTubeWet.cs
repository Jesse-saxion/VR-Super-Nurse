using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTubeWet : SubStep
{
    public Material WaterMaterial;
    public StepHandler Step5;

    private AudioSource AudioSource;

    public AudioClip AudioClip;
    void Start()
    {
        AudioSource = this.GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TubeStart" || other.gameObject.tag == "TubePoint")
        {
            Debug.Log("Collided with Tube");
            // do the thing
            other.gameObject.GetComponentInParent<MeshRenderer>().material = WaterMaterial;
            AudioSource.PlayOneShot(AudioClip);
            this.GetComponent<Collider>().enabled = false;
            Step5.CompleteStep();
        }
    }
}