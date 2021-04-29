using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadInteractions : MonoBehaviour
{
    public GameObject tube;
    public GameObject head;
    PlayReactions patientReactions;
    bool tilted;

    // Start is called before the first frame update
    void Start()
    {

        patientReactions = tube.GetComponent<PlayReactions>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cup")
        {
            patientReactions.StartSwallowing();
            Destroy(other.gameObject);
        }
    }

    public void TiltHead()
    {
        Debug.Log("Tilt");
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
