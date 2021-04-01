using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] private Animator QuestionOff;
    


    // Start is called before the first frame update
    void Start()
    {
        QuestionOff = QuestionOff.GetComponent<Animator>();
    }

    
    void PlayAnimationCanVas()
    {
        QuestionOff.Play("QuestionCanvasOff");
    }
}
