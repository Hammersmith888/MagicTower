#define SHOW_REPLICA_ALWAYS

using ADs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ReplicaUI : MonoBehaviour
    {
        public static event System.Action<EReplicaID> OnReplicaComplete;

        private const float TIME_TO_DESTROY_AFTER_HIDE = 1.05f;
        private const float ACTIVATE_CLOSE_OPTION_DELAY = 0f;

        private const string RESOURCES_FILE_NAME = "ReplicasData";
        private const string RESOURCES_UI_FILE_NAME = "UI/ReplicasUI";
        private const string RESOURCES_UI_IN_SHOP_FILE_NAME = "UI/ReplicasUI_Shop";
        

        #region VARIABLES
        [SerializeField]
        private Canvas canvasComponent;
        [SerializeField]
        private Animator animatorComponent;
        [SerializeField]
        private Image emotionImage;
        [SerializeField]
        private RectTransform emotionPivotRect;
        [SerializeField]
        private RectTransform chatBubbleRect;
        [SerializeField]
        private LocalTextLoc replicaTextLocalizeComponent;
        [Space(10f)]
        [SerializeField]
        [AnimatorHashParameterAttribute(animatorPropertyName = "animatorComponent")]
        private AnimatorPropertyHash hideReplicaAnimTrigger;
        [SerializeField]
        private bool closeByClick;
        //[SerializeField]
        private float showReplicaTime;

        public static GameObject currentReplica;

        [Space(10f)]
        //[SerializeField]
        private bool pauseTimeOnReplica;
        [SerializeField]
        private AnimationCurve pauseTimeCurve;
        [SerializeField]
        private float pauseTimeAnimTime;
        [SerializeField]
        private float changeGameTimeValue;
        [SerializeField]
        private RectTransform SkipButton;

        private bool isClosing;
        private float currentTimeScaleVal;
        private bool isGamePaused;
        private bool blocksPlayerInput;
        private bool restartLevelMusic;

        private EReplicaID replicaID;
        private CharacterLayerChangerForReplica characterLayersChanger;

        bool closeR = false;

        //TODO: Проверить что статические счетчики содержать корректные значения если прервать реплику и выйти из уровня на карту
        private static int currentlyActiveNumber;
        private static int currentlyActiveNumberOfReplicasThatBlocksInput;
        #endregion
        public static bool IsAnyActive
        {
            get
            {
                return currentlyActiveNumber > 0;
            }
        }

        public static void ResetStaticCounters()
        {
            currentlyActiveNumber = 0;
            currentlyActiveNumberOfReplicasThatBlocksInput = 0;
        }

        void Awake()
        {
            gameObject.AddComponent<ReplicaUIAutoDestroy>();
        }

        void Start()
        {
            currentlyActiveNumber++;
            if(SceneManager.GetActiveScene().name != "Map")
            StartCoroutine(DeactivateAfterSomeTime(ACTIVATE_CLOSE_OPTION_DELAY));
        }

        private void Activate(ReplicaData replicaData)
        {
            if(SkipButton)
            {
                if(SceneManager.GetActiveScene().name == "Level_1_Tutorial")
                {
                    SkipButton.gameObject.SetActive(true);
                }
            }
            if(FinishMenu.instance != null)
                GetComponent<Animator>().speed = FinishMenu.instance.indexSpeed;
            if (replicaData.BlockPlayerInput)
            {
                blocksPlayerInput = true;
                currentlyActiveNumberOfReplicasThatBlocksInput++;
                TapController.Current.lastCantShoot = true;
            }
            restartLevelMusic = replicaData.RestartLevelMusic;
            replicaID = replicaData.replicaID;
            canvasComponent.overrideSorting = true;
            canvasComponent.sortingOrder = 150;
            hideReplicaAnimTrigger.Hash();
            showReplicaTime = replicaData.showReplicaTime + replicaData.delayPlayReplicaSound;
            pauseTimeOnReplica = replicaData.pauseTimeOnReplica;
            if (replicaData.emotionImage == null)
            {
                emotionImage.color = new Color(emotionImage.color.r, emotionImage.color.g, emotionImage.color.b, 0);
            }
            emotionImage.sprite = replicaData.emotionImage;
            chatBubbleRect.anchoredPosition = replicaData.replicaBubbleAnchorePos;

            var replicaTextRect = replicaTextLocalizeComponent.GetComponent<RectTransform>();

            if (replicaData.FlipChatBubbleByX)
            {
                var chatBubblePivotTransform = chatBubbleRect.parent;
                var localScale = chatBubblePivotTransform.localScale;
                localScale.x *= -1f;
                chatBubblePivotTransform.localScale = localScale;

                localScale = replicaTextRect.localScale;
                localScale.x *= -1f;
                replicaTextRect.localScale = localScale;
                localScale = SkipButton.localScale;
                localScale.x *= -1f;
                SkipButton.localScale = localScale;
            }

            if (replicaData.scale != 1 && replicaData.scale > 0)
            {
                emotionPivotRect.localScale *= replicaData.scale;
                chatBubbleRect.sizeDelta = chatBubbleRect.sizeDelta * replicaData.scale;
                chatBubbleRect.anchoredPosition *= replicaData.scale;
                ((RectTransform)chatBubbleRect.parent).sizeDelta *= replicaData.scale;
                replicaTextRect = replicaTextLocalizeComponent.GetComponent<RectTransform>();
                replicaTextRect.offsetMax *= replicaData.scale;
                replicaTextRect.offsetMin *= replicaData.scale;
                replicaTextLocalizeComponent.ScaleTextMaxSizeParameter(replicaData.scale);
            }

            replicaTextLocalizeComponent.SetLocaleId(replicaData.replicaTextLocalizationKey);
            replicaTextLocalizeComponent.enabled = true;

            if (TextSheetLoader.Instance.langId == "JP")
                replicaTextLocalizeComponent.GetComponent<Text>().resizeTextMinSize = 18;

            try
            {
                if (pauseTimeOnReplica)
                {
                    if(this.gameObject.activeSelf)
                        StartCoroutine(PauseTimeAnim(true));
                }
                if (showReplicaTime > 0)
                {
                    if(this.gameObject.activeSelf)
                        StartCoroutine(WaitAndHideReplica());
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Catched error + {e.Message}");
            }
#if UNITY_EDITOR
            Debug.Log($"closeByClick: {closeByClick}");
#endif
            if (closeByClick)
            {
                StartCoroutine(ActivateCloseOption(ACTIVATE_CLOSE_OPTION_DELAY));
            }
            //animationComponent.Play( showAnimClip.name, PlayMode.StopAll );
            if (!string.IsNullOrEmpty(replicaData.replicaSoundFile))
            {
                SoundController.PlaySoundFromResources(replicaData.replicaSoundFile, replicaData.delayPlayReplicaSound);
                if (replicaData.replicaID == EReplicaID.Level_kill_boss_ghul ||
                    replicaData.replicaID == EReplicaID.Level_kill_boss_demon ||
                    replicaData.replicaID == EReplicaID.Level_kill_boss_skelet)
                {
                    GameObject.Find("BossDie").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(replicaData.replicaSoundFile);
                    GameObject.Find("BossDie2").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(replicaData.replicaSoundFile);
                    GameObject.Find("BossDie3").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(replicaData.replicaSoundFile);
                    GameObject.Find("BossDie").GetComponent<AudioSource>().Play();
                    GameObject.Find("BossDie2").GetComponent<AudioSource>().Play();
                    GameObject.Find("BossDie3").GetComponent<AudioSource>().Play();
                }
            }
            animatorComponent.Update(0f);
            SoundController.Instanse.ChangeMusicVolume(0.2f, 0.5f, true);
            ReplicaUIDarkBackground.FadeIn();
            Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.PAUSE, OnBattlePauseListener);
        }

        private void ActiveReplicaOnCharacter(ReplicaData replicaData, 
            Transform replicaAnchor, 
            GameObject[] characterRendererObjects = null, bool replicaFollowCharacter = true, ReplicaAnchorVectors anchorVectors = null)
        {
            Activate(replicaData);
            emotionImage.gameObject.SetActive(false);
            RectTransform chatBubblePivotRect = (RectTransform)chatBubbleRect.parent;
            
            if(anchorVectors == null)
                anchorVectors = new ReplicaAnchorVectors(new Vector2(0.5f,0.5f), 
                    new Vector2(0.5f,0.5f), new Vector2(0.5f,0.5f));

            chatBubblePivotRect.anchorMax = anchorVectors.anchorMax;
            chatBubblePivotRect.anchorMin = anchorVectors.anchorMin;
            chatBubblePivotRect.pivot = anchorVectors.pivot;

#if UNITY_EDITOR
            Debug.Log($"characterRendererObjects is null: {characterRendererObjects.IsNullOrEmpty()}");
            
#endif
            if (!characterRendererObjects.IsNullOrEmpty())
            {
                characterLayersChanger = new CharacterLayerChangerForReplica(characterRendererObjects);
            }
            if(replicaFollowCharacter)
                StartCoroutine(FollowAnchoredPos(chatBubblePivotRect, replicaAnchor));
            else
            {
                SetBubbleReplicaToPosition(chatBubblePivotRect, new Vector3(7,0,0));
            }


            var o = GameObject.Find("21_unlock");
            if (o != null)
                o.SetActive(false);
        }

        void OnDisable()
        {
            currentlyActiveNumber--;
        }

        private void OnDestroy()
        {
            Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.PAUSE, OnBattlePauseListener);
            
            Time.timeScale = LevelSettings.Current != null ? LevelSettings.Current.usedGameSpeed : 1;
        }

        private void OnBattlePauseListener(Core.BaseEventParams baseEventParams)
        {
            isGamePaused = (baseEventParams as Core.EventParameterWithSingleValue<bool>).eventParameter;

            if (!isGamePaused)
            {
               // Time.timeScale = currentTimeScaleVal;
            }
        }


        void Update()
        {
            Time.timeScale = currentTimeScaleVal;
        }


        public void OnCloseClick()
        {
            if (!closeR)
                return;
            Debug.Log($"OnCloseClick: {isClosing}");
            if (isClosing)
            {
                return;
            }
            isClosing = true;
            //StopAllCoroutines();
            animatorComponent.SetTrigger(hideReplicaAnimTrigger.PropertyHash);
            OnHideReplica();

            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public static void ShowReplica(EReplicaID replicaID, Transform parent = null)
        {
            GameObject.Find("BossDie").GetComponent<AudioSource>().Stop();
            GameObject.Find("BossDie2").GetComponent<AudioSource>().Stop();
            GameObject.Find("BossDie3").GetComponent<AudioSource>().Stop();
            SoundController.StopSoundFromResources();
            //System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            //System.Diagnostics.StackFrame frame = stackTrace.GetFrame(1); // The caller frame
            //string methodName = frame.GetMethod().Name;    // Method name
            //string fileName = frame.GetFileName();         // File name
            //int lineNumber = frame.GetFileLineNumber(); // Line number

            //Debug.Log("StayPath: " + methodName + "()" + "\n" + fileName + ":" + lineNumber);

#if UNITY_EDITOR
            Debug.Log($" !!!!!!!!!!!! ShowReplica: {replicaID}");
#endif
#if !SHOW_REPLICA_ALWAYS
            if (replicaID.WasShown())
            {
                Debug.LogFormat("Replica with id <b>{0}</b> already was shown", replicaID);
                UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
                return;
            }
#endif
            if (EnemiesGenerator.Instance.enemyWaves.Count == EnemiesGenerator.Instance.currentWave)
            {
                var replicasData = Resources.Load<ReplicasData>(RESOURCES_FILE_NAME);
                var replicaWasShowed = false;
                if (replicasData != null)
                {
                    var replicaData = replicasData.GetReplicaDataByID(replicaID);
                    if (replicaData != null)
                    {
                        replicaWasShowed = true;
                        if (currentReplica != null)
                        {
                            if (currentReplica.GetComponent<ReplicaUI>().replicaID == replicaID)
                                Destroy(currentReplica);
                        }

                        currentReplica = (Instantiate(Resources.Load(RESOURCES_UI_FILE_NAME), parent) as GameObject);
                        currentReplica.GetComponent<ReplicaUI>().Activate(replicaData);
                    }
                }
                if (!replicaWasShowed)//just in case :/
                {
                    UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
                }
            }
            else
            {
                var replicaLoad = Resources.LoadAsync<ReplicasData>(RESOURCES_FILE_NAME);
                replicaLoad.completed += (AsyncOperation obj) =>
                {
                    var replicasData = replicaLoad.asset as ReplicasData;
                    var replicaWasShowed = false;
                    if (replicasData != null)
                    {
                        var replicaData = replicasData.GetReplicaDataByID(replicaID);
                        if (replicaData != null)
                        {
                            replicaWasShowed = true;
                            if (currentReplica != null)
                            {
                                if (currentReplica.GetComponent<ReplicaUI>().replicaID == replicaID)
                                    Destroy(currentReplica);
                            }

                            var nextAsyncReplica = Resources.LoadAsync(RESOURCES_UI_FILE_NAME);
                            nextAsyncReplica.completed += (AsyncOperation nextObj) =>
                            {
                                currentReplica = Instantiate(nextAsyncReplica.asset as GameObject, parent) as GameObject;
                                currentReplica.GetComponent<ReplicaUI>().Activate(replicaData);
                            };
                        }
                    }
                    if (!replicaWasShowed)//just in case :/
                    {
                        UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
                    }
                };
            }
        }

        public static void ShowReplicaInShop(EReplicaID replicaID, Transform parent = null)
        {
            //System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            //System.Diagnostics.StackFrame frame = stackTrace.GetFrame(1); // The caller frame
            //string methodName = frame.GetMethod().Name;    // Method name
            //string fileName = frame.GetFileName();         // File name
            //int lineNumber = frame.GetFileLineNumber(); // Line number

            //Debug.Log("StayPath: " + methodName + "()" + "\n" + fileName + ":" + lineNumber);

#if UNITY_EDITOR
            Debug.Log($" !!!!!!!!!!!! ShowReplica: {replicaID}");
#endif
#if !SHOW_REPLICA_ALWAYS
            if (replicaID.WasShown())
            {
                Debug.LogFormat("Replica with id <b>{0}</b> already was shown", replicaID);
                UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
                return;
            }
#endif
            var replicasData = Resources.Load<ReplicasData>(RESOURCES_FILE_NAME);
            var replicaWasShowed = false;
            if (replicasData != null)
            {
                var replicaData = replicasData.GetReplicaDataByID(replicaID);
                if (replicaData != null)
                {
                    replicaWasShowed = true;
                    if (currentReplica != null)
                    {
                        if (currentReplica.GetComponent<ReplicaUI>().replicaID == replicaID)
                            Destroy(currentReplica);
                    }
                    currentReplica = (Instantiate(Resources.Load(RESOURCES_UI_IN_SHOP_FILE_NAME), parent) as GameObject);
                    currentReplica.GetComponent<ReplicaUI>().Activate(replicaData);
                }
            }
            if (!replicaWasShowed)//just in case :/
            {
                UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
            }
        }


        public static void ShowReplicaOnCharacter(EReplicaID replicaID, Transform replicaAnchor, 
            Transform parent = null, 
            GameObject[] characterRendererObjects = null, bool replicaFollowCharacter = true, ReplicaAnchorVectors anchorVectors = null)
        {
            if(replicaAnchor == null) return;
            if(parent == null) return;

#if !SHOW_REPLICA_ALWAYS
            if (replicaID.WasShown())
            {
                Debug.LogFormat("Replica with id <b>{0}</b> already was shown", replicaID);
                UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
                return;
            }
#endif
            //Debug.Log($" !!!!!!!!!!!! ShowReplica: {replicaID}");
            var resourceRequest = Resources.LoadAsync<ReplicasData>(RESOURCES_FILE_NAME);
            resourceRequest.completed += (AsyncOperation obj) => 
            {
                ReplicasData replicasData = resourceRequest.asset as ReplicasData;
                if (replicasData != null)
                {
                    ReplicaData replicaData = replicasData.GetReplicaDataByID(replicaID);
                    if (replicaData != null)
                    {
                        if (replicaAnchor == null)
                        {
                            Debug.LogError("Replica anchor is null");
                            return;
                        }
                        (
                                Instantiate(Resources.Load(RESOURCES_UI_FILE_NAME), parent) as GameObject).
                            GetComponent<ReplicaUI>().
                            ActiveReplicaOnCharacter(replicaData, replicaAnchor, characterRendererObjects, replicaFollowCharacter, anchorVectors);
                    }
                }
            };
        }


        private void OnHideReplica()
        {
            if(characterLayersChanger!=null)
            characterLayersChanger.SetDefaultLayers();

            if (pauseTimeOnReplica)
            {
                StartCoroutine(PauseTimeAnim(false));
            }
            UIToBlockWhileReplicaActiveProvider.ToggleUIInteractionState(true);
            if (characterLayersChanger != null)
            {
                this.CallActionAfterDelayWithCoroutine(.1f, characterLayersChanger.SetDefaultLayers, true);
            }
            if (blocksPlayerInput)
            {
                currentlyActiveNumberOfReplicasThatBlocksInput--;
                TapController.Current.lastCantShoot = currentlyActiveNumberOfReplicasThatBlocksInput > 0;
            }
            ReplicaUIDarkBackground.FadeOut();
            SoundController.Instanse.ChangeMusicVolume(1f, 0.5f, true);

            if (OnReplicaComplete != null)
            {
                OnReplicaComplete(replicaID);
            }

            this.CallActionAfterDelayWithCoroutine(TIME_TO_DESTROY_AFTER_HIDE, () =>
           {
               Destroy(gameObject);
           }, true);

            Destroy(gameObject);
        }
        
        

        private IEnumerator PauseTimeAnim(bool isForwardAnimation)
        {
            float timer = 0;
            while (timer < pauseTimeAnimTime)
            {
                if (!isGamePaused)
                {
                    timer += Time.unscaledDeltaTime;
                    if (isForwardAnimation)
                    {
                        currentTimeScaleVal = Mathf.Lerp(DefaultGameSpeed, changeGameTimeValue, pauseTimeCurve.Evaluate(timer / pauseTimeAnimTime));
                    }
                    else
                    {
                        currentTimeScaleVal = Mathf.Lerp(changeGameTimeValue, DefaultGameSpeed, pauseTimeCurve.Evaluate(timer / pauseTimeAnimTime));
                    }
                    Time.timeScale = currentTimeScaleVal;
                }
                yield return null;
            }
        }

        private IEnumerator WaitAndHideReplica()
        {
            yield return new WaitForSecondsRealtime(showReplicaTime);
            //animationComponent.Play( hideReplicaAnimTrigger.name, PlayMode.StopAll );
            if (!isClosing)
            {
                isClosing = true;
                animatorComponent.SetTrigger(hideReplicaAnimTrigger.PropertyHash);
                OnHideReplica();
            }
        }

        private IEnumerator ActivateCloseOption(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            gameObject.AddComponent<GraphicRaycaster>();
            closeR = true;
            emotionImage.raycastTarget = true;
            Button button = chatBubbleRect.gameObject.AddComponent<Button>();
            button.transition = Selectable.Transition.None;
            Debug.Log($"ActivateCloseOption");
            button.onClick.AddListener(OnCloseClick);
        }

        private IEnumerator DeactivateAfterSomeTime(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            try
            {
                gameObject.AddComponent<GraphicRaycaster>();
                closeR = true;
                emotionImage.raycastTarget = true;
                Button button = chatBubbleRect.gameObject.AddComponent<Button>();
                button.transition = Selectable.Transition.None;
                Debug.Log($"ActivateCloseOption");
                OnCloseClick();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        private IEnumerator FollowAnchoredPos(RectTransform rectThatFollows, Transform rectToFollow)
        {
            Vector3 viewportAnchorPosition, uiWorldPos;
            while (true)
            {
                viewportAnchorPosition = Helpers.getMainCamera.WorldToViewportPoint(rectToFollow.position);
                uiWorldPos = UIControl.UICamera.ViewportToWorldPoint(viewportAnchorPosition);
                uiWorldPos.z = rectThatFollows.position.z;
                rectThatFollows.position = uiWorldPos;
                yield return null;
            }
        }

        private void SetBubbleReplicaToPosition(RectTransform rectThatFollows, Vector3 positionToSet)
        {
            Vector3 viewportAnchorPosition, uiWorldPos;
            
            viewportAnchorPosition = Helpers.getMainCamera.WorldToViewportPoint(positionToSet);
            uiWorldPos = UIControl.UICamera.ViewportToWorldPoint(viewportAnchorPosition);
            uiWorldPos.z = rectThatFollows.position.z;
            rectThatFollows.position = uiWorldPos;
        }

        private float DefaultGameSpeed
        {
            get
            {
                if (LevelSettings.Current == null)
                {
                    return 1f;
                }
                else
                {
                    return LevelSettings.Current.usedGameSpeed;
                }
            }

        }

#if UNITY_EDITOR
        [Header("Editor Variables")]
        [SerializeField]
        private bool calculateScaleInEditor;
        [SerializeField]
        private bool divideScale;
        [SerializeField]
        [Range(0.5f, 3f)]
        private float scale = 1f;


        private void OnDrawGizmosSelected()
        {
            if (calculateScaleInEditor)
            {
                calculateScaleInEditor = false;
                emotionPivotRect.localScale *= scale;
                chatBubbleRect.sizeDelta = chatBubbleRect.sizeDelta * scale;
                chatBubbleRect.anchoredPosition *= scale;
                ((RectTransform)chatBubbleRect.parent).sizeDelta *= scale;

                //RectTransform replicaTextRect = replicaTextLocalizeComponent.GetComponent<RectTransform>();
                //Debug.Log( replicaTextRect.offsetMax +"  "+ replicaTextRect.offsetMin );
            }
            if (divideScale)
            {
                divideScale = false;
                float _scale = 1f / scale;
                emotionPivotRect.localScale *= _scale;
                chatBubbleRect.sizeDelta = chatBubbleRect.sizeDelta * _scale;
                chatBubbleRect.anchoredPosition *= _scale;
                ((RectTransform)chatBubbleRect.parent).sizeDelta *= _scale;
            }
        }
#endif
    }

public class ReplicaAnchorVectors
{
    public ReplicaAnchorVectors(Vector2 anchorMax, Vector2 anchorMin, Vector2 pivot)
    {
        this.anchorMax = anchorMax;
        this.anchorMin = anchorMin;
        this.pivot= pivot;
    }
    public Vector2 anchorMax = new Vector2(0.5f,0.5f);
    public Vector2 anchorMin = new Vector2(0.5f,0.5f);
    public Vector2 pivot = new Vector2(0.5f,0.5f);
}
}
