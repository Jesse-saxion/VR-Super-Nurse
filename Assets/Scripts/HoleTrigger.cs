using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject HolePlaceHolder;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<InteractablePipePart>())
        {
            InteractablePipePart script = other.gameObject.GetComponent<InteractablePipePart>();
            script.OnHoleEntered(HolePlaceHolder);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<InteractablePipePart>())
        {
            InteractablePipePart script = other.gameObject.GetComponent<InteractablePipePart>();
            script.OnHoleEntered(HolePlaceHolder);
       }

    }
}
