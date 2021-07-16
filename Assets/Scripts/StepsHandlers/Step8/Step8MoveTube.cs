using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Step8MoveTube : SubStep
{
    private Animator animator;
    private PlayReactions playReactions;
    //public Hand leftHand;
    //public Hand rightHand;
    XRBaseInteractor grabbedHand;

    [Tooltip("How much the hand movement is going to move the tube")]
    public float movingAmplification = 3f;
    [Range(0f, 1f)]
    float time;

    private float oldTime;
    float positionDiffirence;
    private bool moving;
    private float startPositionZ;

    public bool tubeInserted = false;

    void Start()
    {
        InstantiateSubStep();
        animator = GetComponent<Animator>();
        playReactions = GetComponent<PlayReactions>();

        animator.Play("NoseInsertion", 0, 0f);
    }

    void Update()
    {
        if (moving)
        {
            positionDiffirence = grabbedHand.transform.position.x - startPositionZ;

            time = oldTime + positionDiffirence * movingAmplification;
            animator.SetFloat("Time", time);

            tubeInserted = false;

            //set time to 0 or 1 to avoid overkill
            if (time < 0)
            {
                time = 0;
            }
            if (time > 1)
            {
                time = 1;
                tubeInserted = true;
                CompleteSubStep();
            }
        }

        //Debugging & Testing 
        //if (Input.GetKey(KeyCode.Alpha0))
        //{
        //    time += 0.005f;
        //    animator.SetFloat("Time", time);
        //}

        //if (Input.GetKey(KeyCode.Alpha9))
        //{
        //    time -= 0.005f;
        //    animator.SetFloat("Time", time);
        //}

    }

    public void StartMoving()
    {
        grabbedHand = GetComponent<XRSimpleInteractable>().hoveringInteractors[0];
        Debug.Log(grabbedHand);
        //if (leftHand.GetGrabStarting() != GrabTypes.None)
        //{
        //    grabbedHand = leftHand;
        //}
        //else if (rightHand.GetGrabStarting() != GrabTypes.None)
        //{
        //    grabbedHand = rightHand;
        //}

        startPositionZ = grabbedHand.transform.position.x;
        moving = true;
    }

    public void StopMoving()
    {
        oldTime = time;
        moving = false;        
    }

    public float GetTubeMovement()
    {
        return positionDiffirence;
    }
}
