using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step7HeadInteractions : SubStep
{
    public GameObject tube;
    public GameObject head;
    PlayReactions patientReactions;
    bool tilted;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateSubStep();
        patientReactions = tube.GetComponent<PlayReactions>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TiltHead();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cup")
        {
            patientReactions.StartSwallowing();
            Destroy(other.gameObject);
            CompleteSubStep();
        }

        if (other.gameObject.name == "Hand")
        {
            TiltHead();
        }
    }

    public void TiltHead()
    {
        if (!tilted)
        {
            head.transform.Rotate(new Vector3(15f, 0f, 0f), Space.Self);
            tilted = true;
        }
        else
        {
            head.transform.Rotate(new Vector3(-15f, 0f, 0f), Space.Self);
            tilted = false;
        }
    }
}
