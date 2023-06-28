using UnityEngine;

[CreateAssetMenu(fileName = "BalanceTables.asset", menuName = "Custom/Create BalanceTables")]
public class BalanceTables : ScriptableObject
{
    [SerializeField]
    private SpellParameters[] spellParams;
    [SerializeField]
    private SpellParameters[] scrollParameters;
    [SerializeField]
    private EnemyParameters[] enemyParams;
    [SerializeField]
    private PotionsParameters[] potionsParams;
    [SerializeField]
    private CharacterUpgradeParameters[] characterUpgrades;
    [SerializeField]
    private BottlesWinParameters[] bottlesWinParams;

    [SerializeField]
    private OtherParameters[] otherParams;

    [SerializeField]
    public GemSellCostParameters[] gemSellCostParams;

    public SpellParameters[] SpellParameters
    {
        get
        {
            var copy = new SpellParameters[spellParams.Length];
            spellParams.CopyTo(copy, 0);
            return copy;
        }
    }

    public SpellParameters[] ScrollParameters
    {
        get
        {
            var copy = new SpellParameters[scrollParameters.Length];
            scrollParameters.CopyTo(copy, 0);
            return copy;
        }
    }

    public EnemyParameters[] EnemyParameters
    {
        get
        {
            var copy = new EnemyParameters[enemyParams.Length];
            enemyParams.CopyTo(copy, 0);
            return copy;
        }
    }

    public PotionsParameters[] PotionsParameters
    {
        get
        {
            var copy = new PotionsParameters[potionsParams.Length];
            potionsParams.CopyTo(copy, 0);
            return copy;
        }
    }

    public BottlesWinParameters[] BottlesWinParameters
    {
        get
        {
            var copy = new BottlesWinParameters[bottlesWinParams.Length];
            bottlesWinParams.CopyTo(copy, 0);
            return copy;
        }
    }

    public CharacterUpgradeParameters[] CharacterUpgrades
    {
        get
        {
            var copy = new CharacterUpgradeParameters[characterUpgrades.Length];
            characterUpgrades.CopyTo(copy, 0);
            return copy;
        }
    }

    public OtherParameters[] OtherParameters
    {
        get
        {
            var copy = new OtherParameters[otherParams.Length];
            otherParams.CopyTo(copy, 0);
            return copy;
        }
    } 
    
    public GemSellCostParameters[] GemSellCostParameters
    {
        get
        {
            var copy = new GemSellCostParameters[gemSellCostParams.Length];
            gemSellCostParams.CopyTo(copy, 0);
            return copy;
        }
    }

    private static BalanceTables _instance;
    public static BalanceTables Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<BalanceTables>("BalanceTables");
#if UNITY_EDITOR
                if (_instance == null)
                {
                    Debug.Log("BalanceTables asset is not found creating new...");
                    _instance = ScriptableObject.CreateInstance<BalanceTables>();
                    UnityEditor.AssetDatabase.CreateAsset(_instance, "Assets/Resources/BalanceTables.asset");
                    UnityEditor.AssetDatabase.SaveAssets();
                    UnityEditor.AssetDatabase.Refresh();
                }
#endif
#if UNITY_STANDALONE && !UNITY_EDITOR
                _instance.ApplyBalanceFromSaveContainer();
#endif
            }

            return _instance;
        }
    }

#if UNITY_STANDALONE
    public void ApplyBalanceFromSaveContainer()
    {
        if (PlayBalanceSaver.CurrentSaveContainer == null)
        {
            Debug.LogError("PlayBalanceSaver.CurrentSaveContainer is null");
            return;
        }
        if (!PlayBalanceSaver.CurrentSaveContainer.IsValid)
        {
            Debug.LogError("PlayBalanceSaver.CurrentSaveContainer data is not valid");
            return;
        }
        spellParams = PlayBalanceSaver.CurrentSaveContainer.spellParamsSave.getInnerArray;
        scrollParameters = PlayBalanceSaver.CurrentSaveContainer.scrollParamsSave.getInnerArray;
        characterUpgrades = PlayBalanceSaver.CurrentSaveContainer.characterUpgradesSave.getInnerArray;
        enemyParams = PlayBalanceSaver.CurrentSaveContainer.enemyParamsSave.getInnerArray;
        Debug.Log("New balance saved to BalanceTables");
    }
#endif

#if UNITY_EDITOR
    public void SetBalanceData(SpellParameters[] spellParams, SpellParameters[] scrollParams,
        EnemyParameters[] enemyParams, CharacterUpgradeParameters[] characterUpgrades,
        PotionsParameters[] potions, BottlesWinParameters[] bottles, OtherParameters[] other)
    {
        this.spellParams = spellParams;
        this.scrollParameters = scrollParams;
        this.enemyParams = enemyParams;
        this.characterUpgrades = characterUpgrades;
        this.potionsParams = potions;
        this.bottlesWinParams = bottles;
        this.otherParams = other;

        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();

    }
#else
     public void SetBalanceData(SpellParameters[] spellParams, SpellParameters[] scrollParams,
    EnemyParameters[] enemyParams, CharacterUpgradeParameters[] characterUpgrades,
    PotionsParameters[] potions, BottlesWinParameters[] bottles, OtherParameters[] other)
    {
        this.spellParams = spellParams;
        this.scrollParameters = scrollParams;
        this.enemyParams = enemyParams;
        this.characterUpgrades = characterUpgrades;
        this.potionsParams = potions;
        this.bottlesWinParams = bottles;
        this.otherParams = other;
    }
#endif
}
