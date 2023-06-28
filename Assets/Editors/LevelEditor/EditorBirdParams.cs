using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorBirdParams : MonoBehaviour
{
    public LevelEditorController levelEditorScript;
    [SerializeField]
    private Text chanceText, timerText, hitsText, maxBirdsText, flySpeedText, pointsText, soarTimeText, soarPointText, maxFreeTimeText;
    [SerializeField]
    private Toggle flyOnTopCheckbox;
    //[HideInInspector]
    public float chance, timer, flySpeed, soarTime, maxFreeTime;
    //[HideInInspector]
    public int hits, maxBirds, points, soarPoint;
    //[HideInInspector]
    public bool flyOnTop, useRandomVariant = true;

    public BonusBirdVariantsLoaderConfig bonusBirdVariantsLoaderConfig;
    [SerializeField]
    private Dropdown variantsDD;

    //[SerializeField]
    public List<GameObject> spawnPoints = new List<GameObject> ();
	[SerializeField]
	private EditorPopupCustomDrop customDrop;

    void Start()
    {
        List<string> tempVariantsOptions = new List<string>();
        for (int i = 0; i < bonusBirdVariantsLoaderConfig.totalVariants; i++)
        {
            tempVariantsOptions.Add((i + 1).ToString());
        }
        useRandomVariant = true;
        tempVariantsOptions.Add("Random");
        tempVariantsOptions.Add("Custom");
        tempVariantsOptions.Add("None");
        variantsDD.ClearOptions();
        variantsDD.AddOptions(tempVariantsOptions);
        variantsDD.value = variantsDD.options.Count - 3;
    }

    public void SaveBirdWaveParams()
    {
        chance = float.Parse(chanceText.text);
        timer = float.Parse(timerText.text);
        flySpeed = float.Parse(flySpeedText.text);
        maxFreeTime = float.Parse(maxFreeTimeText.text);
        hits = int.Parse(hitsText.text);
        soarTime = float.Parse(soarTimeText.text);
        soarPoint = int.Parse(soarPointText.text);
        maxBirds = int.Parse(maxBirdsText.text);
        points = int.Parse(pointsText.text);
        flyOnTop = flyOnTopCheckbox.isOn;
        variantsDD.value = variantsDD.options.Count - 2;
        useRandomVariant = false;
		if (!customDrop) 
		{
			levelEditorScript.SaveCurrentWave ("bird");
		} 
		else 
		{
			customDrop.SaveBird ();
		}
    }

	public void SetParams(BirdLevelParams birdLevelParams)
	{
//		chance = birdLevelParams.chanceSpawn;
		chance = birdLevelParams.chanceSpawn;
		timer = birdLevelParams.spawnEachSeconds;
        maxFreeTime = birdLevelParams.maxFreeTime;
		hits = birdLevelParams.hitsNeed;
		maxBirds = birdLevelParams.birdsLimit;
		soarTime = birdLevelParams.soarTime;
		soarPoint = birdLevelParams.soarEveryPoint;
		points = birdLevelParams.numberOfPoints;
		useRandomVariant = birdLevelParams.useRandomVariant;

		for (int i = 0; i < spawnPoints.Count; i++)
		{
			spawnPoints[i].SetActive(birdLevelParams.useSpawnPoint [i]);
		}
		ResetViewParams ();
	}

    public void LoadWaveBirdParams(EnemyWave wave)
    {
        chance = wave.bird_params.chanceSpawn;
        timer = wave.bird_params.spawnEachSeconds;
        flySpeed = wave.bird_params.flySpeed;
        hits = wave.bird_params.hitsNeed;
        soarTime = wave.bird_params.soarTime;
        soarPoint = wave.bird_params.soarEveryPoint;
        maxBirds = wave.bird_params.birdsLimit;
        points = wave.bird_params.numberOfPoints;
        maxFreeTime = wave.bird_params.maxFreeTime;
        useRandomVariant = wave.bird_params.useRandomVariant;
        if (!useRandomVariant)
        {
            if (chance == 0)
                variantsDD.value = variantsDD.options.Count - 1;
            else
            {
                int readyVariant = bonusBirdVariantsLoaderConfig.compareVariant(wave.bird_params);
                if (readyVariant != -1)
                {
                    variantsDD.value = readyVariant;
                }
                else
                {
                    variantsDD.value = variantsDD.options.Count - 2;
                }
            }
        }
        else
        {
            variantsDD.value = variantsDD.options.Count - 3;
        }
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (wave.bird_params.useSpawnPoint != null)
            {
                spawnPoints[i].SetActive(wave.bird_params.useSpawnPoint[i]);
            }
        }
		ResetViewParams ();
		flyOnTopCheckbox.isOn = wave.bird_params.flyOnTop;
    }

	private void ResetViewParams()
	{
		chanceText.transform.parent.GetComponent<InputField>().text = "" + chance.ToString();
		timerText.transform.parent.GetComponent<InputField>().text = "" + timer.ToString();
		flySpeedText.transform.parent.GetComponent<InputField>().text = "" + flySpeed.ToString();
		hitsText.transform.parent.GetComponent<InputField>().text = "" + hits.ToString();
		soarTimeText.transform.parent.GetComponent<InputField>().text = "" + soarTime.ToString();
		soarPointText.transform.parent.GetComponent<InputField>().text = "" + soarPoint.ToString();
		maxBirdsText.transform.parent.GetComponent<InputField>().text = "" + maxBirds.ToString();
		pointsText.transform.parent.GetComponent<InputField>().text = "" + points.ToString();
        maxFreeTimeText.transform.parent.GetComponent<InputField>().text = "" + maxFreeTime.ToString();
	}

    public BirdLevelParams CurrentBirdParams()
    {
        BirdLevelParams to_return = new BirdLevelParams();
        to_return.chanceSpawn = chance;
        to_return.spawnEachSeconds = timer;
        to_return.hitsNeed = hits;
        to_return.maxFreeTime = maxFreeTime;
        to_return.birdsLimit = maxBirds;
        to_return.soarTime = soarTime;
        to_return.soarEveryPoint = soarPoint;
        to_return.numberOfPoints = points;
		to_return.flySpeed = flySpeed;
		to_return.useRandomVariant = useRandomVariant;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
			to_return.useSpawnPoint[i] = spawnPoints[i].activeSelf;
        }

        return to_return;
    }

    public void PickSpawnPoint(int id)
    {
        bool isOn = !spawnPoints[id].activeSelf;
        spawnPoints[id].SetActive(isOn);
        clearSave();
    }

    public void ClearSave()
    {
        Invoke("clearSave", 0.02f);
    }
    private void clearSave()
    {
		if (!customDrop) 
		{
			levelEditorScript.SaveCurrentWave ("bird");
		} 
		else 
		{
			customDrop.SaveBird ();
		}

    }
    public void OnVariantChosen()
    {
        int id = variantsDD.value;
        if (id >= variantsDD.options.Count - 3 && id < variantsDD.options.Count - 1)
        {
            if (id == variantsDD.options.Count - 3)
            {
                useRandomVariant = true;
            }
            return;
        }
        useRandomVariant = false;

        BirdLevelParams birdParams = bonusBirdVariantsLoaderConfig.GetVariant(id);

        chance = birdParams.chanceSpawn;
        timer = birdParams.spawnEachSeconds;
        maxFreeTime = birdParams.maxFreeTime;
        flySpeed = birdParams.flySpeed;
        hits = birdParams.hitsNeed;
        soarTime = birdParams.soarTime;
        soarPoint = birdParams.soarEveryPoint;
        maxBirds = birdParams.birdsLimit;
        points = birdParams.numberOfPoints;
        chanceText.transform.parent.GetComponent<InputField>().text = "" + chance.ToString();
        timerText.transform.parent.GetComponent<InputField>().text = "" + timer.ToString();
        flySpeedText.transform.parent.GetComponent<InputField>().text = "" + flySpeed.ToString();
        hitsText.transform.parent.GetComponent<InputField>().text = "" + hits.ToString();
        soarTimeText.transform.parent.GetComponent<InputField>().text = "" + soarTime.ToString();
        soarPointText.transform.parent.GetComponent<InputField>().text = "" + soarPoint.ToString();
        maxBirdsText.transform.parent.GetComponent<InputField>().text = "" + maxBirds.ToString();
        pointsText.transform.parent.GetComponent<InputField>().text = "" + points.ToString();
        maxFreeTimeText.transform.parent.GetComponent<InputField>().text = "" + maxFreeTime.ToString();
		clearSave ();
    }
    [SerializeField]
    private GameObject WorkGroup;
    public void EnableDisableIt()
    {
        WorkGroup.SetActive(!WorkGroup.activeSelf);
    }


}
