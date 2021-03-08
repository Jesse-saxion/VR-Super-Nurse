using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR;

public class KnobRotation : MonoBehaviour
{
    public float RotationY1;
    public float RotationY2;
    public GameObject Waterfall;
    [SerializeField] private AudioClip WaterOn;
    [SerializeField] private AudioClip WaterOff;
    AudioSource audioOn;
  

    private void Start()
    {
        audioOn = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    //Valve.VR.InteractionSystem.Hand hand;


    public void Interact()
    { 
        if (gameObject.transform.localRotation.eulerAngles.y == RotationY1)
        {
            Waterfall.SetActive(true);
            gameObject.transform.Rotate(0,RotationY2,0);
            audioOn.PlayOneShot(WaterOn);
        }
        else
        {
            Waterfall.SetActive(false);
            gameObject.transform.Rotate(0, -RotationY2, 0);
            audioOn.PlayOneShot(WaterOff);
        }
    }

}
