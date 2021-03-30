using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertTube : MonoBehaviour
{
    public GameObject insertionTube;
    public GameObject measurementTube;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TubeStart")
        {
            insertionTube.gameObject.SetActive(true);                               //Set the marked material to the insertion tube
            insertionTube.transform.GetChild(0).GetComponent<MeshRenderer>().material = measurementTube.transform.GetChild(0).GetComponent<MeshRenderer>().material;  
            Destroy(measurementTube);
        }
    }
}
