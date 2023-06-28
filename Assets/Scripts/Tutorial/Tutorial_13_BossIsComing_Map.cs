using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials
{
    public class Tutorial_13_BossIsComing_Map : MonoBehaviour
    {
        [SerializeField]
        private RectTransform tutorialCanvasRect;
        [SerializeField]
        private Camera mapCanvasCamera;
        [SerializeField]
        private Button inputBlock;
        [SerializeField]
        private GameObject tutorialMainObject;
        [SerializeField]
        private GameObject bossUIObject;
        [SerializeField]
        private Animator tutorialAnimator;
        [SerializeField]
        [AnimatorHashParameterAttribute(animatorPropertyName = "tutorialAnimator")]
        private AnimatorPropertyHash fadeOutAnimProperty;
        [SerializeField]
        private TutorialDailySpin tutorialDailySpin;

        public Tutorial_4 tutor4;

        private bool isPressed;
        private bool startTutorial;

        int tut = 0;
        public bool StartTutorial
        {
            get
            {
                return startTutorial;
            }
        }

        const int MIN_LEVEL_INDEX_TO_SHOW = 2;
        int BOSS_LEVEL_INDEX = 14;

        private static Tutorial_13_BossIsComing_Map _current;
        public static Tutorial_13_BossIsComing_Map Current
        {
            get
            {
                if (_current == null)
                {
                    _current = FindObjectOfType<Tutorial_13_BossIsComing_Map>();
                }
                return _current;
            }
        }

        //TODO AddGlobal game event on tutorial start, close all windows popup on this event
        // Use this for initialization
        void Start()
        {
            return;
            var open = false;
            var lvl = 0;

            for (int i = 0; i < SaveManager.GameProgress.Current.finishCount.Length; i++)
            {
                if (SaveManager.GameProgress.Current.finishCount[i] == 0)
                {
                    if (i >= MIN_LEVEL_INDEX_TO_SHOW && i < BOSS_LEVEL_INDEX &&
                        !SaveManager.GameProgress.Current.tutorial[(int) ETutorialType.TUTORIAL_BOSS_IS_COMING])
                    {
                        if (!SaveManager.GameProgress.Current.tutorialBossMapClik15)
                        {
                            inputBlock.gameObject.SetActive(false);
                            inputBlock.onClick.AddListener(OnScreenTap);
                            tutorialMainObject.SetActive(false);
                            StartCoroutine(StartTutorialCoroutine());
                            open = true;
                            tut = 15;
                        }
                    }
                    else
                    {
                        var isOpen = true;
                        if (i == 30 || i == 45)
                        {
                            if (i == 30)
                            {
                                BOSS_LEVEL_INDEX = 44;
                                if (SaveManager.GameProgress.Current.tutorialBossMapClik30)
                                    isOpen = false;
                                tut = 30;
                            }
                            if (i == 45)
                            {
                                BOSS_LEVEL_INDEX = 69;
                                if (SaveManager.GameProgress.Current.tutorialBossMapClik45)
                                    isOpen = false;
                               
                                tut = 45;
                            }

                            SaveManager.GameProgress.Current.Save();
                            if (isOpen)
                            {
                                inputBlock.gameObject.SetActive(false);
                                inputBlock.onClick.AddListener(OnScreenTap);
                                tutorialMainObject.SetActive(false);
                                StartCoroutine(StartTutorialCoroutine());
                                open = true;
                            }
                        }
                    }
                    lvl++;
                    break;
                }
            }
            if (!open)
                gameObject.SetActive(false);
        }

        private IEnumerator StartTutorialCoroutine()
        {
            TutorialsManager.OnTutorialStart(ETutorialType.TUTORIAL_BOSS_IS_COMING);
            startTutorial = true;
            fadeOutAnimProperty.Hash();
            Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
            WaitUntil waitUntilMapUpdateView = new WaitUntil(() =>
            {
                return UIMap.Current.isUpdateViewComplete;
            });
            yield return waitUntilMapUpdateView;

            UIMap.Current.SetViewToLevel(BOSS_LEVEL_INDEX, 0);
            UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);

            inputBlock.gameObject.SetActive(true);
            WaitUntil wailtUntilBlackPathIsOut = new WaitUntil(() =>
            {
                return UIBlackPatch.Current.isOuted;
            });
            yield return waitUntilMapUpdateView;

            Canvas bossUICanvas = bossUIObject.GetComponent<Canvas>();
            if(bossUICanvas == null)
            {
                bossUIObject.AddComponent<Canvas>();
                bossUIObject.AddComponent<GraphicRaycaster>();
                Debug.Log($"ADD CANVASSSSS");
            }
            bossUICanvas = bossUIObject.GetComponent<Canvas>();
            bossUICanvas.overrideSorting = true;
            bossUICanvas.sortingOrder = 10;
            GameObject bossLevelCopy = CopyLevelObject();

            tutorialMainObject.SetActive(true);

            WaitUntil waitUntilScreenTap = new WaitUntil(() =>
            {
                return isPressed;
            });
            yield return waitUntilScreenTap;//Show tutorial here;

            Destroy(bossLevelCopy);
            Debug.Log($"SaveManager.GameProgress.Current.tutorialBossMapClik30");
            bossUICanvas.sortingOrder = 2;
            if(tut == 15)
                SaveManager.GameProgress.Current.tutorialBossMapClik15 = true;
            if(tut == 30)
                SaveManager.GameProgress.Current.tutorialBossMapClik30 = true;
            if(tut == 45)
                SaveManager.GameProgress.Current.tutorialBossMapClik45 = true;
            SaveManager.GameProgress.Current.Save();

            tutorialAnimator.SetTrigger(fadeOutAnimProperty.PropertyHash);
            yield return new WaitForSeconds(0.5f);

            UIMap.Current.ScrollToCurrentLevel(1.5f);
            yield return new WaitForSeconds(2f);//Complete tutorial after;

            Debug.Log($"Tutorial completed: {BOSS_LEVEL_INDEX}");
            gameObject.SetActive(false);
            SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.TUTORIAL_BOSS_IS_COMING] = true;
            TutorialsManager.OnTutorialCompleted();
            startTutorial = false;
            bossUICanvas.sortingOrder = 1;

            //CallRateLink.Open(-1);
        }

        private GameObject CopyLevelObject()
        {
            GameObject bossLevelObject = UIMap.Current.GetLevelTransform(BOSS_LEVEL_INDEX + 1).gameObject;

            GameObject bossLevelCopy = Instantiate(bossLevelObject, tutorialMainObject.transform);
            Transform bossLevelCopyTransf = bossLevelCopy.transform;
            bossLevelCopyTransf.localScale = new Vector3(1f, 1f, 1f);
            bossLevelCopyTransf.SetAsLastSibling();

            Vector3 overlayUIPos = tutorialCanvasRect.position;
            Vector3 overlayUIScale = tutorialCanvasRect.localScale;
            Vector3 overlayUISize = ((Vector3)tutorialCanvasRect.sizeDelta).MultiplyVector3(overlayUIScale);
            Vector3 centerOffset = new Vector3(0.5f, 0.5f, 0f);

            Vector3 viewPortPos = (mapCanvasCamera.WorldToViewportPoint(bossLevelObject.transform.position) - centerOffset);// Remap from 0 - 1 to -0.5 - 0.5f
            viewPortPos.z = 1f;
            bossLevelCopyTransf.localScale = new Vector3(1f, 1f, 1f);
            bossLevelCopyTransf.position = overlayUIPos + overlayUISize.MultiplyVector3(viewPortPos);
            return bossLevelCopy;
        }

        private void OnScreenTap()
        {
            isPressed = true;
        }

        private void OnDestroy()
        {
            UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        }

#if UNITY_EDITOR
        [SerializeField]
        [Space(20f)]
        private bool startTutorialEditor;
        private void OnDrawGizmosSelected()
        {
            if (startTutorialEditor)
            {
                startTutorialEditor = false;
                isPressed = false;
                inputBlock.gameObject.SetActive(false);
                inputBlock.onClick.RemoveAllListeners();
                inputBlock.onClick.AddListener(OnScreenTap);
                tutorialMainObject.SetActive(false);
                StartCoroutine(StartTutorialCoroutine());
            }
        }
#endif
    }
}
