using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertTube : MonoBehaviour
{
    public GameObject insertionTube;
    public GameObject measurementTube;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tube")
        {
            insertionTube.gameObject.SetActive(true);
            insertionTube.transform.GetChild(0).GetComponent<MeshRenderer>().material = measurementTube.transform.GetChild(0).GetComponent<MeshRenderer>().material;
            Destroy(measurementTube);
        }
    }
}
