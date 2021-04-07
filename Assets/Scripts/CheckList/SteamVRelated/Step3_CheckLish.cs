// using OculusSampleFramework;
// using System.Collections;
// using System.Collections.Generic;

// using UnityEngine;
// using Valve.VR.InteractionSystem;


// public class Step3_CheckLish : MonoBehaviour
// {

//     [SerializeField] private AudioClip A33;
//     //AudioSource audio;
//     public float Volume;
//     public bool isFirstPickup = false;


//     public List<Click> objects;
//     private int index = 0;
//     [SerializeField] private AudioClip Firstcorrect;
  
//     [SerializeField] private AudioClip End;
//     AudioSource audio;
//     public bool isFirstCorrect = false;
//     public bool isdisable = false;
//     public bool isCollision = false;




//     // Start is called before the first frame update
//     private void Start()
//     {
//         audio = GetComponent<AudioSource>();
//         Destroy(GetComponent<Throwable>());
        

//     }


//     private void OnCollisionEnter(Collision collision)
//     {
        

//         if (collision.collider.CompareTag("correct"))
//         {
//             if (isCollision == false)
//             {
//                 objects[index].enabled = false;
//                 index++;
//                 collision.gameObject.AddComponent<IgnoreHovering>();
//                 if (collision.gameObject.GetComponent<IgnoreHovering>().onlyIgnoreHand = null)
//                 {
//                     Debug.Log("Handsisnull");
//                 }
//                 collision.gameObject.GetComponent<BoxCollider>().enabled = false;

//                 if (isFirstCorrect == false)
//                 {
//                     if (audio.isPlaying)
//                     { audio.Stop(); }

//                     audio.PlayOneShot(Firstcorrect);
//                     isFirstCorrect = true;



//                 }

//                 if (index <= objects.Count - 1)
//                 {


//                     objects[index].enabled = true;





//                 }
//                 else
//                 {
//                     if (audio.isPlaying)
//                     { audio.Stop(); }
//                     ;
//                     audio.PlayOneShot(End);
//                     gameObject.AddComponent<Throwable>();
                   
                    
//                     isCollision = true;
//                 }






//             }

//         }
        

//     }

//         public void OnObjectClicked()
//          {

//             if (index <= objects.Count - 1)
//             {
//                 if (isFirstPickup == false)
//                 {
//                     audio.PlayOneShot(A33);
//                     isFirstPickup = true;

//                 }


//             }

//         }







//     public void DisenableBoxCollider()
// {
//     // Disable hovering by adding IgnoreHover components to the GameObject's with Colliders
//     foreach (Collider coll in objects[index].GetComponents<BoxCollider>())
//     {
//         coll.gameObject.GetComponent<BoxCollider>().enabled = false;

//     }
// }

//     //public void EnableBoxCollider()
//     //{
//     //    // Disable hovering by adding IgnoreHover components to the GameObject's with Colliders
//     //    foreach (Collider coll in objects[index].GetComponents<BoxCollider>())
//     //    {
//     //        coll.gameObject.GetComponent<BoxCollider>().enabled = true;

//     //    }
//     //}
//     //public void EnableHovering()
//     //{
//     //    foreach (IgnoreHovering ignoreHovering in objects[index].GetComponents<IgnoreHovering>())
//     //    {
//     //        Destroy(ignoreHovering);

//     //    }


//     //}

//     //public void DisableHovering()
//     //{
//     //    // Disable hovering by adding IgnoreHover components to the GameObject's with Colliders
//     //    foreach (Collider coll in objects[index].GetComponents<BoxCollider>())
//     //    {
//     //        coll.gameObject.AddComponent<IgnoreHovering>();
//     //    }

//     //}




//     //public void DestroyClick()
//     //{
//     //    foreach (Click clicks in objects[index].GetComponents<Click>())
//     //    {
//     //        Destroy(clicks);

//     //    }


//     //}
//     //}
// }



