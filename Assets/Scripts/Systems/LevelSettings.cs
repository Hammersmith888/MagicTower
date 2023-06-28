using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using Random = UnityEngine.Random;

public class LevelSettings : MonoBehaviour
{
    [System.Serializable]
    public class HardLevel
    {
        public float[] easyCoef;
    }

    #region VARIABLES
    public HardLevel easyCoefs;
    [HideInInspector]
    public float easyCoef, hasteScrollCoef = 1f;
    private int[] scrollUsed = new int[6];
    private int[] potionUsed = new int[4];
    public int currentLevel;
    public ShotController shotController;
    public PlayerController playerController;
    public Text coinsValue; // Количество золота в ходе уровня
    public Text gemsValue; // Количество алмазов в ходе уровня

    private int AmountCoinsAfterGame;

    private SpellItem[] spellItems;
    public UpgradeItem[] upgradeItems;
    public bool wonFlag;
    public UIPauseController pauseObj;
    [HideInInspector]
    public bool VIPenabled;
    public EnemiesGenerator enemies;

    [HideInInspector]
    public float goldenMageCoef = 1f;
    [HideInInspector]
    public float usedGameSpeed = 1f, increasedUsedSpeed = 1.8f;
    public static float defaultUsedSpeed
    {
        get
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level_1_Tutorial")
                return 1.4f;
            else
                return 1f;
        }
    }
    #endregion

    private static LevelSettings m_Current;
    public static LevelSettings Current
    {
        get
        {
            if (m_Current == null)
            {
                m_Current = FindObjectOfType<LevelSettings>();
            }
            return m_Current;
        }
    }

    private void Awake()
    {
        goldenMageCoef = 1f;
        increasedUsedSpeed = 1.8f;
        usedGameSpeed = 1.4f;
        m_Current = this;
        SubAwake();
        //AnalyticsController.Instance.LogMyEvent("LevelStart", new System.Collections.Generic.Dictionary<string, string>() { { "Level", (currentLevel + 1).ToString() } });
        AnalyticsController.Instance.StartProgressionEvent(mainscript.CurrentLvl);
        if (SaveManager.GameProgress.Current.VIP)
        {
            VIPenabled = true;
        }
        var profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings);
        //if (profileSettings.showGemsCounter)
        {
            gemsValue.transform.parent.gameObject.SetActive(true);
        }

    }

    private void SubAwake()
    {
       
        wonFlag = false;
        // Загружаем сохранения
        LoadSaves();

        // Устанавливаем полученные сохранения о заклинаниях
        int spellTypesNumber = System.Enum.GetNames(typeof(Spell.SpellType)).Length;
        for (int i = 0; i < spellItems.Length; i++)
        {
            if (spellItems[i].active)
            {
                Spell.SpellType spellType;
                byte slotIndex = spellItems[i].slot;
                if (i >= spellTypesNumber)
                {
                    spellItems[i].active = false;
                    spellType = GetFirstAvailableSpellToSlot(spellItems, slotIndex, spellTypesNumber);
                }
                else
                {
                    spellType = SpellInfoUtils.GetSpellTypeBySpellDataIndex(i);
                }
                shotController.spells[slotIndex].spellType = spellType;
                shotController.spells[slotIndex].spellIcon.GetComponent<Button>().interactable = true; // Включить интерактивность кнопки выбора заклинания
                shotController.spells[slotIndex].spellIcon.transform.GetChild(4).gameObject.SetActive(true); // Включаем стоимость активного заклинания
                shotController.spells[slotIndex].spellIcon.transform.GetChild(5).gameObject.SetActive(false); // Выключаем замок активного заклинания
            }
        }

        currentLevel = mainscript.CurrentLvl - 1; //TODO: check naming of levels
#if UNITY_EDITOR
        Debug.LogFormat("<color=yellow>{0} {1}</color>", currentLevel, mainscript.CurrentLvl);
#endif
        easyCoef = 1f;
        if (PlayerPrefs.HasKey("LastHardLevel") && PlayerPrefs.GetInt("LastHardLevel") == currentLevel)
        {
            if (currentLevel < 4)
            {
                if (PlayerPrefs.GetInt("LastLoses") > 0)
                {
                    easyCoef = easyCoefs.easyCoef[2];
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("LastLoses") > 2)
                {
                    easyCoef = easyCoefs.easyCoef[1];
                }
                else if (PlayerPrefs.GetInt("LastLoses") > 1)
                {
                    easyCoef = easyCoefs.easyCoef[0];
                }
            }
        }
    }

    private void LoadSaves()
    {
        spellItems = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells).getInnerArray;
        upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades).getInnerArray;
        if (BuffsLoader.Instance != null)
        {
            goldenMageCoef = 1f + BuffsLoader.Instance.GetBuffValue(BuffType.additionalGold) / 100f;
        }
    }

    private Spell.SpellType GetFirstAvailableSpellToSlot(SpellItem[] spellItems, byte slotIndex, int spellsNumber)
    {
        for (int i = 0; i < spellsNumber; i++)
        {
            if (!spellItems[i].active && spellItems[i].unlock)
            {
                spellItems[i].active = true;
                spellItems[i].slot = slotIndex;
                return SpellInfoUtils.GetSpellTypeBySpellDataIndex(i);
            }
        }
        return Spell.SpellType.FireBall;
    }

    public void UsedScroll(int _id)
    {
        scrollUsed[_id]++;
    }

    public void UsedPotion(int _id)
    {
        potionUsed[_id]++;
    }

    public void LogLevelEnd(string EndType)
    {
        AnalyticsController.Instance.LogMyEvent(EndType, new System.Collections.Generic.Dictionary<string, string>() { { "Level", (currentLevel + 1).ToString() },
            {"Poison circle used", scrollUsed[0].ToString()},
            {"Barrier used", scrollUsed[1].ToString()},
            {"Frozen circle used", scrollUsed[2].ToString()},
            {"Mines used", scrollUsed[3].ToString()},
            {"Zombie used", scrollUsed[4].ToString()},
            {"Haste used", scrollUsed[5].ToString()},
            {"Mana used", potionUsed[0].ToString()},
            {"Health used", potionUsed[1].ToString()},
            {"Power used", potionUsed[2].ToString()},
            {"Resurrection used", potionUsed[3].ToString()},
        });
    }

    private void Start()
    {
        if(SoundController.Instanse != null)
        {
            SoundController.Instanse.StopAllBackgroundSFX();
            SoundController.Instanse.playAmbientSFX();
        }
        if (currentLevel < 2 || mainscript.CurrentLvl == 11)
        {
            StartMusicLevelRange();
        }
        else
        {
            var musicStartDelay = Random.Range(3, 5f);
            this.CallActionAfterDelayWithCoroutine(musicStartDelay, StartMusicLevelRange);
        }

        if (LevelPlayerHelpersLoader.Current == null)
        {
            gameObject.AddComponent<LevelPlayerHelpersLoader>();
        }
    }

    private void StartMusicLevelRange()
    {
        SoundController.Instanse.StartGamePlaySmoothLoopingForLevelRange();
    }

    public void Refresh()
    {
        SubAwake();
        shotController.Refresh();
    }

    private void SaveGoldToPP(int amount)
    {
        //Debug.Log("<b>FINAL GOLDS:</b> " + amount);

        //CoinsManager.AddCoinsST(amount);
        AnalyticsController.Instance.CurrencyAccrual(amount, DevToDev.AccrualType.Earned);
    }

    // Сохраняем изменения в конце уровня // Удачное прохождение
    public void FinalScoreVictory()
    {
        // Прогресс
        // fix this problem in nearest future
        currentLevel = currentLevel < 0 ? 0 : currentLevel;
        if (SaveManager.GameProgress.Current.finishCount[currentLevel] <= 0)
        {
            AnalyticsController.Instance.LevelUp(currentLevel + 1);
        }
        ++SaveManager.GameProgress.Current.finishCount[currentLevel];
        // Золото
        int earnedGold = (int)(float.Parse(coinsValue.text) * goldenMageCoef);
        //int healthGold = gameProgress.finishCount[currentLevel] == 1 ? (int)(playerController.CurrentHealth * goldenMageCoef) : 0;//Player gains health gold only on first win
        int healthGold = (int)(playerController.CurrentHealth * goldenMageCoef);//Player gains health gold only on first win
        //int levelGold = (int)((float)GetGoldFromLevel(currentLevel) * goldenMageCoef);
        //goldValue.text = (earnedGold + levelGold + (int)((earnedGold + levelGold) * healthGoldPercent)).ToString();
        // goldValue.text = (earnedGold + levelGold + healthGold).ToString();
        AmountCoinsAfterGame = earnedGold + healthGold;
        if (SaveManager.GameProgress.Current.bestScoreOnLevel == null)
        {
            SaveManager.GameProgress.Current.bestScoreOnLevel = new int[1000];
        }
        if (AmountCoinsAfterGame > SaveManager.GameProgress.Current.bestScoreOnLevel[currentLevel])
        {
            SaveManager.GameProgress.Current.bestScoreOnLevel[currentLevel] = AmountCoinsAfterGame;
        }

        var openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        if (SaveManager.GameProgress.Current.tutorial[0] != true && openLevel > 0)
        {
            SaveManager.GameProgress.Current.tutorial[0] = true;
            SaveManager.GameProgress.Current.tutorial[1] = false;
            // TutorAddCoins = 500;
            AmountCoinsAfterGame += TutorAddCoins;
        }
        SaveManager.GameProgress.Current.Save();
        PlayerPrefs.SetInt("achi_Machine_" + mainscript.CurrentLvl.ToString(), PlayerPrefs.GetInt("achi_Machine_" + mainscript.CurrentLvl.ToString()) + 1);
        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Hero, 1);
        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.HeroRoad, 1);
        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.VictoryRoad, 1);
        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.FirstWin, 1);
        if(PlayerPrefs.GetInt("achi_Machine_" + mainscript.CurrentLvl.ToString()) >= 5)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Machine, 5);
        if (!PlayerController.Instance.isHealthUse)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Invulnerable, 1);
        Achievement.AchievementController.Save();


        if (VIPenabled)
        {
            AmountCoinsAfterGame = (int)((float)AmountCoinsAfterGame * 1.5f);
        }

        SaveGoldToPP(AmountCoinsAfterGame);
        PPSerialization.SaveAllPendingSaves();
        #region ANALYTICS
        LogLevelEnd("Mission Completed");
        AnalyticsController.Instance.EndProgressionEvent(mainscript.CurrentLvl, AmountCoinsAfterGame, true);
        //AnalyticsController.instanse.LogMyEvent( "Mission Completed", new System.Collections.Generic.Dictionary<string, string>() { { "Level", (currentLevel + 1).ToString() } } );
        if (currentLevel == 10)
        {
            AnalyticsController.Instance.LogMyEvent("Mission Compleated 10");//Completed :/ увы уже не переименуешь что бы не ломать аналитику
        }
        if (currentLevel == 15)
        {
            AnalyticsController.Instance.LogMyEvent("Mission Compleated 15");
        }
        if (currentLevel == 30)
        {
            AnalyticsController.Instance.LogMyEvent("Mission Compleated 30");
        }
        if (currentLevel == 40)
        {
            AnalyticsController.Instance.LogMyEvent("Mission Compleated 40");
        }
        #endregion

    }

    [HideInInspector]
    public int TutorAddCoins = 0;
    public void FinalScoreDefeat()
    {
        AmountCoinsAfterGame = int.Parse(coinsValue.text);
        SaveGoldToPP(AmountCoinsAfterGame);
        GemsDropOnLevelData.SendDataToAnalytics();
        PPSerialization.SaveAllPendingSaves();
        LogLevelEnd("Defeat");
        AnalyticsController.Instance.EndProgressionEvent(mainscript.CurrentLvl, AmountCoinsAfterGame, false);
        //AnalyticsController.instanse.LogMyEvent( "Defeat", new System.Collections.Generic.Dictionary<string, string>() { { "Level", (currentLevel + 1).ToString() } } );
    }

    [SerializeField]
    private int[] AutoRewards;
    public int GetGoldFromLevel(int _levelNumber)
    {
        int levelsOpened = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);

        //Debug.Log("AutoRewards: " + AutoRewards.Length);

        //if (EndlessMode.EndlessModeManager.Current == null && AutoRewards.Length > _levelNumber && (_levelNumber == levelsOpened || AutoRewards[_levelNumber] < 0))
        //{
        //    return AutoRewards[_levelNumber];
        //}
        return AutoRewards[_levelNumber];

        //return 0;
    }

    public int GetSpellLevel(Spell.SpellType spellType)
    {
        // Прибавляем 1, т.к. в SpellItems - уровни хранятся от 0 до 7, а в таблице гугл от 1 до 8
        return spellItems[SpellInfoUtils.GetSpellSpellDataIndexBySpellType(spellType)].upgradeLevel + 1;
    }

    public float criticalModifier()
    {
        float to_return = 1f;
        float baseCritChance = 1f;
        float baseCritDamage = 1f;
        if (BuffsLoader.Instance != null)
        {
            baseCritChance = baseCritChance * BuffsLoader.Instance.GetBuffValue(BuffType.criticalChance) / 100f;
            baseCritDamage = baseCritDamage + (baseCritDamage * BuffsLoader.Instance.GetBuffValue(BuffType.criticalDamage) / 100f);
        }

        //Debug.Log($"baseCritChance: {baseCritChance}");
        //Debug.Log($"baseCritDamage: {baseCritDamage}");

        if (UnityEngine.Random.Range(0f, 1f) <= baseCritChance)
        {
            to_return = baseCritDamage;
        }
        return to_return;
    }

    public bool IsCriticalModifier(float criticalModifier)
    {
        //criticalModifier - значение расчитанное методом "criticalModifier"
        return criticalModifier > 1;
    }
}