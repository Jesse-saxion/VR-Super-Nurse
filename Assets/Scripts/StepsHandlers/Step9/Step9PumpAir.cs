using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step9PumpAir : SubStep
{
    public Animator animator;

    public GameObject TubeCap;

    [SerializeField] private AudioClip airPump;
    [SerializeField] private AudioClip temporaryEndOfDemoVoiceLine;

    void Start()
    {
        InstantiateSubStep();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TubeCap)
        {
            Debug.Log("Collided with tube cap, starting pumping animation");
            animator.SetTrigger("pumpAir");
            PlayAudioClip(airPump);
            PlayAudioClip(temporaryEndOfDemoVoiceLine);
        }
    }
}
