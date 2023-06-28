using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials
{
    public class TutorialDailySpin : MonoBehaviour
    {
        private const int MIN_LEVEL_INDEX_TO_SHOW = 1;
        
        public static TutorialDailySpin Instance;

        [Header("Step One:")]
        [SerializeField]
        private GameObject tutorialMainObject;
        [SerializeField]
        private GameObject dailySpinUIObject;
        [SerializeField]
        private Animator tutorialAnimator;
        [SerializeField]
        [AnimatorHashParameter(animatorPropertyName ="tutorialAnimator")]
        private AnimatorPropertyHash fadeOutAnimProperty;
        private Button dailyButtonWheel = null;
        private bool isDailyWheelIconClicked;

        [Header("Step Two:")]
        [SerializeField]
        private GameObject tutorialStopObject;
        [SerializeField]
        private Button dailyButtonStop;
        [SerializeField]
        Tutorials.Tutorial_4 tutorial4;
        [SerializeField]
        UIDailySpin spin;

        public static int spinClose = 0;

        private void Start()
        {
            Instance = this;
            // if (!SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.DAILY_SPIN] && SaveManager.GameProgress.Current.CompletedLevelsNumber >= MIN_LEVEL_INDEX_TO_SHOW)
            // {
            //     StartCoroutine(PlayTutorial());
            // }
        }

        public IEnumerator PlayTutorial()
        {
            if (ValidationDailyCooldown())
            {
                while (TutorialsManager.IsAnyTutorialActive)
                    yield return new WaitForSeconds(0.5f);

                TutorialsManager.OnTutorialStart(ETutorialType.DAILY_SPIN);
                Debug.Log("DAYLY SPIN TUTORIAL START");
                gameObject.SetActive(true);
                tutorialMainObject.SetActive(false);
                SetDailyButton();
                var tut = Tutorial.Open(target: dailySpinUIObject, focus: new Transform[] { dailySpinUIObject.transform }, mirror: true, rotation: new Vector3(0, 0, -55), offset: new Vector2(70, 90), waiting: 0, keyText: "t_0631");
                tut.dublicateObj = false;
            }
        }

        private bool ValidationDailyCooldown()
        {
            UIDailySpin.DailyItem dailyItem = PPSerialization.Load<UIDailySpin.DailyItem>("DailySpin");
            if (dailyItem == null)
            {
                return true;
            }

            DateTime currentDate = UnbiasedTime.Instance.Now();
            if (currentDate >= dailyItem.UnlockNextTime)
            {
                return true;
            }

            return false;
        }

        private void SetDailyButton()
        {
            dailyButtonWheel = dailySpinUIObject.GetComponentInChildren<Button>();
            dailyButtonWheel.onClick.RemoveListener(OnDailyButtonClick);
            dailyButtonWheel.onClick.AddListener(OnDailyButtonClick);

            dailyButtonStop.onClick.RemoveListener(OnDailyFinishTutorial);
            dailyButtonStop.onClick.AddListener(OnDailyFinishTutorial);
        }

        private void SetComplete(bool value)
        {
            SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.DAILY_SPIN] = true;
            SaveManager.GameProgress.Current.Save();
        }

        public void CloseDailySpin()
        {
            if (TutorialsManager.IsTutorialActive(ETutorialType.DAILY_SPIN))
                TutorialsManager.OnTutorialCompleted();

            if (spin.pendingReward)
                return;
            tutorial4.StartTutor();
            if(spinClose == 1)
                TutorialDailySpin.spinClose = 0;
        }

        private bool IsMapViewUpdateCompleted()
        {
            return UIMap.Current.isUpdateViewComplete;
        }

        private bool IsOuted()
        {
            return UIBlackPatch.Current.isOuted;
        }

        private bool IsWheelIconWasClicked()
        {
            return isDailyWheelIconClicked;
        }

        private void OnDailyButtonClick()
        {
            isDailyWheelIconClicked = true;
            dailyButtonWheel.onClick.RemoveListener(OnDailyButtonClick);
            Tutorial.Close();
            Tutorial.Open(target: dailyButtonStop.gameObject, focus: null, mirror: true, rotation: new Vector3(0, 0, -55), offset: new Vector2(40, 40), waiting: 0);
        }

        public void OnDailyFinishTutorial()
        {
            tutorialStopObject.SetActive(false);
            SetComplete(true);
            Debug.Log("Tutorial completed");
            Tutorial.Close();
        }

        private void OnDestroy()
        {
            UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        }
    }
}