using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMurderer : MonoBehaviour
{
    private EnemyCharacter character;
    private EnemyProjectile projectile;
    private float attackPosX;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        projectile = GetComponent<EnemyProjectile>();
        StartCoroutine(SetNewAttackPosX());
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

    public void OnAttackAnimationStarted()
    {
        projectile.OnAttackAnimationStarted();
    }

    public void OnProjectileTime()
    {
        projectile.OnProjectileTime();
    }
}
