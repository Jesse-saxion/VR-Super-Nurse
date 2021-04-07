// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class PointerVR : MonoBehaviour
// {
//     public float DefaultLength = 5.0f;
//     public GameObject Dot;
//     public VRInputModule InputModule;

//     private LineRenderer lineRenderer = null;

//     // Start is called before the first frame update
//     void Awake()
//     {
//         lineRenderer = GetComponent<LineRenderer>();

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         UpdateLine();
//     }
//     void UpdateLine()
//     {
//         //Use default or distance
//         PointerEventData data = InputModule.GetData();
//         float targetLength = InputModule.GetData().pointerCurrentRaycast.distance == 0 ? DefaultLength : data.pointerCurrentRaycast.distance;

//         //Raycast
//         RaycastHit hit = CreateRaycast(targetLength);

//         //Default
//         Vector3 endPosition = transform.position + (transform.forward * targetLength);

//         //Or base on hit
//         if (hit.collider != null)
//             endPosition = hit.point;

//         // Set position of the dot
//         Dot.transform.position = endPosition;


//         // Set linerenderer
//         lineRenderer.SetPosition(0, transform.position);
//         lineRenderer.SetPosition(1, endPosition);

//     }

//     private RaycastHit CreateRaycast(float length)
//     {
//         RaycastHit hit;
//         Ray ray = new Ray(transform.position, transform.forward);
//         Physics.Raycast(ray, out hit, DefaultLength);
//         return hit;
//     }
// }
