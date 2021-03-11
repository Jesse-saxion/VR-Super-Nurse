using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingOnClick : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public void EnableObjects()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
