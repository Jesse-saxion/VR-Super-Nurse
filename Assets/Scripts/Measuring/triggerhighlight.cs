using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerhighlight : MonoBehaviour
{
    [SerializeField] private GameObject cylinder;
    [SerializeField] private GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("highlight"))
        {
            if (text.GetComponent<triggercanvas>().selectednumber == 62)
            {
                cylinder.SetActive(true);
            }
            
        }
    }
}
