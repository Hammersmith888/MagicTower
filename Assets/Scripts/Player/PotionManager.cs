using UnityEngine;
using UnityEngine.UI;

public struct PotionUseParameters
{
    public PotionManager.EPotionType potionType;
    public bool used;
    public int healthRecovery;
    public int manaRecovery;
}

public class PotionManager : MonoBehaviour
{
    public enum EPotionType
    {
        Mana, Health, Power, Resurrection
    }

    private const float SAVE_TO_CLOUD_INTERVAL = 5f;
    #region VARIABLES

    [SerializeField]
    private Button ManaPotionButton;
    [SerializeField]
    private Button HealthPotionButton;
    [SerializeField]
    private Button PowerPotionButton;

    [SerializeField]
    private Text ressurectionText;

    PotionsParameters[] potions = null;

    private static Potion_Items potionItems;
    private Text[] potionTexts; // Текст количества зелий

    private Button[] potionButtons; // Кнопки использования зелий

    private float lastSaveToCloudTime;

    private static PotionManager m_Current;
    public static PotionManager Current
    {
        get
        {
            if (m_Current == null)
            {
                m_Current = FindObjectOfType<PotionManager>();
            }
            return m_Current;
        }
    }
    #endregion

    private void Start()
    {
        m_Current = this;
        ManaPotionButton.onClick.AddListener(OnManaPotionClicked);
        HealthPotionButton.onClick.AddListener(OnHealthPotionClicked);
        PowerPotionButton.onClick.AddListener(OnPowerPotionClicked);
        // Устанавливаем ссылки на текстовые компоненты, отображающие количество каждого зелья
        potionButtons = new Button[3] { ManaPotionButton, HealthPotionButton, PowerPotionButton };
        potionTexts = new Text[potionButtons.Length];
        for (int i = 0; i < potionButtons.Length; i++)
        {
            potionTexts[i] = potionButtons[i].transform.GetChild(0).GetChild(0).GetComponent<Text>();
        }

        lastSaveToCloudTime = Time.unscaledTime - SAVE_TO_CLOUD_INTERVAL;
        potions = BalanceTables.Instance.PotionsParameters;
        RefreshDataAndUpdateUI();

        if(!SaveManager.GameProgress.Current.firstLevelPotion && mainscript.CurrentLvl == 1)
        {
            AddPotion(EPotionType.Health, 2);
            AddPotion(EPotionType.Mana, 3);
            AddPotion(EPotionType.Power, 1);
            RefreshDataAndUpdateUI();
            SaveManager.GameProgress.Current.firstLevelPotion = true;
            SaveManager.GameProgress.Current.Save();
        }

    }

    private void OnManaPotionClicked()
    {
        TryUsePotion(EPotionType.Mana);
    }

    private void OnHealthPotionClicked()
    {
        TryUsePotion(EPotionType.Health);
    }

    private void OnPowerPotionClicked()
    {
        TryUsePotion(EPotionType.Power);
    }

    private void TryUsePotion(EPotionType potionType)
    {
        RefreshDataAndUpdateUI();
        var canBeUsed = potionItems[(int)potionType].count > 0 && PlayerController.CanUsePotion(potionType);
        if (canBeUsed)
        {
            potionItems[(int)potionType].count = potionItems[(int)potionType].count - 1;
            UpdateUI(potionType);
            if(potionType == EPotionType.Health)
                Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Healer, 1);
            if (potionType == EPotionType.Power)
                Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.IAmPower, 1);
            Achievement.AchievementController.Save();
            SoundController.Instanse.playUseBottleSFX();
            SaveChanges();
        }
        var parameters = new PotionUseParameters()
        {
            potionType = potionType,
            used = canBeUsed,
        };
        SetPotionRecovery(potionType, potionItems[(int)potionType].upgradeLevel, out parameters.healthRecovery, out parameters.manaRecovery);
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.POTION_USE, parameters);
    }

    private void SetPotionRecovery(EPotionType potionType, int upgradeLevel, out int healthRecovery, out int manaRecovery)
    {
        //Debug.Log($"- ---- - POSTIONS: {potions.Length} ");
        healthRecovery = 0;
        manaRecovery = 0;
        // Устанавливаем значение маны и здоровья в соответствии с текущим выбранным зельем и его уровнем upgrade
        switch (potionType)
        {
            case EPotionType.Mana:
                manaRecovery =  (int)potions[upgradeLevel].add_value;
                break;
            case EPotionType.Health:
                healthRecovery = (int)potions[(potions.Length / 3) + upgradeLevel].add_value;
                break;
            case EPotionType.Power:
                manaRecovery = (int)potions[(potions.Length / 3) * 2 + upgradeLevel].add_value;
                healthRecovery = (int)potions[(potions.Length / 3) * 2 + upgradeLevel].add_value;
                break;
        }
    }

    private void AddPotionInternal(EPotionType potionType, int number = 1)
    {
        RefreshDataAndUpdateUI();
        potionItems[(int)potionType].count += number;
        UpdateUI(potionType);
        SaveChanges();
    }

    private void SaveChanges()
    {
        if (Time.unscaledTime - lastSaveToCloudTime >= SAVE_TO_CLOUD_INTERVAL)
        {
            lastSaveToCloudTime = Time.unscaledTime;
            PPSerialization.Save(EPrefsKeys.Potions, potionItems, true);
        }
        else
        {
            PPSerialization.Save(EPrefsKeys.Potions, potionItems, false);
        }
    }

    public void UpdateUI(EPotionType potionType)
    {
        var index = (int)potionType;
        var potionsItem = potionItems[index];
        if (index >= potionTexts.Length)
        {
            if (ressurectionText != null && potionType == EPotionType.Resurrection)
                ressurectionText.text = potionsItem.count.ToString();

            return;
        }
        potionTexts[index].text = potionsItem.count.ToString();
        var isAnyPotion = potionsItem.count > 0;
        potionButtons[index].interactable = isAnyPotion;
        potionButtons[index].transform.GetChild(0).gameObject.SetActive(isAnyPotion);
        potionButtons[index].transform.GetChild(1).gameObject.SetActive(!isAnyPotion);
    }

    public void RefreshDataAndUpdateUI()
    {
        potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
        UpdateUI(EPotionType.Mana);
        UpdateUI(EPotionType.Health);
        UpdateUI(EPotionType.Power);
    }

    #region Static Methods
    public static bool IsAnyPotion(EPotionType potionType)
    {
        if (Current != null)
        {
            if (potionItems == null || potionItems.getInnerArray.IsNullOrEmpty())
            {
                m_Current.RefreshDataAndUpdateUI();
            }
            return potionItems[(int)potionType].count > 0;
        }
        else
        {
            var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
            return potionItems[(int)potionType].count > 0;
        }
    }


    public static int GetPotionsNumber(EPotionType potionType)
    {
        if (Current != null)
        {
            if (potionItems == null || potionItems.getInnerArray.IsNullOrEmpty())
            {
                m_Current.RefreshDataAndUpdateUI();
            }
            return potionItems[(int)potionType].count;
        }
        else
        {
            var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
            return potionItems[(int)potionType].count;
        }
    }

    public static void UseRessurectionPotion()
    {
        potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
        if (Current != null)
        {
            //if (m_Current.potionItems == null || m_Current.potionItems.getInnerArray.IsNullOrEmpty())
            //{
            //    m_Current.RefreshDataAndUpdateUI();
            //}
            if (potionItems[(int)EPotionType.Resurrection].count == 0)
            {
                //Debug.LogError("Ressurection potions number already is 0");
                return;
            }
            potionItems[(int)EPotionType.Resurrection].count--;
            m_Current.SaveChanges();
        }
        else
        {
            var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
            if (potionItems[(int)EPotionType.Resurrection].count == 0)
            {
                Debug.LogError("Ressurection potions number already is 0");
                return;
            }
            potionItems[(int)EPotionType.Resurrection].count--;
            PPSerialization.Save(EPrefsKeys.Potions, potionItems, false);
        }
    }

    public static void RefreshPotionsCount()
    {
        if (m_Current != null)
        {
            m_Current.RefreshDataAndUpdateUI();
        }
    }

    public static void AddPotionForTutorial(EPotionType potionType)
    {
        if (Current != null)
        {
            if (potionItems == null || potionItems.getInnerArray.IsNullOrEmpty())
            {
                m_Current.RefreshDataAndUpdateUI();
            }
            if (potionItems[(int)potionType].count == 0)
            {
                m_Current.AddPotionInternal(potionType);
            }
        }
    }

    public static void AddPotion(EPotionType potionType, int number = 1)
    {
        if (Current != null)
        {
            if (potionItems == null || potionItems.getInnerArray.IsNullOrEmpty())
            {
                m_Current.RefreshDataAndUpdateUI();
            }
            m_Current.AddPotionInternal(potionType, number);
        }
        else
        {
            var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
            potionItems[(int)potionType].count += number;
            PPSerialization.Save(EPrefsKeys.Potions, potionItems, false);
        }
    }
    #endregion


    public void AutoUsePotion(EPotionType potionType)
    {
        if (LevelPlayerHelpersLoader.Current == null)
        {
            return;
        }

        if (IsAnyPotion(potionType))
        {
            switch (potionType)
            {
                case EPotionType.Mana:
                    if (LevelPlayerHelpersLoader.Current.manaUse)
                    {
                        TryUsePotion(potionType);
                    }
                    break;
                case EPotionType.Health:
                    if (LevelPlayerHelpersLoader.Current.healthUse)
                    {
                        TryUsePotion(potionType);
                    }
                    break;
            }
        } else
        {
            if (LevelPlayerHelpersLoader.Current.powerUse)
            {
                TryUsePotion( EPotionType.Power);
            }
        }
    }

   

}