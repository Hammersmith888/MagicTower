using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    private const int DUNGEON_LOCATION = 16;
    private const int POUTION_LOCATION = 46;
    private const int LAVA_LOCATION = 71;
    public static AudioClip GetRandomClip(params AudioClip[] clips)
    {
        if (clips.Length == 1)
        {
            return clips[0];
        }

        int notNullIndex = 0;
        int notNullCount = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
            {
                continue;
            }
            notNullIndex = i;
            notNullCount++;
        }

        if (notNullCount == clips.Length)
        {
            int random = Random.Range(0, clips.Length - 1);
            return clips[random];
        }

        return clips[notNullIndex];
    }

    [System.Serializable]
    private class MusicByLevelInfo
    {
        public int levelMinToStartPlayMusic;
        public int levelMaxToStartPlayMusic;
        public AudioSource audioSource;
    }

    private const string ResourcesFolderFormat = "Resources/{0}";

    [SerializeField]
    private GameObject GenericAudioSourceTemplate;

    public GameObject GenericAudioSourc;
    private ObjectsPoolMono<GenericAudioSource> GenericAudioSourcePool;

    #region VARIABLES

    public AudioMixer sfxMixer;
    public AudioMixerGroup sfxMixerGroup;

    [SerializeField]
    private MusicByLevelInfo[] GameplayMusic;

    [Space(10)]
    public AudioSource menuSFX;
    public AudioSource gameSFX;
    public AudioSource mapSFX;
    public AudioSource shopSFX;
    public AudioSource coinsScore;
    public AudioSource upgradeSound;

    public AudioSource ambientSFX;
    [Space(10f)]
    public AudioSource fireBallSFX;
    public AudioSource lightningSFX;
    public AudioSource iceStrikeSFX;
    public AudioSource stoneBallSFX;
    public AudioSource fireWallSFX;
    public AudioSource chainLightningSFX;
    public AudioSource iceBreathSFX;
    public AudioSource acidSpraySFX;
    public AudioSource meteorSFX;
    public AudioSource blizzardSFX;
    public AudioSource electricPoolSFX;
    public AudioSource earthBallSFX;
    public AudioSource scrollPowerSFX;
    public AudioSource scrollZombieSFX;

    public AudioSource useBottle2SFX;
    public AudioSource flipMenuSFX;
    public AudioSource showPauseSFX;
    public AudioSource scrollUnlockSFX;
    [Space(10f)]
    public AudioSource ActivateAcidSFX;
    public AudioSource ActivateBarrierSFX;
    public AudioSource ActivateFreezeSFX;
    public AudioSource ActivateMinesFieldSFX;
    public List<AudioSource> Sounds = new List<AudioSource> ();
    public List<AudioSource> Musics = new List<AudioSource> ();

    public AudioSource drobScrollSFX;

    public AudioSource useBottleSFX;
    public AudioSource lowManaSFX;
    public AudioSource addCoinSFX;
    public AudioSource getCoinSFX;
    public AudioSource openChestSFX;
    public AudioSource timeContinueSFX;
    public AudioSource wallImpactSFX;
    public AudioSource dropCoinSFX;
    public AudioSource winLevelSFX;
    public AudioSource defeatLevelSFX;
    public AudioSource mapUnlockScrollSFX;
    public AudioSource mapNextLevelSFX;
    public AudioSource shopBuySFX;
    public AudioSource buyCoinsSFX;
    public AudioSource windowsActivitySFX;
    public AudioSource scrollFlySFX;
	public AudioSource dailySpinOpen;
	public AudioSource dailySpinRotate;
	public AudioSource dailySpinCongrats;
	public AudioSource dailySpinEnd;
	public AudioSource gemInsert;
    public AudioSource slotChange;

    [Header("Spells:")]
    public AudioClip[] meteorClips;
    public AudioClip[] blizzardClips;
    public AudioClip[] electricPoolClips;
    public AudioClip[] earthBallClips;
   

    [Header("Ambient:")]
    public AudioClip[] ambientLevel_1_15;
    public AudioClip[] ambientLevel_16_45;
    public AudioClip[] ambientLevel_46_70;
    public AudioClip[] ambientLevelMore70;

    private bool pauseBetweenGameplayMusicActive;
    private int gameplayTrackId = 0;
    private AudioSource gameplayMusicSource;

    private static SoundController _instance;
    public static SoundController Instanse
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundController>();
            }
            return _instance;
        }
    }
    private UISettingsPanel.SettingsGame sg;

    private float currentMusicVolume;
    private Coroutine changeMusicVolumeCoroutine;
    private Coroutine gameplayMusicCoroutine;
    private int musicGamePlayLoopChance = 0;
    #endregion

    public float timerPlay = 0;

    private void Awake()
    {
        _instance = this;
        GenericAudioSourc = GenericAudioSourceTemplate;
        currentMusicVolume = 1f;
        GenericAudioSourceTemplate.gameObject.SetActive(true);
        //GenericAudioSourcePool = new ObjectsPoolMono<GenericAudioSource>(GenericAudioSourceTemplate, transform, 0);
        GenericAudioSourceTemplate.gameObject.SetActive(false);
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicGamePlayLoopChance = Random.Range(0, 100);

        Musics.Add(menuSFX);
        Musics.Add(gameSFX);
        Musics.Add(mapSFX);
        Musics.Add(shopSFX);
        for (int i = 0; i < GameplayMusic.Length; i++)
        {
            Musics.Add(GameplayMusic[i].audioSource);
        }
        Musics.Add(ambientSFX);

        foreach (AudioSource _scr in Musics)
        {
            _scr.ignoreListenerVolume = true;
        }

        ReSetVolumes();
    }

    public static void PlaySoundFromResources(string filePathInResources, float delay = 0)
    {
        if (Instanse != null)
        {
            Instanse.PlaySoundFromResourcesInternal(filePathInResources, delay);
        }
    }
    public static void StopSoundFromResources()
    {
        if (Instanse != null)
        {
            Instanse.StopSoundFromResourcesInternal();
        }
    }
    private void StopSoundFromResourcesInternal()
    {
        GenericAudioSourc.GetComponent<GenericAudioSource>().Stop();
    }

    private void PlaySoundFromResourcesInternal(string filePathInResources, float delay)
    {
        var audioClip = Resources.Load<AudioClip>(filePathInResources);
        if (audioClip != null)
        {
            GenericAudioSourc.GetComponent<GenericAudioSource>().Play(audioClip, delay, sfxMixerGroup);
            //GenericAudioSourcePool.GetObjectFromPool().Play(audioClip, delay, sfxMixerGroup);
        }
    }

    public void ReSetVolumes()
    {
        UISettingsPanel.SettingsGame settingsGame = PPSerialization.Load(EPrefsKeys.SettingsGame.ToString(), new UISettingsPanel.SettingsGame());
        EnableSoundsVolume(settingsGame.soundOn);
        EnableMusicsVolume(settingsGame.musicOn);
    }

    #region Music
    public void ChangeMusicVolume(float volume, float overTime = 0f, bool useUnscaledTime = false)
    {
        currentMusicVolume = volume;
        var musicSource = GetCurrentlyPlayingMusicSource();
        if (musicSource != null)
        {
            if (overTime > 0f)
            {
                if (changeMusicVolumeCoroutine != null)
                {
                    StopCoroutine(changeMusicVolumeCoroutine);
                }
                changeMusicVolumeCoroutine = StartCoroutine(ChangeMusicVolumeOverTime(musicSource, currentMusicVolume, overTime, useUnscaledTime));
            }
            else
            {
                musicSource.volume = currentMusicVolume;
            }
        }
    }

    

    public void PlayMenuSFX()
    {
        StartCoroutine(FadeIn(menuSFX, 2f));
    }

    public void PlayGameSFX()
    {
        StartCoroutine(FadeIn(gameSFX, 0.01f));
    }

    public void PlayMapSFX()
    {
        StartCoroutine(FadeIn(mapSFX, 2f));
    }

    public void StopMapSFX()
    {
        //StartCoroutine(FadeOut(mapSFX, 2f));
        mapSFX.Stop();
    }

    public void PauseGamePlaySFX()
    {
        if (gameplayMusicSource != null)
            gameplayMusicSource.Pause();
    }

    public void ResumeGamePlaySFX()
    {
        if (pauseBetweenGameplayMusicActive || gameplayMusicSource == null || gameplayMusicSource.isPlaying)
        {
            return;
        }
        gameplayMusicSource.Play();
    }

    public void RlayShopSFX()
    {
        StartCoroutine(FadeIn(shopSFX, 2f));
    }
    #endregion

    #region SFX
    public void playAmbientSFX()
    {
        if (mainscript.CurrentLvl < DUNGEON_LOCATION)
        {
            PlayRandomClip(ambientSFX, ambientLevel_1_15);
        }
        else if (mainscript.CurrentLvl >= DUNGEON_LOCATION && mainscript.CurrentLvl < POUTION_LOCATION)
        {
            PlayRandomClip(ambientSFX, ambientLevel_16_45);
        }
        else if (mainscript.CurrentLvl >= POUTION_LOCATION && mainscript.CurrentLvl < LAVA_LOCATION)
        {
            PlayRandomClip(ambientSFX, ambientLevel_46_70);
        }
        else
        {
            PlayRandomClip(ambientSFX, ambientLevelMore70);
        }
    }

    public void stopAmbientSFX()
    {
        ambientSFX.Stop();
    }

    public void playFireBallSFX()
    {
        fireBallSFX.Play();
    }

    public void playlightningSFX()
    {
        lightningSFX.Play();
    }

    public void playIceStrikeSFX()
    {
        iceStrikeSFX.Play();
    }

    public void playStoneBallSFX()
    {
        stoneBallSFX.Play();
    }

    public void playFireWallSFX()
    {
        fireWallSFX.Play();
    }

    public void playChainLightningSFX()
    {
        chainLightningSFX.Play();
    }

    public void playIceBreathSFX()
    {
        iceBreathSFX.Play();
    }

    public void playAcidSpraySFX()
    {
        acidSpraySFX.Play();
    }

    public void playMeteorSFX()
    {
        PlayRandomClip(meteorSFX, meteorClips);
    }

    public void playBlizzardSFX()
    {
        PlayRandomClip(blizzardSFX, blizzardClips);
    }

    public void playElectricPoolSFX()
    {
        PlayRandomClip(electricPoolSFX, electricPoolClips);
    }

    public void playEarthBallSFX()
    {
        PlayRandomClip(earthBallSFX, earthBallClips);
    }

    public void playScrollPowerSFX()
    {
        scrollPowerSFX.Play();
    }

    public void playScrollZombieSFX()
    {
        scrollZombieSFX.Play();
    }


    public void playUseBottle2SFX()
    {
        useBottle2SFX.Play();
    }

    public void playFlipMenuSFX()
    {
        flipMenuSFX.Play();
    }

    public void PlayShowPauseSFX()
    {
        showPauseSFX.Play();
    }

    public void playScrollUnlockSFX()
    {
        scrollUnlockSFX.Play();
    }

    public void playActivateAcidSFX()
    {
        ActivateAcidSFX.Play();
    }

    public void playActivateBarrierSFX()
    {
        ActivateBarrierSFX.Play();
    }

    public void playActivateFreezeSFX()
    {
        ActivateFreezeSFX.Play();
    }

    public void playActivateMineFieldSFX()
    {
        ActivateMinesFieldSFX.Play();
    }

    public void playDrobScrollSFX()
    {
        drobScrollSFX.Play();
    }

    public void playUseBottleSFX()
    {
        useBottleSFX.Play();
    }

    public void playLowManaSFX()
    {
        lowManaSFX.Play();
    }

    public void playAddCoinSFX()
    {
        addCoinSFX.Play();
    }

    public void playGetCoinSFX()
    {
        getCoinSFX.Play();
    }

    public void playOpenChestSFX()
    {
        openChestSFX.Play();
    }

    public void playTimerContinueSFX()
    {
        timeContinueSFX.Play();
    }

    public void playWallImpactSFX()
    {
        wallImpactSFX.Play();
    }

    public void PlayDropCoinSFX()
    {
        dropCoinSFX.Play();
    }

    public void playWinLevelSFX()
    {
        winLevelSFX.Play();
    }

    public void PlayDefeatLevelSFX()
    {
        defeatLevelSFX.Play();
    }

    public void PlayMapUnlockScrollSFX()
    {
        mapUnlockScrollSFX.Play();
    }

    public void PlayMapNextLevelSFX()
    {
        mapNextLevelSFX.Play();
    }

    public void PlayShopBuySFX()
    {
        shopBuySFX.Play();
    }

    public void PlayBuyCoinsSFX()
    {
        buyCoinsSFX.Play();
    }

    public static void PlayWindowsAcivitySFX()
    {
        if (Instanse != null)
        {
            if (Instanse.timerPlay > 0)
                return;
            _instance.windowsActivitySFX.Play();
        }
    }

    public void PlayScrollFlySFX()
    {
        scrollFlySFX.Play();
    }

	public void PlayDailySpinOpen()
	{
		dailySpinOpen.Play ();
	}

	public void PlayDailySpinRotate()
	{
		dailySpinRotate.Play ();
	}

    public void StopDailySpinRotate()
    {
        dailySpinRotate.Stop();
        dailySpinEnd.Play();
    }

    public void PlayDailySpinCongrats()
	{
	    dailySpinEnd.Stop();
		dailySpinCongrats.Play ();
	}

    private void PlayRandomClip(AudioSource source, AudioClip[] clips)
    {
        AudioClip clip = GetRandomClip(clips);
        if (clip != null)
        {
            source.clip = clip;
        }
        source.Play();
    }
    #endregion

    public void StopAllBackgroundSFX()
    {
        StopAllCoroutines();

        if (gameplayMusicSource != null)
        {
            gameplayMusicSource.Stop();
        }

        menuSFX.Stop();
        gameSFX.Stop();
        mapSFX.Stop();
        shopSFX.Stop();
    }

    private AudioSource GetCurrentlyPlayingMusicSource()
    {
        foreach (AudioSource audioSource in Musics)
        {
            if (audioSource.isPlaying)
            {
                return audioSource;
            }
        }
        return null;
    }

    public void FadeOutCurrentMusic()
    {
        foreach (AudioSource _scr in Musics)
        {
            if (_scr.isPlaying)
            {
                StartCoroutine(FadeOut(_scr, 0.7f));
                break;
            }
        }
    }

    public void EnableSoundsVolume(bool _on)
    {
        if (_on)
        {
            AudioListener.volume = 1;
            //sfxMixer.SetFloat("Volume", 0f);
        }
        else
        {
            AudioListener.volume = 0;
            //sfxMixer.SetFloat("Volume", -80f);
        }
    }

    public void EnableMusicsVolume(bool _on)
    {
        foreach (AudioSource _scr in Musics)
        {
            _scr.mute = !_on;
        }
    }

    public void StopAllMusic()
    {
        StopAllCoroutines();
        if (gameplayMusicSource != null)
        {
            gameplayMusicSource.Stop();
        }
        foreach (AudioSource _scr in Musics)
        {
            _scr.Stop();
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime, float targetVolume = 0f)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > targetVolume)
        {
            audioSource.volume -= startVolume * Time.unscaledDeltaTime / FadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = Instanse.currentMusicVolume;
    }

    private IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();
        float timer = 0f;
        while (timer < FadeTime)
        {
            timer += Time.unscaledDeltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, currentMusicVolume, timer / FadeTime);
            yield return new WaitForSecondsRealtime(0.2f);
        }

        audioSource.volume = currentMusicVolume;
    }

    public void RestartGamePlayMusicLooping()
    {
        if (gameplayMusicCoroutine != null)
        {
            StopCoroutine(gameplayMusicCoroutine);
        }
        if (gameplayMusicSource != null)
        {
            ChangeMusicVolume(0f, 0.5f, gameplayMusicSource);
            currentMusicVolume = 1f;
        }
        this.CallActionAfterDelayWithCoroutine(0.6f, StartGamePlaySmoothLoopingForLevelRange);
    }

    public void StartGamePlaySmoothLoopingForLevelRange()
    {
        StartCoroutine(StartGamePlaySmoothLoopingForLevelRangeCoroutine());
    }

    private IEnumerator StartGamePlaySmoothLoopingForLevelRangeCoroutine()
    {
        if (mainscript.CurrentLvl > 3 && mainscript.CurrentLvl != 16 && mainscript.CurrentLvl != 31 && mainscript.CurrentLvl != 46 && mainscript.CurrentLvl != 71 && mainscript.CurrentLvl != 96)
        {
            var x = Random.Range(10f, 30f);
            yield return new WaitForSeconds(x);
        }

        countPlaySound++;
        var completedLevelsNumber = mainscript.CurrentLvl;
        var selectedGameplayMusic = new List<AudioSource>();
        gameplayTrackId = -1;
        for (int i = 0; i < GameplayMusic.Length; i++)
        {
            if (completedLevelsNumber >= GameplayMusic[i].levelMinToStartPlayMusic && completedLevelsNumber <= GameplayMusic[i].levelMaxToStartPlayMusic)
            {
                if (completedLevelsNumber == GameplayMusic[i].levelMinToStartPlayMusic)
                {
                    //Для уровня на котором открываеться новый трек мы форсим его проигрывание первым
                    gameplayTrackId = selectedGameplayMusic.Count;
                }
                selectedGameplayMusic.Add(GameplayMusic[i].audioSource);
            }
        }
        if (gameplayTrackId < 0)
        {
            gameplayTrackId = Random.Range(0, selectedGameplayMusic.Count);
        }
        if (gameplayMusicCoroutine != null)
            StopCoroutine(gameplayMusicCoroutine);
        gameplayMusicCoroutine = StartCoroutine(GamePlayLoopingSFX(selectedGameplayMusic));

        yield break;
    }

    private IEnumerator ChangeMusicVolumeOverTime(AudioSource musicSource, float targetVolume, float overTime, bool useUnscaledTime = false)
    {
        float timer = 0f;
        float startVolume = musicSource.volume;
        while (timer < overTime)
        {
            timer += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, timer / overTime);
            yield return null;
        }
        musicSource.volume = targetVolume;
        changeMusicVolumeCoroutine = null;
    }

    public static int countPlaySound = 0;

    private IEnumerator GamePlayLoopingSFX(List<AudioSource> gamePlayMusicList)
    {
        if (gameplayMusicSource != null)
            yield return StartCoroutine(FadeOut(gameplayMusicSource, 1.0f));

        countPlaySound++;

        pauseBetweenGameplayMusicActive = false;
        gameplayMusicSource = gamePlayMusicList[gameplayTrackId];

        yield return StartCoroutine(FadeIn(gameplayMusicSource, 2f));

        float playCycles = 2;
        float remainingPlayTime = gameplayMusicSource.clip.length * playCycles - 2.0f - 1.5f;
        while (true)
        {
            if (gameplayMusicSource.isPlaying)
                remainingPlayTime -= Time.unscaledDeltaTime;

            if (remainingPlayTime <= 0.0f)
                break;

            yield return null;
        }

        yield return StartCoroutine(FadeOut(gameplayMusicSource, 1.5f));

        gameplayTrackId = (gameplayTrackId + 1) % gamePlayMusicList.Count;

        var pauseBetweenTracks = Random.Range(10f, 20f);
        pauseBetweenGameplayMusicActive = true;
        //Debug.Log("pauseBetweenTracks: " + pauseBetweenTracks);
        yield return new WaitForSeconds(pauseBetweenTracks);
        if (gameplayMusicCoroutine != null)
            StopCoroutine(gameplayMusicCoroutine);

        if (musicGamePlayLoopChance <= 80)
        {
            if (countPlaySound < 2)
                gameplayMusicCoroutine = StartCoroutine(GamePlayLoopingSFX(gamePlayMusicList));
        }
        else
        {
            if (countPlaySound <= 2)
                gameplayMusicCoroutine = StartCoroutine(GamePlayLoopingSFX(gamePlayMusicList));
        }

    }

    [SerializeField]
    private Dictionary<string,int> clipsNow = new Dictionary<string,int>();
    public void PlayMultiSound(AudioSource source, AudioClip clip, int maxPlayingNumber = 5, float timeWaitCoefficient = 1)
    {
        if (!clipsNow.ContainsKey(clip.name))
        {
            clipsNow.Add(clip.name, 1);
        }
        else
        {
            int currentlyPlayingNumber = clipsNow[clip.name];
            if (currentlyPlayingNumber >= maxPlayingNumber)
            {
               // Debug.LogFormat("Sound with name <b>{0}</b> is skipped because too many playing sounds. Sounds number: {1}", clip.name, currentlyPlayingNumber);
                return;
            }
            clipsNow[clip.name]++;
        }

        // Eugene get random volume for source
        float randVol = Random.Range(0.7f, 1f);
        source.volume = randVol;

       // Debug.Log($"Play zombie attack");
        source.PlayOneShot(clip);
        StartCoroutine(DecMultiClips(clip.name, clip.length * timeWaitCoefficient));
    }

    private IEnumerator DecMultiClips(string audioclipName, float timeLength)
    {
        yield return new WaitForSecondsRealtime(timeLength);
        clipsNow[audioclipName]--;
    }


    float timeMusic = 0;

    private void Update()
    {
        timerPlay -= Time.deltaTime;
        if (gameplayMusicSource != null)
            timeMusic = gameplayMusicSource.time;
        else
            timeMusic = -3;
    }

}
