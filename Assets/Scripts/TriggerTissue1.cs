using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerTissue1 : MonoBehaviour
{
    public Click Tissuebox;
    //[SerializeField] private Transform Spawnpoint;
    [SerializeField] private GameObject tissue;
    [SerializeField] private AudioClip TissueSound;
    AudioSource audio;
    public float Volume;

    [SerializeField] private GameObject Canvas;
    //[SerializeField] private GameObject CanvasConfirm
        
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnClickTissue()
    {
        Tissue();
        tissue.SetActive(true);
       // Instantiate(tissue, Spawnpoint.position, Spawnpoint.rotation);
        Canvas.SetActive(false);
        //CanvasConfirm.SetActive(true);
    }


    public void Tissue()
    {

        audio.PlayOneShot(TissueSound, Volume);


    }
}
