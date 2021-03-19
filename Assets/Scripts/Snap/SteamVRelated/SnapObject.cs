using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnapObject :
    MonoBehaviour


{
    public GameObject SnapLocation;


    public bool isSnapped;


    [SerializeField] private
        bool objectSnapped;


    [SerializeField] private
        bool grabbed;


    private void Update()


    {
        grabbed = GetComponent<OVRGrabbable>().isGrabbed;


        objectSnapped = SnapLocation.GetComponent<SnapToLocation>().Snapped;


        if (objectSnapped ==
            true)


        {
//GetComponent<Rigidbody>().isKinematic = true;


            isSnapped = true;
        }


        if (objectSnapped ==
            false && grabbed == false)


        {
            isSnapped = false;


//GetComponent<Rigidbody>().isKinematic = false;


// GetComponent<Rigidbody>().useGravity = true;
        }
    }
}