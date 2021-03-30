using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ChangeToPointer : MonoBehaviour
{
    public SteamVR_ActionSet actionset;
    public SteamVR_Action_Boolean booleanaction;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject VRInput;
    public bool isDirect = false;

    private void Awake()
    {
        booleanaction = SteamVR_Actions._default.ButtonA;
       
    }
    private void Start()
    {
        actionset.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (booleanaction.GetStateDown(SteamVR_Input_Sources.Any)) 
        {
            isDirect = !isDirect; 
           
            if (isDirect)
            {
                pointer.SetActive(true);
                VRInput.SetActive(true);
            }
            else
            {
                pointer.SetActive(false);
                VRInput.SetActive(false);
            }               
           
        }
    }
}
