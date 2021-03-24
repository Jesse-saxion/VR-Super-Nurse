using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerinformpatient : MonoBehaviour
{
    [SerializeField] private AudioClip SoundtoPlay;

    AudioSource audio;
    public float Volume;
    public bool alreadyPlayed = false;
    //  public GameObject UIicon;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();


        //  UIicon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!alreadyPlayed)
            {
                //GameObject.Find("Sink Environment").GetComponent<AudioSource>().enabled = false;
                audio.PlayOneShot(SoundtoPlay, Volume);
                alreadyPlayed = true;
                // UIicon.SetActive(true);

            }
        }

    }


}
