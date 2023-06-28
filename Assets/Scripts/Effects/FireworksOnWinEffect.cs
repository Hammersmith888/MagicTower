
using System.Collections;
using UnityEngine;

public class FireworksOnWinEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem Effect;
    [SerializeField]
    private ParticleSystem EffectExplosion;

    private static FireworksOnWinEffect Current;

    [SerializeField]
    AudioClip[] audioClips;

    

    float pp;

    private void Awake()
    {
        Current = this;
        Effect.gameObject.SetActive(false);
    }

    public static void Play(float seconds = 0)
    {
        if (Current != null)
        {
            Current.Effect.gameObject.SetActive(true);
            var emissionModule = Current.Effect.emission;
            emissionModule.enabled = true;
            if (seconds > 0)
            {
                Current.StopAllCoroutines();
                Current.StartCoroutine(Current.StopEffectAfterDelay(seconds));
            }
        }
    }

    public static void PlayLimited(float seconds = 0)
    {
        if (Current != null)
        {
            Current.Effect.gameObject.SetActive(true);
            var emissionModule = Current.Effect.emission;
            emissionModule.enabled = true;
            if (seconds > 0)
            {
                Current.StopAllCoroutines();
                Current.StartCoroutine(Current.StopEffectAfterDelay(seconds));
            }
            ParticleSystem.MainModule newMain = Current.Effect.main;
            newMain.maxParticles = 2;
        }
    }

    public static void Stop()
    {
        if (Current != null)
        {
            Current.Effect.gameObject.SetActive(true);
            var emissionModule = Current.Effect.emission;
            emissionModule.enabled = false;
        }
    }

    private IEnumerator StopEffectAfterDelay(float delay)
    {
        float timer = 0f;
        while (timer < delay)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        Stop();
    }

    private void Update()
    {
        //pp = EffectExplosion.particleCount;
        //if (pp >= 124)
        //{
        //    GameObject o = new GameObject();
        //    o.transform.SetParent(transform);
        //    var a = o.AddComponent<AudioSource>();
        //    a.clip = audioClips[0];
        //    a.playOnAwake = false;
        //    a.Play();
        //}
    }

}
