using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimation : MonoBehaviour
{
    [SerializeField]
    AudioSource sound;
    public void PlaySound()
    {
        if (sound != null)
            sound.Play();
    }
}
