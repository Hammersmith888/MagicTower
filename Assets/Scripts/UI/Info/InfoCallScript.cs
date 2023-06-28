using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCallScript : MonoBehaviour
{
    public event System.Action<EnemyType> OnEnemyInfoViewed;

    private const int SPELL_LENGHT = 12;
    [SerializeField]
    private Button prevBtn, nextBtn;

    private Spell.SpellType[] spellIds =
    {
        Spell.SpellType.FireBall,
        Spell.SpellType.Lightning,
        Spell.SpellType.IceStrike,
        Spell.SpellType.Boulder,
        Spell.SpellType.FireWall,
        Spell.SpellType.ChainLightning,
        Spell.SpellType.IceBreath,
        Spell.SpellType.AcidSpray_Unused,
        Spell.SpellType.Meteor,
        Spell.SpellType.ElecticPool,
        Spell.SpellType.Blizzard,
        Spell.SpellType.FireDragon,
        Spell.SpellType.EarthBall

    };

    private Scroll.ScrollType[] scrollIds =
    {
        Scroll.ScrollType.Acid,
        Scroll.ScrollType.Barrier,
        Scroll.ScrollType.FrostyAura,
        Scroll.ScrollType.Minefield,
        Scroll.ScrollType.Zombie,
        Scroll.ScrollType.Haste

    };

    private UpgradeItem.UpgradeType[] upgradeIds =
    {
        UpgradeItem.UpgradeType.Knowledge,
        UpgradeItem.UpgradeType.Fortification,
        UpgradeItem.UpgradeType.GuardPet,
        UpgradeItem.UpgradeType.FireBarrier,
        UpgradeItem.UpgradeType.GuardPetFrost
    };

    private int currentShowInfoId;
    private GameObject currentInfoObject, currentUpInfoObject;
    public bool isShowBtn = true;
    [SerializeField]
    private GameObject buttonsGroup;
    private enum ShowVariants { Enemies, Spells, Scrolls, Upgrade }
    private ShowVariants currentInfoType = ShowVariants.Enemies;
    [SerializeField]
    private List<Button> enemiesButtons, spellsButtons, scrollsButtons, upgradesButtons;
    [HideInInspector]
    public bool showWhileTutor;

    public bool IsOpened { get { return currentInfoObject != null; } }

    private static InfoCallScript _current;
    int isShowAura = 0;
    int lastID;
    bool isHideAura = false;
    public static InfoCallScript Current
    {
        get
        {
            if (_current == null)
            {
                _current = FindObjectOfType<InfoCallScript>();
            }
            return _current;
        }
    }

    private void Start()
    {
        buttonsGroup.SetActive(false);

        // //Debug.Log(" enemiesButtons.Count: " + enemiesButtons.Count, gameObject);
        // for (int i = 0; i < enemiesButtons.Count; i++)
        // {
        //     if (enemiesButtons[i] != null)
        //     {
        //         enemiesButtons[i].onClick.RemoveAllListeners();
        //         int setId = (int)EnemyInfoIdsUnlockOrder.EnemyIdsOrder[i];
        //         // enemiesButtons[i].onClick.AddListener(delegate
        //         // { ShowEnemyScreen(setId); });

        //         Debug.Log(i + " , " + EnemyInfoIdsUnlockOrder.EnemyIdsOrder[i].ToString(), enemiesButtons[i].gameObject);
        //     }
        // }

        for (int i = 0; i < spellsButtons.Count; i++)
        {
            if (spellsButtons[i] != null)
            {
                spellsButtons[i].onClick.RemoveAllListeners();
                int setId = i;
                spellsButtons[i].onClick.AddListener(delegate
                {
                    Debug.Log($"ShowSpellScreen: {setId}");
                    ShowSpellScreen(setId);
                
                });
            }
        }

        for (int i = 0; i < scrollsButtons.Count; i++)
        {
            if (scrollsButtons[i] != null)
            {
                scrollsButtons[i].onClick.RemoveAllListeners();
                int setId = (int)scrollIds[i];
                scrollsButtons[i].onClick.AddListener(delegate
                { ShowScrollScreen(setId); });
            }
        }

        for (int i = 0, t = 0; i < upgradesButtons.Count; i++)
        {
            if (upgradesButtons[i] != null)
            {
                upgradesButtons[i].onClick.RemoveAllListeners();
                int setId = (int)upgradeIds[i];
                upgradesButtons[i].onClick.AddListener(delegate
                { ShowUpgradeScreen(setId); });
            }
        }
    }

    public void SetEnemiesButtons(int currentId = 0)
    {
        // if (prevBtn != null)
        // {
        //     prevBtn.gameObject.SetActive(currentId > 0);
        // }

        // int maxCallId = InfoLoaderConfig.Instance.maxOpenedLevel + 1;
        // Debug.Log("maxCallId: " + maxCallId + ", InfoLoaderConfig.Instance.maxOpenedLevel : " + InfoLoaderConfig.Instance.maxOpenedLevel);
        // Debug.Log("EnemyMeetOnLevel: " + InfoLoaderConfig.Instance.EnemyMeetOnLevel(EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentId + 1]));
        // if (nextBtn != null)
        // {
        //     var isButtonActive = currentId < EnemyInfoIdsUnlockOrder.EnemyIdsOrder.Length - 1 &&
        //                         (maxCallId == 0 || maxCallId >= InfoLoaderConfig.Instance.EnemyMeetOnLevel(EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentId + 1]));
        //     nextBtn.gameObject.SetActive(isButtonActive || isShowAura > 0);
        // }


        // buttonsGroup.SetActive(true);
        // currentShowInfoId = currentId;
        // currentInfoType = ShowVariants.Enemies;
    }

    public void ShowEnemyScreen(int enemyTypeId = 0)
    {
        // ShowEnemyScreen(enemyTypeId, false);
        // Debug.Log(EnemyInfoIdsUnlockOrder.GetInfoUnlockIndexForEnemyType((EnemyType)enemyTypeId));
        // SetEnemiesButtons(EnemyInfoIdsUnlockOrder.GetInfoUnlockIndexForEnemyType((EnemyType)enemyTypeId));
        // CalculateShowAura(EnemyInfoIdsUnlockOrder.GetInfoUnlockIndexForEnemyType((EnemyType)enemyTypeId), true);
    }

    public void CalculateShowAura(int currentId, bool open = false)
    {
        // Debug.Log("currentId: " + currentId + ", lastID: " + lastID);
        // isShowAura = 0;
        // int maxCallId = InfoLoaderConfig.Instance.maxOpenedLevel + 1;

        // if (nextBtn != null)
        // {
        //     var isButtonActive = currentId < EnemyInfoIdsUnlockOrder.EnemyIdsOrder.Length - 1 &&
        //                         (maxCallId == 0 || maxCallId >= InfoLoaderConfig.Instance.EnemyMeetOnLevel(EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentId + 1]));
        //     if (!isButtonActive && currentId > lastID)
        //     {
        //         isShowAura++;
        //         //if (open)
        //         //    ShowNextEnemy();
        //     }
        // }
        // lastID = currentId;
    }

    private void ShowPrevEnemy()
    {
        // HideButtons();


        // if (isHideAura)
        // {
        //     isHideAura = false;
        //     ReuseEnemyInfo(currentInfoObject, (int)EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentShowInfoId], false, false);
        //     prevBtn.gameObject.SetActive(true);
        //     nextBtn.gameObject.SetActive(true);
        //     prevBtn.transform.parent.gameObject.SetActive(true);
        // }
        // else
        // {
        //     CalculateShowAura(currentShowInfoId - 1);
        //     ReuseEnemyInfo(currentInfoObject, (int)EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentShowInfoId - 1]);
        //     SetEnemiesButtons(currentShowInfoId - 1);
        // }
    }

    private void ShowNextEnemy()
    {
        // HideButtons();
        // if (isShowAura > 0)
        // {
        //     Debug.Log("currentShowInfoId: " + currentShowInfoId);
        //     ReuseEnemyInfo(currentInfoObject, (int)EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentShowInfoId + 1], false, true);
        //     prevBtn.transform.parent.gameObject.SetActive(true);
        //     prevBtn.gameObject.SetActive(true);
        //     nextBtn.gameObject.SetActive(false);
        //     isHideAura = true;
        // }
        // else
        // {
        //     CalculateShowAura(currentShowInfoId + 1);
        //     ReuseEnemyInfo(currentInfoObject, (int)EnemyInfoIdsUnlockOrder.EnemyIdsOrder[currentShowInfoId + 1]);
        //     SetEnemiesButtons(currentShowInfoId + 1);
        // }
    }


    public void SetSpellsButtons(int currentId = 0)
    {
        if (prevBtn != null)
        {
            prevBtn.gameObject.SetActive(currentId > 0);
        }

        int maxCallId = InfoLoaderConfig.Instance.maxOpenedLevel;

        if (nextBtn != null)
        {
            nextBtn.gameObject.SetActive(currentId < SPELL_LENGHT - 1 && (maxCallId == 0 || maxCallId >= InfoLoaderConfig.Instance.SpellMeetOnLevel(spellIds[currentId + 1])));
        }
        if(isShowBtn)
            buttonsGroup.SetActive(true);
        currentShowInfoId = currentId;
        currentInfoType = ShowVariants.Spells;
    }

    public void SetScrollsButtons(int currentId = 0)
    {
        if (prevBtn != null)
        {
            prevBtn.gameObject.SetActive(currentId > 0);
        }

        int maxCallId = InfoLoaderConfig.Instance.maxOpenedLevel;

        if (nextBtn != null)
        {

            nextBtn.gameObject.SetActive(currentId < scrollIds.Length - 1 && (maxCallId == 0 || maxCallId >= InfoLoaderConfig.Instance.ScrollMeetOnLevel(scrollIds[currentId + 1])));
        }
        if (isShowBtn)
            buttonsGroup.SetActive(true);
        currentShowInfoId = currentId;
        currentInfoType = ShowVariants.Scrolls;
    }


    private void ShowPrevSpell()
    {
        HideButtons();
        int index = ShopIndexToSpellIndex(currentShowInfoId - 1, false);
        ReuseSpellInfo(index);
        //ReuseSpellInfo((int)spellIds[currentShowInfoId - 1]);
        SetSpellsButtons(currentShowInfoId - 1);
        AnalyticsController.Instance.LogMyEvent("Open_Prev_Spell");
    }

    private void ShowNextSpell()
    {
        HideButtons();
        int index = ShopIndexToSpellIndex(currentShowInfoId + 1, true);
        ReuseSpellInfo(index);
        //ReuseSpellInfo((int)spellIds[currentShowInfoId + 1]);
        SetSpellsButtons(currentShowInfoId + 1);
    }

    private int ShopIndexToSpellIndex(int index, bool next)
    {
        if (spellIds[index] == Spell.SpellType.Boulder)
        {
            return next ? 12 : 2;
        }
        else if (spellIds[index] == Spell.SpellType.AcidSpray_Unused)
        {
            return next ? 3 : 5;
        }

        return index;
    }

    private void ShowPrevScroll()
    {
        HideButtons();
        ReuseScrollInfo((int)scrollIds[currentShowInfoId - 1]);
        SetScrollsButtons(currentShowInfoId - 1);
        AnalyticsController.Instance.LogMyEvent("Open_Prev_Scroll");
    }

    private void ShowNextScroll()
    {
        HideButtons();
        ReuseScrollInfo((int)scrollIds[currentShowInfoId + 1]);
        SetScrollsButtons(currentShowInfoId + 1);
    }



    public void ShowEnemyScreen(int enemyTypeId = 0, bool hideDarkBack = false)
    {
        // Debug.Log("enemyTypeId: " + enemyTypeId);
        // if (InfoLoaderConfig.Instance != null)
        // {
        //     currentInfoObject = Instantiate(InfoLoaderConfig.Instance.InfoEnemyObject, transform) as GameObject;
        //     if (currentInfoObject == null)
        //     {
        //         return;
        //     }
        //     ReuseEnemyInfo(currentInfoObject, enemyTypeId, hideDarkBack);
        //     if (!hideDarkBack)
        //     {
        //         currentInfoObject.transform.SetAsFirstSibling();
        //     }
        // }
    }

    private void ShowEnemyUpScreen(int enemyTypeId = 0, bool hideDarkBack = false)
    {
        // if (InfoLoaderConfig.Instance != null)
        // {
        //     currentUpInfoObject = Instantiate(InfoLoaderConfig.Instance.InfoEnemyObject, transform) as GameObject;
        //     if (currentUpInfoObject == null)
        //     {
        //         return;
        //     }
        //     ReuseEnemyInfo(currentUpInfoObject, enemyTypeId, hideDarkBack);
        //     currentUpInfoObject.transform.SetAsLastSibling();
        // }
    }

    private void ReuseEnemyInfo(GameObject usedObject, int enemyTypeId = 0, bool hideDarkBack = false, bool aura = false)
    {
        // InfoBasePanel enemyPanel = usedObject.GetComponent<InfoBasePanel>();
        // if (enemyPanel != null)
        // {
        //     OnEnemyInfoViewed.InvokeSafely((EnemyType)enemyTypeId);
        //     InfoBaseData infoBaseData = InfoLoaderConfig.Instance.GetEnemyBaseData((EnemyType)enemyTypeId);
        //     switch ((EnemyType)enemyTypeId)
        //     {
        //         case EnemyType.skeleton_mage:
        //             infoBaseData.infoLineDatas[5].actionTapValue = ShowSkeletonMageSummonInfo;
        //             break;
        //         case EnemyType.skeleton_strong_mage:
        //             infoBaseData.infoLineDatas[5].actionTapValue = ShowSkeletonStrongMageSummonInfo;
        //             break;
        //         case EnemyType.demon_fatty:
        //             infoBaseData.infoLineDatas[5].actionTapValue = ShowDemonFattySummonInfo;
        //             break;
        //     }

        //     enemyPanel.SetBaseData(infoBaseData, aura);
        //     enemyPanel.backgroundObject.SetActive(!hideDarkBack);
        //     if (hideDarkBack)
        //     {
        //         enemyPanel.onDestroyAction = ReturnButtons;
        //     }
        //     else
        //     {
        //         enemyPanel.onDestroyAction = OnGameplayInfoClose;
        //     }
        // }

    }

    public void ShowSkeletonMageSummonInfo()
    {
        ShowEnemyUpScreen(28, true);
        HideButtons();
        AnalyticsController.Instance.LogMyEvent("Open_Skeleton_Mage_Summon_Info");
    }

    public void ShowSkeletonStrongMageSummonInfo()
    {
        ShowEnemyUpScreen(27, true);
        HideButtons();
    }

    public void ShowDemonFattySummonInfo()
    {
        ShowEnemyUpScreen(18, true);
        HideButtons();
    }

    public void ShowSpellScreen(int spellTypeId = 0)
    {
        int index = ShopIndexToSpellIndex(spellTypeId, true);
        ShowSpellScreen(index, false);
        SetSpellsButtons(index);
    }

    public void ShowSpellScreen(int spellTypeId = 0, bool hideDarkBack = false)
    {
        if (InfoLoaderConfig.Instance != null)
        {
            currentInfoObject = Instantiate(InfoLoaderConfig.Instance.InfoSpellObject, transform) as GameObject;
            if (currentInfoObject == null)
            {
                return;
            }
            currentInfoObject.transform.SetAsFirstSibling();
            ReuseSpellInfo(spellTypeId);
            currentInfoObject.transform.SetAsFirstSibling();
        }
    }

    public void ShowScrollScreen(int scrollTypeId = 0)
    {
        ShowScrollScreen(scrollTypeId, false);
        SetScrollsButtons(ScrollInnerTableIndex((Scroll.ScrollType)scrollTypeId));
    }

    public void ShowScrollScreen(int scrollTypeId = 0, bool hideDarkBack = false)
    {
        if (InfoLoaderConfig.Instance != null)
        {
            currentInfoObject = Instantiate(InfoLoaderConfig.Instance.InfoSpellObject, transform) as GameObject;
            if (currentInfoObject == null)
            {
                return;
            }
            currentInfoObject.transform.SetAsFirstSibling();
            ReuseScrollInfo(scrollTypeId);
            currentInfoObject.transform.SetAsFirstSibling();
        }
    }

    private void ReuseScrollInfo(int scrollTypeId = 0)
    {
        InfoBasePanel scrollPanel = currentInfoObject.GetComponent<InfoBasePanel>();

        if (scrollPanel != null)
        {
            InfoBaseData infoBaseData = InfoLoaderConfig.Instance.GetScrollBaseData(scrollTypeId);
            scrollPanel.SetBaseData(infoBaseData);
            scrollPanel.onDestroyAction = OnGameplayInfoClose;
        }
    }

    private void ReuseSpellInfo(int spellTypeId = 0)
    {
        InfoBasePanel spellPanel = currentInfoObject.GetComponent<InfoBasePanel>();

        if (spellPanel != null)
        {
            InfoBaseData infoBaseData = InfoLoaderConfig.Instance.GetSpellBaseData(spellTypeId, spellIds[spellTypeId]);
            spellPanel.SetBaseData(infoBaseData);
            spellPanel.onDestroyAction = OnGameplayInfoClose;
        }
    }

    public void NextBtnEvent()
    {
        switch (currentInfoType)
        {
            case ShowVariants.Enemies:
                ShowNextEnemy();
                break;
            case ShowVariants.Spells:
                ShowNextSpell();
                break;
            case ShowVariants.Scrolls:
                ShowNextScroll();
                break;
            case ShowVariants.Upgrade:
                ShowNextUpgrade();
                break;
        }
    }

    public void PrevBtnEvent()
    {
        switch (currentInfoType)
        {
            case ShowVariants.Enemies:
                ShowPrevEnemy();
                break;
            case ShowVariants.Spells:
                ShowPrevSpell();
                break;
            case ShowVariants.Scrolls:
                ShowPrevScroll();
                break;
            case ShowVariants.Upgrade:
                ShowPrevUpgrade();
                break;
        }
    }

    public void OnGameplayInfoClose()
    {
        if (LevelSettings.Current == null)
        {
            Time.timeScale = LevelSettings.defaultUsedSpeed;
        }
        else
        {
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }

        HideButtons();
    }

    public void HideButtons()
    {
        buttonsGroup.SetActive(false);
    }

    private int SpellInnerTableIndex(Spell.SpellType spellType)
    {
        for (int i = 0; i < spellIds.Length; i++)
        {
            if (spellIds[i] == spellType)
            {
                return i;
            }
        }
        return 0;
    }

    private int ScrollInnerTableIndex(Scroll.ScrollType scrollType)
    {
        for (int i = 0; i < scrollIds.Length; i++)
        {
            if (scrollIds[i] == scrollType)
            {
                return i;
            }
        }
        return 0;
    }

    public void ReturnButtons()
    {
        SetEnemiesButtons(currentShowInfoId);
    }

    private void ShowPrevUpgrade()
    {
        HideButtons();
        ReuseUpgradeInfo((int)upgradeIds[currentShowInfoId - 1]);
        SetUpgradesButtons(currentShowInfoId - 1);
    }

    private void ShowNextUpgrade()
    {
        HideButtons();
        ReuseUpgradeInfo((int)upgradeIds[currentShowInfoId + 1]);
        SetUpgradesButtons(currentShowInfoId + 1);
    }

    public void ShowUpgradeScreen(int upgradeTypeId = 0)
    {
        ShowUpgradeScreen(upgradeTypeId, false);
        SetUpgradesButtons(UpgradeInnerTableIndex((UpgradeItem.UpgradeType)upgradeTypeId));
    }

    public void ShowUpgradeScreen(int upgradeTypeId = 0, bool hideDarkBack = false)
    {
        if (InfoLoaderConfig.Instance != null)
        {
            currentInfoObject = Instantiate(InfoLoaderConfig.Instance.InfoUpgradesObject, transform) as GameObject;
            if (currentInfoObject == null)
            {
                return;
            }
            currentInfoObject.transform.SetAsFirstSibling();
            ReuseUpgradeInfo(upgradeTypeId);
            currentInfoObject.transform.SetAsFirstSibling();
        }
    }

    private int UpgradeInnerTableIndex(UpgradeItem.UpgradeType upgradeType)
    {
        for (int i = 0; i < upgradeIds.Length; i++)
        {
            if (upgradeIds[i] == upgradeType)
            {
                return i;
            }
        }
        return 0;
    }

    private void ReuseUpgradeInfo(int upgradeTypeId = 0)
    {
        InfoBasePanel upgradePanel = currentInfoObject.GetComponent<InfoBasePanel>();

        if (upgradePanel != null)
        {
            InfoBaseData infoBaseData = InfoLoaderConfig.Instance.GetUpgradeBaseData(upgradeTypeId);
            upgradePanel.SetBaseData(infoBaseData);
            upgradePanel.onDestroyAction = OnGameplayInfoClose;
        }
    }

    public void SetUpgradesButtons(int currentId = 0)
    {
        if (prevBtn != null)
        {
            prevBtn.gameObject.SetActive(currentId > 0);
        }

        int maxCallId = InfoLoaderConfig.Instance.maxOpenedLevel;

        if (nextBtn != null)
        {
            nextBtn.gameObject.SetActive(currentId < upgradeIds.Length - 1 && (maxCallId == 0 || maxCallId >= InfoLoaderConfig.Instance.UpgradeMeetOnLevel(upgradeIds[currentId + 1])));
        }
        if (isShowBtn)
            buttonsGroup.SetActive(true);
        currentShowInfoId = currentId;
        currentInfoType = ShowVariants.Upgrade;
    }
}