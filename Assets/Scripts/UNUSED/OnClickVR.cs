using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OnClickVR : Valve.VR.InteractionSystem.UIElement
{
    //public GameObject CurrentScreen;
    //public GameObject ScreenToChangeTo;
   // public bool DissableItSelf = false;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip click;

   

    


    // Start is called before the first frame update
    protected override void OnButtonClick()
    {
        
        
    }

    public void ClickSound()
    {
        sound.PlayOneShot(click);
    }
}
