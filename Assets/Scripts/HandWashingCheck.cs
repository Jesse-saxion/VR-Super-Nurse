using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandWashingCheck : MonoBehaviour
{
    public List<Click> objects;
    private int index = 0;
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


    public void OnObjectClicked()
    {
        objects[index].enabled = false;
        index++;
        if (index <= objects.Count-1)
        {
            objects[index].enabled = true;
            
        }
        else
        {
            GameObject.Find("Trigger_Step1").GetComponent<AudioSource>().enabled = false;
            nextStep.SetActive(true);
            notfinish.SetActive(false);
            checkList.UpdateCheckList("washed hands");
            // invoke
            audio.PlayOneShot(success, Volume);


        }
    }
}
