using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Animations;
using Native;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Linq;
using UnityEngine.SceneManagement;

namespace UI
{
    public class IntroController : MonoBehaviour
    {
        [System.Serializable]
        private class AnimationSequencePart
        {
            public Animator animator;
            [AnimatorHashParameterAttribute]
            public AnimatorPropertyHash animPropertyHash;
            public float delay;
            [SerializeField]
            private bool enabledAtStart;

            public void SetInitialGameObjectState()
            {
                if (animator != null)
                {
                    animator.gameObject.SetActive(enabledAtStart);
                }
            }
        }

        [System.Serializable]
        private class AnimationsSequence
        {
            public AnimationSequencePart[] animationsSequence;
        }

        [System.Serializable]
        private struct IntroScene
        {
            public GameObject scene;
            public GameObject[] textPopups;
            public LocalTextLoc[] texts;
        }

        [SerializeField]
        private AlphaColorAnimation darkScreenAnimation;
        [SerializeField]
        private AudioSource     introAudio;
        [SerializeField]
        private AudioSource     introMusic;
        [SerializeField]
        private float           startAudioDelay;
        [SerializeField]
        private float           darkScreenAnimationTimeBeforeFirstScene;
        [SerializeField]
        private float           darkScreenAnimationTime;
        [SerializeField]
        private float           darkScreenAnimationTimeBeforeLastScene;
        [SerializeField]
        private float           skipButtonShowDelay;
        [SerializeField]
        private Button          skipButton;
        [Space(10f)]
        [SerializeField]
        private IntroScene      scene5Loading;
        [SerializeField]
        private IntroScene[]    scenes;
        [SerializeField]
        private AnimationCurve[]  musicVolumeChangeCurveOnSceneEnd;
        [SerializeField]
        private bool[]          showDarkScreenAfterSceneFlags;

        [SerializeField]
        private AnimationsSequence[] animationsSequence;
        private int             currentScene;
        private Coroutine       currentAnimationSequenceCoroutine;
        private bool            skipClicked;

        public static string WAS_WATCHED_PREFS_KEY ="IntroWasWatched";

        public static IntroController instance;

#if UNITY_EDITOR
        [SerializeField]
        [Header("Editor")]
        private bool dontLoadNextSceneEditor;
        [SerializeField]
        private bool muteSoundEditor;
        [SerializeField]
        private bool disableLogicEditor;
        [SerializeField]
        private Text timerLabel;
        private Coroutine timerCoroutine;
        private float timer;
#endif

        public static bool IntroWasWatched
        {
            get
            {
                return PlayerPrefs.GetInt(WAS_WATCHED_PREFS_KEY, 0) == 1;
            }
        }

        public static void ShowIntro()
        {
            Debug.Log($"ShowIntro");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
            AnalyticsController.Instance.LogMyEvent("StartedWatchingIntro");
        }

        private bool IsItLastSceneBeforeLoading
        {
            get
            {
                return currentScene == scenes.Length - 1;
            }
        }

        private void Awake()
        {
            instance = this;
#if UNITY_EDITOR
            if (disableLogicEditor)
            {
                return;
            }
#endif

            scene5Loading.scene.gameObject.SetActive(false);
            darkScreenAnimation.gameObject.SetActive(true);
            skipButton.gameObject.SetActive(false);
            skipButton.onClick.AddListener(OnSkipClick);
            darkScreenAnimation.Init();
            darkScreenAnimation.SetAlpha(1f);
            darkScreenAnimation.gameObject.SetActive(true);
        }

        IEnumerator Start()
        {
#if UNITY_EDITOR
            if (muteSoundEditor)
            {
                AudioListener.volume = 0;
            }
            if (disableLogicEditor)
            {
                yield break;
            }
#endif
            if (!Application.isEditor)  PlayServices.callbackLogin.Add(OnLoginCompleted);
            else this.CallActionAfterDelayWithCoroutine(skipButtonShowDelay, ShowSkipButton);
            
            ActivateScene(currentScene);
            darkScreenAnimation.Animate(darkScreenAnimationTimeBeforeFirstScene, false, OnDrakScreenFadeoutComplete);
            this.CallActionAfterDelayWithCoroutine(startAudioDelay, introAudio.Play);
#if UNITY_EDITOR
            timerCoroutine = StartCoroutine(Timer());
#else
            yield return new WaitForSecondsRealtime(5);
            if (PlayServices.isAuthenticationCompleted)
                GoogleCloudSavesController.Instance.OnUserLoggedIn();
#endif
            Debug.Log($"Intro scene start");

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                yield return new WaitForSecondsRealtime(2f);
                ShowSkipButton();
            }
        }

#if UNITY_EDITOR
        private IEnumerator Timer()
        {
            while (true)
            {
                timer += Time.deltaTime;
                timerLabel.text = timer.ToString();
                yield return null;
            }
        }
#endif

        public void Pause()
        {
            introMusic.Pause();
            introAudio.Pause();
        }

        public void Play()
        {
            introMusic.Play();
            introAudio.Play();
        }

        public void OnSkipClick()
        {
            if (!skipClicked)
            {
                AnalyticsController.Instance.LogMyEvent("press_skip_intro");

                skipClicked = true;
                StopCoroutine(currentAnimationSequenceCoroutine);
                skipButton.GetComponent<AlphaColorAnimation>().Animate(() =>
                {
                    skipButton.gameObject.SetActive(false);
                });
                StartCoroutine(FadeOutSound());
                if (!darkScreenAnimation.IsPlaying)
                {
                    darkScreenAnimation.Animate(darkScreenAnimationTimeBeforeLastScene, true, OnDrakScreenFadeInComplete);
                }
            }
        }

        public void ShowSkipButton()
        {
            StartCoroutine(SkipButton());
        }

        private IEnumerator SkipButton()
        {
            while (SceneManager.GetActiveScene().name == "Splash" && SceneManager.GetActiveScene().name != "Intro")
            {
                yield return new WaitForSecondsRealtime(1f);

                if (SceneManager.GetActiveScene().name != "Splash" && SceneManager.GetActiveScene().name != "Intro")
                    yield break;
            }

            yield return new WaitForSecondsRealtime(0.5f);

            if (!skipButton.gameObject.activeSelf)
            {
                skipButton.gameObject.SetActive(true);
                skipButton.GetComponent<AlphaColorAnimation>().Animate(null, false);
            }
        }

        private IEnumerator FadeOutSound()
        {
            float fadeOutTime = 1f;
            float timer = 0;
            while (timer < fadeOutTime)
            {
                timer += Time.deltaTime;
                introAudio.volume = 1f - timer / fadeOutTime;
                yield return null;
            }
            introAudio.Stop();
        }

        private void ActivateScene(int index)
        {
            int i;
            bool isActive = false;
            for (i = 0; i < scenes.Length; i++)
            {
                isActive = i == index;
                scenes[i].scene.gameObject.SetActive(isActive);
                foreach (GameObject popup in scenes[i].textPopups)
                {
                    popup.SetActive(isActive);
                }
                if (isActive)
                {
                    SetIntroText(scenes[i]);
                }
            }
            AnimationsSequence currentAnimationsSequence = animationsSequence[index];
            for (i = 0; i < currentAnimationsSequence.animationsSequence.Length; i++)
            {
                currentAnimationsSequence.animationsSequence[i].SetInitialGameObjectState();
            }
            currentAnimationSequenceCoroutine = StartCoroutine(RunAnimationSequence(animationsSequence[currentScene].animationsSequence));
        }

        private void SetIntroText(IntroScene scene)
        {
            for (int i = 0; i < scene.texts.Length; i++)
            {
                if (scene.texts[i] == null)
                {
                    continue;
                }
                scene.texts[i].SetText();
            }
        }

        //private void OnAnimationSequenceComplete()
        //{
        //	ActivateScene(currentScene);
        //	darkScreenAnimation.Animate(darkScreenAnimationTime, true, OnDrakScreenFadeInComplete);
        //}

        private void OnDrakScreenFadeoutComplete()
        {
            if (skipClicked)
            {
                darkScreenAnimation.Animate(darkScreenAnimationTime, true, OnDrakScreenFadeInComplete);
            }
        }

        private IEnumerator RunAnimationSequence(AnimationSequencePart[] animationsSequence)
        {
            for (int i = 0; i < animationsSequence.Length; i++)
            {
                yield return new WaitForSeconds(animationsSequence[i].delay);
                if (animationsSequence[i].animator != null)
                {
                    animationsSequence[i].animator.gameObject.SetActive(true);
                    if (!animationsSequence[i].animPropertyHash.IsNullOrEmpty)
                    {
                        animationsSequence[i].animator.SetTrigger(animationsSequence[i].animPropertyHash.PropertyHash);
                    }
                }
            }
#if UNITY_EDITOR
            Debug.Log("Animations End " + currentScene + "  " + timer);
#endif
            if (showDarkScreenAfterSceneFlags[currentScene])
            {
                darkScreenAnimation.Animate(IsItLastSceneBeforeLoading ? darkScreenAnimationTimeBeforeLastScene : darkScreenAnimationTime, true, OnDrakScreenFadeInComplete);
                StartCoroutine(MusicVolumeAnimationCoroutine(musicVolumeChangeCurveOnSceneEnd[currentScene]));
            }
            else
            {
                //Debug.Log($"prepare");
                PrepareNextScene(false);
            }
        }

        private IEnumerator MusicVolumeAnimationCoroutine(AnimationCurve animCurve)
        {
            float animTime = darkScreenAnimationTime * 2f;
            float timer = 0;

            while (timer <= animTime)
            {
                timer += Time.deltaTime;
                introMusic.volume = animCurve.Evaluate(timer / animTime);
                yield return null;
            }
        }

        private void OnDrakScreenFadeInComplete()
        {
            PrepareNextScene();
        }

        private void PrepareNextScene(bool playDarkFadeOut = true)
        {
            currentScene++;
#if UNITY_EDITOR
            Debug.Log("PrepareNextScene End " + currentScene + "  " + timer);
#endif
            if (currentScene < scenes.Length && !skipClicked)
            {
                ActivateScene(currentScene);
                if (playDarkFadeOut)
                {
                    darkScreenAnimation.Animate(darkScreenAnimationTime, false, OnDrakScreenFadeoutComplete);
                }
            }
            else
            {
                if (skipButton.gameObject.activeSelf)
                {
                    skipButton.gameObject.SetActive(false);
                    //skipButton.GetComponent<AlphaColorAnimation>().Animate();
                }
                scenes[currentScene - 1].scene.SetActive(false);
                foreach (GameObject popup in scenes[currentScene - 1].textPopups)
                    popup.SetActive(false);
                scene5Loading.scene.gameObject.SetActive(true);
                darkScreenAnimation.gameObject.SetActive(false);
                LoadNextGameScene();
                //darkScreenAnimation.Animate(darkScreenAnimationTimeBeforeLastScene, false, LoadNextGameScene);
            }
        }

        private void LoadNextGameScene()
        {
            AnalyticsController.Instance.LogMyEvent("EndedWatchingIntro");

            StartCoroutine(CheckExitConditions());
        }

        private IEnumerator CheckExitConditions()
        {
            while (!PlayServices.isAuthenticationCompleted)
            {
                yield return null;
            }
            yield return new WaitForSecondsRealtime(4.5f);
            OnDelayWithCoroutine();
        }
        
        private void OnDelayWithCoroutine()
        {
//#if UNITY_EDITOR
//            Debug.Log("LoadScene");
//            StopCoroutine(timerCoroutine);
//            if (dontLoadNextSceneEditor)
//            {
//                return;
//            }
//#endif
            PlayerPrefs.SetInt(WAS_WATCHED_PREFS_KEY, 1);
            SaveManager.IntroWasViewed = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
            //if (SaveManager.GameProgress.Current.CompletedLevelsNumber <= 0)
            //{
            //    Debug.Log($"load game");
            //    UIEditorMenu.loadedFile = 0.ToString();
            //    mainscript.CurrentLvl = 0;
            //    PlayerPrefs.SetString("currentLvl", 0.ToString());
            //    UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1_Tutorial");
            //}
        }

        private void OnLoginCompleted(bool useProgressFromCloud)
        {
            Debug.Log("IntroController.OnLoginCompleted: useProgressFromCloud =" + useProgressFromCloud);
            PlayServices.callbackLogin.Remove(OnLoginCompleted);
            if (!useProgressFromCloud)
            {
                ShowSkipButton();
                return;
            }
            PlayerPrefs.SetInt(WAS_WATCHED_PREFS_KEY, 1);
            PlayerPrefs.Save();

            SaveManager.IntroWasViewed = true;

            int openLevel = 0;
            if (SaveManager.GameProgress.Current != null && SaveManager.GameProgress.Current.finishCount != null)
                openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
            else
                Debug.Log("IntroController.OnLoginCompleted: SaveManager.GameProgress.Current finishCount is null");

            if (openLevel > 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1_Tutorial");
        }
    }
}