using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceBreathShot : SpellBase
{
    public int minDamage, maxDamage; // min-max урон
    public int slowdownValue; // Эффект замедления (на сколько замедляем в %)
    public float slowdownTime; // Время действия эффекта замедления
    public int freezingChance; // Вероятность эффекта заморозки // Вероятность эффекта заморозки увеличивается на 10% каждую секунду применения заклинания
    public float freezingTime; // Время действия эффекта заморозки
    public float size;
    public float damageFreeze;

    private int damage;
    private float damageTime = 1f, damageTimer = 0f, freezeTempTime = 1f, freezeTempTimer = 0.9f;
    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта

    private List<EnemyCharacter> enemies;
    private List<float> enemiesTimers;

    private void Start()
    {
        enemies = new List<EnemyCharacter>();
        enemiesTimers = new List<float>();
        transform.localScale = new Vector3(size / 10f, size / 10f, size / 10f);
        Debug.Log($"scale: {transform.localScale}, size: {size}");

        Destroy(gameObject, timeOfSecondEffect);
    }

    // Зашел в зону поражения IceBreath
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
            if (!enemies.Contains(enemyCharacter))
            {
                enemies.Add(enemyCharacter);
                enemiesTimers.Add(0f);
            }
        }
    }

    // Вышел из зоны поражения IceBreath
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            int id = enemies.IndexOf(coll.GetComponent<EnemyCharacter>());
            if (id >= 0)
            {
                enemies.RemoveAt(id);
                enemiesTimers.RemoveAt(id);
            }
        }
    }

    IEnumerator _Damage(EnemyCharacter enemy, float _damage, bool _anim, DamageType damageType, bool canInterruptAttack = true, float critOnlyInfo = 0, bool isSpell = false, bool delay = false)
    {
        yield return new WaitForSeconds(Random.Range(0f,1f));
        enemy.Hit(damage, false, DamageType.WATER, delay: true);
    }

    // Атака всех персонажей, находящихся в зоне поражения
    private void Update()
    {
        damageTimer += Time.deltaTime;
        for (int i = 0; i < enemiesTimers.Count; i++)
        {
            enemiesTimers[i] += Time.deltaTime;
        }

        if (damageTimer >= damageTime)
        {
            damage = (int)((float)Random.Range(minDamage, maxDamage) * damageTime);
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null && enemies[i].CurrentHealth > 0)
                {
                    // Эффекты на персонаже
                    SpellEffects spellEffects = enemies[i].GetComponent<SpellEffects>();

                    // Наносим урон персонажу
                    // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
                    bool canStopEnemy = false;
                    if (freezeTempTimer >= freezeTempTime && enemiesTimers[i] >= 1f)
                    {
                        canStopEnemy = true;
                        enemiesTimers[i] = 0f;
                    }
                    if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                    {
                        // enemies[i].Hit(damage, false, DamageType.WATER, delay: true);
                        StartCoroutine(_Damage(enemies[i], damage, false, DamageType.WATER, delay: true));
                    }
                    else
                    {
                        //enemies[i].Hit(damage, canStopEnemy, DamageType.WATER, delay: true);
                        StartCoroutine(_Damage(enemies[i], damage, canStopEnemy, DamageType.WATER, delay: true));
                    }
                }
            }
            damageTimer = 0;
        }

        freezeTempTimer += Time.deltaTime;
        if (freezeTempTimer >= freezeTempTime)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null && enemies[i].CurrentHealth > 0)
                {
                    chance = Random.Range(0, 100);
                    SpellEffects spellEffects = enemies[i].GetComponent<SpellEffects>();

                    if (chance < freezingChance)
                    {
                        spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Freezing, freezingTime, isSpell: true);
                        spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.IceBurn, freezingTime, (int)damageFreeze);
                        spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.IceSlowdown, freezingTime + 3f, slowdownValue);
                    }
                    else
                    {
                        spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.IceSlowdown, slowdownTime, slowdownValue);
                    }
                }
            }
            freezeTempTimer = 0f;
        }
    }
}