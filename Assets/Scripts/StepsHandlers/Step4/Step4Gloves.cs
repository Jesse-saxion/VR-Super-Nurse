using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4Gloves : SubStep
{
    [SerializeField] private AudioClip gloveSound;
    public SubStep TissueStep;
    public GameObject InformPatientScript;
    [SerializeField] public QuestionHandler questionStep3;

    private void Start()
    {
        InstantiateSubStep();
    }

    public void PutOnGloves()
    {
        Debug.Log("Activated gloves box");
        TissueStep.GetComponent<Step5Tissue>().isGlove = true;
        PlayAudioClip(gloveSound);
        InformPatientScript.GetComponent<InformPatientDialog>().alreadyPlayedStep3 = true;
        CompleteSubStep();
        ActivateQuestion(questionStep3);
    }
}
