using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLine : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        UpdatePos();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }
    void UpdatePos()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (line.positionCount - 1 < i)
            {
                line.positionCount++;
            }
            line.SetPosition(i, objects[i].transform.position);
        }
    }
}
