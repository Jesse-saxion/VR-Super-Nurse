using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Triggerenter : MonoBehaviour
{
    [SerializeField] private AudioClip success;
    AudioSource audio;
    public bool isPlayed = false;
   
    [SerializeField] private GameObject traynew;
    [SerializeField] private GameObject tube;
    [SerializeField] private GameObject canvas;

    public CheckList checkList;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayed == false)
        { 
            audio.PlayOneShot(success, 2f);
            isPlayed = true;
            checkList.UpdateCheckList("Select material");

            traynew.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("materialstep3"));
            Destroy(GameObject.FindGameObjectWithTag("notcorrect"));
            GameObject.FindGameObjectWithTag("glovesBox").GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("glovesBox").GetComponent<MeshRenderer>().enabled = true;           
        }
        if (other.tag == "Tubeold" && isPlayed==true)
        {
            Destroy(tube);
            canvas.SetActive(true);
        }
    }
}

