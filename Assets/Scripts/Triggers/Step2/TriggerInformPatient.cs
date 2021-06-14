using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerinformpatient : MonoBehaviour
{
    [SerializeField] private AudioClip SoundtoPlay;
    AudioSource audio;
    public float Volume;
    public bool alreadyPlayed = false;
    [SerializeField]
    private StepHandler stepHandler;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Inform the patient about the next step in the procedure. Play an audioclip to perform this.
    public void InformPatient()
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(SoundtoPlay, Volume);
            alreadyPlayed = true;
        }
    }
}
