using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformPatientDialog : MonoBehaviour
{
    [SerializeField] private AudioClip soundToPlayStep2;
    [SerializeField] private AudioClip soundToPlayStep4;
    [SerializeField] private AudioClip soundToPlayStep10;
    AudioSource audio;
    public float volume;
    public bool alreadyPlayedStep2 = false;
    public bool alreadyPlayedStep4;
    public bool alreadyPlayedStep10 = false;

    // public Click objects;
    // public List<GameObject> Popup;
 
    // public GameObject nextStep;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Play an audiofragment to inform the patient about what is happening next.
    public void ClickonPatient()
    {
        if (!alreadyPlayedStep2)
        {
            // Popup[0].SetActive(true);
            alreadyPlayedStep2 = true;
            audio.PlayOneShot(soundToPlayStep2, volume);
            // nextStep.SetActive(true);
        }
        else if (alreadyPlayedStep4==true)
        {
            // Popup[1].SetActive(true);
            // Popup[1].gameObject.GetComponent<Animator>().Play("User_B2_1");
            // canvas.Play(0);
            alreadyPlayedStep4 = false;
            // canvasQuestionOn.Play("QuestionCanvasOn");
            audio.PlayOneShot(soundToPlayStep4, volume);
        }
        else if (alreadyPlayedStep10 == true)
        {
            // Popup[2].SetActive(true);
            alreadyPlayedStep10 = false;
            audio.PlayOneShot(soundToPlayStep10, volume);
        }

    }
}
