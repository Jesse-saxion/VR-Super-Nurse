using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSound : MonoBehaviour
{
    [SerializeField] private AudioClip A63;
    AudioSource audio;
    public bool finishasked = true;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void SoundPlay()
    {
        if(finishasked == false)
        {
            audio.PlayOneShot(A63);
            finishasked = true;
        }
       
    }
}
