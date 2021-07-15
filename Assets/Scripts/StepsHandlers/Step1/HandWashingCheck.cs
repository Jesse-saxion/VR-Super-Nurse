using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


// This class also inludes depricated hand washing step. In this version it is only used for hand sanitizer, so if you dont need hand washing, you can ignore/delete it 
public class HandWashingCheck : MonoBehaviour
{
    private bool[] stepsComplete = new bool[6];
    public GameObject nextStep;
    public GameObject notfinish;
    public CheckList checkList;
    [SerializeField] private AudioClip success;
    AudioSource audio;
    public float Volume;
    public bool stepCompleted = false;
    public XRSimpleInteractable xRSimpleInteractable;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        xRSimpleInteractable = GetComponentInChildren<XRSimpleInteractable>();
    }

    // HAND WASHING BELOW
    public void OnKnobRotated()
    {
        if(stepsComplete[0] == false) {
            Debug.Log("Step 1 of hand washing complete: Turn knob on");
            stepsComplete[0] = true;
        } else if(stepsComplete[5] == false && stepsComplete[4] == true){
            Debug.Log("All steps of hand washing complete. Now continuing to the next step of the nasogastric tube procedure");
            GameObject.Find("TriggerStep1").GetComponent<AudioSource>().enabled = false;
            stepsComplete[5] = true;
            //nextStep.SetActive(true);
            //notfinish.SetActive(false);
            //checkList.UpdateCheckList("cleaned hands");
            audio.PlayOneShot(success, Volume);
          }
    }

    public void OnHandUnderFaucet() {
        if(GameObject.FindGameObjectWithTag("water").GetComponent<Collider>().enabled == true) {
            if(stepsComplete[1] == false) {
            Debug.Log("Step 2 of hand washing complete: Make hands wet");
            stepsComplete[1] = true;
        }
        //If hand is already covered in soap, then it is being washed, which is step 4 of washing hands 
        else if(stepsComplete[3] == false && stepsComplete[2] == true) {
            Debug.Log("Step 4 of hand washing complete: Wash hands with soap");
            stepsComplete[3] = true;
            GameObject.FindGameObjectWithTag("water").GetComponent<Collider>().enabled = false;
        }
        Debug.Log("Hand put under water, but no steps completed");
        }
        
    }

    public void OnHandSoaped() {
        if(GameObject.FindGameObjectWithTag("soap").GetComponent<Collider>().enabled == true) {
            if(stepsComplete[2] == false && stepsComplete[1] == true) {
                Debug.Log("Step 3 of hand washing complete: Soap hands");
                stepsComplete[2] = true;
                GameObject.FindGameObjectWithTag("soap").GetComponent<Collider>().enabled = false;
            }
        }

    }

    public void OnHandDried() {
        if(stepsComplete[4] == false && stepsComplete[3] == true) {
            Debug.Log("Step 5 of hand washing complete: Dry hands");
            stepsComplete[4] = true;
        }
    }

    // HAND SANITIZING BELOW
    public void OnHandSanitized() {
        Debug.Log("Hand cleaned using sanitizer, proceeding to next step of the procedure");

        if (!stepCompleted)
        {
            audio.PlayOneShot(success, Volume);
            stepCompleted = true;
            xRSimpleInteractable.enabled = false;
        }
    }
}