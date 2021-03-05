using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNew : MonoBehaviour
{
    public float DistanceBetweenParts;
    public List<GameObject> Parts;
    public float MaxAngle;

    private List<Transform> oldPos;
    void Start()
    {
        foreach (GameObject part in Parts)
        {
            oldPos.Add(part.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
