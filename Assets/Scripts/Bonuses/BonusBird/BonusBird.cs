using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BirdLevelParams
{
    public float spawnEachSeconds;
    public float chanceSpawn;
    public float flySpeed;
    public float soarTime;
    public float maxFreeTime;
    public int soarEveryPoint;
    public int hitsNeed;
    public int birdsLimit;
    public bool flyOnTop = false;
    public bool respawnOnReplay = true;
    public int numberOfPoints;
    public bool[] useSpawnPoint = new bool[20];
    public bool useRandomVariant;
}

public class BonusBird : MonoBehaviour
{
    public static BonusBird Instance;
    public BirdLevelParams currentParams = new BirdLevelParams();
    private int BirdsSpawned;
    [SerializeField]
    private Transform transf, startPosTransform, maxCoordsTransform;
    [SerializeField]
    private List<Transform> wayPoints = new List<Transform> (), spawnPoints = new List<Transform> ();
    [SerializeField]
    private Tutorials.TutorialBird tutorialBird;
    public BonusBirdVariantsLoaderConfig bonusBirdVariantsLoaderConfig;
    private bool isLevelEditorTesting;

    private void Awake()
    {
        Instance = this;
        isLevelEditorTesting = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level";
    }

    public void Restart()
    {
        StopCoroutine("StartTimer");
        maxCoordsTransform.position = new Vector3(maxCoordsTransform.position.x, maxCoordsTransform.position.y, transf.position.z);
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        float _timer = currentParams.spawnEachSeconds;
        if (_timer == 0)
        {
            yield break;
        }
        while (_timer > 0)
        {
            _timer -= currentParams.spawnEachSeconds / 30f;
            yield return new WaitForSeconds(currentParams.spawnEachSeconds / 30f);
        }

        if (currentParams.chanceSpawn >= UnityEngine.Random.Range(1, 100f) &&
            BirdsSpawned < currentParams.birdsLimit &&
            (mainscript.CurrentLvl > 1 || isLevelEditorTesting))
        {
            BirdsSpawned++;
            Vector3 spawnPoint = RandomSpawnPoint();
            GameObject newBird = Instantiate(transf.gameObject, spawnPoint, transf.rotation);
            //newBird.transform.position = RandomSpawnPoint ();
            BonusBirdCollider birdCollScript = newBird.GetComponent<BonusBirdCollider>();
            if (currentParams.flyOnTop)
            {
                birdCollScript.wayPositions = SetStablePoints();
            }
            else
            {
                birdCollScript.wayPositions = RandomizePoints(newBird.transform.position.y);
            }
            birdCollScript.wayPositions[1] = new Vector3(spawnPoint.x, birdCollScript.wayPositions[1].y, birdCollScript.wayPositions[1].z);
            birdCollScript.currentParams = currentParams;
            newBird.SetActive(true);
            if (!SaveManager.GameProgress.Current.tutorial[(int)Tutorials.ETutorialType.BIRD])
            {
                SaveManager.GameProgress.Current.tutorial[(int)Tutorials.ETutorialType.BIRD] = true;
                SaveManager.GameProgress.Current.Save();
                StartCoroutine(CheckForShowTutorial(newBird));
            }
        }
        Restart();
        yield break;
    }

    private IEnumerator CheckForShowTutorial(GameObject tutorialBirdObject)
    {
        BonusBirdCollider tutorialBirdCollider = tutorialBirdObject.GetComponent<BonusBirdCollider>();

        while (true)
        {
            if (tutorialBird == null)
                yield break;
            if (tutorialBirdObject == null)
                yield break;
            if (tutorialBirdCollider == null)
                yield break;

            bool shouldShow = true;
            Vector3 colliderPosition = tutorialBirdCollider.transform.position;

            if (!tutorialBirdCollider.IsCollididerEnabled())
                shouldShow = false;
            if (tutorialBirdCollider.GetPassedPoints() < 1)
                shouldShow = false;
            if (Tutorials.TutorialsManager.IsAnyTutorialActive)
                shouldShow = false;
            if (colliderPosition.y > 2.2f || colliderPosition.y < -2f)
                shouldShow = false;

            if (shouldShow)
            {
                yield return new WaitForSecondsRealtime(1f);
                if (tutorialBirdCollider != null)
                {
                    if (Tutorials.TutorialsManager.IsAnyTutorialActive)
                    {
                        shouldShow = false;
                        yield break;
                    }

                    colliderPosition = tutorialBirdCollider.transform.position;
                    // tutorialBird.ShowMessage(colliderPosition);
                    // StartCoroutine(CheckForHideTutorial(tutorialBirdObject));
                    if (tutorialBird != null)
                        tutorialBird.ContinueGame();
                }
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    // private IEnumerator CheckForHideTutorial(GameObject tutorialBirdObject)
    // {
    //     BonusBirdCollider tutorialBirdCollider = tutorialBirdObject.GetComponent<BonusBirdCollider>();
    //
    //     while (true)
    //     {
    //         bool shouldHide = false;
    //
    //         if (tutorialBirdCollider == null)
    //             shouldHide = true;
    //         if (tutorialBirdCollider.WasClicked())
    //             shouldHide = true;
    //
    //         if (shouldHide)
    //         {
    //             if (tutorialBird != null)
    //                 tutorialBird.ContinueGame();
    //
    //             yield break;
    //         }
    //         else
    //         {
    //             yield return null;
    //         }
    //     }
    // }

    private Vector3 lastUsedSpawnPoint = Vector3.zero;
    private Vector3 RandomSpawnPoint()
    {
        List<Transform> assembledPoints = new List<Transform>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (currentParams != null && currentParams.useSpawnPoint.Length > i && currentParams.useSpawnPoint[i] == true)
            {
                assembledPoints.Add(spawnPoints[i]);
            }
        }
        int returnId = UnityEngine.Random.Range(0, assembledPoints.Count);
        if (assembledPoints.Count > 1)
        {
            while (assembledPoints[returnId].position == lastUsedSpawnPoint)
            {
                returnId = UnityEngine.Random.Range(0, assembledPoints.Count);
            }
        }
        lastUsedSpawnPoint = assembledPoints[returnId].position;
        lastUsedSpawnPoint.z = transf.position.z;
        return lastUsedSpawnPoint;
    }

    private List<Vector3> RandomizePoints(float wayRewerter = 1f)
    {
        float reverter = 1f;
        if (wayRewerter < 0)
        {
            reverter = -1f;
        }
        List<Vector3> wayPositions = new List<Vector3>();
        float zPos = transf.position.z;
        Vector3 firstPoint = Vector3.zero;
        if (reverter > 0f)
        {
            firstPoint = new Vector3(transf.position.x, GameConstants.MaxTopBorder * 0.85f, transf.position.z);
        }
        else
        {
            firstPoint = new Vector3(transf.position.x, GameConstants.MaxBottomBorder * 0.85f, transf.position.z);
        }
        wayPositions.Add(transf.position);
        wayPositions.Add(firstPoint);

        int middlePoints = currentParams.numberOfPoints;
        float maxTop = GameConstants.MaxTopBorder * 0.9f;
        float maxBottom = GameConstants.MaxBottomBorder * 0.9f;
        float maxXpoint = 9f;

        float maxYpoint;
        float minYpoint;
        Vector3 nextPoint;

        for (int i = 1; i < middlePoints + 1; i++)
        {
            maxYpoint = Mathf.Min(wayPositions[i].y + 0.8f, maxTop);
            minYpoint = Mathf.Max(wayPositions[i].y - 0.8f, maxBottom);

            nextPoint = new Vector3(Random.Range(startPosTransform.position.x - 1f, maxXpoint),
                Random.Range(minYpoint, maxYpoint),
                zPos);

            wayPositions.Add(nextPoint);
        }
        wayPositions.Add(maxCoordsTransform.position);
        wayPositions.Add((new Vector3(transf.position.x, reverter * maxCoordsTransform.position.y, zPos)));
        return wayPositions;
    }

    private List<Vector3> SetStablePoints()
    {
        List<Vector3> wayPositions = new List<Vector3>();
        float zPos = transf.position.z;
        //wayPositions.Add (new Vector3( startPosTransform.position.x, mainscript.maxTopBorder*0.8f, transf.position.z));
        for (int i = 0; i < wayPoints.Count; i++)
        {
            Vector3 nextPoint = new Vector3(wayPoints[i].position.x, wayPoints[i].position.y, zPos);
            wayPositions.Add(nextPoint);
        }
        return wayPositions;
    }

    public BirdLevelParams CreateParamsFrom(BirdLevelParams primeParams)
    {
        bool[] _useSpawnPoint = new bool[20];
        if (primeParams.useSpawnPoint != null && primeParams.useSpawnPoint.Length > 0)
        {
            _useSpawnPoint = primeParams.useSpawnPoint;
        }
        bool allEmpty = true;
        for (int i = 0; i < _useSpawnPoint.Length; i++)
        {
            if (_useSpawnPoint[i])
            {
                allEmpty = false;
                break;
            }
        }
        if (allEmpty)
        {
            for (int i = 0; i < 5; i++)
            {
                _useSpawnPoint[i] = true;
            }
        }
        float preSetMaxFreeTime = primeParams.maxFreeTime;
        if (preSetMaxFreeTime < 3f)
        {
            preSetMaxFreeTime = primeParams.spawnEachSeconds - 3;
        }
        return new BirdLevelParams()
        {
            chanceSpawn = primeParams.chanceSpawn,
            spawnEachSeconds = primeParams.spawnEachSeconds,
            hitsNeed = primeParams.hitsNeed,
            birdsLimit = primeParams.birdsLimit,
            soarTime = primeParams.soarTime,
            soarEveryPoint = primeParams.soarEveryPoint,
            numberOfPoints = primeParams.numberOfPoints,
            flySpeed = primeParams.flySpeed,
            useRandomVariant = primeParams.useRandomVariant,
            maxFreeTime = preSetMaxFreeTime,
            useSpawnPoint = _useSpawnPoint
        };
    }

    public void HideTutorial()
    {
        if (tutorialBird)
        {
            tutorialBird.ContinueGame();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (!wayPoints.IsNullOrEmpty())
        {
            Gizmos.color = Color.blue;
            for (int i = 1; i < wayPoints.Count; i++)
            {
                if (wayPoints[i] == null || wayPoints[i - 1] == null)
                {
                    continue;
                }
                Gizmos.DrawLine(wayPoints[i].position, wayPoints[i - 1].position);
                Gizmos.DrawSphere(wayPoints[i].position, 0.2f);
                Gizmos.DrawSphere(wayPoints[i - 1].position, 0.2f);
            }
        }
    }
#endif
}
