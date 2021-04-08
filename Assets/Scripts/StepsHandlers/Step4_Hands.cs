//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR.InteractionSystem;


//public class Step4_Hands : MonoBehaviour
//{
//    public List<Click> objects;
//    private int index = 0;
   
//    public CheckList checkList;
//    [SerializeField] private AudioClip success;
//    AudioSource audio;
//    public float Volume;
//    public GameObject Tissue;
//    public GameObject InformPatientScript;
//    // Start is called before the first frame update

//    private void Start()
//    {
//        audio = GetComponent<AudioSource>();       
//    }

//    public void OnObjectClicked()
//    {
//        objects[index].enabled = false;
//        index++;

//        if (index <= objects.Count - 1)
//        {
//            objects[index].enabled = true;
//        }
//        else
//        {
//            Tissue.GetComponent<TriggerNoTissue>().isGlove = true;
//            InformPatientScript.GetComponent<InformPatientDialog>().alreadyPlayedStep3 = true;
//            checkList.UpdateCheckList("Put on medical gloves");
//            // invoke
//            audio.PlayOneShot(success, Volume);
          

//        }
//    }
    
//}
