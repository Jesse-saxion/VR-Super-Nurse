using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventUnpackaging : MonoBehaviour
{
    // Used to prevent unpacking it by accident on the tool table.
    public bool isReadyToUnpack;
    public GameObject TubeMeasurement;
    public GameObject NasogastricTubing;
    [SerializeField] private AudioClip unwrapSound;
    AudioSource audio;
    public float volume;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void setReadyToUnpack()
    {
        isReadyToUnpack = true;
    }

    public void unpackTube()
    {
        if (isReadyToUnpack)
        {
            TubeMeasurement.SetActive(true);
            audio.PlayOneShot(unwrapSound, volume);
            NasogastricTubing.SetActive(false);
        }
    }
}
