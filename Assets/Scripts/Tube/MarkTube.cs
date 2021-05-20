using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkTube : MonoBehaviour
{
    public bool canMarkSeveralTimes = false;
    bool canMark = true;
    [SerializeField]
    public GameObject tubeStepHandler;

    void OnTriggerEnter(Collider other)
    {
        if (canMarkSeveralTimes)
        {
            if (other.TryGetComponent<PlaceMark>(out PlaceMark component))
            {
                other.GetComponent<PlaceMark>().DrawMark();
                tubeStepHandler.GetComponent<Step6Handler>().TubeMarked();
            }
        }
        else if (other.TryGetComponent<PlaceMark>(out PlaceMark component) && canMark)
        {
            other.GetComponent<PlaceMark>().DrawMark();
            tubeStepHandler.GetComponent<Step6Handler>().TubeMarked();
            canMark = false;
        }
    }
}
