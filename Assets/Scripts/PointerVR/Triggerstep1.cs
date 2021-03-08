using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Triggerstep1 : MonoBehaviour
{
    public SteamVR_ActionSet actionset;
    public SteamVR_Action_Boolean booleanaction;
    [SerializeField] private GameObject canvasgrabobj;
    [SerializeField] private AudioClip BeforeHand;
    AudioSource audio;
    public float Volume;
    public bool alreadyPlayed = false;
    // [SerializeField] private GameObject VRInput;
    public bool isPlayed = false;

    private void Awake()
    {
        booleanaction = SteamVR_Actions._default.GrabGrip;
        audio = GetComponent<AudioSource>();

    }
    private void Start()
    {
        actionset.Activate(SteamVR_Input_Sources.Any, 0, true);
        canvasgrabobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (booleanaction.GetStateDown(SteamVR_Input_Sources.Any))
        {
           
                canvasgrabobj.SetActive(false);
                
        }
    }
    private void OnTriggerEnter()
    {
        if (!alreadyPlayed)
        {
            canvasgrabobj.SetActive(true);
            alreadyPlayed = true;
          
        }
    if (!isPlayed)
        {
            isPlayed = true;
            audio.PlayOneShot(BeforeHand, Volume);
        }
    }
}
