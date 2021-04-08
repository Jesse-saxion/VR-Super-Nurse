//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR.InteractionSystem;

//public class Item : MonoBehaviour
//{
//    //Transform properties
//    Vector3 snapPosition;
//    Quaternion snapRotation;
//    Vector3 snapScale;

//    void Start()
//    {
//        //Set the initial transform (on the table)
//        snapPosition = transform.position;
//        snapRotation = transform.rotation;
//        snapScale = transform.localScale;
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        //When colliding with the snap zone, snap (doesn't apply for Step3 Handler collider)
//        if (other.tag == "ItemResetZone")
//        {
//            Snap(snapPosition);
//        }
//    }

//    public void Snap(Vector3 pSnapPosition)
//    {
//        //Detach the Item from the hand if attached 
//        if (GetComponent<Throwable>().GetIfAttached())
//        {
//            GetComponent<Interactable>().attachedToHand.DetachObject(gameObject, true);           
//        }

//        //Set the transform
//        transform.position = pSnapPosition;
//        transform.rotation = snapRotation;
//        //transform.localScale = snapScale;

//        //Reset the velocity
//        GetComponent<Rigidbody>().velocity = Vector3.zero;
//        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
//        //GetComponent<Rigidbody>().isKinematic = true;
//    }

//    public void SnapToSetLocation()
//    {
//        Snap(snapPosition);
//    }

//    public void SetSnapLocation(Vector3 pSnapPosition)
//    {
//        snapPosition = pSnapPosition;
//    }

//    //Activate items that can be interacted with 
//    public void EnableInteractivity()
//    {
//        if (TryGetComponent<Click>(out Click click))
//        {
//            GetComponent<Click>().enabled = true;
//            Destroy(GetComponent<Throwable>());
//            GetComponent<Rigidbody>().isKinematic = true;
//        }
//    }

//}
