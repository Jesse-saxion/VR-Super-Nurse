using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Step3_CheckisFirst : MonoBehaviour
{

    public List<Click> objects;
    private int index = 0;

    [SerializeField] private AudioClip A33;   
    AudioSource audio;
    public float Volume;
    public bool isFirstPickup = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnObjectClicked()
    {
       
        if (index <= objects.Count - 1)
        {
            if (isFirstPickup == false)
            {
                audio.PlayOneShot(A33);
                isFirstPickup = true;
               
            }
           

        }
        
    }
}
