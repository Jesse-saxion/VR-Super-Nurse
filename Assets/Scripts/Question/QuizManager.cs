using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField]
    private List<Question> questions;
    private Question selectedQuestion;
    private AudioSource sound;


    [SerializeField] private AudioClip rightans;
    [SerializeField] private AudioClip wrongtans;

    [SerializeField] private GameObject Popup;

    private LastQuestion lastQuestion;
    public LastQuestion lastquestion { get { return lastQuestion; } }
    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();
        sound = GetComponent<AudioSource>();
       
    }

    private void SelectQuestion()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            selectedQuestion = questions[i];
            questions.RemoveAt(i);
          
        }
       

           
        quizUI.SetQuestion(selectedQuestion);

       
    }

    private void Answerthepopup()
    {
        quizUI.gameObject.SetActive(false);
    }

    private void EndQuestion()
    {
       
             if (Popup != null)
             {
            Popup.SetActive(true);
            Invoke("Answerthepopup", 5f);
             }
        else
        {
            Answerthepopup();
        }

       

       
    }


    public  bool  Answer(string answered)
    {
        bool correctAns = false; 

        if(answered == selectedQuestion.correctAns)
        {
            //Yes
            if (questions.Count > 0)
            { 
                Debug.Log("No");
                correctAns = true;
                Invoke("SelectQuestion", 0.1f);
                sound.PlayOneShot(rightans);
            }
           
             else  
             {
                    Debug.Log("Yes");
                    correctAns = true;
                    sound.PlayOneShot(rightans);
                    EndQuestion();
             }
                
             
        }

            
           
           
            
    

        else
        {
           
            sound.PlayOneShot(wrongtans);


        }

       
        return correctAns;
    }


    

    [System.Serializable]
    public class Question
    {
        public string questionInfo;
        public List<string> options;
        public string correctAns;
        public QuestionType questionType;
        public AudioClip questionaudio;
       
        public LastQuestion lastquestion;
    }

    [System.Serializable]
    public enum QuestionType
    {
        TEXT,
        AUDIO,
        
    }

    public enum LastQuestion
    {
        Yes,
        No,

    }

}
