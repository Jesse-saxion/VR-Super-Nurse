using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyNoseBandage : MonoBehaviour
{

    public GameObject NoseBandage;
    public GameObject WrappedNoseBandage;
    private List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
    void Start() {
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

    }
    //When clicked on and collider overlaps
    void OnTriggerEnter(Collider other) {
        // bool triggerValue;
        Debug.Log("NoseBandage collided");
        Debug.Log(inputDevices);
        //&& inputDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue
        if(other.gameObject.name == NoseBandage.name ) {
            Debug.Log("Applying bandage");
            other.gameObject.SetActive(false);
            WrappedNoseBandage.SetActive(true);
        }
    }
    public void Remove() {
        WrappedNoseBandage.SetActive(false);
        NoseBandage.SetActive(true);   
    }
}
