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

    public GameObject Item;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Item.name)
        {
            insideSnapZone = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Item.name)
        {
            insideSnapZone = true;
            isPlayed = false;
        }
    }

    void SnapObject()
    {
        if (grabbed == false && insideSnapZone == true)
        {
            Item.gameObject.transform.position = gameObject.transform.position;
            Item.gameObject.transform.rotation = gameObject.transform.rotation;
            Item.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            Snapped = true;

            Debug.Log(this.gameObject.name);
        }
    }

    void Update()
    {
        grabbed = Item.GetComponent<Interactable>().attachedToHand;
        SnapObject();
    }

}
