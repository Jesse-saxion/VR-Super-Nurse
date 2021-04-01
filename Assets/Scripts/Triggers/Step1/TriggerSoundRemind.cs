using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerSoundRemind : MonoBehaviour
{
    [SerializeField] private AudioClip SoundtoPlay;
    AudioSource audio;
    public float Volume;

    [SerializeField] private GameObject Material_Step3;
    [SerializeField] private GameObject Manny;
    [SerializeField] private GameObject enablezone;
    [SerializeField] private GameObject Trigger_InformPatient;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))        {

            audio.PlayOneShot(SoundtoPlay, Volume);
            Debug.Log("play");
            Material_Step3.SetActive(false);

            Manny.GetComponent<InformPatientDialog>().enabled = false;
            Manny.GetComponent<Click>().enabled = false;
            enablezone.SetActive(false);
            Trigger_InformPatient.GetComponent<Triggerinformpatient>().enabled = false;
            Trigger_InformPatient.GetComponent<Triggerinformpatient>().alreadyPlayed = false;
            Trigger_InformPatient.GetComponent<BoxCollider>().enabled = false;
            Trigger_InformPatient.GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Sink Environment").GetComponent<AudioSource>().enabled = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("out");
            audio.Stop();

            Material_Step3.SetActive(true);
            enablezone.SetActive(true);
            Manny.GetComponent<InformPatientDialog>().enabled = true;
            Manny.GetComponent<Click>().enabled = true;
            Trigger_InformPatient.GetComponent<Triggerinformpatient>().enabled = true;
            Trigger_InformPatient.GetComponent<BoxCollider>().enabled = true;
            Trigger_InformPatient.GetComponent<AudioSource>().enabled = true;
        }

    }
}
