using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class KnobRotation : MonoBehaviour
{
    public float RotationY1;
    public float RotationY2;
    public GameObject Waterfall;
    [SerializeField] private AudioClip WaterOn;
    [SerializeField] private AudioClip WaterOff;
    AudioSource audioOn;
  
// Start is called before the first frame update
    private void Start()
    {
        audioOn = GetComponent<AudioSource>();
    }


    public void Interact()
    { 
        if (Waterfall.activeSelf == false)
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
