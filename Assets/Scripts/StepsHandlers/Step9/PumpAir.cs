using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAir : MonoBehaviour
{
    public Animator animator;

    public GameObject TubeCap;

    [SerializeField] private AudioClip airPump;
    [SerializeField] private AudioClip temporaryEndOfDemoVoiceLine;
    AudioSource audio;
    public float volume;

    // Start is called before the first frame update
        void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TubeCap)
        {
            Debug.Log("Collided with tube cap, starting pumping animation");
            animator.SetTrigger("pumpAir");
            audio.PlayOneShot(airPump, volume);
            audio.PlayOneShot(temporaryEndOfDemoVoiceLine, volume);
        }
    }
}
