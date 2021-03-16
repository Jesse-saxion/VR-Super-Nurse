using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerTissue : MonoBehaviour
{
    public Click Tissuebox;

    [SerializeField] private AudioClip A51;
    [SerializeField] private AudioClip TissueSound;
    AudioSource audio;
    public float Volume;

    // Start is called before the first frame update

    private void Start()
    {
        audio = GetComponent<AudioSource>();

    }


    public void OnObjectClicked()
    {
        audio.PlayOneShot(TissueSound, Volume);
        Invoke("PlayA51",1f);
        Debug.Log("ClickTissue");

    }
    private void PlayA51()
    {
        audio.PlayOneShot(A51, Volume);
    }
}
