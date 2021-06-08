using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerScreen : MonoBehaviour
{

    public Animator Screen;
    // Start is called before the first frame update
    void Start()
    {
        Screen.GetComponent<Animator>();
        Screen.SetTrigger("QuestionAsked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
