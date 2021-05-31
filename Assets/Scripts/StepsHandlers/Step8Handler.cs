using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step8Handler : StepHandler
{
    public GameObject Nose;
    public GameObject NoseBandage;
    public Animator tubeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tubeAnimator.GetCurrentAnimatorStateInfo(0).IsName("TubeInserted")) {
            //Tube is fully inserted, allowing the syringe to take out stomach fluids
            Debug.Log("Tube fully inserted");
            CompleteSubStep(2);
        }

        // if(CheckIfSubstepComplete(2)) {
        //     //Now the syringe can take out stomach fluids
        //         //TODO: Run script that fills syringe with stomach fluids if activated
        // }
    }
}
