
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TubeInsertion : MonoBehaviour //DEPRICATED
{    
    public bool CorrectDirection = false;
    public List<AudioClip> CoughingClips;
    public List<AudioClip> SwallowingClips;
    public List<AudioClip> GaggingClips;
    public GameObject Tube;
    public List<GameObject> Points;
    public LineRenderer TubeLine;
    public GameObject RestartCanvas;
    public GameObject ContinueCanvas;
    public AudioSource AudSource;
    public Animator Animator;
    public SkinnedMeshRenderer PatientMesh;
    public float TubeSpeed;
    public GameObject Movable;
    public GameObject MeasuringCanvas;
    private bool DirectionChosen = false;
    private int delay = 60;
    private Color col;
    private bool insertTube = false;
    private bool returnToNormal = false;
    // Start is called before the first frame update
    void Start()
    {
        col = PatientMesh.material.GetColor("_Color");
        //enableTube(false);
    }

    private void Update()
    {  
           
        if (insertTube)
        {
            TubeAnimation();
        }
        if (returnToNormal)
        {
            if (col.g < 1)
            {
                col = new Color(col.r,
                Mathf.Lerp(col.g, 1, 0.005f),
                Mathf.Lerp(col.b, 1, 0.005f));
                PatientMesh.material.SetColor("_Color", col);
            }
            else
            {
                returnToNormal = false;
            }
        }

        //debuging
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayCoughAnimationSound();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlaySwallowAnimationSound();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayGagAnimationSound();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            enableTube(true);
        }
    }
    public void StartTubeInsertion()
    {
        MeasuringCanvas.SetActive(false);
        insertTube = true;
        TubeLine.positionCount = 3;
        TubeLine.SetPosition(0, Points[0].transform.position);
        TubeLine.SetPosition(1, Points[1].transform.position);
    }
    void TubeAnimation()
    {
        Movable.transform.position = Vector3.MoveTowards(Movable.transform.position,Points[2].transform.position,TubeSpeed);
        TubeLine.SetPosition(2, Movable.transform.position);
        if (Movable.transform.position == Points[2].transform.position)
        {
            TimeToDecide();
            if (CorrectDirection)
            {
                ContinueCanvas.SetActive(true);
            }
            else
            {
                RestartCanvas.SetActive(true);
            }
        }
    }
    /// <summary>
    /// Time to decide whenever tube goes in correct or wrong direction
    /// </summary>
    void TimeToDecide()
    {
        if (!DirectionChosen)
        {
            DirectionChosen = true;
            CorrectDirection = Random.Range(0, 2) == 1 ? true : false;
        }
        if (!CorrectDirection)
        {
            Cough();
        }
    }
    public void OnTubeRespawn()
    {
        if (DirectionChosen&& col.g < 1)
        {
            CorrectDirection = true;
        }
        TubeLine.positionCount = 0;
        Movable.transform.position = Points[1].transform.position;
        StartTubeInsertion();
        returnToNormal = true;
    }
    public void Correct()
    {
        CorrectDirection = true;
        DirectionChosen = true;
    }
    public void Incorrect()
    {
        CorrectDirection = false;
        DirectionChosen = true;
    }

    void Cough()
    {
        col = new Color(col.r,
              Mathf.Lerp(col.g, 0.85f, 1f),
              Mathf.Lerp(col.b, 0.85f, 1f));
        PatientMesh.material.SetColor("_Color", col);


        if (!AudSource.isPlaying)
        {
            if (delay < 0)
            {
                PlayCoughAnimationSound();
                delay = Random.Range(50, 100);
            }
            else
            {
                delay -= 1;
            }
        }
    }

    void PlayCoughAnimationSound()
    {
        AudSource.clip = CoughingClips[Random.Range(0, CoughingClips.Count)];
        AudSource.Play();
        Animator.Play("Coughing");        
    }

    void PlaySwallowAnimationSound()
    {
        AudSource.clip = SwallowingClips[Random.Range(0, SwallowingClips.Count)];
        AudSource.Play();
        Animator.Play("Swallowing");
    }

    void PlayGagAnimationSound()
    {
        AudSource.clip = GaggingClips[Random.Range(0, GaggingClips.Count)];
        AudSource.Play();
        Animator.Play("Gagging");
    }

    void enableTube(bool enable)
    {
        Tube.SetActive(enable);
    }
}
