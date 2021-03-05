using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ObjectonTray : MonoBehaviour
{
    [SerializeField] private AudioClip wrong;
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("notcorrect"))
        {
            Debug.Log("notcorrect");
            audio.Play();
        }
    }
}
