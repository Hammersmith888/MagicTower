using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnedKing : MonoBehaviour
{
    [System.Serializable]
    private class SpawnVariant
    {
        public EnemyType type;
        public int number;
    }
    [HideInInspector]
    public bool enraged;
    private EnemyCharacter character;
    [SerializeField]
    private List<SpawnVariant> spawnVars = new List<SpawnVariant>();

    private const float SUMMON_INTERVAL = 8.0f;
    private float summonTimer = 0.0f;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        StartCoroutine(CheckHealthLevel());
    }

    private IEnumerator CheckHealthLevel()
    {
        float timeStep = 0.2f;
        while (gameObject != null && character.CurrentHealth > character.health * 0.7f)
            yield return new WaitForSeconds(timeStep);
        if (gameObject == null)
            yield break;
        EnableAura();
        while (gameObject != null && character.CurrentHealth > character.health * 0.25f)
            yield return new WaitForSeconds(timeStep);
        if (gameObject == null)
            yield break;
        Enrage();
        yield break;
    }

    private void EnableAura()
    {
        character.gives_aura_id = 1;
    }

    private void Enrage()
    {
        enraged = true;
        character.SetMovementType(EnemyMovementType.run);
    }

    private void Update()
    {
        if (!enraged)
        {
            if (character.IsOnGameField)
                summonTimer += Time.deltaTime;

            if (summonTimer > SUMMON_INTERVAL)
            {
                if (EnemiesGenerator.Instance != null && EnemiesGenerator.Instance.CanSummonEnemy)
                {
                    character.Summon();
                    summonTimer = 0.0f;
                }
            }
        }
    }

    public void OnSummonTime()
    {
        if (EnemiesGenerator.Instance == null || !EnemiesGenerator.Instance.CanSummonEnemy)
            return;

        int id = UnityEngine.Random.Range(0, spawnVars.Count);
        float yStep = (Mathf.Abs(GameConstants.MaxTopBorder) + Mathf.Abs(GameConstants.MaxBottomBorder)) / (spawnVars[id].number + 2);

        for (int i = 0; i < spawnVars[id].number; i++)
        {
            GameObject createdEnemy;
            EnemyCharacter createdEnemyCharacterComponent = null;

            float yPos = GameConstants.MaxBottomBorder + yStep * (float)(i + 1);
            createdEnemy = EnemiesGenerator.Instance.CreateEnemy(spawnVars[id].type, new Vector2(8, yPos), true, true);
            if (createdEnemy != null)
                createdEnemyCharacterComponent = createdEnemy.GetComponent<EnemyCharacter>();
            if (createdEnemyCharacterComponent != null)
                createdEnemyCharacterComponent.InitAsSummoned(2.5f);
        }
    }

    public void onDeath()
    {
        for (int i = EnemiesGenerator.Instance.enemiesOnLevelComponents.Count - 1; i >= 0; i--)
        {
            EnemiesGenerator.Instance.enemiesOnLevelComponents[i].Death();
        }
    }
}
