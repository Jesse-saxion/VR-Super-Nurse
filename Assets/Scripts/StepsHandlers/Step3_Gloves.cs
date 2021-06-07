using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3_Gloves : StepHandler
{
    public GameObject Tissue;
    public GameObject InformPatientScript;
    [SerializeField] public QuestionHandler questionStep3;

    private void Start()
    {

    }

    public void OnObjectClicked()
    {
        Debug.Log("Activated gloves box");
        Tissue.GetComponent<TriggerNoTissue>().isGlove = true;
        InformPatientScript.GetComponent<InformPatientDialog>().alreadyPlayedStep3 = true;
        CompleteSubStep();
        ActivateQuestion(questionStep3);
    }
}
