using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step6Handler : StepHandler
{
 
   public Material WaterMaterial;
    public void TubeMarked() {
        Debug.Log("Tube has been marked");
        CompleteSubStep(1);
    }

    //This method is called in Tube's children with colliders (it didn't work otherwise)
    public void CollisionDetected(Collision other)
    {    
        //When colliding with the snap zone, snap (doesn't apply for Step3 Handler collider)
        if (other.gameObject.name == "KidneyDish" && CheckIfSubstepComplete(1))
        {
            SnapTube(other.gameObject.GetComponent<GameObject>());
        }
    }

    void SnapTube(GameObject tube) {
        this.GetComponentInChildren<MeshRenderer>().material = WaterMaterial;
    }
}
