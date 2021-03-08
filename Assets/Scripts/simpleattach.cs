using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class simpleattach : MonoBehaviour
{
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin (Hand hand)
    {

    }

    private void OnHandHoverEnd (Hand hand)
    {

    }
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrapEnding = hand.IsGrabEnding(gameObject);

        if(interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            
        }
        else if(isGrapEnding)
        {
            hand.DetachObject(gameObject);
        }
    }
}
