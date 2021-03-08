using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfActive : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public GameObject NextCanvasPart;

    private bool thereIsTrue = false;
    // Update is called once per frame
    void Update()
    {
        if (objects.Count!=0)
        {
            foreach (GameObject obj in objects)
            {
                if (obj.activeSelf)
                {
                    thereIsTrue = true;
                }
            }
            if(thereIsTrue)
            {
                thereIsTrue = false;
            }
            else
            {
                NextCanvasPart.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
