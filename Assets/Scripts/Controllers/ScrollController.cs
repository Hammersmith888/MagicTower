using System.Collections;
using System.Collections.Generic;
using Animations;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    private const int MAX_SLOT_COUNT = 4;
    private const float SCROLL_ALPHA_ANIMATION_TIME = 0.6f;
    private static ScrollController _instance;
    public static ScrollController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScrollController>();
            }

            return _instance;
        }
    }
    [SerializeField]
    private Animator mageAnimator;
    [SerializeField]
    private RectTransform canvasRectTransform;

    public Scroll[] scrolls = new Scroll[6];

    private Scroll_Items scrollItems;
    private Vector2[] scrollSlotsUI; // Слоты для свитков (в координатах UI)
    private Vector3[] scrollSlotsWorld; // Слоты для свитков (в координатах сцены)
    private int[] minesDamageGradation = new int[8] { 100, 120, 144, 173, 207, 207, 207, 207 };

    private byte unlockedCount; // Количество разблокированных свитков

    private AlphaColorAnimation[] scrollAnimation;

    public List<HasteScroll> listHaste = new List<HasteScroll>();
    [SerializeField] GameObject[] lockIconScroll;
    private List<GameObject> activeBarriers = new List<GameObject>();
    public List<GameObject> ActiveBarriers
    {
        get
        {
            activeBarriers.RemoveAll(barrierScroll => barrierScroll == null);
            return activeBarriers;
        }
    }

    void Start()
    {
        if (canvasRectTransform == null)
        {
            canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        }
        Core.GlobalGameEvents.Instance.AddListenerToEvent(Core.EGlobalGameEvent.RESOLUTION_CHANGE, ResolutionChangeEventListener);
        // Получаем сохранения о количестве свитков
        scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls.ToString());
        scrollSlotsUI = new Vector2[scrollItems.Length];
        scrollAnimation = new AlphaColorAnimation[scrollItems.Length];

        CalculateUIElementsPositionsInCameraWorldSpace();
        SetScrolls();
    }

    public void UnlockScrollSlots()
    {
        var count = 0;
        for (int i = 0; i < scrollItems.Length; i++)
            if (scrollItems[i].active)
                count++;

        for (int i = count - 1; i >= 0; i--)
            lockIconScroll[i].SetActive(false);
    }

    private void SetScrolls()
    {
        // Устанавливаем поля объектов свитков, включаем свиток (если он разблокирован), устанавливаем его позицию
        int childCount = Mathf.Min(scrolls.Length, transform.childCount);
        if (scrolls.Length > transform.childCount)
        {
            Debug.LogFormat("Scrolls array is greater then childs count. Some Scrolls will be skipped. Scrolls: {0} ChildCount: {1}", scrolls.Length, transform.childCount);
        }

        var typ = new List<Scroll.ScrollType>() {
            Scroll.ScrollType.Acid,
            Scroll.ScrollType.Barrier,
            Scroll.ScrollType.FrostyAura,
            Scroll.ScrollType.Minefield,
            Scroll.ScrollType.Zombie,
            Scroll.ScrollType.Haste,
        };

        int lastOpenSlot = 0;
        for (int i = 0; i < childCount; i++)
        {
            scrolls[i] = new Scroll();
            scrolls[i].scrollTrans = transform.GetChild(i);
            scrolls[i].scrollCountText = scrolls[i].scrollTrans.GetComponentInChildren<Text>();
            scrolls[i].scrollIconImg = scrolls[i].scrollTrans.GetComponentInChildren<Image>();
            scrolls[i].raycastGraphick = scrolls[i].scrollTrans.GetComponent<UI.NonRenderedGraphic>();
            scrolls[i].ScrollCount = scrollItems[i].count;
            scrolls[i].scrollPrefab = Resources.Load(GetScrollPath(i), typeof(GameObject)) as GameObject;
            scrolls[i].scrollType = typ[i];
            //Debug.LogFormat( i + "  " + ( Scroll.ScrollType ) i + "  " + scrollItems[ i ].unlock );
            MyGSFU.current.SetScrollParameters((Scroll.ScrollType)i, scrolls[i].scrollPrefab, scrollItems[i].upgradeLevel);

            // Если свиток разблокирован (устанавливаем его позицию и делаем активным)
            if (scrollItems[i].active)
            {
                //scrolls[i].scrollTrans.GetComponent<RectTransform>().anchoredPosition = scrollSlotsUI[unlockedCount - scrollItems[i].slot - 1];
                scrolls[i].scrollTrans.GetComponent<RectTransform>().anchoredPosition = lockIconScroll[Mathf.Clamp(scrollItems[i].slot, 0, 3)].transform.localPosition;
                lockIconScroll[Mathf.Clamp(scrollItems[i].slot, 0, 3)].SetActive(false);
                lastOpenSlot++;
                scrolls[i].scrollTrans.gameObject.SetActive(true);
            }

            scrollAnimation[i] = scrolls[i].scrollTrans.GetComponent<AlphaColorAnimation>();
        }
        for (int i = 0; i < scrollItems.Length; i++)
        {
            if (!scrollItems[i].active)
            {
                scrollSlotsUI[i].x = lockIconScroll[Mathf.Clamp(lastOpenSlot, 0, 3)].transform.localPosition.x;
                scrolls[i].scrollTrans.GetComponent<RectTransform>().anchoredPosition = lockIconScroll[Mathf.Clamp(lastOpenSlot, 0, 3)].transform.localPosition;
            }
        }
    }

    private void OnDestroy()
    {
        Core.GlobalGameEvents.Instance.RemoveListenerFromEvent(Core.EGlobalGameEvent.RESOLUTION_CHANGE, ResolutionChangeEventListener);
    }

    private void ResolutionChangeEventListener(Core.BaseEventParams eventParams)
    {
        CalculateUIElementsPositionsInCameraWorldSpace();
    }

    private void CalculateUIElementsPositionsInCameraWorldSpace()
    {
        scrollSlotsWorld = new Vector3[scrollSlotsUI.Length];
        Vector2 transfPos = transform.position;
        //Debug.Log($"unlockedCount: {unlockedCount}");
        for (int i = 0; i < scrollSlotsWorld.Length; i++)
        {
             scrollSlotsWorld[i] = Helpers.UIWorildPosToCameraWorldPos(transfPos + scrollSlotsUI[i], canvasRectTransform);
        }
    }

    // Активация заклинания
    public void Activation(int scrollNumber, Vector2 _position)
    {
        if (scrolls[scrollNumber].ScrollCount == 0 || scrollItems[scrollNumber].count == 0)
            return;

        Vector3 scrollPos;
        scrollPos = Helpers.getMainCamera.ScreenToWorldPoint(_position);
        scrollPos = new Vector3(scrollPos.x, scrollPos.y, 0);
        Scroll.ScrollType scrollType = (Scroll.ScrollType)scrollNumber;
        if (scrollType == Scroll.ScrollType.Haste && listHaste.Count > 0)
            return;
        mageAnimator.SetTrigger(AnimationPropertiesCach.instance.undirectedAnim); // Анимация атаки мага

        if (scrollNumber != 3)
        {
            if (scrollNumber == 1)
            {
                if (scrollPos.y > GameConstants.MaxTopBorder)
                {
                    scrollPos.y = GameConstants.MaxTopBorder;
                }
                if (scrollPos.y < GameConstants.MaxBottomBorder)
                {
                    scrollPos.y = GameConstants.MaxBottomBorder;
                }
            }

            GameObject newScroll = Instantiate(scrolls[scrollNumber].scrollPrefab, scrollPos, Quaternion.identity);

            if (scrollNumber == 1)
            {
                activeBarriers.Add(newScroll);
                newScroll.transform.position = new Vector3(newScroll.transform.position.x, newScroll.transform.position.y, 0); //newScroll.transform.position.y * 2.0f - 6.0f
            }

            if(scrollNumber == 4 && mainscript.CurrentLvl == 56)
            {
                Tutorials.Tutorial_1.Current.CloseZombieTutorial();
            }
            if (scrollNumber == 1 && mainscript.CurrentLvl == 5)
            {
                Tutorials.Tutorial_1.Current.CloseWallTutorial();
            }
            if (scrollNumber == 2 && mainscript.CurrentLvl == 8)
            {
                Tutorials.Tutorial_1.Current.CloseIceTutorial();
            }

        }
        else
        {
            SpawnMines();
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Miner, 1);
            if (scrollNumber == 3 && mainscript.CurrentLvl == 12)
            {
                Tutorials.Tutorial_1.Current.CloseMineTutorial();
            }
        }
        if (scrollNumber == 0)
        {
            SoundController.Instanse.playActivateAcidSFX();
        }
        if (scrollNumber == 1)
        {
            SoundController.Instanse.playActivateBarrierSFX();
        }
        if (scrollNumber == 2)
        {
            SoundController.Instanse.playActivateFreezeSFX();
        }
        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.ScrollMaster, 1);
        Achievement.AchievementController.Save();
        scrolls[scrollNumber].ScrollCount--;
        scrollItems[scrollNumber].count--;
        PPSerialization.Save(EPrefsKeys.Scrolls.ToString(), scrollItems);

        #region ANALYTICS
        if (LevelSettings.Current != null)
        {
            LevelSettings.Current.UsedScroll(scrollNumber);
        }
        #endregion
    }

    public bool IsScrollUnlock(int idScroll)
    {
        return scrollItems[idScroll].unlock;
    }

    public bool IsSlotFree()
    {
        int freeSlotsNumber = 0;
        int childCount = Mathf.Min(scrolls.Length, transform.childCount);
        for (int i = 0; i < childCount; i++)
        {
            if (scrollItems[i].active)
            {
                freeSlotsNumber++;
            }
        }

        if (freeSlotsNumber >= MAX_SLOT_COUNT)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Добавляем свитки выпадающие из сундука или монстра
    public void AddScrolls(int _scrollNumber, int _count)
    {
        //Debug.Log($"_scrollNumber: {_scrollNumber}");
        // Если свиток уже открыт
        if (scrollItems[_scrollNumber].unlock)
        {
            scrolls[_scrollNumber].ScrollCount += _count;
            scrollItems[_scrollNumber].count += _count;
            PPSerialization.Save(EPrefsKeys.Scrolls.ToString(), scrollItems);
        }
        else
        {
            scrollItems[_scrollNumber].unlock = true;
            scrollItems[_scrollNumber].order = (byte)(unlockedCount + 1);
            scrolls[_scrollNumber].ScrollCount += _count;
            scrollItems[_scrollNumber].count += _count;

            AutoPlaceScrollsToSlots();
            ReloadScrollsPanel();
            PPSerialization.Save(EPrefsKeys.Scrolls.ToString(), scrollItems);
        }
    }

    private bool IsNew(int _scrollNumber)
    {
        for (byte i = 0; i < MAX_SLOT_COUNT; i++)
        {
            if (scrollItems[_scrollNumber].unlock)
            {
                if (scrollItems[_scrollNumber].active && scrollItems[_scrollNumber].slot == i)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void DisableFirst()
    {
        int first = GetFirstScrollNumberInPanel();
        scrollItems[first].active = false;
        scrollItems[first].slot = MAX_SLOT_COUNT;
        unlockedCount--;

        scrollAnimation[first].enabled = true;
        scrollAnimation[first].fromAlpha = 1;
        scrollAnimation[first].toAlpha = 0;
        scrollAnimation[first].disableObjectAtEnd = true;
        scrollAnimation[first].autoStart = false;
        scrollAnimation[first].animationTime = SCROLL_ALPHA_ANIMATION_TIME;
        scrollAnimation[first].Init();
        scrollAnimation[first].Animate();
    }

    private void SetNewOrder()
    {
        for (int i = 0; i < scrollItems.Length; i++)
        {
            if (scrollItems[i].active)
            {
                scrollItems[i].slot--;
            }
        }
    }

    private void SetLast(int _scrollNumber)
    {
        int last = MAX_SLOT_COUNT - 1;
        scrollItems[_scrollNumber].active = true;
        scrollItems[_scrollNumber].slot = (byte)last;
        unlockedCount++;

        scrollAnimation[_scrollNumber].enabled = true;
        scrollAnimation[_scrollNumber].fromAlpha = 0;
        scrollAnimation[_scrollNumber].toAlpha = 1;
        scrollAnimation[_scrollNumber].disableObjectAtEnd = false;
        scrollAnimation[_scrollNumber].autoStart = true;
        scrollAnimation[_scrollNumber].autoStart = true;
        scrollAnimation[_scrollNumber].animationTime = SCROLL_ALPHA_ANIMATION_TIME;
        scrollAnimation[_scrollNumber].Init();
    }

    private void UpdatePosition()
    {
        for (int i = 0; i < scrollItems.Length; i++)
        {
            if (scrollItems[i].active)
            {
                scrolls[i].scrollTrans.GetComponent<RectTransform>().anchoredPosition = scrollSlotsUI[unlockedCount - scrollItems[i].slot - 1];
                scrolls[i].scrollTrans.gameObject.SetActive(true);
            }
        }
    }

    private int GetFirstScrollNumberInPanel()
    {
        int first = SlotToScrollNumber(0);
        NumberScrollToDebugLog(first);

        return first;
    }

    private int GetLastScrollNumberInPanel()
    {
        int last = SlotToScrollNumber(MAX_SLOT_COUNT - 1);
        NumberScrollToDebugLog(last);

        return last;
    }

    private int SlotToScrollNumber(int slotIndex)
    {
        for (int j = 0; j < scrollItems.Length; j++)
        {
            if (scrollItems[j].unlock)
            {
                if (scrollItems[j].active && scrollItems[j].slot == slotIndex)
                {
                    return j;
                }
            }
        }

        return -1;
    }

    private void NumberScrollToDebugLog(int number)
    {
        string log = "";
        switch (number)
        {
            case 0:
                log = "AcidScroll";
                break;
            case 1:
                log = "BarrierScroll";
                break;
            case 2:
                log = "FreezeScroll";
                break;
            case 3:
                log = "Mine";
                break;
            case 4:
                log = "ZombieScroll";
                break;
            case 5:
                log = "HasteScroll";
                break;
        }
        Debug.Log("NumberScrollToDebugLog:  " + log);
    }

    private void AutoPlaceScrollsToSlots()
    {
        for (byte i = 0; i < MAX_SLOT_COUNT; i++)
        {
            bool thisEmpty = true;
            for (int j = 0; j < scrollItems.Length; j++)
            {
                if (scrollItems[j].unlock)
                {
                    if (scrollItems[j].active && scrollItems[j].slot == i)
                    {
                        thisEmpty = false;
                        break;
                    }
                }
            }

            if (thisEmpty)
            {
                for (int j = 0; j < scrollItems.Length; j++)
                {
                    if (scrollItems[j].unlock)
                    {
                        if (!scrollItems[j].active)
                        {
                            scrollItems[j].active = true;
                            scrollItems[j].slot = i;
                            break;
                        }
                    }
                }
            }
        }
    }

    // Получаем позицию слота свитка в координатах сцены
    public Vector3 GetPanelPos(int _scrollNumber)
    {
        var order = scrollItems[_scrollNumber].order;
        var count = 0;
        var t = 0;
        foreach(var o in scrolls)
        {
            if (o.scrollTrans.gameObject.activeSelf)
                count++;
          //  Debug.Log($"_scrollNumber: {_scrollNumber}, (int)o.scrollType: {((int)o.scrollType)},  o.scrollTrans.gameObject.activeSelf: { o.scrollTrans.gameObject.activeSelf}");

            if (_scrollNumber == (int)o.scrollType && o.scrollTrans.gameObject.activeSelf)
                t++;
        }
        if (count >= 4 && t == 0)
            return Vector3.zero;
        // Если свиток уже открыт
        if (scrollItems[_scrollNumber].unlock && unlockedCount >= order)
        {
            return scrollSlotsWorld[unlockedCount - order];
        }
        else
        {
            return scrollSlotsWorld[0];
        }
    }

    private string GetScrollPath(int _scrollNumber)
    {
        switch (_scrollNumber)
        {
            case 0:
                return "Scrolls/Acid/AcidScroll";
            case 1:
                return "Scrolls/Barrier/BarrierScroll";
            case 2:
                return "Scrolls/Freeze/FreezeScroll";
            case 3:
                return "Scrolls/Minesfield/Mine";
            case 4:
                return "Scrolls/Zombie/ZombieScroll";
            case 5:
                return "Scrolls/Haste/HasteScroll";
        }
        return "";
    }

    private void ReloadScrollsPanel()
    {
        // Увеличиваем количество разблокированных свитков
        unlockedCount++;

        // Обновляем позиции разблокированных свитков и включаем, если свиток выключен
        for (int i = 0; i < scrolls.Length; i++)
        {
            // Если свиток разблокирован (устанавливаем его позицию и делаем активным)
            if (scrollItems[i].unlock)
            {
                //scrolls[i].scrollTrans.GetComponent<RectTransform>().anchoredPosition = scrollSlotsUI[unlockedCount - scrollItems[i].order];
                scrolls[i].scrollTrans.gameObject.SetActive(true);
            }
        }
    }

    public void SpawnMines(int customNumber = -1)
    {
        int mines_count = scrollItems[3].upgradeLevel + 4;

        if (customNumber == 0)
        {
            return;
        }
        else if (customNumber > 0)
        {
            mines_count = customNumber;
        }

        for (int i = 0; i < mines_count; i++)
        {
            Vector3 mine_pos = new Vector3(UnityEngine.Random.Range(-4, 4), ((float)UnityEngine.Random.Range(-3, 3)) / 1.5f, transform.position.z);
            GameObject new_mine = Instantiate(scrolls[3].scrollPrefab, mine_pos, Quaternion.identity) as GameObject;
            new_mine.GetComponent<MinesScroll>().SetMineParam(minesDamageGradation[scrollItems[3].upgradeLevel], 1f);
        }

    }

    public void SpawnBarrier(Vector3 barrierPosition)
    {
        if (barrierPosition.y > GameConstants.MaxTopBorder)
        {
            barrierPosition.y = GameConstants.MaxTopBorder;
        }
        if (barrierPosition.y < GameConstants.MaxBottomBorder)
        {
            barrierPosition.y = GameConstants.MaxBottomBorder;
        }

        GameObject newBarrier = Instantiate(scrolls[1].scrollPrefab, barrierPosition, Quaternion.identity) as GameObject;

        MagicalFX.FX_SpawnDirectionBarrier fX_SpawnDirectionBarrier;
        newBarrier.TryGetComponent(out fX_SpawnDirectionBarrier);
        if (fX_SpawnDirectionBarrier != null)
            StartCoroutine(ReActiveBarrierFx(fX_SpawnDirectionBarrier));

        fX_SpawnDirectionBarrier.LifeTime = 9999f;
    }

    private IEnumerator ReActiveBarrierFx(MagicalFX.FX_SpawnDirectionBarrier fX_SpawnDirectionBarrier)
    {
        yield return new WaitForSeconds(0.1f);
        fX_SpawnDirectionBarrier.enabled = true;
        yield break;
    }
}