using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestion : MonoBehaviour
{
    [SerializeField] private Animator CanvasQuestion;
    [SerializeField] private GameObject D21;
    //[SerializeField] private GameObject TutorialDepointer;
    // Start is called before the first frame update

    private void Awake()

    {
        CanvasQuestion = CanvasQuestion.GetComponent<Animator>();
        
    }
   
    void QuestionOn()
    {
        
        CanvasQuestion.Play("QuestionCanvasOn");
        D21.SetActive(true);
        //TutorialDepointer.SetActive(true);

        //Animation canvas on
    }
}
