using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5Handler : StepHandler
{
 
   public Material WaterMaterial;
    public void TubeMarked() {
        Debug.Log("Tube has been marked");
        CompleteSubStep(1);
    }

    //This method is called in Tube's children with colliders (it didn't work otherwise)
    public void OnTriggerEnter(Collider other)
    {    
        Debug.Log("Collided");
        //When colliding with the snap zone, snap (doesn't apply for Step3 Handler collider)
        if (other.gameObject.tag == "TubeWater" 
        // && CheckIfSubstepComplete(1)
        )
        {
            Debug.Log("Tube collided with kidney dish. Changing materials...");
            WaterTube();
        }
    }

    void WaterTube() {
        this.GetComponentInChildren<MeshRenderer>().materials[0] = WaterMaterial;
    }
}
