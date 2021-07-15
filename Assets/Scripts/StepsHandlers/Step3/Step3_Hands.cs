using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Step3_Hands : MonoBehaviour
{
    public CheckList checkList;
    [SerializeField] private AudioClip success;
    AudioSource audio;
    public float Volume;
    public GameObject Tissue;
    public GameObject InformPatientScript;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnObjectClicked()
    {
        Tissue.GetComponent<Step4Tissue>().isGlove = true;
        InformPatientScript.GetComponent<InformPatientDialog>().alreadyPlayedStep3 = true;
        checkList.UpdateCheckList();
        audio.PlayOneShot(success, Volume);
    }

}
