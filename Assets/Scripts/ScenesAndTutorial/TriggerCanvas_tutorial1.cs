using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCanvas_tutorial1 : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Canvas.SetActive(true);
            if (Text != null)
            {
                Text.SetActive(false);
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Canvas.SetActive(false);
        }
    }
}
