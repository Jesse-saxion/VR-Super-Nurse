using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField]
    private List<QuestionHandler> questions;

    public void AnswerQuestion(int index)
    {
        // Check for the active questions in the list and try to answer the question
        foreach (QuestionHandler item in questions)
        {
            if (item.gameObject.activeInHierarchy)
            {
                item.CheckAnswer(index);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
