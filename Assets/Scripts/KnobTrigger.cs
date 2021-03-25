using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class KnobTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent onKnobClick;
    
    private void OnTriggerEnter(Collider other) {
        if(other.isTrigger && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) {
            onKnobClick?.Invoke();
        }
    }
}
