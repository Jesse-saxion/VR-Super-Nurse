using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5BlowNose : SubStep
{
    //[SerializeField] private AudioClip A61;
    [SerializeField] private AudioClip BlowNoseSound;
    [SerializeField] private GameObject tissuenew;

    bool isPlayed = false;

    private void Start()
    {
        InstantiateSubStep();
    }

    // When the tissue collides with the nose of the patient, blow nose     
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tissue")
        {
            if (isPlayed == false)
            {
                Destroy(other.gameObject);
                tissuenew.SetActive(true);
                PlayAudioClip(BlowNoseSound);
                Invoke("CompleteNoseBlowing", 10f);
                isPlayed = true;
                CompleteSubStep();
            }           
        }        
    }

    void CompleteNoseBlowing()
    {
        tissuenew.SetActive(false);
        CompleteSubStep();
        //Invoke("PlaySoundA61", 1f);
    }

    // DEPRICATED VOICE LINE 
    //void PlaySoundA61()
    //{
    //    audio.PlayOneShot(A61);
    //}
}

