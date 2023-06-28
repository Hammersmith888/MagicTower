using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Enemy
{
#if UNITY_EDITOR
//	[SerializeField][PickStringValueFromOtherPropertyAttribute(propertyToGetValueName="enemyNumber")]
//	private string nameInEditor;
#endif
	public EnemyType enemyNumber; // Номер врага, соответствует номер врага в массиве
    public float spawnPointX, spawnPointY;
	public int giveAuraId;
    public int casketChance; // Шанс выпадения сундука
    public int casketContent; // Содержимое сундука, номера соответствуют порядку в выпадающем списке
	public EnemyCustomsDropsPack enemyCustomsDropsPack = new EnemyCustomsDropsPack();
}

[System.Serializable]
public class EnemyWave
{
    public float delay; // Задержка данной волны
    public List<Enemy> enemies = new List<Enemy>();
	public List<CasketDrop> casket_drops = new List<CasketDrop> ();
	public BirdLevelParams bird_params = new BirdLevelParams ();
	public List<GemDrop> gem_drops = new List<GemDrop> ();
    public LevelPlayerHelpers levelPlayerHelpers = new LevelPlayerHelpers();
}

[System.Serializable]
public class LevelPlayerHelpers
{
    public int minesNumber;
    public List<BarrierPosition> barriersPositions = new List<BarrierPosition>();
    [System.Serializable]
    public class BarrierPosition
    {
        public float spawnPointX, spawnPointY, spawnPointZ;
    }
}

public class LevelEditorController : MonoBehaviour {
    public GameObject CasketContentDevice, GemsContentDevice;
    [SerializeField]
    private EditorBirdParams BirdContentDevice;
    [SerializeField]
    private EditorPlayerHelpers editorPlayerHelpers;
    public GameObject[] enemyPrefabs; // Префабы врагов
    [SerializeField]
    private List<EnemyWave> enemyWaves;
    private int currentWave; // Текущая волна
    private int current; // Текущая волна при симуляции всех волн

    public GameObject[] uiPanels; // Панели UI-элементов которые появляются после создания или загрузки файла
    [Header("Wave elements")]
    public Text waveCount;
    public InputField waveDelayText;
    public GameObject ddCurrentWave; // Выпадающий список - волны
    public GameObject textWaveEmpty;

    // Файл меню
    [Header("File elements")]
    public Text currentFileText;
    private string currentFile;
    public Transform parentFileList;
    public GameObject filePrefab, saveError;
    public InputField saveAsFileText;
    public Button loadBtn;

    // Для проигрывания волн
    private bool delay, start;

    [SerializeField] private GameObject statsPanel;
    [SerializeField] private Text buttonStatsText;


    // Меню файл - Создать, Загрузить, Сохранить, Сохранить как, Выход
    public void CreateEnemyWavesFile()
    {
        enemyWaves = new List<EnemyWave>();
        ShowUIPanels(1, 4);
        AddNewWave();

        // Присваивание имени по умолчанию
        int fileIndex = 0;
        string fileName = "noname-";
        currentFile = fileName + fileIndex.ToString();

        while (FileSerialization.CheckFileExists(currentFile))
        {
            fileIndex++;
            currentFile = fileName + fileIndex.ToString();
        }

        currentFileText.text = currentFile;

        // Чистим значения задержек и выпадающий список
        Dropdown dd = ddCurrentWave.GetComponent<Dropdown>();
        dd.value = currentWave;
        dd.options.RemoveRange(1, dd.options.Count - 1); // Чистим выпадающий список, т.к. в загруженном файле может быть меньше волн чем в предыдущем
        List<string> lvls = new List<string>();
        for (int i = 1; i < enemyWaves.Count; i++)
        {
            lvls.Add(i.ToString());
        }
        var comparer = new StringNumberComparer();
        lvls.Sort(comparer);
        foreach (var o in lvls)
            dd.options.Add(new Dropdown.OptionData() { text = o });
        waveDelayText.text = "0";
    }

    public void OpenLoadMenu()
    {
        HideUIPanels(0, 5);
        ShowUIPanels(5, 1);

        int i = 0;
        List<string> lvls = new List<string>();

        // Смотрим список файлов
#if UNITY_ANDROID
        foreach (string file in Directory.GetFiles(FileSerialization.LevelsPath()))
        {
            string fileName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).LastIndexOf(".dat"));
            lvls.Add(fileName);
        }
#else
        foreach (string file in Directory.GetFiles("Levels/"))
        {
            string fileName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).LastIndexOf(".dat"));
            lvls.Add(fileName);
        }
#endif

        var comparer = new StringNumberComparer();
        lvls.Sort(comparer);
        foreach (var o in lvls)
        {
            GameObject fileItem = Instantiate(filePrefab);
            fileItem.transform.SetParent(parentFileList);
            fileItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -50 * i);
            fileItem.GetComponent<Text>().text = o;
            i++;
        }

        parentFileList.GetComponent<RectTransform>().sizeDelta = new Vector2(parentFileList.GetComponent<RectTransform>().sizeDelta.x, 50 * i);

        if (i == 0)
            loadBtn.interactable = false;
        else
            loadBtn.interactable = true;
    }
    public void CloseLoadMenu()
    {
        // Уничтожаем все файлы списка, чтобы каждый раз список обновлялся
        for (int i = 0; i < parentFileList.transform.childCount; i++)
            Destroy(parentFileList.transform.GetChild(i).gameObject);

        HideUIPanels(5, 1);
        if (currentFile != null)
            ShowUIPanels(0, 5);
        else
            ShowUIPanels(0, 1);
    }
    public void LoadEnemyWaves()
    {
        ClearWave();

        currentFile = FileItemPicker.currentFileItem.GetComponent<Text>().text;
        currentFileText.text = currentFile;
        CloseLoadMenu();

        enemyWaves = FileSerialization.Load(currentFile) as List<EnemyWave>;
        waveCount.text = enemyWaves.Count.ToString();

        currentWave = 0;
        LoadWave(0);

        Dropdown dd = ddCurrentWave.GetComponent<Dropdown>();
        dd.value = currentWave;
        dd.options.RemoveRange(1, dd.options.Count - 1); // Чистим выпадающий список, т.к. в загруженном файле может быть меньше волн чем в предыдущем
        for (int i = 1; i < enemyWaves.Count; i++)
        {
            dd.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }
    }
    private void LoadWave(int _waveNumber)
    {
        CasketContentDevice.GetComponent<CasketContentScript>().LoadWaveCasketContent(enemyWaves[_waveNumber]);
        if (GemsContentDevice != null) {
            GemsContentDevice.GetComponent<EditorGems>().LoadWaveCasketContent(enemyWaves[_waveNumber]);
        }
        if (enemyWaves[_waveNumber].bird_params != null && BirdContentDevice != null) {
            BirdContentDevice.LoadWaveBirdParams(enemyWaves[_waveNumber]);
        }
        if (enemyWaves[_waveNumber].levelPlayerHelpers != null && editorPlayerHelpers != null) {
            editorPlayerHelpers.SetHelpers(enemyWaves[_waveNumber].levelPlayerHelpers);
            editorPlayerHelpers.PlaceHelpers();
        }
        for (int i = 0; i < enemyWaves[_waveNumber].enemies.Count; i++)
        {
            // Создаем монстра
            Vector3 spawnPosition = new Vector3(enemyWaves[_waveNumber].enemies[i].spawnPointX, enemyWaves[_waveNumber].enemies[i].spawnPointY, -1);
            int prefabNumber = (int)enemyWaves[_waveNumber].enemies[i].enemyNumber;
            GameObject enemy = Instantiate(enemyPrefabs[prefabNumber], spawnPosition, enemyPrefabs[prefabNumber].transform.rotation) as GameObject;

            EditorEnemyMover enemyMover = enemy.GetComponent<EditorEnemyMover>();
            EnemyCharacter enemyChar = enemy.GetComponent<EnemyCharacter>();
            if (enemyMover != null) {
                enemyMover.casketChance = enemyWaves[_waveNumber].enemies[i].casketChance;
                enemyMover.casketContent = enemyWaves[_waveNumber].enemies[i].casketContent;
                if (enemyChar != null)
                {
                    enemyChar.enemyCustomsDropsPack = enemyWaves[_waveNumber].enemies[i].enemyCustomsDropsPack;
                    enemyChar.gives_aura_id = enemyWaves[_waveNumber].enemies[i].giveAuraId;
                }
            }
        }
        waveDelayText.text = enemyWaves[_waveNumber].delay.ToString();
    }

    public void SaveLevelAndShare()
    {
        FileSerialization.Save(enemyWaves, currentFile, true);
    }

    public void SaveEnemyWaves()
    {
        if (currentFile != null)
            FileSerialization.Save(enemyWaves, currentFile);
    }

    public void OpenSaveAsMenu()
    {
        if (currentFile != null)
        {
            HideUIPanels(0, 5);
            ShowUIPanels(6, 1);
            saveAsFileText.text = currentFile;
            saveError.SetActive(false);
        }
    }
    public void CloseSaveMenu()
    {
        HideUIPanels(6, 1);
        if (currentFile != null)
            ShowUIPanels(0, 5);
        else
            ShowUIPanels(0, 1);
    }
    public void SaveAsEnemyWaves()
    {
        string saveAsName = saveAsFileText.text; // имя которое пользователь задал для сохранения файла
        // Проверить заданное имя не равно "" и файл с таким именем не существует, иначе отображаем ошибку
        if (saveAsName == "")
        {
            saveError.SetActive(true);
            return;
        }
        foreach (string file in Directory.GetFiles("Levels"))
        {
            string fileName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).LastIndexOf(".dat"));
            if (fileName == saveAsName)
            {
                saveError.SetActive(true);
                return;
            }
        }

        // Если всё хорошо - то сохраняем и закрываем меню
        currentFile = saveAsName;
        currentFileText.text = currentFile;
        FileSerialization.Save(enemyWaves, currentFile);
        CloseSaveMenu();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuEditor");
    }

    // Меню работы с волнами
    public void DeleteAllWaves()
    {
        enemyWaves.Clear();

        waveDelayText.text = "0";
        ddCurrentWave.GetComponent<Dropdown>().options.RemoveRange(1, ddCurrentWave.GetComponent<Dropdown>().options.Count - 1);

        AddNewWave();
    }

    public void AddNewWave()
    {
        enemyWaves.Add(new EnemyWave());
        waveCount.text = enemyWaves.Count.ToString();
        currentWave = enemyWaves.Count - 1;
        enemyWaves[currentWave].bird_params = BirdContentDevice.CurrentBirdParams();
        if (enemyWaves.Count > 1)
            ddCurrentWave.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = currentWave.ToString() });
        ddCurrentWave.GetComponent<Dropdown>().value = currentWave;
    }

    public void ClearWave()
    {
        DeleteAllEnemyPrefabs();
    }

    public void RemoveWave()
    {
        if (enemyWaves.Count <= 1)
            return;

        ClearWave();
        enemyWaves.Remove(enemyWaves[currentWave]);

        SaveEnemyWaves();

        currentWave = 0;
        LoadWave(0);
        waveCount.text = enemyWaves.Count.ToString();

        Dropdown dd = ddCurrentWave.GetComponent<Dropdown>();
        dd.value = currentWave;
        dd.options.RemoveRange(1, dd.options.Count - 1); // Чистим выпадающий список, т.к. в загруженном файле может быть меньше волн чем в предыдущем
        for (int i = 1; i < enemyWaves.Count; i++)
        {
            dd.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }
    }

    public void PlayAllWaves()
    {
        delay = false;
        start = true;
        CancelInvoke();
        DeleteAllEnemyPrefabs();

        current = 0;
    }

    public void PlayCurrentWave()
    {
        delay = false;
        start = false;
        CancelInvoke();
        DeleteAllEnemyPrefabs();
        DeleteAllHelpers();

        LoadWave(currentWave);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
        for (int i = 0; i < enemies.Length; i++)
            enemies[i].GetComponent<EditorEnemyMover>().StartMove();
    }

    void Update()
    {
        if (start && !delay && current < enemyWaves.Count && GameObject.FindGameObjectWithTag(GameConstants.ENEMY_TAG) == null)
        {
            delay = true;
            LoadWave(current);
            Invoke("SpawnWave", enemyWaves[current].delay);
        }
    }

    private void SpawnWave()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
        for (int i = 0; i < enemies.Length; i++)
            enemies[i].GetComponent<EditorEnemyMover>().StartMove();

        current++;
        delay = false;
    }

    // Меню работы с волной
    public void ChangeCurrentWave()
    {
		StartCoroutine (TimedChangeCurrentWave ());
    }

	private IEnumerator TimedChangeCurrentWave()
	{
		DeleteAllEnemyPrefabs();
        DeleteAllHelpers();
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
		while (enemies.Length > 0) 
		{
			yield return new WaitForSeconds (0.2f);
			enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
		}
		yield return new WaitForSeconds (0.2f);
		currentWave = ddCurrentWave.GetComponent<Dropdown>().value;
		LoadWave(currentWave);
		yield break;
	}

	public void SaveCurrentWave(string justFragment = "all")
    {

		if (enemyWaves == null || enemyWaves.Count == 0)
			return;
		switch (justFragment) {
		case "enemies":
			SaveEnemiesOnWave ();
			break;
		case "gems":
			SaveGemsOnWave ();
			break;
		case "drops":
			SaveDropsOnWave ();
			break;
		case "bird":
			SaveBirdOnWave ();
			break;
		case "playerHelpers":
			SavePlayerHelpersOnWave ();
			break;
		case "all":
			SaveEnemiesOnWave ();
			SaveGemsOnWave ();
			SaveDropsOnWave ();
			SaveBirdOnWave ();
			break;
		default:
			SaveEnemiesOnWave ();
			SaveGemsOnWave ();
			SaveDropsOnWave ();
			SaveBirdOnWave ();
			break;
		}
    }

	private void SaveEnemiesOnWave()
	{
		enemyWaves[currentWave].enemies.Clear();
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
		for (int i = 0; i < enemies.Length; i++)
		{
			// сохраняем в текущую волну
			Enemy enemy = new Enemy();

			EditorEnemyMover enemyMover = enemies[i].GetComponent<EditorEnemyMover>();
			EnemyCharacter enemyChar = enemies[i].GetComponent<EnemyCharacter>();
			enemy.enemyNumber = enemyMover.enemyType;
			enemy.casketChance = enemyMover.casketChance;
			enemy.casketContent = enemyMover.casketContent;
			enemy.spawnPointX = enemies[i].transform.position.x;
			enemy.spawnPointY = enemies[i].transform.position.y;
			if (enemyChar != null) 
			{
				enemy.enemyCustomsDropsPack = enemyChar.enemyCustomsDropsPack;
				enemy.giveAuraId = enemyChar.gives_aura_id;
			}
			enemyWaves[currentWave].enemies.Add(enemy);
			enemyWaves[currentWave].delay = float.Parse(waveDelayText.text);
		}
	}

	private void SaveDropsOnWave()
	{
		if (enemyWaves [currentWave].casket_drops != null) {
			enemyWaves [currentWave].casket_drops.Clear ();
		} else {
			enemyWaves [currentWave].casket_drops = new List<CasketDrop> ();
		}
		for (int i = 0; i < CasketContentDevice.GetComponent<CasketContentScript> ().casket_drops.Count; i++) {
			enemyWaves [currentWave].casket_drops.Add(CasketContentDevice.GetComponent<CasketContentScript> ().casket_drops[i]);
		}
	}

	private void SaveGemsOnWave()
	{
		if (enemyWaves [currentWave].gem_drops != null) {
			enemyWaves [currentWave].gem_drops.Clear ();
		} else {
			enemyWaves [currentWave].gem_drops = new List<GemDrop> ();
		}
		if (GemsContentDevice != null) {
			for (int i = 0; i < GemsContentDevice.GetComponent<EditorGems> ().gem_drops.Count; i++) {
				enemyWaves [currentWave].gem_drops.Add (GemsContentDevice.GetComponent<EditorGems> ().gem_drops [i]);
			}
		}
	}

	private void SaveBirdOnWave()
	{
		if (BirdContentDevice != null) {
			enemyWaves [currentWave].bird_params = new BirdLevelParams ();
			enemyWaves [currentWave].bird_params.chanceSpawn = BirdContentDevice.chance;
			enemyWaves [currentWave].bird_params.soarTime = BirdContentDevice.soarTime;
			enemyWaves [currentWave].bird_params.soarEveryPoint = BirdContentDevice.soarPoint;
			enemyWaves [currentWave].bird_params.spawnEachSeconds = BirdContentDevice.timer;
			enemyWaves [currentWave].bird_params.maxFreeTime = BirdContentDevice.maxFreeTime;
			enemyWaves [currentWave].bird_params.flySpeed = BirdContentDevice.flySpeed;
			enemyWaves [currentWave].bird_params.hitsNeed = BirdContentDevice.hits;
			enemyWaves [currentWave].bird_params.birdsLimit = BirdContentDevice.maxBirds;
			enemyWaves [currentWave].bird_params.numberOfPoints = BirdContentDevice.points;
			enemyWaves [currentWave].bird_params.flyOnTop = BirdContentDevice.flyOnTop;
			enemyWaves [currentWave].bird_params.useRandomVariant = BirdContentDevice.useRandomVariant;
			for (int i = 0; i < BirdContentDevice.spawnPoints.Count; i++) {
				enemyWaves [currentWave].bird_params.useSpawnPoint [i] = BirdContentDevice.spawnPoints [i].activeSelf;
			}
		}
	}

	private void SavePlayerHelpersOnWave()
	{
		if (editorPlayerHelpers != null) {
			enemyWaves [currentWave].levelPlayerHelpers = new LevelPlayerHelpers ();
            enemyWaves[currentWave].levelPlayerHelpers.barriersPositions = editorPlayerHelpers.levelPlayerHelpers.barriersPositions;
            enemyWaves[currentWave].levelPlayerHelpers.minesNumber = editorPlayerHelpers.levelPlayerHelpers.minesNumber;
        }
	}


    private void DeleteAllEnemyPrefabs()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
        for (int i = 0; i < enemies.Length; i++)
            Destroy(enemies[i]);
		enemies = GameObject.FindGameObjectsWithTag(GameConstants.ENEMY_TAG);
    }

    private void ShowUIPanels(int _startIndex, int _count)
    {
        for (int i=_startIndex; i<_startIndex+_count; i++)
        {
            uiPanels[i].SetActive(true);
        }
    }
    private void HideUIPanels(int _startIndex, int _count)
    {
        for (int i = _startIndex; i < _startIndex + _count; i++)
        {
            uiPanels[i].SetActive(false);
        }
    }

    // Для тестов
    public void ShowAllCollection()
    {
        print("Count of waves="+enemyWaves.Count+" Current wave="+currentWave);
        for (int i=0; i<enemyWaves.Count; i++)
        {
            print("Wave=" + i + " Count of enemies="+ enemyWaves[i].enemies.Count);
            for (int j=0; j<enemyWaves[i].enemies.Count; j++)
            {
                print("-----Enemy="+j+" Type=" + enemyWaves[i].enemies[j].enemyNumber + " Point=(" + enemyWaves[i].enemies[j].spawnPointX + "; " + enemyWaves[i].enemies[j].spawnPointY+")"+" Casket= "+ enemyWaves[i].enemies[j].casketChance+ "-"+ enemyWaves[i].enemies[j].casketContent);
            }
        }
    }

    private void DeleteAllHelpers()
    {
        for (int i = 0; i < editorPlayerHelpers.barriers.Count; i++)
        {
            try
            {
                Destroy(editorPlayerHelpers.barriers[i].gameObject);
            }
            catch (System.Exception)
            {

            }
        }
        editorPlayerHelpers.barriers.Clear();
    }

    private class StatsEnemy
    {
        public EnemyType typeEnemy;
        public int coutEnemy = 1;

        public StatsEnemy(EnemyType type)
        {
            typeEnemy = type;
        }

        public void AddCount()
        {
            coutEnemy++;
        }
    }

    public void GetStats()
    {
        var statsText = statsPanel.GetComponentInChildren<Text>();
        if (statsText.text != "")
        {
            statsText.text = "";
        }

        List<StatsEnemy> statsEnemy = new List<StatsEnemy>();
        List<EnemyType> types = new List<EnemyType>();

        foreach (var wave in enemyWaves)
        {
            foreach (var enemy in wave.enemies)
            {
                var type = enemy.enemyNumber;
                if (!types.Contains(type))
                {
                    types.Add(type);
                    statsEnemy.Add(new StatsEnemy(type));
                }
                else
                {
                    foreach (var enemies in statsEnemy)
                    {
                        if (enemies.typeEnemy == type)
                        {
                            enemies.AddCount();
                        }
                    }
                }
            }
        }
        PrintStats(statsEnemy);
    }

    private void PrintStats(List<StatsEnemy> stats)
    {
        buttonStatsText.text = "UpdateStats";
        statsPanel.SetActive(true);
        var statsText = statsPanel.GetComponentInChildren<Text>();
        foreach (var stat in stats)
        {
            statsText.text += "Type: " + stat.typeEnemy.ToString() + ", Count: " + stat.coutEnemy.ToString() + "\n";
        }
    }

    public void ClosePanelStats()
    {
        statsPanel.SetActive(false);
        buttonStatsText.text = "Stats";
    }
}