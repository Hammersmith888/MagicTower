using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : MonoBehaviour
{
    private const float PlayerWallPositionByX = -4.7f;
    public ArrowFly ArrowFly;

    private EnemyCharacter character;
    private float attackPosX;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        StartCoroutine(SetNewAttackPosX());

        if (ArrowFly != null)
            ArrowFly.RegisterForUpdate();
    }

    void Update()
    {
        if (transform.position.x < attackPosX)
            character.SetCanAttackPlayerFromDistanceNow(true);
        else
            character.SetCanAttackPlayerFromDistanceNow(false);
    }

    IEnumerator SetNewAttackPosX()
    {
        if (character == null)
            yield break;

        while (character.minActionX == 0.0f && character.maxActionX == 0.0f)
            yield return null;

        attackPosX = Random.Range(character.minActionX, character.maxActionX);
    }

    // Called by animation
    public void OnAttackAnimationStarted()
    {
        if (ArrowFly != null)
            ArrowFly.StartAtack();
    }

    // Called by animation
    public void OnProjectileTime()
    {
        if (ArrowFly != null)
        {
            if (character.isWallAttack)
            {
                ArrowFly.SpawnArrow(PlayerWallPositionByX);
            }
            else if (character.attackedObject != null)
            {
                ArrowFly.SpawnArrow(character.attackedObject.transform.position.x);
            }
        }
    }
}
