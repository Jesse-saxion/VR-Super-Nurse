using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OnButtonInVrClicked : Valve.VR.InteractionSystem.UIElement
{
    public GameObject CurrentScreen;
    public GameObject ScreenToChangeTo;
    public bool DissableItSelf = false;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip click;
    [SerializeField] private CheckList checkList;

    public float Time;

    void Turnoff()
    {
        CurrentScreen.SetActive(false);
    }

    void Changescreen()
    {
        if (ScreenToChangeTo != null)
        {
            ScreenToChangeTo.SetActive(true);
        }
        
    }
    protected override void OnButtonClick()
    {

        if (ScreenToChangeTo != null)
        {
            Invoke("Turnoff", 2f);
            Invoke("Changescreen", Time);
        }
       
        else
        {
            return;
        }


        if (DissableItSelf)
        {
            gameObject.SetActive(false);
        }

        checkList.UpdateCheckList("Inform the patient");
    }

    public void ClickSound()
    {
        sound.PlayOneShot(click);
    }

}

