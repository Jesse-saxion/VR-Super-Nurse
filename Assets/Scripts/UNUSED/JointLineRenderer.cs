using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointLineRenderer : MonoBehaviour
{
    public LineRenderer LRenderer;
    public List<GameObject> Objs;
    // Start is called before the first frame update
    void Start()
    {
        LRenderer.positionCount = Objs.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<Objs.Count; i++)
        {
            LRenderer.SetPosition(i, Objs[i].transform.position);
        }

    }
}
