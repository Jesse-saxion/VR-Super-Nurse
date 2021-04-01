using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenCleanUp : MonoBehaviour
{
    List<GameObject> children;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();

        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            children.Add(child.gameObject);
        }

    }

    void OnDestroy()
    {
        foreach (GameObject child in children)
        {
            Destroy(child);
        }
    }
}
