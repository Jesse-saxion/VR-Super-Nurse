using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class Measuring : MonoBehaviour
{
    public List<GameObject> MeasuringCheckPoints = new List<GameObject>();
    public List<GameObject> IncorrectCheckPoints = new List<GameObject>();
    //public GameObject ErrorCanvas;
    //public GameObject EndCanvas;
    //public GameObject RestartCanvas;
    public GameObject MeasuringCanvas;
    [SerializeField]private GameObject Tube;
    public Material InputMaterial;
    public Material ErrorMaterial;
    public Text text;
    public LineRenderer line;


    [SerializeField] private AudioClip sucess;
    [SerializeField] private AudioClip wrong;
    AudioSource audio;

    private int index = 0;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ClickedOnCheckPoint(GameObject obj)
    {
        if (obj == MeasuringCheckPoints[index])
        {
            switch (index)
            {
                case 1:
                    MeasuringCanvas.SetActive(true);
                    audio.PlayOneShot(sucess);
                    text.text += "10cm";
                    break;
                case 2:
                    text.text += "+40cm";
                    audio.PlayOneShot(sucess);
                    break;
            }

            if (line.GetPosition(0).x != 0)
            {
                line.positionCount++;
            }
            line.SetPosition(index, MeasuringCheckPoints[index].transform.position);
            index++;
            if (index >= MeasuringCheckPoints.Count)
            {
                audio.PlayOneShot(sucess);
                Tube.SetActive(true);
                gameObject.SetActive(false);
                line.gameObject.SetActive(false);
                //EndCanvas.SetActive(true);
            }
        }
        else if (obj == IncorrectCheckPoints[index])
        {
            audio.PlayOneShot(wrong);
           
        }

    }
    //public void onButtonClicked()
    //{
    //    //RestartCanvas.SetActive(false);
    //    index = 0;
    //    line.positionCount = 0;
    //    line.positionCount = 1;
    //    text.text = "";
    //  //  ChangeMaterial(InputMaterial);
    //   // ErrorCanvas.SetActive(false);
    //}
    //private void ChangeMaterial(Material mat)
    //{
    //    foreach (GameObject checkPoint in MeasuringCheckPoints)
    //    {
    //        checkPoint.GetComponent<Renderer>().material = mat;
    //    }
    //    foreach (GameObject checkPoint in IncorrectCheckPoints)
    //    {
    //        checkPoint.GetComponent<Renderer>().material = mat;
    //    }
    //}
}
