using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step8NoseBandage : SubStep
{

    public GameObject NoseBandage;
    public GameObject WrappedNoseBandage;

    private void Start()
    {
        InstantiateSubStep();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == NoseBandage.name)
        {
            Debug.Log("Applying bandage");
            other.gameObject.SetActive(false);
            WrappedNoseBandage.SetActive(true);
            CompleteSubStep();
        }
    }
    public void Remove()
    {
        WrappedNoseBandage.SetActive(false);
        NoseBandage.SetActive(true);
    }
}
