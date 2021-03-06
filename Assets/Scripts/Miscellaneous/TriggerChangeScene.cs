using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    [SerializeField] private Animator ChangetoNextScene;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Roomnew;
    [SerializeField] private GameObject Roomold;
    // private float fadeDuration = 2f;

    private void Start()
    {
        ChangetoNextScene = ChangetoNextScene.GetComponent<Animator>();

    }
    private void FadeToBlack()
    {
        //set start color
        //SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        //SteamVR_Fade.Start(Color.black, fadeDuration);
        Roomnew.SetActive(true);
    }

    private void FadeFromWhite()
    {
        //set start color
        //SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        //SteamVR_Fade.Start(Color.clear, fadeDuration);
        Roomold.SetActive(false);
        Player.GetComponent<Animator>().enabled = false;
    }

    private void PlayAnim()
    {
        Player.GetComponent<Animator>().enabled = true;
        ChangetoNextScene.Play("ChangeToInteract");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FadeToBlack();
            Invoke("PlayAnim", 1f);
            Invoke("FadeFromWhite", 3f);
        }
    }
}
