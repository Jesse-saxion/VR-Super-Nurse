using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimationCall : MonoBehaviour
{
    public Animator anim;
    public void PlayHandAnim()
    {
        anim.Play("Rise hand");
    }
}
