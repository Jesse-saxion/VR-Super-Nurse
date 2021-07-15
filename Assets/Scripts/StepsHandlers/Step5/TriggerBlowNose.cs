using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlowNose : SubStep
{
    [SerializeField] private AudioClip A55;
    [SerializeField] private AudioClip A61;
    [SerializeField] private AudioClip BlowNoseSound;
    [SerializeField] private bool Step4isdone = false;
    [SerializeField] private GameObject Step5_Measuring;
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
                Invoke("PlaySoundEndStep4", 10f);
                isPlayed = true;
                Step4isdone = true;
                Debug.Log("Completed Subtep 2 of Step 4");
                CompleteSubStep();
            }           
        }
        if (Step4isdone == true)
        {
            if (other.tag == "Tube")
            {
                Step5_Measuring.SetActive(true);
            }
        }
    }

    void PlaySoundEndStep4()
    {
        tissuenew.SetActive(false);
        audio.PlayOneShot(A55);
        checkList.UpdateCheckList();
        Invoke("PlaySoundA61", 1f);
    }

    void PlaySoundA61()
    {
        audio.PlayOneShot(A61);

    }

}

