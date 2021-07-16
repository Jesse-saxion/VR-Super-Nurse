using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayReactions : MonoBehaviour
{
    [Header("Sounds")]
    public List<AudioClip> CoughingClips;
    public List<AudioClip> SwallowingClips;
    public List<AudioClip> GaggingClips;

    [Header("References")]
    public AudioSource AudSource;
    public Animator Animator;
    public GameObject cup;
    public GameObject straw;
    Step8MoveTube tubeAnimation;

    [Header("Parameters")]
    [Tooltip("Delay in seconds before the patient swallows again")]
    public float swallowingTiming = 1f;
    [Tooltip("Time window in seconds when the player can safely move the tube starting when the patient swallows")]
    public float timeWindow = 0.5f;
    [Tooltip("Chance of the tube going into the lungs when NOT swallowing")]
    [Range(0f, 100f)]
    public int chanceNotSwallowing = 50;
    [Tooltip("Chance of the tube going into the lungs when swallowing")]
    [Range(0f, 100f)]
    public int chanceSwallowing = 10;

    bool swallowing;
    bool tubeInLungs;
    bool forceLungs;
    float timeBeforeSwallow;

    void Start()
    {
        tubeAnimation = GetComponent<Step8MoveTube>();
        Debug.Log("kut ding");
        StartSwallowing();
    }

    void Update()
    {
        if (swallowing)
        {
            timeBeforeSwallow += Time.deltaTime;

            if (timeBeforeSwallow >= swallowingTiming)
            {
                PlaySwallowAnimationSound();
                timeBeforeSwallow = 0;
            }
        }

        //if (Input.GetKey(KeyCode.F)) //force the tube to go into lungs function for teachers 
        //{
        //    forceLungs = true;
        //}

        ////debuging
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    PlayCoughAnimationSound();
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    PlaySwallowAnimationSound();
        //}

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    PlayGagAnimationSound();
        //}
    }

    void GoInLungs()
    {
        if (forceLungs)
        {
            tubeInLungs = true;
            return;
        }

        if (timeBeforeSwallow >= timeWindow && !tubeInLungs) //time the insertion with the swallowing 
        {
            if (Random.Range(0f, 100f) <= chanceNotSwallowing) //50% chance of the tube going into lungs 
            {
                tubeInLungs = true;
            }
        }
        else if (Random.Range(0f, 100f) <= chanceSwallowing) //10% chance of the tube going into lungs  
        {
            tubeInLungs = true;
        }
    }

    void GoOutLungs()
    {
        if (tubeInLungs)
        {
            tubeInLungs = false;
            forceLungs = false;
        }
    }

    void Cough()
    {
        if (tubeInLungs && tubeAnimation.GetTubeMovement() >= 0f) //If tube is in lungs and is moving forward
        {
            PlayCoughAnimationSound();
            timeBeforeSwallow = 0f;
        }
    }

    void Gag()
    {
        if (timeBeforeSwallow >= timeWindow)
        {
            PlayGagAnimationSound();
            timeBeforeSwallow = 0f;
        }
    }

    public void StartSwallowing()
    {
        if (swallowing)
            return;

        swallowing = true;
        cup.SetActive(true);
        straw.SetActive(true);
        Animator.SetInteger("FacialExpression", 5);
    }

    void StopSwallowing()
    {
        swallowing = false;
        Animator.SetInteger("FacialExpression", 0);
        cup.SetActive(false);
        straw.SetActive(false);
    }

    void PlayCoughAnimationSound()
    {
        AudSource.clip = CoughingClips[Random.Range(0, CoughingClips.Count)];
        if (!AudSource.isPlaying)
        {
            AudSource.Play();
        }
        Animator.Play("Coughing");

    }

    void PlaySwallowAnimationSound()
    {
        AudSource.clip = SwallowingClips[Random.Range(0, SwallowingClips.Count)];
        if (!AudSource.isPlaying)
        {
            AudSource.Play();
        }
        Animator.Play("Swallowing");

        //Sip water
        Transform water = cup.transform.GetChild(0);
        if (water.localPosition.z > 0f)
        {
            water.localPosition -= new Vector3(0, 0, 0.00005f);
        }
    }

    void PlayGagAnimationSound()
    {
        AudSource.clip = GaggingClips[Random.Range(0, GaggingClips.Count)];
        if (!AudSource.isPlaying)
        {
            AudSource.Play();
        }
        Animator.Play("Gagging");
    }
}
