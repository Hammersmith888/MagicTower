using ADs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials
{
    public class Tutorial_1 : MonoBehaviour
    {
        #region VARIABLES
        [SerializeField]
        private Camera uiCamera;
        [SerializeField]
        private Transform bottomSpellsAndManaParent;

        public GameObject[] messages;
        public GameObject enemiesController, panelInfo, centerScreen;
        public RectTransform DarkBack;
        public GameObject pointerHand;
        private RectTransform pointerAnchor;
        public Transform scrollObj;
        public Transform zombieObj, centerZombie, wallObj, wallCenter, mineObj, mineCenter, centerWind, centerWind2;
        public Transform healthObj;
        public Transform powerPotionObj;
        public Transform healthBar;
        public Transform manaObj;
        public Transform manaBar;
        public List<Transform> spellsPlaces = new List<Transform>();
        public Transform scrollNewParent;

        private Transform scrollStartParent;

        public Transform spellsNewParent;
        public PotionManager potions;
        public Transform infoButton;
        public Transform doubleSpeedButton;
        public Transform casualGameButton;
        public Transform hpCheckbox;

        private Transform spellsStartParent;
        private UIPauseController pause;

        public bool animatePointer;
        private Vector3 HandDefaultScale;
        private GameObject first_enemy;
        [HideInInspector]
        public GameObject tutor0TargetEnemy;
        private bool shootingTutorialInProcess;
        public bool shouldStartCoinTutorial;
        public static TutorialFirstCrystal tutorialFirstCrystal;
        private int wavesSpawned = 0;
        Image hand1, hand2;
        [SerializeField]
        Font[] fontLocalize;

        Coroutine corWall;
        private Coroutine loopHand;

        private bool tutorialLevel2Complete = false;

        CharacterLayerChangerForReplica characterLayersChanger;
        public bool checkOldVersion = false;

        private static Tutorial_1 _current;
        public static Tutorial_1 Current
        {
            get
            {
                if (_current == null)
                {
                    _current = FindObjectOfType<Tutorial_1>();
                }
                return _current;
            }
        }
        #endregion

        private void Start()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level")
                return;

            _current = this;
            pause = enemiesController.GetComponent<EnemiesGenerator>().levelSettings.pauseObj;


            // Check if last game player lose game
            if (PlayerPrefs.GetInt("LastGameLose", 0) == 1 && (!SaveManager.GameProgress.Current.tutorial[5] || !SaveManager.GameProgress.Current.tutorial[6]))
            {
                float lastGameHP = PlayerPrefs.GetFloat("LastGameHP", float.MaxValue);
                float lastGameMana = PlayerPrefs.GetFloat("LastGameMana", float.MaxValue);

                if (lastGameHP < lastGameMana)
                {
                    if (mainscript.CurrentLvl == 5)
                        return;

                    if (EnemiesGenerator.Instance.currentWave == EnemiesGenerator.Instance.GetUsefulTotalWavesNumber)
                        return;
                    
                    ShowHealthPotionTutorial();
                    
                }
                else
                {
                    if (!SaveManager.GameProgress.Current.tutorial[6])
                    {
                        ShowManaPotionTutorial();
                    }
                }

                PlayerPrefs.SetInt("LastGameLose", 0);
            }
            
            // Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.LOW_HEALTH, OnLowHealth);
            // if (!SaveManager.GameProgress.Current.tutorial[6])
            // {
            //     Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.LOW_MANA, OnLowMana);
            // }
            Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.POTION_USE, OnPotionUse);

            int openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
            pointerAnchor = pointerHand.transform.Find("anchor").GetComponent<RectTransform>();
            Canvas handCanvas = pointerHand.AddComponent<Canvas>();
            handCanvas.overrideSorting = true;
            handCanvas.sortingOrder = 20;
            HandDefaultScale = pointerHand.transform.localScale;

            if (spellsPlaces.Count > 0)
            {
                spellsStartParent = spellsPlaces[0].parent;
            }
            else
            {
                spellsStartParent = transform;
            }

            if (!SaveManager.GameProgress.Current.tutorial[0] && mainscript.CurrentLvl == 1)
            {
                UI.ReplicaUI.OnReplicaComplete += ReplicaUIOnReplicaComplete;
            }
            else
            {
                if (mainscript.CurrentLvl == 2)
                {
                    UI.ReplicaUI.OnReplicaComplete += ReplicaUIOnReplicaComplete;
                }
                
                if (mainscript.CurrentLvl == 4)
                {
                    UI.ReplicaUI.OnReplicaComplete += ReplicaUIOnReplicaComplete;
                }
                float infoDelay = 1.5f;

                if (!SaveManager.GameProgress.Current.tutorial[4] && mainscript.CurrentLvl == 2)
                {
                    var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
                    if (scrollItems[0].active && scrollItems[0].count > 0)
                    {
                        if (ScrollController.Instance.scrolls[0].raycastGraphick.gameObject.activeSelf)
                        {
                            scrollStartParent = scrollObj.parent;
                            infoDelay += 3.5f;
                            AnalyticsController.Instance.Tutorial(4, 0);
                            this.CallActionAfterDelayWithCoroutine(1.5f, ShowUseAcidScrollMessasge);
                        }
                    }
                }
                if (!SaveManager.GameProgress.Current.tutorialMyZombie && mainscript.CurrentLvl == 56)
                {
                    var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);

                    if (scrollItems[4].active && scrollItems[4].count > 0)
                    {
                        if (ScrollController.Instance != null)
                        {
                            if (ScrollController.Instance.scrolls[4].raycastGraphick.gameObject.activeSelf)
                            {
                                scrollStartParent = zombieObj.parent;
                                infoDelay += 3.5f;
                                this.CallActionAfterDelayWithCoroutine(3.5f, ShowUseZombieScrollMessasge);
                            }
                        }
                    }
                }
                if (!SaveManager.GameProgress.Current.tutorial12mine && mainscript.CurrentLvl == 12)
                {
                    var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
                    if (scrollItems[3].active && scrollItems[3].count > 0)
                    {
                        if (ScrollController.Instance != null)
                        {
                            if (ScrollController.Instance.scrolls[3].raycastGraphick.gameObject.activeSelf)
                            {
                                scrollStartParent = mineObj.parent;
                                this.CallActionAfterDelayWithCoroutine(3.5f, ShowUseMineScrollMessasge);
                            }
                        }
                    }
                }
                if (mainscript.CurrentLvl == 8 && !SaveManager.GameProgress.Current.tutorial8lvl)
                {
                    var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);

                    if (scrollItems[2].active && scrollItems[2].count > 0)
                    {
                        if (ScrollController.Instance != null)
                        {
                            HideHandPointer();
                            TutorialUtils.ClearAllCanvasOverrides();
                            pause.pauseCalled = false;
                            messages[9].SetActive(false);
                            scrollStartParent = wallObj.parent;
                            this.CallActionAfterDelayWithCoroutine(1f, ShowUseIceScrollMessasge);
                        }
                    }
                }
                if (!SaveManager.GameProgress.Current.tutorial5lvl && mainscript.CurrentLvl == 5)
                {
                    //AnalyticsController.Instance.Tutorial(12, 0);
                    var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
                    if (scrollItems[1].count > 0 && scrollItems[1].active)
                    {
                        scrollStartParent = wallObj.parent;
                        this.CallActionAfterDelayWithCoroutine(1f, ShowUseWallScrollMessasge);
                    }
                }
                if (!SaveManager.GameProgress.Current.tutorial17lvl && mainscript.CurrentLvl == 17)
                {
                    AnalyticsController.Instance.Tutorial(12, 0);

                    this.CallActionAfterDelayWithCoroutine(7f, ShowTutorial_ClickInfoButton);
                }
                if (!SaveManager.GameProgress.Current.tutorial19lvl && mainscript.CurrentLvl == 19)
                {
                    AnalyticsController.Instance.Tutorial(12, 0);
                    this.CallActionAfterDelayWithCoroutine(7f, ShowTutorial_ClickInfoButton);
                }
                if (!SaveManager.GameProgress.Current.tutorial22lvl && mainscript.CurrentLvl == 22)
                {
                    AnalyticsController.Instance.Tutorial(12, 0);
                    this.CallActionAfterDelayWithCoroutine(7f, ShowTutorial_ClickInfoButton);
                }
                if (mainscript.CurrentLvl == 3)
                {
                    StartCoroutine(ChangeSpellTutorialCoroutine());
                }
                if (!SaveManager.GameProgress.Current.tutorialx2Speed && mainscript.CurrentLvl == 4)
                {
                    AnalyticsController.Instance.Tutorial(14, 0);
                    Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.ENEMY_WAVE_SPAWNED, ShowDoubleSpeedTutorialOnWaveNumber);
                }
                if (!SaveManager.GameProgress.Current.tutorialx2Speed8lvl && mainscript.CurrentLvl == 8)
                {
                    AnalyticsController.Instance.Tutorial(14, 0);
                    Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.ENEMY_WAVE_SPAWNED, ShowDoubleSpeedTutorialOnWaveNumber);
                }
                if (SaveManager.GameProgress.Current.tutorialx2Speed && !SaveManager.GameProgress.Current.tutorialEasy && mainscript.CurrentLvl == 5)
                {
                    AnalyticsController.Instance.Tutorial(15, 0);
                    Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.ENEMY_WAVE_SPAWNED, ShowCasualTutorialOnWaveNumber);
                }
                else if (!SaveManager.GameProgress.Current.tutorialx2Speed && !SaveManager.GameProgress.Current.tutorialEasy && mainscript.CurrentLvl == 5)
                {
                    checkOldVersion = true;
                    AnalyticsController.Instance.Tutorial(15, 0);
                    Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.ENEMY_WAVE_SPAWNED, ShowSpeed2XAndCasualTutorialOnWaveNumber);
                }
                if (!SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.FIRST_CRYSTAL_INGAME] || mainscript.CurrentLvl == 2 || mainscript.CurrentLvl == 15)
                {
                    if (tutorialFirstCrystal != null)
                    {
                        Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.GEM_SPAWN, tutorialFirstCrystal.ShowMessage);
                        Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.ON_ITEM_PICKED_BY_PLAYER, tutorialFirstCrystal.OnItemPickedByPlayerGems);
                    }

                    tutorialFirstCrystal = new TutorialFirstCrystal(this, uiCamera, messages, pause, SaveManager.GameProgress.Current, PlaceHandPointer, CenterBlackOnObject);
                    tutorialFirstCrystal.tutor = this;
                    PlayerPrefs.SetInt("CanGrabCrystal",1);

                    Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.GEM_SPAWN, tutorialFirstCrystal.ShowMessage);
                    Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.ON_ITEM_PICKED_BY_PLAYER, tutorialFirstCrystal.OnItemPickedByPlayerGems);
                }
                if ((!SaveManager.GameProgress.Current.tutorialx2Speed && !SaveManager.GameProgress.Current.tutorialEasy) && mainscript.CurrentLvl > 5)
                {
                    CheckOldVersion();
                }

                StartLevel();
            }

            if (mainscript.CurrentLvl == 10 || mainscript.CurrentLvl == 20 || mainscript.CurrentLvl == 30 || mainscript.CurrentLvl == 40 ||
                mainscript.CurrentLvl == 50 || mainscript.CurrentLvl == 60 || mainscript.CurrentLvl == 70 || mainscript.CurrentLvl == 80 || mainscript.CurrentLvl == 90)
            {
                if (PlayerPrefs.GetInt("x2Speed") >= 5)
                {
                    this.CallActionAfterDelayWithCoroutine(2f, Show_DoubleSpeedButton);
                    PlayerPrefs.SetInt("x2Speed", 0);
                }
            }

            hand1 = pointerHand.transform.Find("Hand").gameObject.GetComponent<Image>();
            hand2 = pointerHand.transform.Find("FingerPointerPress").gameObject.GetComponent<Image>();
        }

        private void CheckOldVersion()
        {
            checkOldVersion = true;

            Enemy enemy = new Enemy();
            enemy.enemyNumber = EnemyType.zombie_fire;
            enemy.spawnPointX = 9.236074f;
            enemy.spawnPointY = -0.07949531f;

            var generator = EnemiesGenerator.Instance;
            generator.enemyWaves[generator.currentWave].enemies.Insert(0, enemy);
            foreach (var enem in generator.enemyWaves[generator.currentWave].enemies)
            {
                if (enem.spawnPointX < enemy.spawnPointX)
                {
                    enem.spawnPointX = enemy.spawnPointX + 5f;
                }
            }
            this.CallActionAfterDelayWithCoroutine(2f, ShowTutorial_DoubleSpeedButton);
        }

        private void ShowSpeed2XAndCasualTutorialOnWaveNumber(Core.BaseEventParams eventParams)
        {
            wavesSpawned++;
            Debug.Log($"ShowCasualTutorialOnWaveNumber: {wavesSpawned}");
            if (wavesSpawned == 3)
            {
                this.CallActionAfterDelayWithCoroutine(3f, ShowTutorial_DoubleSpeedButton);
            }
        }

        private void OnDestroy()
        {
            UI.ReplicaUI.OnReplicaComplete -= ReplicaUIOnReplicaComplete;
        }

        private void ReplicaUIOnReplicaComplete(UI.EReplicaID replicaID)
        {
            if (!SaveManager.GameProgress.Current.tutorial[0] && mainscript.CurrentLvl == 1)
            {
                if (replicaID == UI.EReplicaID.Level1_Boss)
                { 
                    StartCoroutine(ShootingTutorialCoroutine(1.0f, true));
                }
            }
            if (replicaID == UI.EReplicaID.Level2_Enemy && !SaveManager.GameProgress.Current.tutorialInfoLevel2 && mainscript.CurrentLvl == 2)
            {
                tutorialLevel2Complete = true;
                this.CallActionAfterDelayWithCoroutine(1f, ShowTutorial_ClickInfoButton);
            }
        }

        private void StartLevel()
        {
            enemiesController.SetActive(true);
        }

        #region GAME_EVENTS_CALLBACKS
        private void OnPotionUse(Core.BaseEventParams eventsParams)
        {
            var eventData = eventsParams.GetParameterSafe<PotionUseParameters>();
            if (!TutorialsManager.IsAnyTutorialActive)
            {
                switch (eventData.potionType)
                {
                    case PotionManager.EPotionType.Mana:
                        SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.USE_MANA_POTION);
                        break;
                    case PotionManager.EPotionType.Health:
                        SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.USE_HEALTH_POTION);
                        break;
                    case PotionManager.EPotionType.Power:
                        SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.USE_POWER_POTION);
                        break;
                }
            }
            else
            {
                switch (eventData.potionType)
                {
                    case PotionManager.EPotionType.Mana:
                        ContinueGame(7);
                        break;
                    case PotionManager.EPotionType.Health:
                        ContinueGame(6);
                        break;
                    case PotionManager.EPotionType.Power:
                        ContinueGame(10);
                        break;
                }
            }
        }

        private void OnLowHealth(Core.BaseEventParams eventParams)
        {
            if (mainscript.CurrentLvl == 5)
                return;

            if (EnemiesGenerator.Instance.currentWave == EnemiesGenerator.Instance.GetUsefulTotalWavesNumber)
                return;

            if (!SaveManager.GameProgress.Current.tutorial[5])
            {
                if (mainscript.CurrentLvl == 2 && SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.FIRST_CRYSTAL_INGAME])
                    ShowHealthPotionTutorial();
                else if (mainscript.CurrentLvl != 2)
                    ShowHealthPotionTutorial();
            }
            else if (!SaveManager.GameProgress.Current.tutorialPowerPotion)
            {
                if(mainscript.CurrentLvl == 2 && SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.FIRST_CRYSTAL_INGAME])
                    ShowPowerPotionTutorial();
                else if (mainscript.CurrentLvl != 2)
                    ShowPowerPotionTutorial();
            }
            Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.LOW_HEALTH, OnLowHealth);
        }

        private void OnLowMana(Core.BaseEventParams eventParams)
        {
            if (mainscript.CurrentLvl == 5)
                return;

            if (EnemiesGenerator.Instance.currentWave == EnemiesGenerator.Instance.GetUsefulTotalWavesNumber)
                return;

            if (!SaveManager.GameProgress.Current.tutorial[6] && !TutorialsManager.IsAnyTutorialActive)
                ShowManaPotionTutorial();

            Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.LOW_MANA, OnLowMana);
        }
        #endregion

        #region HAND POINTER RELATED
        public void PlaceHandPointer(Vector3 rectPos, bool loopIt)
        {
            rectPos.z = 0;
            pointerHand.GetComponent<RectTransform>().position = rectPos;
            if (loopIt)
            {
                animatePointer = true;
                loopHand = StartCoroutine(LoopHandPoint());
            }
        }

        public void RotateHandPointer(float zAngle)
        {
            pointerHand.GetComponent<RectTransform>().eulerAngles = new Vector3(0f, 0f, zAngle);
        }

        IEnumerator LoopHandPoint()
        {
            if (hand1 == null || hand2 == null)
                yield break;

            hand1.color = new Color(1f, 1f, 1f, 1f);
            hand2.color = new Color(1f, 1f, 1f, 1f);
            var click = false;
            while (animatePointer == true)
            {
                hand2.gameObject.SetActive(animatePointer ? click : false);
                hand1.gameObject.SetActive(animatePointer? !click : false);
                yield return new WaitForSecondsRealtime(click ? 0.2f : 0.5f);
                click = !click;
                if (!animatePointer)
                    break;
            }
            if (streamReplica == null)
            {
                hand1.color = new Color(1f, 1f, 1f, 0f);
                hand2.color = new Color(1f, 1f, 1f, 0f);
            }

            yield break;
        }

        public void HideHandPointer()
        {
            StopHandCoroutines();

            Debug.Log("HideHandPointer");
            if (hand1 != null)
            {
                hand1.gameObject.SetActive(false);
            }
            if (hand2 != null)
            {
                hand2.gameObject.SetActive(false);
            }

            ResetHands();
        }
        
        private void StopHandCoroutines()
        {
            animatePointer = false;

            if (loopHand != null)
            {
                StopCoroutine(LoopHandPoint());
            }
        }

        private void ResetHands()
        {
            if (hand1 != null)
            {
                hand1.color = new Color(1f, 1f, 1f, 0f);
                hand1.gameObject.SetActive(true);
            }
            if (hand2 != null)
            {
                hand2.gameObject.SetActive(false);
            }
            if (pointerHand != null)
            {
                pointerHand.transform.localScale = HandDefaultScale;
                pointerHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            Debug.Log("Reset Tutorial Hands");
        }
        #endregion

        #region Tutorial 1 On First Level(Kill enemy -> pick up a Coin -> Open Casket )

        private IEnumerator ShootingTutorialCoroutine(float startDelay, bool secondTime)
        {
            TapController.Current.lastCantShoot = true;

            yield return new WaitForSeconds(startDelay);

            EnemyCharacter targetEnemy = null; 
            while (true)
            {
                if (EnemiesGenerator.Instance != null)
                {
                    foreach (EnemyCharacter enemy in EnemiesGenerator.Instance.enemiesOnLevelComponents)
                    {
                        if (enemy.enemyType != EnemyType.zombie_boss && enemy.IsOnGameField)
                        {
                            targetEnemy = enemy;
                            break;
                        }
                    }
                }

                if (targetEnemy != null)
                    break;

                yield return null;
            }

            if (secondTime)
            {
                targetEnemy.getCoin = true;
                shouldStartCoinTutorial = true;
                characterLayersChanger = new CharacterLayerChangerForReplica(PlayerController.Instance.m_mageRendererObjects);
            }

            AnalyticsController.Instance.Tutorial(1, 0);

            yield return new WaitForSeconds(0.5f);

            shootingTutorialInProcess = true;
            SaveManager.GameProgress.Current.tutorial[1] = false;

            if (!secondTime)
            {
                UIOver.Set(true, Mana.Current.manaBar.transform.parent.gameObject);
                UIOver.Set(true, ShotController.Current.spells[0].progressBar.transform.parent.gameObject);
                characterLayersChanger = new CharacterLayerChangerForReplica(PlayerController.Instance.m_mageRendererObjects);
            }

            Vector3 enemyPosition = Vector3.zero;
            if (targetEnemy != null)
                enemyPosition = targetEnemy.transform.position;
            CenterBlackOnObject(messages[1].transform.GetChild(0).GetComponent<RectTransform>(), enemyPosition + new Vector3(-0.1f, 0.5f, 0f));
            PlaceHandPointer(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(enemyPosition)) + new Vector3(-3.5f, 20f, 0f), true);
            messages[1].SetActive(true);

            Time.timeScale = 0f;
            pause.pauseCalled = true;
            TapController.Current.lastCantShoot = false;
        }

        public void OnShotPerformed()
        {
            AnalyticsController.Instance.LogMyEvent("FirstShotTutorialComplete");

            if (shootingTutorialInProcess)
            {
                ContinueGame(1);
                shootingTutorialInProcess = false;

                if (shouldStartCoinTutorial)
                {
                    StartCoroutine(CoinTutorialCoroutine());
                    shouldStartCoinTutorial = false;
                }
            }
        }

        #region Tutorial 3 ( Where player must pick up coin )
        public IEnumerator CoinTutorialCoroutine()
        {
            GameObject coinObj = null;

            while (true)
            {
                coinObj = GameObject.FindGameObjectWithTag(GameConstants.COIN_TAG);
                if (coinObj != null && coinObj.activeSelf)
                    break;
                else
                    yield return null;
            }

            yield return new WaitForSeconds(2.8f);

            if (coinObj == null)
                yield break;


            characterLayersChanger.SetDefaultLayers();
            AnalyticsController.Instance.Tutorial(1, 2);
            CasketWithNewItem.CasketSpawned += ShowMessage_4;
        

            ContinueGame(2);

            // Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.ON_ITEM_PICKED_BY_PLAYER, OnItemPickedByPlayerCoins);
            //         
            // UIOver.ClearAll();
            // if (!shouldStartCoinTutorial)
            // {
            //     messages[2].SetActive(true);
            //     Time.timeScale = 0f;
            //     pause.pauseCalled = true;
            //
            //     // Вычисляю позицию монеты и стрелки через экранные координаты, т.к. один объект на сцене, а другой UI
            //     GameObject arrow = messages[2].transform.GetChild(2).gameObject;
            //     RectTransform arrowRT = arrow.GetComponent<RectTransform>();
            //     Vector3 coinPosition = coinObj.transform.GetChild(0).position;
            //     Vector3 handPos = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(coinPosition));
            //     CenterBlackOnObject(messages[2].transform.GetChild(0).GetComponent<RectTransform>(), coinPosition);
            //     PlaceHandPointer(handPos, true);
            // }
        }

        // public void OnItemPickedByPlayerCoins(Core.BaseEventParams eventParams)
        // {
        //     Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.ON_ITEM_PICKED_BY_PLAYER, OnItemPickedByPlayerCoins);
        //     UI.UIBattleElementPositionHolder.EUIElementType elementType = eventParams.GetParameterUnSafe<UI.UIBattleElementPositionHolder.EUIElementType>();
        //     if (elementType == UI.UIBattleElementPositionHolder.EUIElementType.COINS)
        //     {
        //         characterLayersChanger.SetDefaultLayers();
        //         AnalyticsController.Instance.Tutorial(1, 2);
        //         CasketWithNewItem.CasketSpawned += ShowMessage_4;
        //     }
        //
        //     ContinueGame(2);
        // }
        #endregion

        public void ShowMessage_4()
        {

            if (messages[3] != null)
            {
                CasketWithNewItem.CasketSpawned -= ShowMessage_4;
                SaveManager.GameProgress.Current.tutorial[1] = false; // Вторая часть туториала - магазин
                messages[3].SetActive(true);
                GameObject casketPos = GameObject.FindGameObjectWithTag(GameConstants.CASKET_TAG);
                CenterBlackOnObject(messages[3].transform.GetChild(0).GetComponent<RectTransform>(), casketPos.transform.position + new Vector3(0f, -0.2f, 0f));
                PlaceHandPointer(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(casketPos.transform.position)), true);
                SaveManager.GameProgress.Current.Save();
                pause.pauseCalled = true;
                Time.timeScale = 0f;
                CasketWithNewItem.CasketCollected += ShowMessage_5;
            }
        }

        public void ShowMessage_5()
        {
            AnalyticsController.Instance.Tutorial(1, 3);
            CasketWithNewItem.CasketCollected -= ShowMessage_5;
            //messages[4].SetActive(true);

            // Сохраняем прохождение первой части туториала
            //progress.tutorial[0] = true;
            SaveManager.GameProgress.Current.tutorial[1] = false; // Вторая часть туториала - магазин
            SaveManager.GameProgress.Current.Save();
        }
        #endregion

        private void CenterBlackOnObject(RectTransform _black, Vector3 _objectPos)
        {
            Vector3 new_pos = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(_objectPos));
            new_pos.z = 0;
            _black.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.8f);
            _black.position = new Vector3(new_pos.x, new_pos.y, _black.position.z);
        }

        #region Tutorial 4 ( Where player must use scroll on enemy )
        private void ShowUseAcidScrollMessasge()
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            if (scrollItems[0].count == 0)
            {
                SaveManager.GameProgress.Current.tutorial[0] = true;
                SaveManager.GameProgress.Current.tutorial[4] = true;
                SaveManager.GameProgress.Current.Save();
                return;
            }

            AnalyticsController.Instance.LogMyEvent("FirstSrollTutorialComplete");

            var e = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
            first_enemy = e[0];
            if (first_enemy != null && first_enemy.transform.position.x < 9.5f)
            {
                TutorialsManager.OnTutorialStart(ETutorialType.USE_ACID_SCROLL);
                scrollObj.SetParent(scrollNewParent);
                CenterBlackOnObject(messages[5].transform.GetChild(0).GetComponent<RectTransform>(), first_enemy.transform.position + new Vector3(-1.5f, -0.7f, 0f));
                PlaceHandPointer(scrollObj.position + new Vector3(4f, 20f, 0f), false);
                RotateHandPointer(-95f);
                animatePointer = true;
                messages[5].SetActive(true);
                Time.timeScale = 0f;
                pause.pauseCalled = true;

                // Сохраняем прохождение первой части туториала
                SaveManager.GameProgress.Current.tutorial[0] = true;
                SaveManager.GameProgress.Current.tutorial[4] = true;
                SaveManager.GameProgress.Current.Save();

                StartCoroutine(UseScrollAnimation(messages[5].transform.GetChild(0).GetChild(0).position + new Vector3(-4.6f, 0.8f, 0f)));
            }
            else
            {
                this.CallActionAfterDelayWithCoroutine(0.1f, ShowUseAcidScrollMessasge);
            }
        }

        private void ShowUseZombieScrollMessasge()
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            if (scrollItems[4].count == 0)
            {
                return;
            }
            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                if (i != 4)
                    ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = false;
            }

            // TutorialsManager.OnTutorialStart(ETutorialType.USE_ACID_SCROLL);
            zombieObj.SetParent(scrollNewParent);
            CenterBlackOnObject(messages[5].transform.GetChild(0).GetComponent<RectTransform>(), centerZombie.position);
            RotateHandPointer(-95f);
            PlaceHandPointer(zombieObj.position + new Vector3(4f, 20f, 0f), false);
            animatePointer = true;
            messages[5].SetActive(true);
            messages[5].transform.Find("TutorTextBar").gameObject.SetActive(false);
            Time.timeScale = 0f;
            pause.pauseCalled = true;

          
            StartCoroutine(UseScrollAnimation(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(centerZombie.position))));
        }

        public void CloseZombieTutorial()
        {
            if (SaveManager.GameProgress.Current.tutorialMyZombie)
                return;
            zombieObj.SetParent(scrollStartParent);
            SaveManager.GameProgress.Current.tutorialMyZombie = true;
            SaveManager.GameProgress.Current.Save();
            messages[5].SetActive(false);
            Time.timeScale = LevelSettings.defaultUsedSpeed;
            pause.pauseCalled = false;
            pointerHand.gameObject.SetActive(false);
            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = true;
            }
        }

        private void ShowUseWallScrollMessasge()
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);

            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                if (i != 1)
                    ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = false;
            }

            //TutorialsManager.OnTutorialStart(ETutorialType.);
            wallObj.SetParent(scrollNewParent);
            CenterBlackOnObject(messages[5].transform.GetChild(0).GetComponent<RectTransform>(), wallCenter.position);
            RotateHandPointer(-95f);
            PlaceHandPointer(wallObj.position + new Vector3(4f, 20f, 0f), true);
            animatePointer = true;
            messages[5].SetActive(true);
            messages[5].transform.Find("TutorTextBar").gameObject.SetActive(false);
            Time.timeScale = 0f;
            pause.pauseCalled = true;

            corWall = StartCoroutine(UseScrollAnimation(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(wallCenter.position))));
        }

        public void CloseWallTutorial()
        {
            if (SaveManager.GameProgress.Current.tutorial5wall)
                return;
            wallObj.SetParent(scrollStartParent);
            SaveManager.GameProgress.Current.tutorial5wall = true;
            SaveManager.GameProgress.Current.Save();
            messages[5].SetActive(false);
            Time.timeScale = LevelSettings.defaultUsedSpeed;
            pause.pauseCalled = false;
            HideHandPointer();
            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = true;
            }

            this.CallActionAfterDelayWithCoroutine(4, ShowTutorial_ClickInfoButton);
        }

        private void ShowUseIceScrollMessasge()
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            if (scrollItems[1].count == 0)
            {
                return;
            }

            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                if (i != 2)
                    ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = false;
            }

            // TutorialsManager.OnTutorialStart(ETutorialType.USE_ACID_SCROLL);
            centerWind.SetParent(scrollNewParent);
            CenterBlackOnObject(messages[5].transform.GetChild(0).GetComponent<RectTransform>(), wallCenter.position);
            RotateHandPointer(-95f);
            PlaceHandPointer(centerWind.position + new Vector3(4f, 20f, 0f), false);
            animatePointer = true;
            messages[5].SetActive(true);
            messages[5].transform.Find("TutorTextBar").gameObject.SetActive(false);
            Time.timeScale = 0f;
            pause.pauseCalled = true;


            corWall = StartCoroutine(UseScrollAnimation(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(wallCenter.position))));
        }

        public void CloseIceTutorial()
        {
            if (SaveManager.GameProgress.Current.tutorial8lvl)
                return;
            centerWind.SetParent(scrollStartParent);
            SaveManager.GameProgress.Current.tutorial8lvl = true;
            SaveManager.GameProgress.Current.Save();
            messages[5].SetActive(false);
            Time.timeScale = LevelSettings.defaultUsedSpeed;
            pause.pauseCalled = false;
            pointerHand.gameObject.SetActive(false);
            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = true;
            }
        }

        private void ShowUseMineScrollMessasge()
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            if (scrollItems[3].count == 0)
            {
                return;
            }

            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                if (i != 3)
                    ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = false;
            }

            // TutorialsManager.OnTutorialStart(ETutorialType.USE_ACID_SCROLL);
            mineObj.SetParent(scrollNewParent);
            CenterBlackOnObject(messages[5].transform.GetChild(0).GetComponent<RectTransform>(), mineCenter.position);
            RotateHandPointer(-95f);
            PlaceHandPointer(mineObj.position + new Vector3(4f, 20f, 0f), false);
            animatePointer = true;
            messages[5].SetActive(true);
            messages[5].transform.Find("TutorTextBar").gameObject.SetActive(false);
            Time.timeScale = 0f;
            pause.pauseCalled = true;
            StartCoroutine(UseScrollAnimation(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(mineCenter.position))));
        }

        public void CloseMineTutorial()
        {
            if (SaveManager.GameProgress.Current.tutorial12mine)
                return;
            Debug.Log("MINE ________________ CLOSE TUTORIAL");
            mineObj.SetParent(scrollStartParent);
            SaveManager.GameProgress.Current.tutorial12mine = true;
            SaveManager.GameProgress.Current.Save();
            messages[5].SetActive(false);
            Time.timeScale = LevelSettings.defaultUsedSpeed;
            pause.pauseCalled = false;
            pointerHand.gameObject.SetActive(false);
            for (int i = 0; i < ScrollController.Instance.scrolls.Length; i++)
            {
                ScrollController.Instance.scrolls[i].raycastGraphick.raycastTarget = true;
            }
        }
        #endregion

        #region Tutorial 5 (Where player must use Health potion )
        private void ShowHealthPotionTutorial()
        {
            if (TutorialsManager.IsAnyTutorialActive)
                return;

            TutorialsManager.OnTutorialStart(ETutorialType.USE_HEALTH_POTION);
            AnalyticsController.Instance.Tutorial(5, 0);
            PotionManager.AddPotionForTutorial(PotionManager.EPotionType.Health);

            var tutor = Tutorial.Open(target: healthObj.gameObject, focus: new Transform[] { healthObj.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 90), offset: new Vector2(20f, 60f), waiting: 0f, keyText: "t_0254");
            tutor.dublicateObj = false;
            healthObj.gameObject.GetComponent<Button>().onClick.AddListener(ClickHealthButton); 
            Time.timeScale = 0f;
            pause.pauseCalled = true;

            // Сохраняем прохождение первой части туториала
            SaveManager.GameProgress.Current.tutorial[5] = true;
            SaveManager.GameProgress.Current.Save();
        }

        private void ClickHealthButton()
        {
            Tutorial.Close();
            healthObj.gameObject.GetComponent<Button>().onClick.RemoveListener(ClickHealthButton);
        }

        #endregion

        #region Tutorial 6 (Where player must use Mana potion )
        private void ShowManaPotionTutorial()
        {
            if (TutorialsManager.IsAnyTutorialActive)
                return;
            
            TutorialsManager.OnTutorialStart(ETutorialType.USE_MANA_POTION);
            AnalyticsController.Instance.Tutorial(6, 0);
            PotionManager.AddPotionForTutorial(PotionManager.EPotionType.Mana);
            
            var tutor = Tutorial.Open(target: manaObj.gameObject, focus: new Transform[] { manaObj.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 90), offset: new Vector2(30f, 80f), waiting: 0f, keyText: "t_0026");
            tutor.dublicateObj = false;
            manaObj.gameObject.GetComponent<Button>().onClick.AddListener(ClickManaButton);
            
            Time.timeScale = 0f;
            pause.pauseCalled = true;
            
        
            
            // Сохраняем прохождение первой части туториала
            SaveManager.GameProgress.Current.tutorial[6] = true;
            SaveManager.GameProgress.Current.Save();
        }

        private void ClickManaButton()
        {
            Tutorial.Close();
            manaObj.gameObject.GetComponent<Button>().onClick.RemoveListener(ClickManaButton);
        }
        #endregion

        #region Tutorial 7 (Where player must use new spell)
        [HideInInspector]
        public bool showingSecondSpellTutor;
        public void ShowMessage_9(int spellPlaceId)
        {
            if (mainscript.CurrentLvl != 3) return;
            if (SaveManager.GameProgress.Current.tutorial[7]) return;

            showingSecondSpellTutor = true;
            spellsPlaces[spellPlaceId].SetParent(spellsNewParent);
            RotateHandPointer(-55f);
            PlaceHandPointer(spellsPlaces[spellPlaceId].position + new Vector3(0f, 0f, 0f), true);
            messages[8].SetActive(true);
            Time.timeScale = 0f;
            pause.pauseCalled = true;

            // Сохраняем прохождение первой части туториала
            SaveManager.GameProgress.Current.tutorial[7] = true;
            SaveManager.GameProgress.Current.Save();

        }
        #endregion

        #region Change Spell Tutorial ( 3 level )
        private IEnumerator ChangeSpellTutorialCoroutine()
        {
            ShotController shotContoller = ShotController.Current;
            if (shotContoller == null)
                yield break;

            while (true)
            {
                if (shotContoller.currentSpellIndex == 0)
                    yield return null;
                else
                    break;
            }

            while (true)
            {
                if (EnemiesGenerator.Instance != null && EnemiesGenerator.Instance.currentWave == EnemiesGenerator.Instance.GetUsefulTotalWavesNumber)
                    break;

                if (shotContoller.currentSpellIndex == 0)
                    yield break;

                yield return null;
            }

            float startTime = Time.time;
            while (Time.time - startTime < 6.0f)
            {
                if (shotContoller.currentSpellIndex == 0)
                    yield break;

                yield return null;
            }

            Time.timeScale = 0f;
            shotContoller.changeSpellTutorial = true;

            shotContoller.spells[0].SetSpellActive();
            shotContoller.spells[0].SetSpellCostInActive();

            var tutor = Tutorial.Open(target: shotContoller.GetSpellButtonObject(0), focus: new Transform[] { shotContoller.GetSpellButtonObject(0).transform }, mirror: false, rotation: new Vector3(0, 0, 60), offset: new Vector2(75, 90), waiting: 0f, keyText: "");
            tutor.dublicateObj = false;

            while (true)
            {
                if (shotContoller.currentSpellIndex != 0)
                    yield return null;
                else
                    break;
            }

            shotContoller.changeSpellTutorial = false;

            Time.timeScale = LevelSettings.Current.usedGameSpeed;
            Tutorial.Close();
        }
        #endregion

        #region Change Spell Tutorial Click
        public IEnumerator ChangeSpellTutorialClickCoroutine() 
        {
            ShotController shotContoller = ShotController.Current;
            if (shotContoller == null)
                yield break;

            var spellIndex = shotContoller.currentSpellIndex;

            int randIndex = 0;

            while (spellIndex == randIndex)
            {
                randIndex = UnityEngine.Random.Range(0, shotContoller.GetSpellIsUse());
            }

            
            Time.timeScale = 0f;
            shotContoller.changeSpellTutorial = true;
            TutorialsManager.OnTutorialStart(ETutorialType.CHANGE_SPELL);

            var spell = shotContoller.GetSpellButtonObject(randIndex);

            shotContoller.spells[randIndex].SetSpellActive();
            shotContoller.spells[randIndex].SetSpellCostActive();

            var tutor = Tutorial.Open(target: spell, focus: new Transform[] { spell.transform }, mirror: false, rotation: new Vector3(0, 0, 60), offset: new Vector2(75, 90), waiting: 0f, keyText: "");
            tutor.dublicateObj = false;
            while (TutorialsManager.ActiveTutorial == ETutorialType.CHANGE_SPELL)
            {
                if (shotContoller.currentSpellIndex != randIndex)
                    yield return null;
                else
                    break;
            }
            CloseChangeSpellTutorial(tutor.gameObject);
        }

        private void CloseChangeSpellTutorial(GameObject tutor)
        {
            ShotController.Current.tutorialIsViewed = true;
            ShotController.Current.changeSpellTutorial = false;

            TutorialsManager.OnTutorialStart(ETutorialType.None);
            Tutorial.Close();

            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }
        #endregion

        #region Tutorial 14 (Where player must use Power potion to regen health )
        private void ShowPowerPotionTutorial()
        {
            if (TutorialsManager.IsAnyTutorialActive)
                return;

            if (EnemiesGenerator.Instance.currentWave == EnemiesGenerator.Instance.GetUsefulTotalWavesNumber)
                return;

            TutorialsManager.OnTutorialStart(ETutorialType.USE_POWER_POTION);
            AnalyticsController.Instance.Tutorial(14, 0);
            PotionManager.AddPotionForTutorial(PotionManager.EPotionType.Power);

            var tutor = Tutorial.Open(target: powerPotionObj.gameObject, focus: new Transform[] { powerPotionObj.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 90), offset: new Vector2(30f, 80f), waiting: 0f, keyText: "t_0313");
            tutor.dublicateObj = false;
            powerPotionObj.gameObject.GetComponent<Button>().onClick.AddListener(ClickPowerButton);

            Time.timeScale = 0f;
            pause.pauseCalled = true;
            SaveManager.GameProgress.Current.tutorialPowerPotion = true;
            SaveManager.GameProgress.Current.Save();
        }

        private void ClickPowerButton()
        {
            Tutorial.Close();
            powerPotionObj.gameObject.GetComponent<Button>().onClick.RemoveListener(ClickPowerButton);
        }
        #endregion

        #region Tutorial 12 (Player must click on info button on 5 level )
        public void ShowTutorial_ClickInfoButton()
        {
            // skip tutorial with info button
            OnInfoButtonTutorialComplete();
            
            // if (!infoButton.gameObject.activeSelf)
            // {
            //     return;
            // }
            //
            // TutorialsManager.OnTutorialStart(ETutorialType.CLICK_INFO_BUTTON_LVL_5);
            // Button infoButtonComp = infoButton.GetComponent<Button>();
            // infoButtonComp.enabled = true;
            // infoButtonComp.onClick.AddListener(InfoButtonTutorialCallback);
            // TutorialUtils.AddCanvasOverride(infoButton.gameObject);
            //
            // RotateHandPointer(0f);
            // PlaceHandPointer(infoButton.position + new Vector3(35f, 25f, 0f), true);
            // messages[9].SetActive(true);
            // Time.timeScale = 0f;
            // pause.pauseCalled = true;
            // pointerHand.transform.localScale = new Vector3(-0.8f, 0.8f, 1f);
        }

        private void InfoButtonTutorialCallback()
        {
            infoButton.GetComponent<Button>().onClick.RemoveListener(InfoButtonTutorialCallback);
            OnInfoButtonTutorialComplete();
        }

        private void OnInfoButtonTutorialComplete()
        {
            if (mainscript.CurrentLvl == 2)
            {
                if (TutorialsManager.IsAnyTutorialActive)
                {
                    HideHandPointer();
                    TutorialUtils.ClearAllCanvasOverrides();
                    pause.pauseCalled = false;
                    messages[9].SetActive(false);
                    AnalyticsController.Instance.Tutorial(12, 1);
                    TutorialsManager.OnTutorialCompleted();
                    TutorialsManager.MarkTutorialAsComplete(ETutorialType.CASUAL_MODE_BUTTON);
                }
                else
                {
                    SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.CLICK_INFO_BUTTON_LVL_5);
                }
            }
            else if(mainscript.CurrentLvl == 5)
            {
                //Tutorial.Close();
                HideHandPointer();
                TutorialUtils.ClearAllCanvasOverrides();
                pause.pauseCalled = false;
                messages[9].SetActive(false);

                //
                Tutorial.Close();
                SaveManager.GameProgress.Current.tutorial5lvl = true;
                SaveManager.GameProgress.Current.Save();
                // Remove

                //StartCoroutine(_Info2());
            }
            else if (mainscript.CurrentLvl == 17 || mainscript.CurrentLvl == 19 || mainscript.CurrentLvl == 22)
            {
                HideHandPointer();
                TutorialUtils.ClearAllCanvasOverrides();
                pause.pauseCalled = false;
                messages[9].SetActive(false);
                Tutorial.Open(target: messages[9], focus: null, mirror: false,
                      rotation: new Vector3(0, 0, 0), offset: new Vector2(-3000, 40), waiting: 0, keyText: "");

               
            }
            else if (mainscript.CurrentLvl == 7)
            {
                HideHandPointer();
                TutorialUtils.ClearAllCanvasOverrides();
                pause.pauseCalled = false;
                messages[9].SetActive(false);
                StartCoroutine(_Info2());
            }
        }
        IEnumerator _Info2()
        {
            yield return new WaitForEndOfFrame();
            var o = FindObjectOfType<InfoBasePanel>();
            foreach(var x in o.infoParameterLines)
            {
                if(x.gameObject.GetComponent<InfoParameterLineIcon>() != null)
                {
                    var btn = x.gameObject.GetComponent<InfoParameterLineIcon>().firsIcon.gameObject;
                    btn.GetComponent<Button>().onClick.AddListener(() => {
                        Tutorial.Close();
                        SaveManager.GameProgress.Current.tutorial5lvl = true;
                        SaveManager.GameProgress.Current.Save();
                    });
                    var t = Tutorial.Open(target: btn, focus: new Transform[] { o.transform }, mirror: false,
                        rotation: new Vector3(0, 0, 0), offset: new Vector2(30, 40), waiting: 0, keyText: ""); // "t_0637"
                    t.disableAnimation = true;
                    t.mainPanel.GetComponent<Image>().color = new Color(0,0,0,0);
                    break;
                }
            }
           
        }
        #endregion

        #region Tutorial 15 (Player must click on Double speed button on level 3)
        private void ShowTutorial_DoubleSpeedButton()
        {
            StartCoroutine(Tutorial_DoubleSpeedButton());
        }

        private IEnumerator Tutorial_DoubleSpeedButton()
        {
            while (TutorialsManager.IsAnyTutorialActive == true) yield return null;

            pause.pauseCalled = true;
            pause.Pause();

            doubleSpeedButton = FindObjectOfType<UIDoubleSpeedButton>().transform;

            TutorialsManager.OnTutorialStart(ETutorialType.DOUBLE_SPEED_BUTTON);

            Button doubleSpeedComp = doubleSpeedButton.GetComponent<Button>();
            doubleSpeedComp.enabled = true;
            doubleSpeedComp.onClick.AddListener(DoubleSpeedTutorialCallback);

            TutorialUtils.AddCanvasOverride(doubleSpeedButton.gameObject);
            RotateHandPointer(-120f);
            PlaceHandPointer(doubleSpeedButton.position + new Vector3(0f, 10f, 0f), true);

            messages[12].SetActive(true);
            pointerHand.transform.localScale = new Vector3(-0.8f, -0.8f, 1f);

            var btn = FindObjectOfType<UIDoubleSpeedButton>();
            btn.requiredEnable = true;
            btn._anim.gameObject.SetActive(false);

            SaveManager.GameProgress.Current.Save();
        }

        private void Show_DoubleSpeedButton()
        {
            var _doubleSpeedButton = FindObjectOfType<UIDoubleSpeedButton>();
            _doubleSpeedButton.PlayShow();
            if (mainscript.CurrentLvl == 8)
            { 
                SaveManager.GameProgress.Current.tutorialx2Speed8lvl = true;
                SaveManager.GameProgress.Current.Save();
            }
        }

        private void DoubleSpeedTutorialCallback()
        {
            Debug.Log($"DoubleSpeedTutorialCallback");
            doubleSpeedButton.GetComponent<Button>().onClick.RemoveListener(DoubleSpeedTutorialCallback);
            OnDoubleSpeedTutorialComplete();
        }

        private void OnDoubleSpeedTutorialComplete()
        {
            if (TutorialsManager.IsAnyTutorialActive)
            {
                HideHandPointer();
                TutorialUtils.ClearAllCanvasOverrides();
                //Time.timeScale = LevelSettings.Current.usedGameSpeed;
                pause.Continue();
                messages[12].SetActive(false);
                AnalyticsController.Instance.Tutorial(15, 1);
                TutorialsManager.OnTutorialCompleted();
            }
            else
            {
                SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.DOUBLE_SPEED_BUTTON);
            }

            if (checkOldVersion)
                ShowTutorial_CasualGameButton();
        }

        private void ShowDoubleSpeedTutorialOnWaveNumber(Core.BaseEventParams eventParams)
        { 
            wavesSpawned++;
            Debug.Log($"$ShowDoubleSpeedTutorialOnWaveNumber: {wavesSpawned}");
            if (wavesSpawned == 3 && mainscript.CurrentLvl == 4)
            {
                this.CallActionAfterDelayWithCoroutine(2f, ShowTutorial_DoubleSpeedButton);
                return;
            }
            if (wavesSpawned == 2 && mainscript.CurrentLvl == 8)
            {
                this.CallActionAfterDelayWithCoroutine(2f, Show_DoubleSpeedButton);
                return;
            }
        }


        #endregion

        #region Tutorial 16 (Player must click on Casual game button on level 5)
        private void ShowTutorial_CasualGameButton()
        {
            if (UIAutoHelpersWindow.saveData.auto_pick_purchase == "1")
                return;
            UIAutoHelperButton.instance._anim.gameObject.SetActive(false);
            casualGameButton = FindObjectOfType<UIAutoHelperButton>().transform;
            if (corWall != null)
                StopCoroutine(corWall);
            TutorialsManager.OnTutorialStart(ETutorialType.CASUAL_MODE_BUTTON);
            Button casualGameComp = casualGameButton.GetComponent<Button>();
            casualGameComp.enabled = true;
            casualGameComp.onClick.AddListener(CasualGameTutorialCallback);
           
            UIAutoHelperButton.instance._anim.gameObject.SetActive(false);

            pause.pauseCalled = true;
            pause.Pause();
            var o = Tutorial.Open(target: casualGameButton.gameObject, focus: new Transform[] { casualGameButton.transform }, mirror: false, rotation: new Vector3(0, 0, 30), offset: new Vector2(60, 30), waiting: 0, keyText: "t_0638");
            o.dublicateObj = false;
        }

        private void CasualGameTutorialCallback()
        {
            OnCasualGameTutorialComplete();
            casualGameButton.GetComponent<Button>().onClick.RemoveListener(CasualGameTutorialCallback);
        }

        private void OnCasualGameTutorialComplete()
        {
            if (TutorialsManager.IsAnyTutorialActive)
            {
                AnalyticsController.Instance.Tutorial(16, 1);
                TutorialsManager.OnTutorialCompleted();
                TutorialsManager.MarkTutorialAsComplete(ETutorialType.CASUAL_MODE_AUTO_HP);
                Tutorial.Close();
            }
            else
            {
                SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.CASUAL_MODE_BUTTON);
            }

            this.CallActionAfterDelayWithCoroutine(0, () => ShowTutorial_CasualGameAutoManaCheckbox(), true);
        }

        #region Tutorial (Stream Spell Tutorial Level-5)
        private float gameSpeed;

        private IEnumerator CasualSpellStreamTutorial(int tutorialIndex = 17, float delay = 0.5f, EnemyType type = EnemyType.zombie_fire)
        {
            if (!TutorialsManager.IsAnyTutorialActive)
                TutorialsManager.OnTutorialStart(ETutorialType.STREAM_SPELL);

            yield return new WaitForSeconds(delay);

            gameSpeed = LevelSettings.Current.usedGameSpeed;

            var enemy = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
            foreach (var e in enemy)
            {
                if (e.GetComponent<EnemyCharacter>().enemyType == type)
                {
                    first_enemy = e;
                    break;
                }
            }

            if (first_enemy == null)
            {
                TutorialsManager.OnTutorialCompleted();
                yield break;
            }

            TapController.tutorial5IsStart = true;

            enemyPosition = first_enemy;

            messages[tutorialIndex].SetActive(true);
            CenterBlackOnObject(messages[tutorialIndex].transform.GetChild(0).GetComponent<RectTransform>(), new Vector3(first_enemy.transform.position.x, first_enemy.transform.position.y + 1f, first_enemy.transform.position.z));
            PlaceHandPointer(messages[tutorialIndex].transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().position, true);
            RotateHandPointer(0f);

            Time.timeScale = 0f;
        }

        GameObject enemyPosition;
        Coroutine handPosition = null;

        public void ResetHandStreamTutorial()
        {
            Time.timeScale = 0.5f;
            handPosition = StartCoroutine(SetHand());
        }

        private IEnumerator SetHand(bool isPressed = false)
        {
            if (!isPressed)
            {
                yield return new WaitForEndOfFrame();

                hand1.gameObject.SetActive(true);
                hand1.color = new Color(1, 1, 1, 1);
                hand2.gameObject.SetActive(false);

                yield return new WaitForSecondsRealtime(0.5f);
            }
            if (TapController.tutorial5IsStart)
            {
                hand2.gameObject.SetActive(true);
                hand2.color = new Color(1, 1, 1, 1);
                hand1.gameObject.SetActive(false);
            }
            else
            {
                hand2.gameObject.SetActive(false);
                hand1.gameObject.SetActive(false);
            }

        }

        private IEnumerator SetHandPosition()
        {
            EnemyCharacter character = null;
            if (enemyPosition != null)
            {
                character = enemyPosition.gameObject.GetComponent<EnemyCharacter>();
            }
            while (TapController.tutorial5IsStart)
            {
                yield return new WaitForEndOfFrame();
                if (character != null && character.CurrentHealth > 0)
                {
                    PlaceHandPointer(uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint( 
                        new Vector3 (enemyPosition.transform.position.x, enemyPosition.transform.position.y + 1))), false);
                }
                else
                {
                    OnStreamTutorialComplete();
                    break;
                }
            }
            yield break;
        }

        public void OnShotClick(int index)
        {
            // if (streamReplica == null)
            // {
            //     messages[index].transform.GetChild(0).gameObject.SetActive(false);
            //     streamReplica = StartCoroutine(StreamReplica());
            //     StartCoroutine(SetHandPosition());
            //     StopHandCoroutines();
            //     StartCoroutine(SetHand(true));
            // }
            //
            // Time.timeScale = LevelSettings.Current.usedGameSpeed;
            //
            // if (pause != null)
            //     pause.pauseCalled = false;
            
            OnStreamTutorialComplete();
        }

        public void OnStreamTutorialComplete()
        {
            TapController.tutorial5IsStart = false;
            if (handPosition != null)
                StopCoroutine(handPosition);

            messages[17].gameObject.SetActive(false);
            Time.timeScale = gameSpeed;
            HideHandPointer();
            streamReplica = null;
            TutorialsManager.OnTutorialCompleted();
        }
        #endregion

        private void ShowTutorial_CasualGameAutoManaCheckbox()
        {
            var btn = FindObjectOfType<UIAutoHelperButton>();
            btn._anim.gameObject.SetActive(false);
            TutorialsManager.OnTutorialStart(ETutorialType.CASUAL_MODE_AUTO_HP);
            Tutorial.OpenBlock(timer:1.5f);
            var tut = Tutorial.Open(target: UIAutoHelpersWindow.instance._commonToogle.button.gameObject, focus: new Transform[] { UIAutoHelpersWindow.instance._commonToogle.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(90, 35), waiting: 1f, keyText: "");
            tut.disableAnimation = true;
            tut.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            UIAutoHelpersWindow.instance.btnClose.SetActive(false);
            UIAutoHelpersWindow.instance.isFree = true;
            UIAutoHelpersWindow.instance.btnFree.gameObject.SetActive(true);
            UIAutoHelpersWindow.instance._commonToogle.button.onClick.AddListener(CasualGameTutorialAutoManaCallback);
            Debug.Log("_________---_Click2");
        }

        private void CasualGameTutorialAutoManaCallback()
        {
            if (UIAutoHelpersWindow.instance._commonToogle.GetValue)
            {
                CasualGameTutorialAutoManaComplete();
                // hpCheckbox.GetComponent<Toggle>().onValueChanged.RemoveListener(CasualGameTutorialAutoManaCallback);
                UIAutoHelpersWindow.instance._commonToogle.button.onClick.RemoveListener(CasualGameTutorialAutoManaCallback);
            }
        }

        private void CasualGameTutorialAutoManaComplete()
        {
            if (TutorialsManager.IsAnyTutorialActive)
            {
                Tutorial.Close();
                pause.pauseCalled = false;
                AnalyticsController.Instance.Tutorial(17, 1);
                TutorialsManager.OnTutorialCompleted();

                UIAutoHelpersWindow.instance.btnFree.GetComponent<Button>().onClick.AddListener(OnTrySpells);
                var tut = Tutorial.Open(target:  UIAutoHelpersWindow.instance.btnFree, focus: new Transform[] { UIAutoHelpersWindow.instance.btnFree.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(150, 35), waiting: 0, keyText: "");
                tut.disableAnimation = true;
                tut.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                SaveManager.GameProgress.Current.tutorialEasy = true;
                SaveManager.GameProgress.Current.Save();

            }
            else
            {
                SaveManager.GameProgress.Current.tutorial = TutorialsManager.MarkTutorialAsComplete(ETutorialType.CASUAL_MODE_AUTO_HP);
            }
        }

        void OnTrySpells()
        {
            UIAutoHelpersWindow.instance.btnFree.GetComponent<Button>().onClick.RemoveListener(OnTrySpells);
            Tutorial.Close();
            UIAutoHelpersWindow.instance.btnClose.SetActive(true);
            StartCoroutine(CasualSpellStreamTutorial());
        }

        private void ShowCasualTutorialOnWaveNumber(Core.BaseEventParams eventParams)
        {
            wavesSpawned++;
            Debug.Log($"ShowCasualTutorialOnWaveNumber: {wavesSpawned}");
            if (wavesSpawned == 3)
            {
                this.CallActionAfterDelayWithCoroutine(3f, ShowTutorial_CasualGameButton);
            }
        }
        #endregion

        private IEnumerator UseScrollAnimation(Vector3 newPos)
        {
            Vector3 startHandPos = pointerHand.transform.position;
            GameObject hand1 = pointerHand.transform.Find("Hand").gameObject;
            GameObject hand2 = pointerHand.transform.Find("FingerPointerPress").gameObject;
            hand1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            while (animatePointer == true)
            {
                Debug.Log("UseScrollAnimation");
                float _timer = 0.2f;
                yield return new WaitForSecondsRealtime(1f);
                hand1.SetActive(true);
                hand2.SetActive(false);
                for (int i = 0; i < 10; i++)
                {
                    if (animatePointer != true)
                    {
                        break;
                    }
                    yield return new WaitForSecondsRealtime(_timer / 10f);
                }
                hand1.SetActive(false);
                hand2.SetActive(true);
                _timer = 0.1f;
                for (int i = 0; i < 10; i++)
                {
                    if (animatePointer != true)
                    {
                        break;
                    }
                    yield return new WaitForSecondsRealtime(_timer / 10f);
                }
                _timer = 0.2f;
                float speed = Vector3.Distance(startHandPos, newPos) / _timer;
                for (int i = 0; i < 10; i++)
                {
                    if (animatePointer != true)
                    {
                        break;
                    }
                    pointerHand.transform.position = Vector3.MoveTowards(pointerHand.transform.position, newPos, _timer / 10f * speed);
                    yield return new WaitForSecondsRealtime(_timer / 10f);
                }
                _timer = 0.2f;
                for (int i = 0; i < 10; i++)
                {
                    if (animatePointer != true)
                    {
                        break;
                    }
                    yield return new WaitForSecondsRealtime(_timer / 10f);
                }
                hand2.SetActive(false);
                hand1.SetActive(true);
                _timer = 0.2f;
                for (int i = 0; i < 10; i++)
                {
                    if (animatePointer != true)
                    {
                        break;
                    }
                    yield return new WaitForSecondsRealtime(_timer / 10f);
                }
                hand1.SetActive(false);
                pointerHand.transform.position = startHandPos;
            }
            hand1.GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0f);
            yield break;
        }

        private Coroutine streamReplica = null;

        public void ContinueGame(int messageIndex)
        {
            if ((/*mainscript.CurrentLvl == 2 ||*/ mainscript.CurrentLvl == 15) && PlayerPrefs.GetInt("CanGrabCrystal") == 1)
            {
                PlayerPrefs.SetInt("CanGrabCrystal",0);
                tutorialFirstCrystal.CollectCrystal();
            }

            animatePointer = false;
            Time.timeScale = LevelSettings.Current.usedGameSpeed;

            if (pause != null)
            {
                pause.pauseCalled = false;
            }

            messages[messageIndex].SetActive(false);

            if (messageIndex == 17)
                OnShotClick(17);

            switch (TutorialsManager.ActiveTutorial)
            {
                case ETutorialType.USE_ACID_SCROLL:
                    scrollObj.SetParent(scrollStartParent);
                    break;

                case ETutorialType.USE_MANA_POTION:
                    TutorialUtils.ClearAllCanvasOverrides();
                    break;

                case ETutorialType.USE_HEALTH_POTION:
                    TutorialUtils.ClearAllCanvasOverrides();
                    break;

                case ETutorialType.USE_POWER_POTION:
                    TutorialUtils.ClearAllCanvasOverrides();
                    break;
            }
            if (!TutorialsManager.IsTutorialActive(ETutorialType.BIRD))
            {
                HideHandPointer();
                TutorialsManager.OnTutorialCompleted();
            }
            pointerHand.transform.localScale = HandDefaultScale;
            if (spellsPlaces.Count > 0 && showingSecondSpellTutor)
            {
                showingSecondSpellTutor = false;
                for (int i = 0; i < spellsPlaces.Count; i++)
                    spellsPlaces[i].SetParent(spellsStartParent);
            }
        }
        private Coroutine streamTutorial;
        private IEnumerator StreamReplica()
        {
            yield return new WaitForSeconds(3f);
             UI.ReplicasConditionsChecker.Current.ShowMageReplica(UI.EReplicaID.Level5_Mage);
        }
    }
}