using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlowNose : StepHandler
{
    [SerializeField] private AudioClip A55;
    [SerializeField] private AudioClip A61;
    [SerializeField] private AudioClip BlowNoseSound;
    [SerializeField] private bool Step5isdone = false;
    [SerializeField] private GameObject Step6_Measuring;
    [SerializeField] private GameObject tissuenew;

    AudioSource audio;
    bool isPlayed = false;
    public CheckList checkList;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tissue")
        {
            if (isPlayed == false)
            {
                Destroy(other.gameObject);
                tissuenew.SetActive(true);
                audio.PlayOneShot(BlowNoseSound);
                Invoke("PlaySoundEndStep5", 10f);
                isPlayed = true;
                Step5isdone = true;
                CompleteSubStep();
            }           
        }
        if (Step5isdone == true)
        {
            if (other.tag == "Tube")
            {
                Step6_Measuring.SetActive(true);
            }
        }
    }

    void PlaySoundEndStep5()
    {
        tissuenew.SetActive(false);
        audio.PlayOneShot(A55);
        checkList.UpdateCheckList("Blow the patient's nose");
        Invoke("PlaySoundA61", 1f);
        // GameObject.Find("Patient").GetComponent<InformPatientDialog>(). areadyPlayedStep5 = true;
    }

    void PlaySoundA61()
    {
        audio.PlayOneShot(A61);

    }

}

