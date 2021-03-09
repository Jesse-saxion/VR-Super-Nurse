using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour
{
   
    [SerializeField] private GameObject Canvasfalse;

    public void Setup()
    {
        Invoke("TurnOn", 1f);

    }

    public void TurnOn()
    {
        Canvasfalse.SetActive(false);
        
    }
}
