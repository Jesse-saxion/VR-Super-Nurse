﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapObject : MonoBehaviour
{
    public GameObject Snaplocation;
    public bool isSnapped;
    [SerializeField]private bool objectSnapped;
    [SerializeField] private bool grabbed;

    private void Update()
    {
        grabbed = GetComponent<Interactable>().attachedToHand;
        objectSnapped = Snaplocation.GetComponent<SnapToLocation>().Snapped;

        if(objectSnapped == true)
        {
            //GetComponent<Rigidbody>().isKinematic = true;
            isSnapped = true;
        }

        if(objectSnapped == false && grabbed == false)
        {
            isSnapped = false;
            //GetComponent<Rigidbody>().isKinematic = false;
           // GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
