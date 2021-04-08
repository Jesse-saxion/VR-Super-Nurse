using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
public struct CurtainsParts
{
    public GameObject gameObject;
    public GameObject target;
    public bool end;
    public GameObject startPos;
}
public class Curtains : MonoBehaviour
{
   
    public GameObject Prefab;
    public GameObject CheckPoint;
    public GameObject EndPoint;
    public GameObject SpawnPoint;
    public float SpawnDistance;
    public float Speed;
    public float RotationSpeed;
    private CurtainsParts item;
    private bool movingFinished = false;
    private bool rotationFinished = false;
  
    private List<CurtainsParts> parts = new List<CurtainsParts>();
    private List<Vector3> endRotations = new List<Vector3>();
    private float counter = 0;
    private bool start = false;
    // Start is called before the first frame update

    public void CloseCurtains()
    {
        item.gameObject = GameObject.Instantiate(Prefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        item.gameObject.transform.localScale = new Vector3(2, 2, 2);
        item.target = CheckPoint;
        item.end = false;
        item.startPos = SpawnPoint;
        parts.Add(item);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (Vector3.Distance(SpawnPoint.transform.position, parts[parts.Count - 1].gameObject.transform.position) > SpawnDistance)
            {
                item.gameObject = GameObject.Instantiate(Prefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                item.gameObject.transform.localScale = new Vector3(2, 2, 2);
                item.target = CheckPoint;
                item.end = false;
                parts.Add(item);
            }
            if (!movingFinished)
            {

                MoveParts();
            }
            else
            {
                if (!rotationFinished)
                {
                    RotateParts();
                }
            }
        }
    }

    void MoveParts()
    {
        for (int i = 0; i< parts.Count;i++)
        {
            parts[i].gameObject.transform.position = Vector3.MoveTowards(parts[i].gameObject.transform.position, parts[i].target.transform.position, Speed);
            if (Vector3.Distance(parts[i].target.transform.position, parts[i].gameObject.transform.position) < SpawnDistance/5)
            {
                parts[i].gameObject.transform.position = parts[i].target.transform.position;
            }
            if (parts[i].gameObject.transform.position == parts[i].target.transform.position)
            {
                if (parts[i].target.transform.position == CheckPoint.transform.position)
                {
                    parts[i].gameObject.transform.Rotate(new Vector3(0,0,90));
                    item.gameObject = parts[i].gameObject;
                    item.target = EndPoint;
                    item.startPos = CheckPoint;
                    parts[i] = item;
                }
                else
                {
                    movingFinished = true;
                    foreach(CurtainsParts part in parts)
                    {
                        endRotations.Add(new Vector3(part.gameObject.transform.rotation.x, part.gameObject.transform.rotation.y + 90, part.gameObject.transform.rotation.z));
                    }
                        
                }
            }
        }
    }
    void RotateParts()
    {
       for(int i = 0;i<parts.Count-1;i++)
        {
            parts[i].gameObject.transform.Rotate(0, 0,90);

            rotationFinished = true;
        }
    }

}
