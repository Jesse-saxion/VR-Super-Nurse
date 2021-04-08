//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEngine;
//using Valve.VR.InteractionSystem;

//public class HandScript : MonoBehaviour
//{
//    public Material GloveMaterial;
//    public Material waterMat;
//    public Material soapMat;
//    public Material glovesMat;
//    public GameObject bubblePrefab;
//    GameObject bubble;
//    GameObject soap;
//    GameObject towelBox;
//    GameObject glovesBox;
//    GameObject MeasuringObj;


//    List<GameObject> MeasuringCheckPoints = new List<GameObject>();
//    GameObject CanvasPart;
//    LineRenderer line;
//    private int index = 0;
//    // Start is called before the first frame update
//    void Awake()
//    {
//        soap = GameObject.FindGameObjectWithTag("soap");
//        towelBox = GameObject.FindGameObjectWithTag("towelBox");
//        glovesBox = GameObject.Find("GlovesBox");
//        soap.GetComponent<Click>().OnClick.AddListener(OnSoapClicked);
//        towelBox.GetComponent<Click>().OnClick.AddListener(OnHandTowelPressed);
//        glovesBox.GetComponent<Click>().OnClick.AddListener(OnGlovesBoxClicked);
//        bubble = Instantiate(bubblePrefab, Vector3.zero, Quaternion.identity, transform);
//        //bubble = GameObject.FindGameObjectWithTag("bubble");

//        bubble.SetActive(false);
//    }

//    // Update is called once per frame

//    private void OnSoapClicked()
//    {
//        gameObject.GetComponent<SkinnedMeshRenderer>().material = soapMat;
//        bubble.SetActive(true);
//    }
//    private void OnHandTowelPressed()
//    {
//        gameObject.GetComponent<SkinnedMeshRenderer>().material = GloveMaterial;

//    }
//    private void OnGlovesBoxClicked()
//    {
//        gameObject.GetComponent<SkinnedMeshRenderer>().material = glovesMat;
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("water"))
//        {
//            gameObject.GetComponent<SkinnedMeshRenderer>().material = waterMat;
//            bubble.SetActive(false);
//        }
//    }
//}
