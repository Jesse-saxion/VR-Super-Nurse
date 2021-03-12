using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;


public class checknumber : MonoBehaviour
{
    public SteamVR_ActionSet actionset;
    public SteamVR_Action_Boolean booleanaction;
    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        actionset.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (booleanaction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("setnum");
            text.GetComponent<triggercanvas>().Addnumber();
           
        }
       

        
    }
}
