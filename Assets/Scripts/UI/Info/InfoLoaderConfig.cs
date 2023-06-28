using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoLoaderConfig", menuName = "Custom/InfoLoaderConfig")]
public class InfoLoaderConfig : ScriptableObject
{
    private const string EMPTY_SPEED = "0";
    private static InfoLoaderConfig _instance;
    public static InfoLoaderConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<InfoLoaderConfig>("InfoLoaderConfig");
            }
            return _instance;
        }
    }

    [System.Serializable]
    private class TitleColors
    {
        public TitleColorTypes colorType;
        public Color color;
    }

    [System.Serializable]
    private class SpeedTextId
    {
        public SpeedTypes speed;
        public string id;
    }

    [System.Serializable]
    private class EnemyMeet
    {
        public EnemyType enemy;
        public int levelId;
    }

    [System.Serializable]
    private class SpellMeet
    {
        public Spell.SpellType spell;
        public int levelId;
    }

    [System.Serializable]
    private class ScrollMeet
    {
        public Scroll.ScrollType scroll;
        public int levelId;
    }
    [System.Serializable]
    private class UpgradeMeet
    {
        public UpgradeItem.UpgradeType upgrade;
        public int levelId;
    }

    [System.Serializable]
    public class EnemyBaseData : InfoBaseData
    {
        public EnemyType enemyType;
        public SpeedTypes speed;
        public AttackTypes attackType;
        public int openLevel;
        public bool showOnMap = true;
        public bool showOnLevel = true;

        [HideInInspector]
        public ResistOrVulnarebilityTextData resistOrVulnarebilityTextData;
    }

    [System.Serializable]
    public class SpellBaseData : InfoBaseData
    {
        public Spell.SpellType spellType;
        public DamageType damageType;
    }

    [System.Serializable]
    public class ScrollBaseData : InfoBaseData
    {
        public Scroll.ScrollType scrollType;
        public DamageType damageType;
    }

    [System.Serializable]
    public class UpgradeBaseData : InfoBaseData
    {
        public UpgradeItem.UpgradeType upgradeType;
    }

    [System.Serializable]
    public class ResistOrVulnarebilityTextData
    {
        public DamageType damageType;
        public string localTextId;
        [HideInInspector]
        public float percentValue;

        public string DescriptionText
        {
            get
            {
                string to_return = TextSheetLoader.Instance.GetString(localTextId).Replace("#", percentValue.ToString());
                return to_return;
            }
        }
    }

    public enum TitleColorTypes { HEALTH, DAMAGE, SPEED, WEAK, RESIST, OTHER1, OTHER2, OTHER3 };
    public enum SpeedTypes { VerySlow, Slow, Middle, Fast, VeryFast, Auto };
    public enum AttackTypes { Melee, Ranged, None };

    [ResourceFile(resourcesFolderPath = "Info")]
    [SerializeField]
    private string infoLine, infoLineIcon, infoEnemy, infoSpell, infoUpgrades;
    [SerializeField]
    public List<EnemyBaseData> infoEnemiesDatas = new List<EnemyBaseData>();
    [SerializeField]
    private List<SpellBaseData> infoSpellsDatas = new List<SpellBaseData>();
    [SerializeField]
    private List<ScrollBaseData> infoScrollsDatas = new List<ScrollBaseData>();
    [SerializeField]
    private List<UpgradeBaseData> infoUpgradesDatas = new List<UpgradeBaseData>();
    [SerializeField]
    private TitleColors[] titleColors;
    [SerializeField]
    private SpeedTextId[] speedIds;
    [SerializeField]
    private EnemyMeet[] enemyMeets;
    [SerializeField]
    private SpellMeet[] spellMeets;
    [SerializeField]
    private ScrollMeet[] scrollMeets;
    [SerializeField]
    private UpgradeMeet[] upgradeMeets;
    [SerializeField]
    private ResistOrVulnarebilityTextData[] resistTextDatas, vulnarebilityTextDatas;

    private EnemyParameters[] enemyParams;
    private SpellParameters[] spellParams;

    public int maxOpenedLevel = 0;

    public RectTransform InfoLineObject
    {
        get
        {
            RectTransform to_return = Resources.Load<RectTransform>(infoLine);
            if (to_return != null)
            {
                return to_return;
            }
            return null;
        }
    }

    public RectTransform InfoIconObject
    {
        get
        {
            RectTransform to_return = Resources.Load<RectTransform>(infoLineIcon);
            if (to_return != null)
            {
                return to_return;
            }
            return null;
        }
    }

    public GameObject InfoEnemyObject
    {
        get
        {
            GameObject to_return = Resources.Load<GameObject>(infoEnemy);
            if (to_return != null)
            {
                return to_return;
            }
            return null;
        }
    }

    public GameObject InfoSpellObject
    {
        get
        {
            GameObject to_return = Resources.Load<GameObject>(infoSpell);
            if (to_return != null)
            {
                return to_return;
            }
            return null;
        }
    }

    public GameObject InfoUpgradesObject
    {
        get
        {
            GameObject to_return = Resources.Load<GameObject>(infoUpgrades);
            if (to_return != null)
            {
                return to_return;
            }
            return null;
        }
    }

    public InfoBaseData GetEnemyBaseData(EnemyType enemyType)
    {
        if (enemyParams == null)
        {
            enemyParams = BalanceTables.Instance.EnemyParameters;
        }
        var index = 0;
        for (int i = 0; i < infoEnemiesDatas.Count; i++)
        {
            if (infoEnemiesDatas[i].enemyType == enemyType)
            {
                index = i;
                break;
            }
        }

        InfoBaseData _returnData = new InfoBaseData();

        _returnData = infoEnemiesDatas[index];

        if (infoEnemiesDatas[index].enemyType == EnemyType.aura_properties1 
            || infoEnemiesDatas[index].enemyType == EnemyType.aura_properties2
            || infoEnemiesDatas[index].enemyType == EnemyType.aura_properties3)
            return _returnData;

        int balanceIndex = GetEnemyIndex(enemyType);
        bool isVulnarablesVisible = VulnarablesIsEmpty(enemyParams[balanceIndex]);
        bool isResistanceVisible = ResistanceIsEmpty(enemyParams[balanceIndex]);
        string valueVulnarables = VulnarablesOfString(enemyParams[balanceIndex]);
        string valueResistence = ResistanceOfString(enemyParams[balanceIndex]);
        string speed = SpeedStringId(infoEnemiesDatas[index].speed);
        Sprite[] iconVulnarable = VulnarablesOfIcon(enemyParams[balanceIndex]);
        Sprite[] iconResistence = ResistanceOfIcon(enemyParams[balanceIndex]);
        string[] textsVulnarable = VulnarablesTexts(enemyParams[balanceIndex]);
        string[] textsResistance = ResistancesTexts(enemyParams[balanceIndex]);

        if (enemyParams[balanceIndex].health == 0)
        {
            _returnData.infoLineDatas[0].IsVisibleEmpty = true;
        }
        _returnData.infoLineDatas[0].valueLocaleId = enemyParams[balanceIndex].health.ToString();

        if (enemyParams[balanceIndex].dpStrike == 0)
        {
            _returnData.infoLineDatas[1].IsVisibleEmpty = true;
        }
        _returnData.infoLineDatas[1].valueLocaleId = enemyParams[balanceIndex].dpStrike.ToString();
        _returnData.infoLineDatas[1].titleLocaleId = AttackTypeStringId(infoEnemiesDatas[index].attackType);

        if (speed == EMPTY_SPEED)
        {
            _returnData.infoLineDatas[2].IsVisibleEmpty = true;
        }
        _returnData.infoLineDatas[2].valueLocaleId = speed;

        Debug.Log($"isVulnarablesVisible: {isVulnarablesVisible}");
        _returnData.infoLineDatas[3].titleLocaleId = "t_0427";
        _returnData.infoLineDatas[3].valueLocaleId = valueVulnarables;
        _returnData.infoLineDatas[3].IsVisibleEmpty = isVulnarablesVisible;
        _returnData.infoLineDatas[3].ValueiIcon = iconVulnarable;
        _returnData.infoLineDatas[3].resistOrVulnarebilityTexts = textsVulnarable;
        _returnData.infoLineDatas[3].IsVisibleIcon = true;

        _returnData.infoLineDatas[4].valueLocaleId = valueResistence;
        _returnData.infoLineDatas[4].IsVisibleEmpty = isResistanceVisible;
        _returnData.infoLineDatas[4].ValueiIcon = iconResistence;
        _returnData.infoLineDatas[4].resistOrVulnarebilityTexts = textsResistance;
        _returnData.infoLineDatas[4].IsVisibleIcon = true;

        SetBossLineNotVisible(_returnData);

        for (int i = 0; i < _returnData.infoLineDatas.Count; i++)
        {
            _returnData.infoLineDatas[i].titleColor = ColorForEnemyTitle(_returnData.infoLineDatas[i].enemyParamType);
            _returnData.infoLineDatas[i].valueColor = Color.white;
        }
        return _returnData;

        Debug.LogError($"Not found enemy data: {enemyType}");
        return null;
    }

    // public InfoBaseData GetEnemyBaseData(EnemyType enemyType)
    // {
    //     if (enemyParams == null)
    //     {
    //         enemyParams = BalanceTables.Instance.EnemyParameters;
    //     }

    //     //Debug.Log("GetEnemyBaseData " + enemyType);

    //     int index = 0;

    //     for (int i = 0; i < infoEnemiesDatas.Count; i++)
    //     {
    //         if (infoEnemiesDatas[i].enemyType == enemyType)
    //         {
    //             index = i;
    //             break;
    //         }
    //     }

    //     if (index == 29)
    //         return infoEnemiesDatas[index];



    //     InfoBaseData _returnData = new InfoBaseData();

    //     if (index < 0)
    //     {
    //         return _returnData;
    //     }



    //     _returnData = infoEnemiesDatas[index];

    //     int balanceIndex = GetEnemyIndex(enemyType);
    //     bool isVulnarablesVisible = VulnarablesIsEmpty(enemyParams[balanceIndex]);
    //     bool isResistanceVisible = ResistanceIsEmpty(enemyParams[balanceIndex]);
    //     string valueVulnarables = VulnarablesOfString(enemyParams[balanceIndex]);
    //     string valueResistence = ResistanceOfString(enemyParams[balanceIndex]);
    //     string speed = SpeedStringId(infoEnemiesDatas[index].speed);
    //     Sprite[] iconVulnarable = VulnarablesOfIcon(enemyParams[balanceIndex]);
    //     Sprite[] iconResistence = ResistanceOfIcon(enemyParams[balanceIndex]);
    //     string[] textsVulnarable = VulnarablesTexts(enemyParams[balanceIndex]);
    //     string[] textsResistance = ResistancesTexts(enemyParams[balanceIndex]);

    //     if (enemyParams[balanceIndex].health == 0)
    //     {
    //         _returnData.infoLineDatas[0].IsVisibleEmpty = true;
    //     }
    //     _returnData.infoLineDatas[0].valueLocaleId = enemyParams[balanceIndex].health.ToString();

    //     if (enemyParams[balanceIndex].dpStrike == 0)
    //     {
    //         _returnData.infoLineDatas[1].IsVisibleEmpty = true;
    //     }
    //     _returnData.infoLineDatas[1].valueLocaleId = enemyParams[balanceIndex].dpStrike.ToString();
    //     _returnData.infoLineDatas[1].titleLocaleId = AttackTypeStringId(infoEnemiesDatas[index].attackType);

    //     if (speed == EMPTY_SPEED)
    //     {
    //         _returnData.infoLineDatas[2].IsVisibleEmpty = true;
    //     }
    //     _returnData.infoLineDatas[2].valueLocaleId = speed;

    //     _returnData.infoLineDatas[3].titleLocaleId = "t_0427";
    //     _returnData.infoLineDatas[3].valueLocaleId = valueVulnarables;
    //     _returnData.infoLineDatas[3].IsVisibleEmpty = isVulnarablesVisible;
    //     _returnData.infoLineDatas[3].ValueiIcon = iconVulnarable;
    //     _returnData.infoLineDatas[3].resistOrVulnarebilityTexts = textsVulnarable;
    //     _returnData.infoLineDatas[3].IsVisibleIcon = true;

    //     _returnData.infoLineDatas[4].valueLocaleId = valueResistence;
    //     _returnData.infoLineDatas[4].IsVisibleEmpty = isResistanceVisible;
    //     _returnData.infoLineDatas[4].ValueiIcon = iconResistence;
    //     _returnData.infoLineDatas[4].resistOrVulnarebilityTexts = textsResistance;
    //     _returnData.infoLineDatas[4].IsVisibleIcon = true;

    //     SetBossLineNotVisible(_returnData);

    //     for (int i = 0; i < _returnData.infoLineDatas.Count; i++)
    //     {
    //         _returnData.infoLineDatas[i].titleColor = ColorForEnemyTitle(_returnData.infoLineDatas[i].enemyParamType);
    //         _returnData.infoLineDatas[i].valueColor = Color.white;
    //     }
    //     return _returnData;
    // }

    private void SetBossLineNotVisible(InfoBaseData _returnData)
    {
        for (int i = 0; i < _returnData.infoLineDatas.Count; i++)
        {
            if (_returnData.infoLineDatas[i].valueLocaleId == "t_0436") //BOSS
            {
                _returnData.infoLineDatas[i].IsVisibleEmpty = true;
                return;
            }
        }
    }

    private int GetEnemyIndex(EnemyType enemyType)
    {
        EnemyParametersSettings enemyParamsSettings = null;
        if (MyGSFU.enemyTypeToEnemyParamsMap.TryGetValue(enemyType, out enemyParamsSettings))
        {
            return enemyParamsSettings.enemyParamIndex;
        }
        return 0;
    }

    public Color ColorForEnemyTitle(TitleColorTypes titleColorType)
    {
        for (int i = 0; i < titleColors.Length; i++)
        {
            if (titleColors[i].colorType == titleColorType)
            {
                return titleColors[i].color;
            }
        }
        return Color.white;
    }

    private string VulnarablesOfString(EnemyParameters enemyParameters)
    {
        string to_return = "";
        if (enemyParameters.vulnerabilityFire != 0)
        {
            to_return += TextSheetLoader.Instance.GetString("t_0423");
        }
        if (enemyParameters.vulnerabilityAir != 0)
        {
            SeparatedComma(ref to_return);
            to_return += TextSheetLoader.Instance.GetString("t_0422");
        }
        if (enemyParameters.vulnerabilityEarth != 0)
        {
            SeparatedComma(ref to_return);
            to_return += TextSheetLoader.Instance.GetString("t_0425");
        }
        if (enemyParameters.vulnerabilityWater != 0)
        {
            SeparatedComma(ref to_return);
            to_return += TextSheetLoader.Instance.GetString("t_0424");
        }
        if (string.IsNullOrEmpty(to_return))
        {
            to_return = TextSheetLoader.Instance.GetString("t_0443");
        }
        return to_return;
    }

    private bool VulnarablesIsEmpty(EnemyParameters enemyParameters)
    {
        return !(enemyParameters.vulnerabilityFire != 0 ||
                 enemyParameters.vulnerabilityAir != 0 ||
                 enemyParameters.vulnerabilityEarth != 0 ||
                 enemyParameters.vulnerabilityWater != 0);
    }

    private Sprite[] VulnarablesOfIcon(EnemyParameters enemyParameters)
    {
        List<Sprite> sprites = new List<Sprite>();

        if (enemyParameters.vulnerabilityFire != 0)
        {
            sprites.Add(LoadFireIcon());
        }
        if (enemyParameters.vulnerabilityAir != 0)
        {
            sprites.Add(LoadAirIcon());
        }
        if (enemyParameters.vulnerabilityEarth != 0)
        {
            sprites.Add(LoadEarthIcon());
        }
        if (enemyParameters.vulnerabilityWater != 0)
        {
            sprites.Add(LoadWaterIcon());
        }
        if (sprites.Count == 0)
        {
            return null;
        }
        return sprites.ToArray();
    }

    private string ResistanceOfString(EnemyParameters enemyParameters)
    {
        string to_return = "";
        if (enemyParameters.resistanceFire != 0)
        {
            to_return += TextSheetLoader.Instance.GetString("t_0423");
        }
        if (enemyParameters.resistanceAir != 0)
        {
            SeparatedComma(ref to_return);
            to_return += TextSheetLoader.Instance.GetString("t_0422");
        }
        if (enemyParameters.resistanceEarth != 0)
        {
            SeparatedComma(ref to_return);
            to_return += TextSheetLoader.Instance.GetString("t_0425");
        }
        if (enemyParameters.resistanceWater != 0)
        {
            SeparatedComma(ref to_return);
            to_return += TextSheetLoader.Instance.GetString("t_0424");
        }
        if (string.IsNullOrEmpty(to_return))
        {
            to_return = TextSheetLoader.Instance.GetString("t_0443");
        }
        return to_return;
    }

    private Sprite[] ResistanceOfIcon(EnemyParameters enemyParameters)
    {
        List<Sprite> sprites = new List<Sprite>();

        if (enemyParameters.resistanceFire != 0)
        {
            sprites.Add(LoadFireIcon());
        }
        if (enemyParameters.resistanceAir != 0)
        {
            sprites.Add(LoadAirIcon());
        }
        if (enemyParameters.resistanceEarth != 0)
        {
            sprites.Add(LoadEarthIcon());
        }
        if (enemyParameters.resistanceWater != 0)
        {
            sprites.Add(LoadWaterIcon());
        }
        if (sprites.Count == 0)
        {
            return null;
        }
        return sprites.ToArray();
    }

    private bool ResistanceIsEmpty(EnemyParameters enemyParameters)
    {
        return !(enemyParameters.resistanceFire != 0 ||
                 enemyParameters.resistanceAir != 0 ||
                 enemyParameters.resistanceEarth != 0 ||
                 enemyParameters.resistanceWater != 0);
    }

    private Sprite LoadFireIcon()
    {
        return Resources.Load<Sprite>("Gems/Buffs/FireDamage");
    }

    private Sprite LoadAirIcon()
    {
        return Resources.Load<Sprite>("Gems/Buffs/DamageLight");
    }

    private Sprite LoadEarthIcon()
    {
        return Resources.Load<Sprite>("Gems/Buffs/DamageEarth");
    }

    private Sprite LoadWaterIcon()
    {
        return Resources.Load<Sprite>("Gems/Buffs/DamageIce_road");
    }

    private void SeparatedComma(ref string str)
    {
        if (!string.IsNullOrEmpty(str))
        {
            str += ", ";
        }
    }

    private string SpeedStringId(SpeedTypes speedType)
    {
        for (int i = 0; i < speedIds.Length; i++)
        {
            if (speedIds[i].speed == speedType)
            {
                return speedIds[i].id;
            }
        }
        return EMPTY_SPEED;
    }

    private string SpeedStringValue(SpeedTypes speedType)
    {
        for (int i = 0; i < speedIds.Length; i++)
        {
            if (speedIds[i].speed == speedType)
            {
                int val = (int)speedIds[i].speed;
                return ((val + 1) * 10).ToString();
            }
        }
        return EMPTY_SPEED;
    }

    public InfoBaseData GetSpellBaseData(int itemId, Spell.SpellType spellType)
    {
        if (spellParams == null)
        {
            spellParams = BalanceTables.Instance.SpellParameters;
        }

        int index = 0;

        for (int i = 0; i < infoSpellsDatas.Count; i++)
        {
            if (infoSpellsDatas[i].spellType == spellType)
            {
                index = i;
                break;
            }
        }

        InfoBaseData _returnData = new InfoBaseData();

        if (index < 0)
        {
            return _returnData;
        }
        Spell_Items spellItems = new Spell_Items(SpellItem.SpellsNumber);
        spellItems = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells);

        _returnData = infoSpellsDatas[index];
        int spellIndex = SpellInfoUtils.GetSpellSpellDataIndexBySpellType(spellType);
        int balanceIndex = GetTableSpellIndex(spellType) + spellItems[spellIndex].upgradeLevel;
        float damage = (float)((int)(spellParams[balanceIndex].maxDamage + spellParams[balanceIndex].minDamage) / 2);
        _returnData.infoLineDatas[0].valueLocaleId = damage.ToString();
        //_returnData.infoLineDatas[0].titleLocaleId = DamageTypeStringId(infoSpellsDatas[index].damageType);

        string secondsText = TextSheetLoader.Instance.GetString("t_0501");
        _returnData.infoLineDatas[1].valueLocaleId = spellParams[balanceIndex].reload + " " + secondsText;
        _returnData.infoLineDatas[1].titleLocaleId = "t_0466";

        _returnData.infoLineDatas[2].valueLocaleId = spellParams[balanceIndex].manacost.ToString();
        _returnData.infoLineDatas[2].titleLocaleId = "t_0467";

        for (int i = 0; i < _returnData.infoLineDatas.Count; i++)
        {
            _returnData.infoLineDatas[i].titleColor = ColorForEnemyTitle(_returnData.infoLineDatas[i].enemyParamType);
            _returnData.infoLineDatas[i].valueColor = Color.white;
        }
        return _returnData;
    }

    public int GetTableSpellIndex(Spell.SpellType spellType)
    {
        SpellParameters spellParamsSettings = new SpellParameters();
        if (MyGSFU.SpellTypeToSpellsParamsMap.TryGetValue(spellType, out spellParamsSettings))
        {
            return spellParamsSettings.spellTableIndex;
        }
        return 0;
    }

    private string AttackTypeStringId(AttackTypes attackType)
    {
        string to_return = "t_0429";
        switch (attackType)
        {
            case AttackTypes.Melee:
                to_return = "t_0429";
                break;
            case AttackTypes.Ranged:
                to_return = "t_0431";
                break;
        }
        return to_return;
    }

    public int EnemyMeetOnLevel(EnemyType enemyId)
    {
        for (int i = 0; i < enemyMeets.Length; i++)
        {
            if (enemyMeets[i].enemy == enemyId)
            {
                return enemyMeets[i].levelId;
            }
        }
        return 9999;
    }

    public List<EnemyType> GetEnemyTypesOnLevel(int level, bool getAllUntilCurrentLevel)
    {
        var result = new List<EnemyMeet>();
        var r = new List<EnemyType>();
        for (int i = 0; i < enemyMeets.Length; i++)
        {
            //if (getAllUntilCurrentLevel ? enemyMeets[i].levelId <= level : enemyMeets[i].levelId == level)
            //{

            //}
            result.Add(enemyMeets[i]);
        }

        var l = result.OrderBy((key) => key.levelId);

        //result.Sort(EnemyInfoIdsUnlockOrder.SortingByInfoUnlockIndex);

        foreach (var o in result)
        {
            // Debug.Log(o.enemy);
            r.Add(o.enemy);
        }


        return r;
    }

    public int SpellMeetOnLevel(Spell.SpellType spellId)
    {
        for (int i = 0; i < spellMeets.Length; i++)
        {
            if (spellMeets[i].spell == spellId)
            {
                return spellMeets[i].levelId;
            }
        }
        return 9999;
    }

    private string DamageTypeStringId(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.AIR:
                return "t_0422";
            case DamageType.EARTH:
                return "t_0425";
            case DamageType.FIRE:
                return "t_0423";
            case DamageType.WATER:
                return "t_0424";
        }

        return "t_0443";
    }


    public InfoBaseData GetScrollBaseData(int scrollTypeId)
    {
        if (spellParams == null)
        {
            spellParams = BalanceTables.Instance.SpellParameters;
        }

        int index = 0;

        for (int i = 0; i < infoScrollsDatas.Count; i++)
        {
            if (infoScrollsDatas[i].scrollType == (Scroll.ScrollType)scrollTypeId)
            {
                index = i;
                break;
            }
        }

        InfoBaseData _returnData = new InfoBaseData();

        if (index < 0)
        {
            return _returnData;
        }
        Scroll_Items scrollItems = new Scroll_Items(ScrollItem.ItemsNumber);
        scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);

        var balanceIds = MyGSFU.ScrollsBalanceIdsMap;
        var scrollParameters = BalanceTables.Instance.ScrollParameters;
        var enemyParameters = BalanceTables.Instance.EnemyParameters;

        _returnData = infoScrollsDatas[index];
        float neededParam = 0;
        int currentId = balanceIds[scrollTypeId] + scrollItems[scrollTypeId].upgradeLevel;

        //Switch Value
        switch (scrollTypeId)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                neededParam = ((int)scrollParameters[currentId].maxDamage + (int)scrollParameters[currentId].minDamage) / 2;
                _returnData.infoLineDatas[0].valueLocaleId = neededParam.ToString();
                break;
            case 4:
                neededParam = (int)enemyParameters[currentId].dpStrike;
                _returnData.infoLineDatas[1].valueLocaleId = neededParam.ToString();
                _returnData.infoLineDatas[0].valueLocaleId = ((int)enemyParameters[currentId].health).ToString();
                break;
            case 5:
                neededParam = (int)scrollParameters[currentId].abilityEffect;
                _returnData.infoLineDatas[0].valueLocaleId = "+" + neededParam.ToString() + "%";
                break;
        }

        //Switch Localization
        switch (scrollTypeId)
        {
            case 0:
            case 2:
            case 3:
            //_returnData.infoLineDatas[0].titleLocaleId = DamageTypeStringId(infoScrollsDatas[index].damageType);
            //break;
            case 1:
                // _returnData.infoLineDatas[0].titleLocaleId = "t_0428";
                break;
            case 4:
                _returnData.infoLineDatas[1].titleLocaleId = "t_0429";
                // _returnData.infoLineDatas[0].titleLocaleId = "t_0428";
                break;
            case 5:
                _returnData.infoLineDatas[0].titleLocaleId = "t_0434";
                break;
        }

        for (int i = 0; i < _returnData.infoLineDatas.Count; i++)
        {
            _returnData.infoLineDatas[i].titleColor = ColorForEnemyTitle(_returnData.infoLineDatas[i].enemyParamType);
            _returnData.infoLineDatas[i].valueColor = Color.white;
        }
        return _returnData;
    }

    public InfoBaseData GetUpgradeBaseData(int upgradeTypeId)
    {

        int index = 0;

        for (int i = 0; i < infoUpgradesDatas.Count; i++)
        {
            if (infoUpgradesDatas[i].upgradeType == (UpgradeItem.UpgradeType)upgradeTypeId)
            {
                index = i;
                break;
            }
        }

        InfoBaseData _returnData = new InfoBaseData();

        if (index < 0)
        {
            return _returnData;
        }
        _returnData = infoUpgradesDatas[index];

        return _returnData;
    }

    public int GetScrollIndex(Scroll.ScrollType scrollType)
    {
        SpellParameters spellParamsSettings = new SpellParameters();
        if (MyGSFU.ScrollTypeToSpellParamsMap.TryGetValue(scrollType, out spellParamsSettings))
        {
            return spellParamsSettings.spellTableIndex;
        }
        return 0;
    }

    public int ScrollMeetOnLevel(Scroll.ScrollType scrollId)
    {
        for (int i = 0; i < spellMeets.Length; i++)
        {
            if (scrollMeets[i].scroll == scrollId)
            {
                return scrollMeets[i].levelId;
            }
        }
        return 9999;
    }

    public int UpgradeMeetOnLevel(UpgradeItem.UpgradeType upgradeId)
    {
        for (int i = 0; i < upgradeMeets.Length; i++)
        {
            if (upgradeMeets[i].upgrade == upgradeId)
            {
                return upgradeMeets[i].levelId;
            }
        }
        return 9999;
    }

    public ResistOrVulnarebilityTextData GetResistData(DamageType damageType)
    {
        for (int i = 0; i < resistTextDatas.Length; i++)
        {
            if (resistTextDatas[i].damageType == damageType)
            {
                return resistTextDatas[i];
            }
        }

        return new ResistOrVulnarebilityTextData();
    }

    public ResistOrVulnarebilityTextData GetVulnerabilityData(DamageType damageType)
    {
        for (int i = 0; i < vulnarebilityTextDatas.Length; i++)
        {
            if (vulnarebilityTextDatas[i].damageType == damageType)
            {
                return vulnarebilityTextDatas[i];
            }
        }

        return new ResistOrVulnarebilityTextData();
    }

    private string[] VulnarablesTexts(EnemyParameters enemyParameters)
    {
        List<string> texts = new List<string>();

        if (enemyParameters.vulnerabilityFire != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetVulnerabilityData(DamageType.FIRE).localTextId).Replace("#", enemyParameters.vulnerabilityFire.ToString()));
        }
        if (enemyParameters.vulnerabilityAir != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetVulnerabilityData(DamageType.AIR).localTextId).Replace("#", enemyParameters.vulnerabilityAir.ToString()));
        }
        if (enemyParameters.vulnerabilityEarth != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetVulnerabilityData(DamageType.EARTH).localTextId).Replace("#", enemyParameters.vulnerabilityEarth.ToString()));
        }
        if (enemyParameters.vulnerabilityWater != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetVulnerabilityData(DamageType.WATER).localTextId).Replace("#", enemyParameters.vulnerabilityWater.ToString()));
        }
        if (texts.Count == 0)
        {
            return null;
        }
        return texts.ToArray();
    }

    private string[] ResistancesTexts(EnemyParameters enemyParameters)
    {
        List<string> texts = new List<string>();

        if (enemyParameters.resistanceFire != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetResistData(DamageType.FIRE).localTextId).Replace("#", enemyParameters.resistanceFire.ToString()));
        }
        if (enemyParameters.resistanceAir != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetResistData(DamageType.AIR).localTextId).Replace("#", enemyParameters.resistanceAir.ToString()));
        }
        if (enemyParameters.resistanceEarth != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetResistData(DamageType.EARTH).localTextId).Replace("#", enemyParameters.resistanceEarth.ToString()));
        }
        if (enemyParameters.resistanceWater != 0)
        {
            texts.Add(TextSheetLoader.Instance.GetString(GetResistData(DamageType.WATER).localTextId).Replace("#", enemyParameters.resistanceWater.ToString()));
        }
        if (texts.Count == 0)
        {
            return null;
        }
        return texts.ToArray();
    }
}