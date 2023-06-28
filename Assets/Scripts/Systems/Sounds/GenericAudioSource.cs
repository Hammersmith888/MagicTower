
using System;
using UnityEngine;
using UnityEngine.Audio;

public class GenericAudioSource : MonoBehaviour, IPoolObject
{
    [SerializeField]
    private AudioSource audioSource;

    public bool canBeUsed
    {
        get
        {
            GameObject go = SoundController.Instanse.GenericAudioSourc;
            return !go.activeSelf;
        }
    }

    public void Init()
    {
        this.GetComponentIfNull(ref audioSource);
        audioSource.clip = null;
        gameObject.SetActive(false);
    }

    public void Play(AudioClip audioClip, float delay, AudioMixerGroup m)
    {
        audioSource = SoundController.Instanse.GenericAudioSourc.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = m;
        SoundController.Instanse.GenericAudioSourc.gameObject.SetActive(true);
        //gameObject.SetActive(true);
        audioSource.PlayDelayed(delay);
    }
    public void Stop()
    {
        audioSource = SoundController.Instanse.GenericAudioSourc.GetComponent<AudioSource>();
        audioSource.Stop();
    }

private void LateUpdate()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = null;
            gameObject.SetActive(false);
        }
    }
}