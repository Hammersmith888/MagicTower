using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpell : SpellBase
{
    public GameObject burnEffect; // Эффект возгорания
    public float lifeTime; // Время жизни молнии
    private float startTime;
    public int damage; // min-max урон
    public int burnChance; // Вероятность эффекта возгорания
    public int burnDamage; // Урон от эффекта возгорания
    public float burnTime; // Длительность эффекта возгорания
    private float crit;
    public float radius;

    [SerializeField]
    private float radiusOuter = 2.0f;
    [SerializeField]
    private float radiusInner = 1.0f;

    private List<EnemyCharacter> burnedEnemies = new List<EnemyCharacter>();
    private EnemiesGenerator enemiesGenerator;

    private bool damaged = false;

    private void Start()
    {
        crit = LevelSettings.Current.criticalModifier();
        damage = (int)((float)damage * crit);
        startTime = Time.time;
        Destroy(gameObject, lifeTime);
        SoundController.Instanse.playMeteorSFX();
        transform.localScale = new Vector3(radius, radius, radius);
    }

    private void Update()
    {
        if (enemiesGenerator == null)
            enemiesGenerator = EnemiesGenerator.Instance;

        if (Time.time - startTime > 0.5f)
        {
            if (enemiesGenerator != null)
            {
                Vector2 positionOnPlane = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);

                int enemiesCount = enemiesGenerator.enemiesOnLevelComponents.Count;
                for (int i = enemiesCount - 1; i >= 0; i--)
                {
                    EnemyCharacter enemy = enemiesGenerator.enemiesOnLevelComponents[i];
                    float distanceSqr = (enemy.enemyMover.positionOnPlane - positionOnPlane).sqrMagnitude;
                    if (distanceSqr < (radiusOuter + enemy.enemyMover.movementRadius) * (radiusOuter + enemy.enemyMover.movementRadius))
                    {
                        if (!damaged)
                        {
                            bool inner = false;
                            if (distanceSqr < (radiusInner + enemy.enemyMover.movementRadius) * (radiusInner + enemy.enemyMover.movementRadius))
                                inner = true;

                            StartCoroutine(DamageEnemyAfterTime(enemy, inner, 0.1f));
                        }

                        if (!burnedEnemies.Contains(enemy))
                        {
                            StartCoroutine(BurnEnemyAfterTime(enemy, 0.1f));
                            burnedEnemies.Add(enemy);
                        }
                    }
                }
            }

            damaged = true;
        }
    }

    public void Activation(Vector3 _targetDirection)
    {
        float value = 0;
        if (radius == 4)
            transform.position = new Vector3(_targetDirection.x, 0.5f, 0f); //

        if (_targetDirection.y < 0)
        {
            value = Mathf.Clamp(_targetDirection.y + radius / 3 , _targetDirection.y, 0);
            transform.position = new Vector3(_targetDirection.x, Mathf.Clamp(_targetDirection.y, value, -value), 0f); //
        }
        else
        {
            value = Mathf.Clamp(2.7f - radius / 2, 0, 2.7f);
            transform.position = new Vector3(_targetDirection.x, Mathf.Clamp(_targetDirection.y, -value, value), 0f); //
        }
    }

    private IEnumerator DamageEnemyAfterTime(EnemyCharacter enemy, bool inner, float time)
    {
        yield return new WaitForSeconds(time);

        if (inner)
            enemy.Hit(damage, true, DamageType.FIRE, true, crit);
        else
            enemy.Hit(damage / 4, true, DamageType.FIRE, true, crit);
    }

    private IEnumerator BurnEnemyAfterTime(EnemyCharacter enemy, float time)
    {
        yield return new WaitForSeconds(time);

        if (FireExplosion.BurnValidation(enemy.CurrentHealth, burnChance))
        { 
            enemy.SpellEffects.AddEffect(SpellEffects.Effect.EffectTypes.FireBurn, burnTime, burnDamage);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < 2; i++)
        {
            float circleRadius;
            if (i == 0)
                circleRadius = radiusOuter;
            else
                circleRadius = radiusInner;

            Vector2 circleCenter = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);
            for (int a = 0; a < 360; a++)
            {
                float a1 = a;
                float a2 = (a + 1) % 360;

                Vector2 circlePointPlane1 = circleCenter + circleRadius * new Vector2(Mathf.Cos(a1 * Mathf.Deg2Rad), Mathf.Sin(a1 * Mathf.Deg2Rad));
                Vector2 circlePointPlane2 = circleCenter + circleRadius * new Vector2(Mathf.Cos(a2 * Mathf.Deg2Rad), Mathf.Sin(a2 * Mathf.Deg2Rad));

                Vector3 circlePoint1 = new Vector3(circlePointPlane1.x, circlePointPlane1.y * EnemyMover.WORLD_PLANE_SIN,
                    circlePointPlane1.y * EnemyMover.WORLD_PLANE_COS - 6.0f);
                Vector3 circlePoint2 = new Vector3(circlePointPlane2.x, circlePointPlane2.y * EnemyMover.WORLD_PLANE_SIN,
                    circlePointPlane2.y * EnemyMover.WORLD_PLANE_COS - 6.0f);

                Gizmos.DrawLine(circlePoint1, circlePoint2);
            }
        }
    }
#endif
}