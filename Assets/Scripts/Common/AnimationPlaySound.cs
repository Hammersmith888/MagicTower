using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlaySound : MonoBehaviour
{
    public AudioSource _audio;
    public AudioSource _audio1;
    public AudioSource _audio2;

    public void Play()
    {
        _audio?.Play();
    }
    public void Play1()
    {
        _audio1?.Play();
    }
    public void Play2()
    {
        _audio2?.Play();
    }
}
