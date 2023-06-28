using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKing : MonoBehaviour
{
    private EnemyCharacter character;

    private const float SUMMON_INTERVAL = 8.0f;
    private float summonTimer = 0.0f;

    private List<GameObject> spawnedEnemies;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        spawnedEnemies = new List<GameObject>();
    }

    void Update()
    {
        if (character.IsOnGameField)
            summonTimer += Time.deltaTime;

        if (summonTimer > SUMMON_INTERVAL)
        {
            int spawnedEnemiesCount = spawnedEnemies.Count;
            for (int i = spawnedEnemiesCount - 1; i >= 0; i--)
            {
                if (spawnedEnemies[i] == null)
                    spawnedEnemies.RemoveAt(i);
            }

            if (spawnedEnemies.Count == 0)
            {
                character.Summon();
                summonTimer = 0.0f;
            }
        }
    }

    public void OnSummonTime()
    {
        if (EnemiesGenerator.Instance == null)
            return;

        float y1, y2;
        do
        {
            y1 = Random.Range(-1.5f, 1.5f);
            y2 = Random.Range(-1.5f, 1.5f);
        }
        while (Mathf.Abs(y1 - y2) > 1.5f || Mathf.Abs(y1 - y2) < 0.5f);

        GameObject createdEnemy;
        EnemyCharacter createdEnemyCharacterComponent = null;

        createdEnemy = EnemiesGenerator.Instance.CreateEnemy(EnemyType.skeleton_swordsman, new Vector2(8, y1));
        if (createdEnemy != null)
            createdEnemyCharacterComponent = createdEnemy.GetComponent<EnemyCharacter>();
        if (createdEnemyCharacterComponent != null)
            createdEnemyCharacterComponent.InitAsSummoned(2.5f);
        spawnedEnemies.Add(createdEnemy);

        createdEnemy = EnemiesGenerator.Instance.CreateEnemy(EnemyType.skeleton_swordsman, new Vector2(8, y2));
        if (createdEnemy != null)
            createdEnemyCharacterComponent = createdEnemy.GetComponent<EnemyCharacter>();
        if (createdEnemyCharacterComponent != null)
            createdEnemyCharacterComponent.InitAsSummoned(2.5f);
        spawnedEnemies.Add(createdEnemy);
    }
}
