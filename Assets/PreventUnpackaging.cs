using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventUnpackaging : MonoBehaviour
{
    // Used to prevent unpacking it by accident on the tool table.
    public bool isReadyToUnpack;
    public GameObject TubeMeasurement;
    public GameObject NasogastricTubing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setReadyToUnpack()
    {
        isReadyToUnpack = true;
    }

    public void unpackTube()
    {
        if (isReadyToUnpack)
        {
            TubeMeasurement.SetActive(true);
            NasogastricTubing.SetActive(false);
        }
    }
}
