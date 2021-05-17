using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5_Question : MonoBehaviour
{
    public GameObject D53;
    
    public void TriggerQuestionOn()
    {
        D53.SetActive(true);
        D53.gameObject.GetComponent<Animator>().Play("D53");
    }

    public void InvokeDestroy()
    {
        Invoke("DestroyStep2", 3f);
    }

    private void DestroyStep2()
    {
        Destroy(GameObject.Find("B2.1"));
        Destroy(GameObject.Find("D2.1"));
    }
}
