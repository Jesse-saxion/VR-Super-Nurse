using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnWaterCollision : MonoBehaviour
{
    public UnityEvent onWater;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Hand"){        
            onWater.Invoke();              
            
        }
    }
}
