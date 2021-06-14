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
   SkinnedMeshRenderer[] HandMeshRenderers;


   List<GameObject> MeasuringCheckPoints = new List<GameObject>();
   GameObject CanvasPart;
   LineRenderer line;
   // private int index = 0;
   // Start is called before the first frame update
   void Start() {
       HandMeshRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
       Debug.Log(HandMeshRenderers);
   }
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
        SetHandMaterial(soapMat);
        bubble.SetActive(true);
       
   }
   public void OnHandTowelPressed()
   {
       SetHandMaterial(GloveMaterial);
       bubble.SetActive(false);
   }
   public void OnGlovesBoxClicked()
   {
       SetHandMaterial(glovesMat);
   }
   public void OnHandOnWater()
   {
        Debug.Log("Applying water texture");
        SetHandMaterial(waterMat);
        bubble.SetActive(false);
   }

   public void OnSanitizerActivated() {
       SetHandMaterial(soapMat);
       float alpha = 1.0f;
       float fadespeed = 1.0f;
       while(alpha > 0.0f) {
           alpha -= fadespeed * Time.deltaTime;
        //    HandMeshRenderers[0].color = new Color();
       }
   }

   private void SetHandMaterial(Material mat) {
       HandMeshRenderers[0].material = mat;
       HandMeshRenderers[1].material = mat;
   }
}
