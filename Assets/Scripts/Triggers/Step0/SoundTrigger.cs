using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip SoundtoPlay;
    AudioSource audio;
    public float Volume;
    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!alreadyPlayed)
            {
                audio.PlayOneShot(SoundtoPlay, Volume);
                alreadyPlayed = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            audio.Stop();
        }
        
    }


}
