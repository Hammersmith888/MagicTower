using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject onDeathExplosion, explosionPos;
    [SerializeField]
    private Transform spawnPos, handsPlace;
    private EnemyCharacter character;
    [SerializeField]
    private float minSpawnZone = -1f, spawnerDelay = 6f, attackDelay = 3.5f;
    [SerializeField]
    private GameObject spawnEnemy;
    [SerializeField]
    private AudioClip throwSFX;

    [HideInInspector]
    public bool shooting;

    private float shootingTimer = 0.0f;

    private GameObject SpawnedEnemy;
    private List<GameObject> spawnedEnemies;
    private int spawnedEnemiesCountBeforeReset = 0;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        spawnedEnemies = new List<GameObject>();
    }

    private void Update()
    {
        int spawnedEnemiesCount = spawnedEnemies.Count;
        for (int i = spawnedEnemiesCount - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i] == null)
                spawnedEnemies.RemoveAt(i);
        }

        if (spawnedEnemiesCountBeforeReset == 5 && spawnedEnemies.Count == 0)
            spawnedEnemiesCountBeforeReset = 0;

        if (transform.position.x < character.invunarableDistance - 1.5f && transform.position.x > 1.0f)
            shootingTimer += Time.deltaTime;

        if (spawnedEnemiesCountBeforeReset < 5 && shootingTimer > spawnerDelay)
        {
            shootingTimer = 0.0f;
            spawnedEnemiesCountBeforeReset++;
            character.Shoot();
        }
    }

    public void SpawnEnemy()
    {
        SpawnedEnemy = EnemiesGenerator.Instance.CreateEnemy(new Enemy { enemyNumber = EnemyType.ghoul_festering }, transform.position - new Vector3(1f, -1.8f, 0.5f), true);
        if (SpawnedEnemy != null)
        {
            SpawnedEnemy.GetComponent<GhoulFestering>().InitAsGhoulBossSummoned(handsPlace);
            Invoke("ThrowEnemy", 0.6f);
            spawnedEnemies.Add(SpawnedEnemy);
        }
    }

    private void ThrowEnemy()
    {
        if (SpawnedEnemy != null)
        {
            SpawnedEnemy.GetComponent<GhoulFestering>().Throw();
            if (throwSFX != null)
                GetComponent<AudioSource>().PlayOneShot(throwSFX);
            SpawnedEnemy = null;
        }
    }

    public void OnDeath()
    {
        StartCoroutine(DeathPartsFly());
    }


    private class DeathPartsParams
    {
        public float Speed;
        public Vector3 way;
    }
    private IEnumerator DeathPartsFly()
    {
        int parts = 7;
        float minFlySpeed = 5f;
        float maxFlySpeed = 25f;
        float lifeTime = 0.6f;
        float timeStep = 0.02f;
        List<GameObject> explosions = new List<GameObject>();
        List<DeathPartsParams> ways = new List<DeathPartsParams>();
        for (int i = 0; i < parts; i++)
        {
            explosions.Add(Instantiate(onDeathExplosion, explosionPos.transform.position - new Vector3(0, 0, 1f), Quaternion.identity) as GameObject);
            DeathPartsParams newWay = new DeathPartsParams();
            newWay.Speed = UnityEngine.Random.Range(minFlySpeed, maxFlySpeed);
            newWay.way = new Vector3(UnityEngine.Random.Range(-1f, 1f) * 100f, UnityEngine.Random.Range(-1f, 1f) * 100f, 0f);
            ways.Add(newWay);
        }
        while (lifeTime > 0f)
        {
            yield return new WaitForSeconds(timeStep);
            lifeTime -= timeStep;
            for (int i = 0; i < parts; i++)
            {
                explosions[i].transform.position = Vector3.MoveTowards(explosions[i].transform.position, ways[i].way, ways[i].Speed * timeStep);
            }
        }
        yield return new WaitForSeconds(timeStep);
        for (int i = 0; i < parts; i++)
        {
            Destroy(explosions[i]);
        }
        yield break;
    }
}
