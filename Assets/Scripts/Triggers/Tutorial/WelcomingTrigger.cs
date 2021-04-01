using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomingTrigger : MonoBehaviour
{
    [SerializeField] private Animator Chad;

    [SerializeField] private AudioClip SoundtoPlay;
    AudioSource audio;
    public float Volume;
    public bool alreadyPlayed = false;


    [SerializeField] private GameObject btntext;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Chad = Chad.GetComponent<Animator>();
    }

    // Update is called once per frame
   public void OnClickChad()
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(SoundtoPlay, Volume);
            Chad.SetBool("talking", true);
            //Chad.Play("Talking_HeadNod");

            alreadyPlayed = true;
            Invoke("TalkingHand", 19f);
            Invoke("AfterTalking", 20f);
            

        }

       
    }


    private void AfterTalking()
    {
        Chad.SetBool("talking", false);
        Chad.SetBool("transition", false);
        Chad.SetBool("idle", true);
        // Chad.Play("Standing");

        // Click the button script on
        btntext.SetActive(true);

    }
    private void TalkingHand()
    {
        Chad.SetBool("transition", true);
        Chad.Play("Talkingtouser");
       
    }
}
