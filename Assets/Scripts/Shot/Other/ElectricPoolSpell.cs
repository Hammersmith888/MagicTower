using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPoolSpell : BaseAOESpell
{
    public int minDamage, maxDamage; // min-max урон
    public float lifeTime; // Длительность эффекта возгорания
    public int paralysisChance; // Вероятность эффекта паралича
    public float paralysisTime; // Время паралича
    private float crit;
    override protected DamageType SpellDamageType
    {
        get
        {
            return DamageType.AIR;
        }
    }

    private void Start()
    {
        enemies = new List<EnemyCharacter>();
        enemiesTimers = new List<float>();

        crit = LevelSettings.Current.criticalModifier();
        damage = (int)(((float)Random.Range(minDamage, maxDamage)) * crit);
        SoundController.Instanse.playElectricPoolSFX();
        if (lifeTime > 0.01)
        {
            Destroy(gameObject, lifeTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            var enemyCharacter = coll.GetComponent<EnemyCharacter>();

            if (enemyCharacter.CurrentHealth > 0)
            {
                if (enemyCharacter.enemyType == EnemyType.ghoul && enemyCharacter.transform.position.x > PlayerController.Position.x + 2.2f && lifeTime != 0)
                {
                    if (!enemies.Contains(enemyCharacter))
                    {
                        enemyCharacter.Jump(new Vector2(-2.2f, 0.0f));
                    }
                    return;
                }
                if (lifeTime > 0.01f)
                {
                    ApplyDamage(enemyCharacter, crit);
                    if (!IsAlreadyAdded(enemyCharacter.gameObject.GetInstanceID()))
                    {
                        enemies.Add(enemyCharacter);
                        enemiesTimers.Add(0f);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (damageTimer == 0)
        {
            damageTimer = 3f;
        }

        int count = enemies.Count;
        for (int i = 0; i < count; i++)
        {
            if (enemiesTimers[i] + damageTimer <= Time.time)
            {
                if (enemies[i] != null)
                {
                    var enemyCharacter = enemies[i];
                    enemiesTimers[i] = Time.time;
                    ApplyDamage(enemyCharacter);
                    int chance = Random.Range(0, 100);
                    if (chance < paralysisChance)
                    {
                        SpellEffects spellEffects = enemyCharacter.GetComponent<SpellEffects>();
                        spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Paralysis, paralysisTime);
                    }
                }
            }
        }
    }
}
