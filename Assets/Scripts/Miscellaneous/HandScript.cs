using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HandScript : MonoBehaviour
{
   public Material GloveMaterial;
   public Material waterMat;
   public Material soapMat;
   public Material glovesMat;
   public GameObject bubblePrefab;
   GameObject bubble;
   GameObject soap;
   GameObject towelBox;
   GameObject glovesBox;
   GameObject MeasuringObj;


   List<GameObject> MeasuringCheckPoints = new List<GameObject>();
   GameObject CanvasPart;
   LineRenderer line;
   private int index = 0;
   // Start is called before the first frame update
   void Awake()
   {
       soap = GameObject.FindGameObjectWithTag("soap");
       towelBox = GameObject.FindGameObjectWithTag("towelBox");
       glovesBox = GameObject.Find("GlovesBox");
       bubble = Instantiate(bubblePrefab, Vector3.zero, Quaternion.identity, transform);
       //bubble = GameObject.FindGameObjectWithTag("bubble");

       bubble.SetActive(false);
   }
   public void OnSoapClicked()
   {
       gameObject.GetComponent<SkinnedMeshRenderer>().material = soapMat;
       bubble.SetActive(true);
   }
   public void OnHandTowelPressed()
   {
       gameObject.GetComponent<SkinnedMeshRenderer>().material = GloveMaterial;

   }
   public void OnGlovesBoxClicked()
   {
       gameObject.GetComponent<SkinnedMeshRenderer>().material = glovesMat;
   }
   public void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("water"))
       {
        Debug.Log(gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material);
        Debug.Log("Applying water texture");
        gameObject.GetComponent<SkinnedMeshRenderer>().material =  waterMat;
        bubble.SetActive(false);
       }
   }
}
