using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBirdSounds : MonoBehaviour {
    [SerializeField]
    private AudioClip flySFX, hitSFX, dieSFX;

    private AudioSource _audioSource;
    private SoundController sController;

    private Coroutine walkSoundRepeateCoroutine;
    private bool firstPlayFly = false;
    private bool lastPlayFly = false;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        sController = SoundController.Instanse;
        if (sController != null)
        {
            sController.Sounds.Add(_audioSource);
            sController.ReSetVolumes();
        }

        PlayFlySFX();
    }

    public void DisableWalkSound()
    {
        if (walkSoundRepeateCoroutine != null)
        {
            StopCoroutine(walkSoundRepeateCoroutine);
        }
    }

    public void PlayFlySFX()
    {
        if (flySFX == null)
        {
            return;
        }
        if (ScreenRange())
        {
            if (!firstPlayFly)
            {
                _audioSource.PlayOneShot(flySFX);
                firstPlayFly = true;
            }
            walkSoundRepeateCoroutine = this.CallActionAfterDelayWithCoroutine(flySFX.length, PlayFlySFX);

        }
        else
        {
            if (!firstPlayFly)
            {
                walkSoundRepeateCoroutine = this.CallActionAfterDelayWithCoroutine(flySFX.length, PlayFlySFX);
            }
            else
            {
                if (!lastPlayFly)
                {
                    lastPlayFly = true;
                    _audioSource.PlayOneShot(flySFX);
                }
            }
        }
    }
        
    private bool ScreenRange()
    {
        Vector3 view = Helpers.getMainCamera.WorldToViewportPoint(transform.position);

        return view.x >= 0 && view.x <= 1 && view.y >= 0 && view.y <= 1;
        
    }

    public void PlayDamageSFX()
    {
        if (hitSFX == null)
            return;
        SoundController.Instanse.PlayMultiSound(_audioSource, hitSFX, 1, 2);
    }

    public void PlayDeathSFX()
    {
        if (dieSFX == null)
            return;

        SoundController.Instanse.PlayMultiSound(_audioSource, dieSFX, 1);

        if (sController != null)
            sController.Sounds.Remove(_audioSource);
    }
}
