using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
   
    public void PlayAudioClip()
    {
        source.clip = clip;
        source.Play();
    }
}
