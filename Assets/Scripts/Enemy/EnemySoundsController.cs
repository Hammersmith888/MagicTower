using UnityEngine;

public class EnemySoundsController : MonoBehaviour
{
    public AudioClip walkSFX;
    public AudioClip walkSFX2;
    public AudioClip wakeUpSFX;

    public AudioClip damageSFX;
    public AudioClip damageSFX2;

    public AudioClip[] damageBoss;
    public AudioClip deathBoss;

    public AudioClip deathSFX;
    public AudioClip deathSFX2;

    public AudioClip attackSFX;
    public AudioClip attackSFX2;

    public AudioClip jumpSFX;

    private AudioSource _audioSource;
    private SoundController sController;

    private Coroutine walkSoundRepeateCoroutine;
    private bool walkSoundIsDisabled = false;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        sController = SoundController.Instanse;
        if (sController != null)
        {
           
            sController.Sounds.Add(_audioSource);
            sController.ReSetVolumes();
        }
        PlayWakeUPSFX();
        PlayWalkSFX();
        _audioSource.outputAudioMixerGroup = SoundController.Instanse.sfxMixerGroup;
        _audioSource.volume = Random.Range(0.7f, 1.0f);
    }

    public void DisableWalkSound()
    {
        walkSoundIsDisabled = true;
        if (walkSoundRepeateCoroutine != null)
        {
            StopCoroutine(walkSoundRepeateCoroutine);
        }
    }

    public void PlayWakeUPSFX()
    {
        if (wakeUpSFX == null)
        {
            return;
        }
        SoundController.Instanse.PlayMultiSound(_audioSource, wakeUpSFX, 1);
    }

    public void PlayWalkSFX()
    {
        if (walkSoundIsDisabled)
        {
            return;
        }
        AudioClip clip = SoundController.GetRandomClip(walkSFX, walkSFX2);
        if (clip == null)
        {
            return;
        }
        // Eugene Disable walk sound after one play 
        walkSoundIsDisabled = true;
        
        SoundController.Instanse.PlayMultiSound(_audioSource, clip, 1);
        walkSoundRepeateCoroutine = this.CallActionAfterDelayWithCoroutine(5f, PlayWalkSFX);
    }

    public void PlayDamageSFX()
    {
        
        AudioClip clip = SoundController.GetRandomClip(damageSFX, damageSFX2);
        if (clip == null)
        {
            return;
        }

        int randomPlay = Random.Range(0, 10);
            if(randomPlay>5)
        SoundController.Instanse.PlayMultiSound(_audioSource, clip, 2, 3);
    } 
    
    // type - 0 goul
    // type - 1 king
    public void PlayDamageBoss()
    {
        int r = Random.Range(0,damageBoss.Length);
        AudioClip clip = damageBoss[r];
        if (clip == null)
            return;
        SoundController.Instanse.PlayMultiSound(_audioSource, clip, 1, 3);
    }

    public void PlayDeathBoss()
    {
        AudioClip clip = deathBoss;
        if (clip == null)
            return;
        //SoundController.Instanse.PlayMultiSound(_audioSource, clip, 1, 3);
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayDeathSFX()
    {
        AudioClip clip = SoundController.GetRandomClip(deathSFX, deathSFX2);
        if (clip == null)
        {
            return;
        }

        SoundController.Instanse.PlayMultiSound(_audioSource, clip, 1, 3);

        if (sController != null)
        {
            sController.Sounds.Remove(_audioSource);
        }
    }

    public void PlayAttackSFX()
    {
        AudioClip clip = SoundController.GetRandomClip(attackSFX, attackSFX2);
       
        if (clip == null)
        {
            return;
        }
        SoundController.Instanse.PlayMultiSound(_audioSource, clip, 1, 2);
        //_audioSource.clip = clip;
        //_audioSource.volume = UnityEngine.Random.Range(0.7f, 1f);
        //_audioSource.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
        //_audioSource.Play();
    }

    public void PlayJumpSFX()
    {
        if (jumpSFX == null)
        {
            return;
        }
        SoundController.Instanse.PlayMultiSound(_audioSource, jumpSFX, 1);
    }
}