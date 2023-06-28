using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulScavenger : MonoBehaviour
{
    private EnemyCharacter character;
    private EnemyProjectile projectile;
    private float attackPosX;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        projectile = GetComponent<EnemyProjectile>();
        attackPosX = Random.Range(2.4f, 3.2f);
    }

    void Update()
    {
        if (transform.position.x < attackPosX)
            character.SetCanAttackPlayerFromDistanceNow(true);
        else
            character.SetCanAttackPlayerFromDistanceNow(false);
    }

    public void OnAttackAnimationStarted()
    {
        projectile.OnAttackAnimationStarted();
    }

    public void OnProjectileTime()
    {
        projectile.OnProjectileTime();
    }

    public void OnAttackAnimationFinished()
    {
        character.Jump(new Vector2(3.0f, 0.0f));
    }
}
