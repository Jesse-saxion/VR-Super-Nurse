using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapToLocation : MonoBehaviour
{
    


    private bool grabbed;
    private bool insideSnapZone;
    public bool Snapped;

    public bool isPlayed = false;

    public GameObject RocketPart;
    public GameObject SnapRotationRef;

 
  

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == RocketPart.name)
        {
            insideSnapZone = false;
           
          //  Debug.Log("out");

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == RocketPart.name)
        {
            insideSnapZone = true;
            isPlayed = false;
            Debug.Log("In");

          

        }
    }

    void SnapObject()
    {
        if(grabbed == false && insideSnapZone == true)
        {
            RocketPart.gameObject.transform.position = gameObject.transform.position;
            RocketPart.gameObject.transform.rotation = SnapRotationRef.transform.rotation;
            Snapped = true;
          //  Debug.Log("Transform");
        }
    }

     void Update()
    {
        

        grabbed = RocketPart.GetComponent<Interactable>().attachedToHand;
        SnapObject();
       // Debug.Log("Snap");

    }

}
