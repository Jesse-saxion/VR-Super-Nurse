using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudeSpawn : MonoBehaviour
{
    public GameObject TubePrefab;
    GameObject currentTube;
    //need to store each children because steam VR is moving them in hierarchy, 
    //so you can't just delete current tube, parts which you touched with hand will still be there
    Transform[] chlidrensOfTube;
   
   
    void Start()
    {
        SpawnTube();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTube()
    {
        
        if(currentTube != null)
        {
            foreach(Transform child in chlidrensOfTube)
            {
                Destroy(child.gameObject);
            }
            Destroy(currentTube);
        }
        currentTube = Instantiate(TubePrefab, gameObject.transform.position, gameObject.transform.rotation);
        chlidrensOfTube = currentTube.GetComponentsInChildren<Transform>();
    }
}
