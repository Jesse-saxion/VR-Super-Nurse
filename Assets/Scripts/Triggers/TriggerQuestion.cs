using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestion : MonoBehaviour
{
    [SerializeField] private Animator CanvasQuestion;
    [SerializeField] private GameObject Question;

    private void Awake()
    {
        CanvasQuestion = CanvasQuestion.GetComponent<Animator>();
    }

    void QuestionOn()
    {

        CanvasQuestion.Play("QuestionCanvasOn");
        Question.SetActive(true);
    }
}
