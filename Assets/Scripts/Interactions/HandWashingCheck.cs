﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWashingCheck : MonoBehaviour
{
    public GameObject[] objects;
    private int index = 0;
    private bool[] stepsComplete = new bool[5];
    public GameObject nextStep;
    public GameObject notfinish;
    public CheckList checkList;
    [SerializeField] private AudioClip success;
    AudioSource audio;
    public float Volume;

    // Start is called before the first frame update

    private void Start()
    {
        audio = GetComponent<AudioSource>();
       
    }

    private bool checkIfHandWashingComplete() {
        foreach(bool value in stepsComplete) {
                if(value == false) {
                    return false;
                }
            }
            return true;
    }

    public void OnKnobRotated()
    {
        if(stepsComplete[0] == false) {
            Debug.Log("Step 1 of hand washing complete: Turn knob on");
            stepsComplete[0] = true;
        } else if(checkIfHandWashingComplete()){
            Debug.Log("All steps of hand washing complete. Now continuing to the next step of the nasogastric tube procedure");
            GameObject.Find("TriggerStep1").GetComponent<AudioSource>().enabled = false;
            nextStep.SetActive(true);
            notfinish.SetActive(false);
            checkList.UpdateCheckList("washed hands");
            audio.PlayOneShot(success, Volume);
        }
    }

    public void OnHandUnderFaucet() {
        if(stepsComplete[1] == false) {
            Debug.Log("Step 2 of hand washing complete: Make hands wet");
            stepsComplete[1] = true;
        }
        //If hand is already covered in soap, then it is being washed, which is step 4 of washing hands 
        else if(stepsComplete[3] == false && stepsComplete[2] == true) {
            Debug.Log("Step 4 of hand washing complete: Wash hands with soap");
            stepsComplete[3] = true;
        }
    }

    public void OnHandSoaped() {
        if(stepsComplete[2] == false && stepsComplete[1] == true) {
            Debug.Log("Step 3 of hand washing complete: Soap hands");
            stepsComplete[2] = true;
        }
    }

    public void OnHandDried() {
        if(stepsComplete[4] == false && stepsComplete[3] == true) {
            Debug.Log("Step 5 of hand washing complete: Dry hands");
            stepsComplete[4] = true;
        }
    }
}