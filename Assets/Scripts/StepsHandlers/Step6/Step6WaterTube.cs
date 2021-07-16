using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step6WaterTube : SubStep
{
    public Material WaterMaterial;
    public AudioClip SplashSound;

    private void Start()
    {
        InstantiateSubStep();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TubeStart" || other.gameObject.tag == "TubePoint")
        {
            Debug.Log("Collided with Tube");
            other.gameObject.GetComponentInParent<MeshRenderer>().material = WaterMaterial;
            PlayAudioClip(SplashSound);
            GetComponent<Collider>().enabled = false;
            CompleteSubStep();
        }
    }
}