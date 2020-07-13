using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip footstep1;
    public AudioClip footstep2;

    public bool alternateStep;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Footstep()
    {
        if (alternateStep)
        {
            audio.PlayOneShot(footstep1);
        } else
        {
            audio.PlayOneShot(footstep2);
        }

        alternateStep = !alternateStep;
    }
}
