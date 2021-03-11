using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR.InteractionSystem;

public class InteractablePipePart : MonoBehaviour
{
    public PipeManager Manager;
    public bool InTheHole = false;
    private Valve.VR.InteractionSystem.Hand Hand;
    private Rigidbody rg;
    // Start is called before the first frame update
    private void Update()
    {
        if (rg.velocity.magnitude > 1)
        {
            rg.velocity = new Vector3(rg.velocity.x/10,rg.velocity.y/10) ;
        }
    }
    void Start()
    {
        gameObject.GetComponent<Valve.VR.InteractionSystem.Interactable>().onAttachedToHand += OnInteracted;
        gameObject.GetComponent<Valve.VR.InteractionSystem.Interactable>().onDetachedFromHand += OnStopInteracting;
        rg = gameObject.GetComponent<Rigidbody>();
    }
    public void OnInteracted(Valve.VR.InteractionSystem.Hand hand)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
       // Manager.OnPipePartSelected(gameObject);
        Manager.currentInteractibleObject = gameObject;
        Hand = hand;
    }
    public void OnStopInteracting(Valve.VR.InteractionSystem.Hand hand)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
       // Manager.OnPipePartDeselected(gameObject);
        Manager.currentInteractibleObject = null;
        Hand = null;
    }
    public void OnHoleEntered(GameObject HolePlaceHolder)
    {
        if (Hand != null)
        {
            gameObject.GetComponent<Valve.VR.InteractionSystem.Interactable>().OnDetachedFromHand(Hand);
        }
        gameObject.transform.position = HolePlaceHolder.transform.position;
        gameObject.transform.rotation = HolePlaceHolder.transform.rotation;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Valve.VR.InteractionSystem.Interactable>().enabled = false;
       Manager.EnteredTrigger.Add(this.gameObject);
        if (Manager.EnteredTrigger.Count > 2)
        {
            Manager.EnteredTrigger[Manager.EnteredTrigger.Count - 2].GetComponent<MeshRenderer>().enabled = false;
        }
       
    }
    public void OnHoleExit()
    {
    
    }
  
}
