// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using static QuizManager;


// public class QuizUI : MonoBehaviour
// {
//     [SerializeField] private QuizManager quizManager;
//     [SerializeField] private TMP_Text questionText;
//     [SerializeField] private List<Button> options;
//     [SerializeField] private Color correct, wrong, normal;

    
//     [SerializeField] private AudioSource questionAudio;

//     private Question question;
//     private bool answered;
//     private float audioLenght;

//     //Start is called before the first frame update
//     void Start()
//     {
//         for (int i = 0; i < options.Count; i++)
//         {
//             Button localBtn = options[i];
//             localBtn.onClick.AddListener(() => OnClick(localBtn));
//         }


//     }

//     public void SetQuestion(Question question)
//     {
//         this.question = question;

//         switch (question.questionType)
//         {
//             case QuestionType.TEXT:
//                 questionAudio.transform.gameObject.SetActive(false);
//                 break;
//             case QuestionType.AUDIO:
//                 questionAudio.transform.gameObject.SetActive(true);
//                 audioLenght = question.questionaudio.length;
//                 StartCoroutine(PlayAudio());
//                 break;

//         }
        

//         questionText.text = question.questionInfo;
//         List<string> ansList = ShuffleList.ShuffleListItems<string>(question.options);

//         for (int i = 0; i < options.Count; i++)
//         {
//             options[i].GetComponentInChildren<TextMeshProUGUI>().text = ansList[i];
//             options[i].name = ansList[i];
//             options[i].image.color = normal;
//         }
//         answered = false;

//     }

//   IEnumerator PlayAudio()
//     {
//         if (question.questionType == QuestionType.AUDIO)
//         {
//             questionAudio.PlayOneShot(question.questionaudio);
//             yield return new WaitForSeconds(audioLenght + 0.5f);
//            // StartCoroutine(PlayAudio());
//         }
//         else
//         {
//             StopCoroutine(PlayAudio());
//             yield return null;

//         }
//     }


//     private void OnClick(Button btn)
//     {
//         if (!answered)
//         {
//             answered = true;
//             bool a = quizManager.Answer(btn.name);

//             if (a)
//             {
                
//                     btn.image.color = correct;
//                    // Questioncanvas.SetActive(true);

               
//                     btn.image.color = correct;

                
//             }

//             else
//             {
//                 answered = false;
//                 // btn.image.color = wrong;
//             }
//         }
//     }

    

// }
