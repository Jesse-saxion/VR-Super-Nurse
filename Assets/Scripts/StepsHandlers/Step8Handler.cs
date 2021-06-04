using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step8Handler : StepHandler
{
    public GameObject Nose;
    public GameObject NoseBandage;
    public GameObject tube;

    private MoveTubeAnimation tubestuff;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate();

        tubestuff = tube.GetComponent<MoveTubeAnimation>();
        
        if(tubestuff == null){
            Debug.Log("Tube animation is NULL");
        }
        else{
            Debug.Log("Tube is FINE");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tubestuff.tubeInserted && !CheckIfSubstepComplete(2)) {
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
