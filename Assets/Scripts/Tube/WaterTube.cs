using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //When colliding with the snap zone, snap (doesn't apply for Step3 Handler collider)
        if (other.name == "NasogastricTubing")
        {
            SnapTube();
        }
    }

    void SnapTube() {
        
    }
}
