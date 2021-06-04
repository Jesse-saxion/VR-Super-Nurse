using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4_Gloves : StepHandler
{
    public GameObject Tissue;
    public GameObject InformPatientScript;

    private void Start()
    {

    }

    public void OnObjectClicked()
    {
        Debug.Log("Activated gloves box");
        Tissue.GetComponent<TriggerNoTissue>().isGlove = true;
        InformPatientScript.GetComponent<InformPatientDialog>().alreadyPlayedStep4 = true;
        CompleteSubStep();
    }
}
