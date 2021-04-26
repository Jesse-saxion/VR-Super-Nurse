using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Item : MonoBehaviour
{
    public bool Interactable;

    //Transform properties
    Vector3 snapPosition;
    Quaternion snapRotation;
    Vector3 snapScale;

    void Start()
    {
        //Set the initial transform (on the table)
        snapPosition = transform.position;
        snapRotation = transform.rotation;
        snapScale = transform.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        //When colliding with the snap zone, snap (doesn't apply for Step3 Handler collider)
        if (other.tag == "ItemResetZone")
        {
            Snap(snapPosition);           
        }
    }

    public void Snap(Vector3 pSnapPosition)
    {
        //Detach the Item from the hand if attached 
        if (GetComponent<XRGrabInteractable>().isSelected)
        {           
            GetComponent<XRGrabInteractable>().trackPosition = false;
            GetComponent<XRGrabInteractable>().trackRotation = false;
        }

        //Set the transform
        transform.position = pSnapPosition;
        transform.rotation = snapRotation;
        //transform.localScale = snapScale;

        //Reset the velocity
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SnapToSetLocation()
    {
        Snap(snapPosition);
    }

    public void SetSnapLocation(Vector3 pSnapPosition)
    {
        snapPosition = pSnapPosition;        
    }

    //Activate items that can be interacted with 
    public void EnableInteractivity()
    {
        if (Interactable)
        {
            GetComponent<XRGrabInteractable>().trackPosition = false;
            GetComponent<XRGrabInteractable>().trackRotation = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
