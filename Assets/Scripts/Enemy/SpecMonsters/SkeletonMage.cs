using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour
{
    private EnemyCharacter character;
    private float summonPosX;
    private bool currentSummonPosUsed = false;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        StartCoroutine(SetNewSummonPosX());
    }

    void Update()
    {
        if (transform.position.x == summonPosX)
        {
            if (!currentSummonPosUsed)
            {
                character.Summon();
                currentSummonPosUsed = true;
            }
            else
            {
                if (!character.IsSummoning)
                    StartCoroutine(SetNewSummonPosX());
            }
        }
    }

    IEnumerator SetNewSummonPosX()
    {
        if (character == null)
            yield break;

        while (character.minActionX == 0.0f && character.maxActionX == 0.0f)
            yield return null;

        float minPos = transform.position.x * 0.75f;
        if (minPos > character.maxActionX)
        {
            minPos = character.maxActionX * 0.75f;
        }
        summonPosX = Mathf.Max(Random.Range(character.minActionX, character.maxActionX), minPos);
        currentSummonPosUsed = false;

        character.SetTargetPosX(summonPosX);
    }

    public void OnSummonTime()
    {
        if (EnemiesGenerator.Instance != null && EnemiesGenerator.Instance.CanSummonEnemy)
        {
            StartCoroutine(SummonEnemy());
        }
    }

    private IEnumerator SummonEnemy()
    {
        GameObject createdEnemy = null;
        EnemyCharacter createdEnemyCharacterComponent = null;

        if (character.enemyType == EnemyType.skeleton_mage || character.enemyType == EnemyType.skeleton_mage2)
        {
            createdEnemy = EnemiesGenerator.Instance.CreateEnemy(EnemyType.zombie_brain, transform.position + Vector3.left * 1.5f);
        }
        else if (character.enemyType == EnemyType.skeleton_strong_mage || character.enemyType == EnemyType.skeleton_strong_mage2)
        {
            createdEnemy = EnemiesGenerator.Instance.CreateEnemy(EnemyType.skeleton_tom, transform.position + Vector3.left * 1.5f);
        }

        if (createdEnemy != null)
            createdEnemyCharacterComponent = createdEnemy.GetComponent<EnemyCharacter>();
        if (createdEnemyCharacterComponent != null)
            StartCoroutine(InitSummonMover(createdEnemyCharacterComponent));
        yield return null;
    }

    private IEnumerator InitSummonMover(EnemyCharacter createdEnemyCharacterComponent)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        createdEnemyCharacterComponent.InitAsSummoned(1f, true);
    }
}
