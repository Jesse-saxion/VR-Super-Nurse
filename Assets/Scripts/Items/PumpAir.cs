using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAir : MonoBehaviour
{
    public Animator animator;

    public GameObject TubeCap;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == TubeCap.name)
        {
            Debug.Log("Collided with tube cap, starting pumping animation");
            animator.SetTrigger("pumpAir");
        }
    }
}
