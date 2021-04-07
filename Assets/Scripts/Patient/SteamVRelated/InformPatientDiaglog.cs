// using System.Collections;
// using System.Collections.Generic;

// using UnityEngine;
// using Valve.VR.InteractionSystem;

// public class InformPatientDiaglog : MonoBehaviour
// {
//     [SerializeField] private AudioClip SoundtoPlay;
//     AudioSource audio;
//     public float Volume;
//     public bool alreadyPlayedStep1 = false;
//     public bool alreadyPlayedStep3;
//     public bool areadyPlayedStep5 = false;


//     public Animator canvas;
//     public Animator canvasQuestionOn;


//     public Click objects;
//     public List<GameObject> Popup;
   
//     public GameObject nextStep;

//     // Start is called before the first frame update
//     void Start()
//     {
//         canvas = canvas.GetComponent<Animator>();
//         audio = GetComponent<AudioSource>();
//         canvas.gameObject.SetActive(false);
//         canvasQuestionOn = canvasQuestionOn.GetComponent<Animator>();
//     }



//     public void ClickonPatient()
//     {
//         if (!alreadyPlayedStep1)
//         {
//             Popup[0].SetActive(true);
//             canvas.gameObject.SetActive(true);
//             canvas.Play("User_B2_1");
//             alreadyPlayedStep1 = true;
//             audio.PlayOneShot(SoundtoPlay, Volume);
//             //nextStep.SetActive(true);


//         }
//         else if (alreadyPlayedStep3==true)
//         {
//             Popup[1].SetActive(true);
//              Popup[1].gameObject.GetComponent<Animator>().Play("User_B2_1");
//             // canvas.Play(0);
//             alreadyPlayedStep3 = false;
//            // canvasQuestionOn.Play("QuestionCanvasOn");

//             audio.PlayOneShot(SoundtoPlay, Volume);
//         }
//         else if (areadyPlayedStep5 == true)
//         {
//             Popup[2].SetActive(true);
//             areadyPlayedStep5 = false;
//             audio.PlayOneShot(SoundtoPlay, Volume);
            
//             GameObject.Find("Question Canvas").SetActive(false);
//         }

//     }



//     // Update is called once per frame

    
// }
