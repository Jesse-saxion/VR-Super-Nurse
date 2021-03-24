using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlowNose : MonoBehaviour
{
    [SerializeField] private AudioClip A55;
    [SerializeField] private AudioClip A61;
    [SerializeField] private AudioClip BlowNoseSound;
    AudioSource audio;
    bool isPlayed = false;
    [SerializeField] private bool Step5isdone = false;
    [SerializeField] private GameObject Step6_Measuring;
   // [SerializeField] private GameObject NewTube;

    //[SerializeField] private GameObject tissueold;
    [SerializeField] private GameObject tissuenew;

    public CheckList checkList;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
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
        checkList.UpdateCheckList("Blow the patient's  nose");
        Invoke("PlaySoundA61", 1f);
        GameObject.Find("Patient").GetComponent<InformPatientDiaglog>(). areadyPlayedStep5 = true;
    }

    void PlaySoundA61()
    {
        audio.PlayOneShot(A61);

    }

}

