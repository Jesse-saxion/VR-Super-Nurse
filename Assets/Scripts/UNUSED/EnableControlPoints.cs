using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using Valve.VR.InteractionSystem;


public class EnableControlPoints : MonoBehaviour
{
    public ObiParticleAttachment controlPoint;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void EnableDisablePoint(bool value)
    {
        controlPoint.enabled = value;
    }
}
