using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UI;
using ADs;

public class EnemiesGenerator : MonoBehaviour
{
    #region VARIABLES
    private static EnemiesGenerator _instance;
    public static EnemiesGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemiesGenerator>();
            }
            return _instance;
        }
    }

    public LevelSettings levelSettings;
    public GameObject levelsPrefab;
    private bool victory;

    public bool isVictory = false;

    public List<Transform> enemiesOnLevel;
    [HideInInspector]
    public List<EnemyCharacter> enemiesOnLevelComponents;
    public List<EnemyCharacter> spawnedFriendlyCharacters;
    public List<GameObject> dropsOnLevel;
    public List<EnemyWave> enemyWaves;
    [HideInInspector]
    public int currentWave; // Текущая волна
    private bool delay;

    private Dictionary<EnemyType, GameObject> enemyPrefabs;
    private List<int> activeAuras = new List<int>();//Currently not implemented
    private float[] flDifference; // Разница по X между первым и последним персонажем
    private int total_drop_chance;
    [HideInInspector]
    public CasketDrop temp_drop;
    public UIMultiKill multyMessage;

    public MyGSFU gsfu;

    // private int amountOfAllZombies;
    private int amountOfWaveWithOutCaskets;

    private ObjectsPoolMono<AddCoin> coinsObjectPool;
    private float invulnerableDistance;
    private string levelId;

    #endregion

    public List<GameObject> listObjs = new List<GameObject>();

    int vawe = 0;
    private void Awake()
    {
        _instance = this;
        // Доступ к меню Victory
        enemiesOnLevelComponents = new List<EnemyCharacter>();
        spawnedFriendlyCharacters = new List<EnemyCharacter>();
        enemyPrefabs = new Dictionary<EnemyType, GameObject>();
        coinsObjectPool = new ObjectsPoolMono<AddCoin>(Resources.Load("Bonuses/Coin") as GameObject, null, 4);
        GemsDropOnLevelData.Initialize(mainscript.CurrentLvl);
    }

    IEnumerator Start()
    {
        if (mainscript.CurrentLvl < 0)
        {
            gameObject.AddComponent<EndlessMode.EndlessModeManager>();
        }
        else
        {
            LoadFromFile();
            flDifference = new float[enemyWaves.Count];
            SetupWavesForProgressBar();
            BarLoadWaves();
        }

        multyMessage = GameObject.FindObjectOfType<UIMultiKill>();
        Camera cam = Camera.main;
        float heightCamera = 2f * cam.orthographicSize;
        float widthCamera = heightCamera * cam.aspect;
        invulnerableDistance = cam.transform.position.x + widthCamera / 2;
        yield return new WaitForEndOfFrame();

        Casket.countCasketInScene = 0;
        AddCoin.countInScene = 0;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void LoadFromFile()
    {
        string loadLevelID = "1";

#if LEVEL_EDITOR
        if (UIEditorMenu.isEditorStart)
        {
            loadLevelID = UIEditorMenu.loadedFile;
            UIEditorMenu.isEditorStart = false;
        }
        else
            loadLevelID = mainscript.CurrentLvl.ToString();
#else
            loadLevelID = mainscript.CurrentLvl.ToString();
#endif

        List<EnemyWave> tempWaves = new List<EnemyWave>();
        List<LevelWaves> allLevels = levelsPrefab.GetComponent<LevelWavesPrefab>().waves;

        for (int i = 0; i < allLevels.Count; i++)
        {
            if (allLevels[i].fileName == loadLevelID)
            {
                enemyWaves = allLevels[i].waves;
                levelId = allLevels[i].fileName;
                break;
            }
        }
    }

    public static void SpawnCoin(Vector3 pos, Quaternion rotation, bool autoLoot = false)
    {
        if (Instance != null)
        {
            AddCoin coinObj = Instance.coinsObjectPool.GetObjectFromPool();
            if (pos.y < -1.5f)
            {
                pos+=new Vector3(0,0.4f,0);
            }
            coinObj.Spawn(pos, rotation, autoLoot);
            
            Instance.dropsOnLevel.Add(coinObj.gameObject);
        }
    }

    private void LateUpdate()
    {
        if (EndlessMode.EndlessModeManager.Current != null)
        {
            return;
        }
        else
        {
            CheckWave();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                StartCoroutine(LoadWave(enemyWaves.Count - 1));
            }
            else
            {
                OnWin();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerController.Instance.CurrentHealth = 0;
        }

        Input.GetKeyDown(KeyCode.Escape);
#endif
    }

    private void CheckWave()
    {
        if (!delay && currentWave < enemyWaves.Count &&
        enemiesOnLevel.Count == 0 && !ReplicaUI.IsAnyActive && CheckCoinAndCasket())
        {
            delay = true;
            this.CallActionAfterDelayWithCoroutine(enemyWaves[currentWave].delay, SpawnWave);
        }
        for (int i = 0; i < listObjs.Count; i++)
        {
            if (listObjs[i] == null)
                listObjs.RemoveAt(i);
        }
        if (!victory && listObjs.Count == 0 && currentWave == enemyWaves.Count && enemiesOnLevel.Count == 0 &&
                    GameObject.FindGameObjectWithTag("DeadEnemy") == null && 
                    GameObject.FindGameObjectWithTag(GameConstants.CASKET_TAG) == null &&
                    GameObject.FindGameObjectWithTag(GameConstants.COIN_TAG) == null)
        {
            OnWin();
        }
    }

    private bool CheckCoinAndCasket()
    {
        return (AddCoin.countInScene <= 0 && Casket.countCasketInScene <= 0 );
    }

    public void OnWin()
    {
        FinishMenu.instance.panelBlocker.SetActive(true);
        GemsDropOnLevelData.SendDataToAnalytics();
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);
        Time.timeScale = 0;
        if (mainscript.CurrentLvl == GameConstants.TotalLevels && PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0) == 0)
        {
            PlayerPrefs.SetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 1);
        }
        levelSettings.FinalScoreVictory();

        levelSettings.wonFlag = true;
        levelSettings.pauseObj.pauseCalled = true;
        levelSettings.pauseObj.currentState = UIPauseController.StateOfPause.VICTORY;
        if (PlayerPrefs.HasKey("LastHardLevel") && PlayerPrefs.GetInt("LastHardLevel") == levelSettings.currentLevel)
        {
            PlayerPrefs.SetInt("LastHardLevel", -1);
            PlayerPrefs.SetInt("LastLoses", 0);
        }

        ReturnOneLifeOnWin();
        levelSettings.wonFlag = true;
        victory = true;
        HideAllEffects();
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.LEVEL_COMPLETED, true);

        if (mainscript.CurrentLvl == 1)
            UI.ReplicaUI.ShowReplica(UI.EReplicaID.Level1_Completed_Enemy, UIControl.Current.transform);

        StartCoroutine(WaitForReplicaBeforeCompleteLevel());
    }

    private IEnumerator WaitForReplicaBeforeCompleteLevel()
    {
        yield return null;
        while (UI.ReplicaUI.IsAnyActive)
        {
            yield return null;
        }

        if (mainscript.CurrentLvl == 2)
            yield return new WaitForSecondsRealtime(1f);

        if (mainscript.CurrentLvl == 95)
            yield return new WaitForSecondsRealtime(1f);

        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);

        // WIN
        var boss = false;
        if (mainscript.CurrentLvl == 15 || mainscript.CurrentLvl == 30 || mainscript.CurrentLvl == 45 || mainscript.CurrentLvl == 70
            || mainscript.CurrentLvl == 95)
            boss = true;
        if (mainscript.CurrentLvl == 95)
        {
            yield return new WaitForSecondsRealtime(4f);

            while (UI.ReplicaUI.IsAnyActive)
            {
                yield return new WaitForSecondsRealtime(1f);
            }
        }

        FinishMenu.instance.Open(boss, mainscript.CurrentLvl);

        SoundController.Instanse.playWinLevelSFX();
        FireworksOnWinEffect.Play(0);
    }

    public void HideAllEffects()
    {
        var _infoAnim = GameObject.FindObjectOfType<UIInfoAnimation>();
        if (_infoAnim != null)
        {
            _infoAnim.gameObject.SetActive(false);
        }
    }

    private void ReturnOneLifeOnWin()
    {
        if (LivesManager.Instance.canRefillLives())
        {
            LivesManager.Instance.refillOneLife();
        }
    }

    private void SpawnWave()
    {
        StartCoroutine(LoadWave(currentWave));
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.ENEMY_WAVE_SPAWNED, currentWave);
        currentWave++;
        vawe = currentWave;
        UpdateWaveInfoHelper();
        delay = false;

        if (mainscript.CurrentLvl <= 4)
        {
            AnalyticsController.Instance.LogMyEvent("New Wave", new Dictionary<string, string>()
            {
                { "Current Level", mainscript.CurrentLvl.ToString() },
                { "Wave Number", currentWave.ToString() }
            });
        }
    }

    private IEnumerator LoadWave(int _waveNumber)
    {
        // Сортируем персонажей по координате X и вычисляем разницу между последним и первым персонажем
        if (enemyWaves[_waveNumber].bird_params != null && BonusBird.Instance != null)
        {
            if (enemyWaves[_waveNumber].bird_params.useRandomVariant)
            {
                BonusBird.Instance.currentParams = BonusBird.Instance.CreateParamsFrom(BonusBird.Instance.bonusBirdVariantsLoaderConfig.GetVariant(-1));
            }
            else
            {
                BonusBird.Instance.currentParams = BonusBird.Instance.CreateParamsFrom(enemyWaves[_waveNumber].bird_params);
            }
            BonusBird.Instance.Restart();
        }

        //if (enemyWaves[_waveNumber].levelPlayerHelpers != null)
        //{
        //    if (LevelSpawnPlayerHelpers.Current == null)
        //    {
        //        gameObject.AddComponent<LevelSpawnPlayerHelpers>();
        //    }

        //    LevelSpawnPlayerHelpers.Current.SpawnPlayerHelpers(enemyWaves[_waveNumber].levelPlayerHelpers);
        //}
        
        if (enemyWaves[_waveNumber].enemies.Count > 0)
        {
            enemyWaves[_waveNumber].enemies.Sort((x, y) => x.spawnPointX.CompareTo(y.spawnPointX));
            flDifference[_waveNumber] =
            enemyWaves[_waveNumber].enemies[enemyWaves[_waveNumber].enemies.Count - 1].spawnPointX -
            enemyWaves[_waveNumber].enemies[0].spawnPointX;

            for (int i = 0; i < enemyWaves[_waveNumber].enemies.Count; i++)
            {
                Enemy enemy = enemyWaves[_waveNumber].enemies[i];
                Vector3 spawnPosition = new Vector3(enemy.spawnPointX, enemy.spawnPointY, -1);
                temp_drop = CalculatedDrop(enemyWaves[_waveNumber].casket_drops);
                if (BuffsLoader.Instance != null)
                {
                    temp_drop.chance_id += (int)((float)temp_drop.chance_id * BuffsLoader.Instance.GetBuffValue(BuffType.chestDropChance));
                }
                CreateEnemy(enemy, spawnPosition, useSpawnEffect: false);
                yield return new WaitForSeconds(0.3f);
            }
        }

        UpdateWaveInfoHelper();
    }

    public UILevelProgressBar progressBar;
    private void BarLoadWaves()
    {
        float totalEnemiesHealth = 0f;
        int enemyWavesCount = enemyWaves.Count;
        for (int i = 0; i < enemyWavesCount; i++)
        {
            int enemiesInWaveCount = enemyWaves[i].enemies.Count;
            if (enemiesInWaveCount > 0)
            {
                enemyWaves[i].enemies.Sort((x, y) => x.spawnPointX.CompareTo(y.spawnPointX));
                flDifference[i] =
                enemyWaves[i].enemies[enemiesInWaveCount - 1].spawnPointX -
                enemyWaves[i].enemies[0].spawnPointX;

                for (int j = 0; j < enemiesInWaveCount; j++)
                {
                    Enemy enemy = enemyWaves[i].enemies[j];
                    string path = "Enemies/";
                    if (!enemyPrefabs.ContainsKey(enemy.enemyNumber) && enemy.enemyNumber != EnemyType.casket)
                    {
                        GameObject enemyPrefab = Resources.Load<GameObject>(path + Enum.GetName(typeof(EnemyType), enemy.enemyNumber));
                        MyGSFU.current.ApplyEnemyParameters(enemyPrefab);
                        enemyPrefabs.Add(enemy.enemyNumber, enemyPrefab);
                    }
                    if (enemy.enemyNumber != EnemyType.casket)
                    {
                        //Debug.Log($"ADD HEALTH: {mainscript.CurrentLvl}, enemy.enemyNumber: {enemy.enemyNumber}");
                        if(mainscript.CurrentLvl == 1)
                        {
                            if (enemy.enemyNumber != EnemyType.zombie_boss)
                                totalEnemiesHealth += enemyPrefabs[enemy.enemyNumber].GetComponent<EnemyCharacter>().health;
                        }
                        else
                            totalEnemiesHealth += enemyPrefabs[enemy.enemyNumber].GetComponent<EnemyCharacter>().health;
                    }
                }
            }
        }
        //Debug.Log($"HEALTH: {totalEnemiesHealth}");
        progressBar.SetTotalEnemiesHealth(totalEnemiesHealth);
    }

    internal GameObject CreateEnemy(EnemyType enemyType, Vector3 spawnPosition, bool isSpawnedByAnotherEnemy = true, bool useSpawnEffect = true, float endlessPowerModificator = 1f)
    {
        return CreateEnemy(new Enemy { enemyNumber = enemyType }, new Vector3(spawnPosition.x, spawnPosition.y, -1), isSpawnedByAnotherEnemy, useSpawnEffect, endlessPowerModificator);
    }

    public GameObject CreateEnemy(Enemy enemy, Vector3 spawnPosition, bool isSpawnedByAnotherEnemy = false, bool useSpawnEffect = true, float endlessPowerModificator = 1f)
    {
        if (enemy.enemyNumber == EnemyType.casket && GetWawes() > currentWave)
            return null;

        if (!enemyPrefabs.ContainsKey(enemy.enemyNumber))
        {
            string path = "Enemies/";
            if (enemy.enemyNumber == EnemyType.casket)
            {
                path = "Bonuses/";
                enemyPrefabs.Add(enemy.enemyNumber, Resources.Load<GameObject>(path + Enum.GetName(typeof(EnemyType), enemy.enemyNumber)));
            }
            else
            {
                GameObject enemyPrefab = Resources.Load<GameObject>(path + Enum.GetName(typeof(EnemyType), enemy.enemyNumber));
                MyGSFU.current.ApplyEnemyParameters(enemyPrefab);
                enemyPrefabs.Add(enemy.enemyNumber, enemyPrefab);
            }
        }

        var enemyPref = enemyPrefabs[enemy.enemyNumber];
        if (enemy.enemyNumber == EnemyType.casket)
            spawnPosition = new Vector3(0.89f, 0.18f, spawnPosition.z);

        if (spawnPosition.y >= 1f)
            spawnPosition = new Vector3(spawnPosition.x, Mathf.Clamp(spawnPosition.y, spawnPosition.y, 1.4f), spawnPosition.z);

        if (enemy.enemyNumber == EnemyType.zombie_fatty && spawnPosition.y >= 1f)
            spawnPosition = new Vector3(spawnPosition.x, Mathf.Clamp(spawnPosition.y, spawnPosition.y, 1f), spawnPosition.z);

        GameObject spawnedObject = Instantiate(enemyPref, spawnPosition, enemyPref.transform.rotation) as GameObject;
        var enemyCharacter = spawnedObject.GetComponent<EnemyCharacter>();


        var summonAnimProperty = spawnedObject.GetComponent<SummonAnimationWithMaterial>();
        if (summonAnimProperty != null)
        {
            summonAnimProperty.dontUse = !useSpawnEffect;
        }

        if (enemy.enemyNumber == EnemyType.casket)
        {
            TapController.Current.lastCantShoot = true;
            AddDropToList(spawnedObject);
        }
        else
        {
            MyGSFU.current.ApplyEnemyParameters(spawnedObject);
            enemiesOnLevel.Add(spawnedObject.transform);
            enemiesOnLevelComponents.Add(enemyCharacter);
            enemyCharacter.gives_aura_id = enemy.giveAuraId;
            if (enemy.giveAuraId > 0)
            {
                EnemyAurasCollector.Current.SpawnAura();
            }
        }

        if (spawnedObject == null)
        {
            return null;
        }

        if (enemyCharacter != null)
        {
            enemyCharacter.invunarableDistance = invulnerableDistance;
            enemyCharacter.casketChance = temp_drop.chance_id;
            enemyCharacter.casketContent = temp_drop.content_id;
            enemyCharacter.enemyCustomsDropsPack = enemy.enemyCustomsDropsPack;
        }

        var casketComp = spawnedObject.GetComponent<CasketWithNewItem>();
        if (casketComp != null)
        {
            casketComp.casketContent = enemy.casketContent;
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }

        var enemyMover = spawnedObject.GetComponent<EnemyMover>();
        if (enemyMover != null)
        {
            enemyMover.countInProgress = !isSpawnedByAnotherEnemy;
            StartCoroutine(SetupDataForEnemy(enemyCharacter, enemyMover, enemyPref.name + "_1"));
        }

        return spawnedObject;
    }

    public CasketDrop CalculatedDrop(List<CasketDrop> newDrop)
    {
        var to_return = new CasketDrop();
        var casket_drops = new List<CasketDrop>();
        total_drop_chance = 0;
        if (newDrop != null)
        {
            for (int i = 0; i < newDrop.Count; i++)
            {
                casket_drops.Add(newDrop[i]);
                total_drop_chance += newDrop[i].chance_id;
            }

            int current_chance = UnityEngine.Random.Range(0, total_drop_chance);
            for (int j = 0; j < casket_drops.Count; j++)
            {
                if (casket_drops[j].chance_id >= current_chance)
                {
                    to_return.content_id = casket_drops[j].content_id;
                    break;
                }
                else
                {
                    current_chance -= casket_drops[j].chance_id;
                }
            }
        }
        to_return.chance_id = total_drop_chance;
        return to_return;
    }

    private const int SummonedEnemiesOnLevelLimit = 10;
    public bool CanSummonEnemy
    {
        get
        {
            return SummonedEnemiesOnLevel() < SummonedEnemiesOnLevelLimit;
        }
    }

    public int SummonedEnemiesOnLevel()
    {
        int to_return = 0;
        for (int i = 0; i < enemiesOnLevelComponents.Count; i++)
        {
            if (enemiesOnLevelComponents[i].enemyType == EnemyType.skeleton_tom
                || enemiesOnLevelComponents[i].enemyType == EnemyType.zombie_brain
                || enemiesOnLevelComponents[i].enemyType == EnemyType.skeleton_swordsman)
            {
                to_return++;
            }
        }
        return to_return;
    }

    public void RemoveEnemy(int enemyInstanceID)
    {
        int count = enemiesOnLevelComponents.Count;
        for (int i = 0; i < count; i++)
        {
            if (enemiesOnLevelComponents[i].GetInstanceID() == enemyInstanceID)
            {
                enemiesOnLevelComponents.RemoveAt(i);
                enemiesOnLevel.RemoveAt(i);
                break;
            }
        }
        //// Отправляем событие о начале волны
        //if (waveStarted != null)
        //    waveStarted();
    }

    // Разница по X между последним и первым персонажем в текущей волне
    public float FLDifferenceCurrentWave()
    {
        return flDifference[currentWave - 1];
    }

    public int GetWawes()
    {
        return amountOfWaveWithOutCaskets;
    }

    public void PubSetupDataForEnemy(EnemyCharacter eChar, EnemyMover eMover, string eName)
    {
        StartCoroutine(SetupDataForEnemy(eChar, eMover, eName));
    }

    private IEnumerator SetupDataForEnemy(EnemyCharacter eChar, EnemyMover eMover, string eName)
    {
        //yield return new WaitForSecondsRealtime (0.005f);
        if (gsfu == null || eChar == null || eMover == null)
            yield break;

        EnemyParameters enemyParamsTemp = new EnemyParameters();

        //int index = -1;
        if (gsfu != null && gsfu.enemyParams != null)
        {
            for (int i = 0; i < gsfu.enemyParams.Length; i++)
            {
                if (eName.Equals(gsfu.enemyParams[i].Name))
                {
                    enemyParamsTemp = gsfu.enemyParams[i];
                    break;
                }
            }
        }

        eChar.isWallAttack = false;
        //eMover.speed = enemyParamsTemp.speed;
        //eMover.specSpeed = enemyParamsTemp.specialSpeed;
        if (eChar.enemyType == EnemyType.ghoul_scavenger || eChar.enemyType == EnemyType.zombie_murderer)
        {
            eChar.minActionX = -1.4f;
            eChar.maxActionX = -1.0f;
        }
        else if (eChar.enemyType == EnemyType.skeleton_archer || eChar.enemyType == EnemyType.skeleton_archer_big)
        {
            eChar.minActionX = -1.0f;
            eChar.maxActionX = 6.8f;
        }
        else if (eChar.enemyType == EnemyType.skeleton_mage || eChar.enemyType == EnemyType.skeleton_strong_mage ||
            eChar.enemyType == EnemyType.skeleton_mage2 || eChar.enemyType == EnemyType.skeleton_strong_mage2)
        {
            eChar.minActionX = -1.0f;
            eChar.maxActionX = 8.0f;
        }
        else
        {
            eChar.minActionX = -4.2f + enemyParamsTemp.rangeDistanceMin * 10 / 13;
            eChar.maxActionX = -4.2f + enemyParamsTemp.rangeDistanceMax * 10 / 13;
        }
        yield break;
    }

    private void SetupWavesForProgressBar()
    {
        amountOfWaveWithOutCaskets = enemyWaves.Count;
        foreach (EnemyWave v in enemyWaves)
        {
            if (v.enemies.Count == 1)
            {
                if (v.enemies[0].enemyNumber == EnemyType.casket)
                {
                    amountOfWaveWithOutCaskets--;
                }
            }
        }
    }

    public void AddDropToList(GameObject dropObject)
    {
        dropsOnLevel.Add(dropObject);
    }

    public void RemoveDropFromList(GameObject dropObject)
    {
        int index = dropsOnLevel.LastIndexOf(dropObject);
        if (index > 0 && index < dropsOnLevel.Count)
        {
            dropsOnLevel.RemoveAt(index);
        }
    }

    public bool CheckPointerOverDrop(Vector2 clickPoint)
    {
        bool to_return = false;
        for (int i = 0; i < dropsOnLevel.Count; i++)
        {
            if (dropsOnLevel[i] != null)
            {
                Vector2 leftTopCorner = new Vector2(0f, 0f);
                Vector2 rightBottomCorner = new Vector2(0f, 0f);
                Vector3 center = new Vector3(0f, 0f, 0f);
                Vector3 sizeSprite = new Vector3(0f, 0f, 0f);
                if (dropsOnLevel[i].tag == GameConstants.COIN_TAG)
                {
                    center = Helpers.getMainCamera.WorldToScreenPoint(dropsOnLevel[i].transform.GetChild(0).GetChild(0).position);
                    if (dropsOnLevel[i].transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>() != null)
                    {
                        sizeSprite = Helpers.getMainCamera.WorldToScreenPoint(dropsOnLevel[i].transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().bounds.size);
                    }
                }
                if (dropsOnLevel[i].tag == GameConstants.CASKET_TAG)
                {
                    var casketTransform = dropsOnLevel[i].transform;
                    var casketSpriteRenderer = casketTransform.GetComponent<SpriteRenderer>();
                    if (casketSpriteRenderer != null)
                    {
                        if (!casketSpriteRenderer.enabled)
                        {
                            try
                            {
                                casketTransform = dropsOnLevel[i].transform.GetChild(0);
                            }
                            catch (Exception e)
                            {
                                Debug.Log(e.Message);
                            }
                        }
                        center = Helpers.getMainCamera.WorldToScreenPoint(casketTransform.position);
                        sizeSprite = Helpers.getMainCamera.WorldToScreenPoint(casketSpriteRenderer.sprite.bounds.size);
                    }
                }
                leftTopCorner = new Vector2(center.x - sizeSprite.x / 2, center.y + sizeSprite.y / 2);
                rightBottomCorner = new Vector2(center.x + sizeSprite.x / 2, center.y - sizeSprite.y / 2);
                if (clickPoint.x >= leftTopCorner.x && clickPoint.y <= leftTopCorner.y && clickPoint.x <= rightBottomCorner.x && clickPoint.y >= rightBottomCorner.y)
                {
                    to_return = true;
                    break;
                }
            }
        }
        return to_return;
    }

    public void OnFriendlyCharacterSpawned(EnemyCharacter character)
    {
        spawnedFriendlyCharacters.Add(character);
    }

    public void OnFriendlyCharacterDestroyed(EnemyCharacter character)
    {
        var instanceID = character.GetInstanceID();
        var count = spawnedFriendlyCharacters.Count;
        for (int i = 0; i < count; i++)
        {
            if (spawnedFriendlyCharacters[i].GetInstanceID() == instanceID)
            {
                spawnedFriendlyCharacters.RemoveAt(i);
                break;
            }
        }
    }

    public void DisableAllEnemies()
    {
        int count = enemiesOnLevelComponents.Count;
        for (int i = 0; i < count; i++)
        {
            enemiesOnLevelComponents[i].DisableEnemy();
        }
    }

    public void OnContinueGameUsed()
    {
        float leftestX = 20f;
        int leftestId = 0;
        int enemiesCount = enemiesOnLevelComponents.Count;
        for (int i = 0; i < enemiesCount; i++)
        {
            if (enemiesOnLevelComponents[i] != null && enemiesOnLevelComponents[i].transform.position.x < leftestX)
            {
                leftestX = enemiesOnLevelComponents[i].transform.position.x;
                leftestId = i;
            }
        }
        try
        {
            float shiftX = enemiesOnLevelComponents[leftestId].invunarableDistance - leftestX;
            for (int i = 0; i < enemiesCount; i++)
            {
                var s = UnityEngine.Random.Range(shiftX - 1f, shiftX + 1f);
                enemiesOnLevelComponents[i].ShiftEnemyToScreenBorder(s);
            }
        }
        catch (Exception e) { Debug.LogError(e.Message); }
    }

    public void CheckAuras(Action<int> auraEffectReceiver)
    {
        int count = activeAuras.Count;
        for (int i = 0; i < count; i++)
        {
            auraEffectReceiver(activeAuras[i]);
        }
    }

    public void TrySpawnGem(Vector3 position, List<GemDrop> customDrop = null, bool isBoss = false)
    {
        var currentDrops = enemyWaves[currentWave - 1].gem_drops;
        if (!customDrop.IsNullOrEmpty())
        {
            currentDrops = customDrop;
        }
        if (currentDrops.IsNullOrEmpty())
        {
            return;
        }

        int totalChances = 0;
        for (int i = 0; i < currentDrops.Count; i++)
        {
            totalChances += currentDrops[i].chance;
        }
        if (totalChances < 100)
        {
            totalChances = 100;
        }

        if (BuffsLoader.Instance != null)
        {
            totalChances += (int)((float)totalChances * BuffsLoader.Instance.GetBuffValue(BuffType.gemDropChance) / 100f);
        }

        int chosenId = 0;
        var dropIt = false;

        while (totalChances > 0 && chosenId < currentDrops.Count)
        {
            var droppedChance = UnityEngine.Random.Range(0, totalChances);
            if (droppedChance <= currentDrops[chosenId].chance)
            {
                dropIt = true;
                break;
            }
            else
            {
                totalChances -= currentDrops[chosenId].chance;
                chosenId++;
            }
        }

        if (!dropIt)
        {
            return;
        }
        position.Set(position.x, position.y + -0.7f, position.z);
        GemCollectable.Spawn(currentDrops[chosenId].gem, position, isBoss);
    }

    public void UpdateWaveInfoHelper()
    {
        if (LevelWaveInfoText.Current != null)
        {
            LevelWaveInfoText.Current.UpdateWaveInfo(levelId, GetUsefulCurrentWaveNumber, GetUsefulTotalWavesNumber);
        }
    }

    public int GetUsefulCurrentWaveNumber
    {
        get
        {
            int to_return = 0;
            for (int i = 0; i < Mathf.Clamp(currentWave, 1, enemyWaves.Count); i++)
            {
                if (enemyWaves[i].enemies.Count > 1 || (enemyWaves[i].enemies.Count == 1 && enemyWaves[i].enemies[0].enemyNumber != EnemyType.casket))
                {
                    to_return++;
                }
            }
            to_return = Mathf.Clamp(to_return, 1, GetUsefulTotalWavesNumber);
            return to_return;
        }
    }

    public int GetUsefulTotalWavesNumber
    {
        get
        {
            int to_return = 0;
            for (int i = 0; i < enemyWaves.Count; i++)
            {
                if (enemyWaves[i].enemies.Count > 1 || (enemyWaves[i].enemies.Count == 1 && enemyWaves[i].enemies[0].enemyNumber != EnemyType.casket))
                {
                    to_return++;
                }
            }
            return to_return;
        }
    }

    public void SetEndlessValues(List<GemDrop> gemGrops, List<CasketDrop> casketDrops)
    {
        enemyWaves.Clear();
        if (gemGrops == null)
        {
            gemGrops = new List<GemDrop>();
        }
        if (casketDrops == null)
        {
            casketDrops = new List<CasketDrop>();
        }
        temp_drop = CalculatedDrop(casketDrops);
        if (BuffsLoader.Instance != null)
        {
            temp_drop.chance_id += (int)((float)temp_drop.chance_id * BuffsLoader.Instance.GetBuffValue(BuffType.chestDropChance));
        }
        enemyWaves.Add(new EnemyWave() { gem_drops = gemGrops, casket_drops = casketDrops });
        currentWave = 1;
    }

}