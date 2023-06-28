using UnityEngine;
using System.Collections.Generic;

public partial class MyGSFU : MonoBehaviour
{
    public GameObject enemyGenerator, shotController;

    public CharacterUpgradesValues[] charUpgradesValues;

    private CharacterUpgradeParameters[] characterUpgrades;
    private SpellParameters[] spellParams;
    private SpellParameters[] scrollParams;
    public EnemyParameters[] enemyParams { get; private set; }

    #region ENEMY PARAMS MAP
    public static readonly Dictionary<EnemyType, EnemyParametersSettings> enemyTypeToEnemyParamsMap = new Dictionary<EnemyType, EnemyParametersSettings>()
    {
        { EnemyType.zombie_walk, new EnemyParametersSettings() { enemyParamIndex = 0} },
        { EnemyType.zombie_big, new EnemyParametersSettings() { enemyParamIndex = 3, hasMetamorph = true, hasSpecMove = true } },
        { EnemyType.zombie_fire, new EnemyParametersSettings() { enemyParamIndex = 92} },
        { EnemyType.zombie_boss, new EnemyParametersSettings() { enemyParamIndex = 18} },
        { EnemyType.zombie_fatty, new EnemyParametersSettings() { enemyParamIndex = 15, hasSpecMove = true, hasSpecDamage= true  } },
        { EnemyType.zombie_murderer, new EnemyParametersSettings() { enemyParamIndex = 12} },
        { EnemyType.zombie_snapper, new EnemyParametersSettings() { enemyParamIndex = 9} },
        { EnemyType.skeleton_grunt, new EnemyParametersSettings() { enemyParamIndex = 33} },
        { EnemyType.skeleton_archer, new EnemyParametersSettings() { enemyParamIndex = 30} },
        { EnemyType.skeleton_king, new EnemyParametersSettings() { enemyParamIndex = 81} },
        { EnemyType.skeleton_mage, new EnemyParametersSettings() { enemyParamIndex = 21} },
        { EnemyType.skeleton_swordsman, new EnemyParametersSettings() { enemyParamIndex = 27, hasSpecMove = true} },
        { EnemyType.skeleton_mage2, new EnemyParametersSettings() { enemyParamIndex = 45} },
        { EnemyType.skeleton_strong_mage, new EnemyParametersSettings() { enemyParamIndex = 36} },
        { EnemyType.skeleton_strong_mage2, new EnemyParametersSettings() { enemyParamIndex = 48} },
        { EnemyType.zombie_brain, new EnemyParametersSettings() { enemyParamIndex = 24} },
        { EnemyType.skeleton_tom, new EnemyParametersSettings() { enemyParamIndex = 39} },
        { EnemyType.ghoul_scavenger, new EnemyParametersSettings() { enemyParamIndex = 51} },
        { EnemyType.ghoul, new EnemyParametersSettings() { enemyParamIndex = 69, hasSpecMove = true} },
        { EnemyType.ghoul_boss, new EnemyParametersSettings() { enemyParamIndex = 78} },
        { EnemyType.ghoul_festering, new EnemyParametersSettings() { enemyParamIndex = 75} },
        { EnemyType.ghoul_grotesque, new EnemyParametersSettings() { enemyParamIndex = 72} },
        { EnemyType.demon_bomb, new EnemyParametersSettings() { enemyParamIndex = 63, hasSpecMove = true} },
        { EnemyType.demon_boss, new EnemyParametersSettings() { enemyParamIndex = 66} },
        { EnemyType.demon_fatty, new EnemyParametersSettings() { enemyParamIndex = 60} },
        { EnemyType.demon_grunt, new EnemyParametersSettings() { enemyParamIndex = 57, hasSpecMove = true, hasSpecDamage = true} },
        { EnemyType.demon_imp, new EnemyParametersSettings() { enemyParamIndex = 54, hasSpecMove = true} },
        { EnemyType.burned_king, new EnemyParametersSettings() { enemyParamIndex = 42, hasSpecMove = true} },
        { EnemyType.zombie_snapper_big, new EnemyParametersSettings() { enemyParamIndex = 95, hasSpecMove = true, hasSpecDamage = true} },
        { EnemyType.skeleton_archer_big, new EnemyParametersSettings() { enemyParamIndex = 101, hasSpecMove = true} },
        { EnemyType.skeleton_swordsman_big, new EnemyParametersSettings() { enemyParamIndex = 98, hasSpecMove = true} },
    };
    #endregion

    public bool alreadySet;

    private static MyGSFU _current;
    public static MyGSFU current
    {
        get
        {
            if (_current == null)
            {
                _current = FindObjectOfType<MyGSFU>();
                _current.SetAllParameters();
            }
            return _current;
        }
    }

    void Start()
    {
        _current = this;
        SetAllParameters();
    }

    public void SetAllParameters()
    {
        //print("mgsfu SetAllParameters");
        if (alreadySet)
        {
            return;
        }

        alreadySet = true;

        spellParams = BalanceTables.Instance.SpellParameters;
        scrollParams = BalanceTables.Instance.ScrollParameters;
        enemyParams = BalanceTables.Instance.EnemyParameters;
        characterUpgrades = BalanceTables.Instance.CharacterUpgrades;
        charUpgradesValues = new CharacterUpgradesValues[5];

        //Debug.Log("SetAllParameters");
        // Установка параметров заклинаний
        if (shotController != null && spellParams.Length > 0)
        {
            //SetFireBallParameters();
            //SetLightingParameters();
            //SetIceStrikeParameters();
            //SetRollingBowlderParameters();
            //SetChainLightingParameters();
            //SetIceBreathParameters();
            //SetFireWallParameters();
            //SetAcidSprayParameters();

            // Установка параметров свитков
            //SetAcidScrollParameters();
            //SetBarrierScrollParameters();
            //SetFreezScrollParameters();
            //SetMinesScrollParameters();

            SetManaUpgradeParameters();
            SetFireWallUpgradeParameters();
            SetDragonUpgradeParameters();
            SetDragonFrostUpgradeParameters();
            SetHealthUpgradeParameters();
        }
        else
        {
            print("setparams fail, spellParams.Length = " + spellParams.Length);
        }
        // Когда все параметры загрузятся и установятся, включаем объекты заклинаний и генерации монстров
        if (enemyGenerator != null)
        {
            enemyGenerator.SetActive(true);
        }
        if (shotController != null)
        {
            shotController.SetActive(true);
        }
    }
 

    #region ENEMIES
    public void ApplyEnemyParameters(EnemyCharacter enemyCharacter, EnemyMover enemyMover, int enemyIndex = 0)
    {
        if (enemyParams.IsNullOrEmpty())
        {
            Debug.Log("Enemy_Parameters is null or empty");
            return;
        }
        EnemyParametersSettings enemyParamsSettings = null;
        if (enemyTypeToEnemyParamsMap.TryGetValue(enemyCharacter.enemyType, out enemyParamsSettings))
        {
            enemyIndex = enemyParamsSettings.enemyParamIndex;
            if (enemyParams.Length <= enemyIndex)
            {
                Debug.LogErrorFormat("EnemyParameters index out of range Index: {0}  ParamsLength: {1} EnemyType: {2}", enemyIndex, enemyParams.Length, enemyCharacter.enemyType);
                return;
            }
            enemyCharacter.health = enemyParams[enemyIndex].health;
            enemyCharacter.damage = enemyParams[enemyIndex].dpStrike;
            enemyCharacter.indexFreeze = enemyParams[enemyIndex].indexFreeze;
            if (enemyParamsSettings.hasSpecDamage)
            {
                enemyCharacter.specDamage = enemyParams[enemyIndex].dpSpecialStrike;
            }
            if (enemyParamsSettings.hasMetamorph)
            {
                enemyCharacter.lowHealth = enemyParams[enemyIndex].metamorph;
            }
            enemyCharacter.attackSpeed = enemyParams[enemyIndex].attackSpeed;

            enemyCharacter.gold = (int)enemyParams[enemyIndex].gold;
            enemyMover.InitializeSpeed(enemyParams[enemyIndex].speed); // Делим на 10, т.к. в таблице скорость - за сколько секунд преодолевается все поле, в игре скорость - юниты в секунду
            if (enemyParamsSettings.hasSpecMove)
            {
                enemyMover.InitialieSpecSpeed(enemyParams[enemyIndex].specialSpeed);
            }

            enemyCharacter.SetupVulnerabilities(enemyParams[enemyIndex].vulnerabilityFire,
                enemyParams[enemyIndex].vulnerabilityAir,
                enemyParams[enemyIndex].vulnerabilityWater,
                enemyParams[enemyIndex].vulnerabilityEarth);
            enemyCharacter.SetupResistances
            (enemyParams[enemyIndex].resistanceFire,
            enemyParams[enemyIndex].resistanceAir,
            enemyParams[enemyIndex].resistanceWater,
            enemyParams[enemyIndex].resistanceEarth);
        }
        else
        {
            Debug.LogErrorFormat("No EnemyParametersSettings for enemy with type {0}", enemyCharacter.enemyType);
        }
    }
    public void ApplyFriendlyParameters(EnemyCharacter enemyCharacter, EnemyMover enemyMover, int enemyIndex = 86)
    {
        enemyCharacter.health = enemyParams[enemyIndex].health;
        enemyCharacter.damage = enemyParams[enemyIndex].dpStrike;

        enemyCharacter.attackSpeed = enemyParams[enemyIndex].attackSpeed;

        enemyMover.InitializeSpeed(enemyParams[enemyIndex].speed); // Делим на 10, т.к. в таблице скорость - за сколько секунд преодолевается все поле, в игре скорость - юниты в секунду
        enemyCharacter.SetupVulnerabilities(enemyParams[enemyIndex].vulnerabilityFire,
            enemyParams[enemyIndex].vulnerabilityAir,
            enemyParams[enemyIndex].vulnerabilityWater,
            enemyParams[enemyIndex].vulnerabilityEarth);
        enemyCharacter.SetupResistances(enemyParams[enemyIndex].resistanceFire,
            enemyParams[enemyIndex].resistanceAir,
            enemyParams[enemyIndex].resistanceWater,
            enemyParams[enemyIndex].resistanceEarth);
    }

    public void ApplyEnemyParameters(GameObject enemyPrefab)
    {
        ApplyEnemyParameters(enemyPrefab.GetComponent<EnemyCharacter>(), enemyPrefab.GetComponent<EnemyMover>());
    }
    #endregion
}
