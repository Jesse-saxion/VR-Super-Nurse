using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CupScript : MonoBehaviour
{
    // public GameObject Cupplace;
    // // public GameObject CallingCanvas;
    ////  public GameObject NextStep;


    public Transform target;
    public float speed;
    

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            Debug.Log("Cupin");

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);


            //other.gameObject.transform.position = Cupplace.transform.position ;
            //// NextStep.SetActive(true);
            ////gameObject.GetComponent<Interactable>().enabled = false;
            //// Destroy(gameObject.GetComponent<InteractableHoverEvents>());
            //// gameObject.GetComponent<BoxCollider>().enabled = false;
            //Cupplace.gameObject.GetComponent<Renderer>().enabled = true;
            //Cupplace.gameObject.GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
            ////   Destroy(gameObject);
            ////other.gameObject.SetActive(false);
        }
    }
    //public void ActivateCupInteraction()
    //{
    //   // CallingCanvas.SetActive(false);
    //    CupPlace.SetActive(true);
    //}
}
