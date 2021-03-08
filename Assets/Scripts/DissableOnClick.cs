using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableOnClick : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public void DissableObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
