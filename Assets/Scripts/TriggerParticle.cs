using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParticle : MonoBehaviour
{
    [SerializeField] private AudioClip WaterFalling;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.Play();
    }

}

    
