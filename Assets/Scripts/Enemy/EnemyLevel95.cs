using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel95 : MonoBehaviour
{
    EnemyCharacter character;

    [SerializeField]
    private EnemyType[] enemyTypesForSpawn;
    private List<GameObject> spawnedEnemies;
    float spawnTimer = 0;
    int spawnsConter = 0;

    [SerializeField]
    float[] posX, posY;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        spawnedEnemies = new List<GameObject>();
        spawnTimer = Random.Range(7f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        int spawnedEnemiesCount = spawnedEnemies.Count;
        for (int i = spawnedEnemiesCount - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i] == null)
                spawnedEnemies.RemoveAt(i);
        }

        if (character.IsOnGameField && !character.IsDead && !character.IsDeadBeforeSpawn)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer < 0 && spawnedEnemies.Count == 0)
            {
                spawnTimer = Random.Range(7f, 15f);
                spawnsConter++;
                if (spawnsConter % 2 == 0)
                    SpawnEnemies(3);
                else
                    SpawnEnemies(5);
            }
        }
    }

    private void SpawnEnemies(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var x = Random.Range(posX[0], posX[1]);
            var y = Random.Range(posY[0], posY[1]);

            GameObject createdEnemy;
            EnemyCharacter createdEnemyCharacterComponent = null;
            createdEnemy = EnemiesGenerator.Instance.CreateEnemy(enemyTypesForSpawn[Random.Range(0, enemyTypesForSpawn.Length)], new Vector2(x, y), true, true);
            if (createdEnemy != null)
                createdEnemyCharacterComponent = createdEnemy.GetComponent<EnemyCharacter>();
            if (createdEnemyCharacterComponent != null)
                createdEnemyCharacterComponent.InitAsSummoned(1.5f);

            spawnedEnemies.Add(createdEnemy);
        }
    }
}
