using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FireExplosion : ExplosionBase
{
    const float EXPLOSION_DAMAGE_TIME = 0.2f;

    private int damage; // Основной урон от заклинания
    private int burnChance; // Вероятность эффекта возгорания
    private int burnDamage; // Урон от эффекта возгорания
    private float burnTime; // Длительность эффекта возгорания
    private int killCounter;
    private float crit;

    public static bool ColliderValidation(Collider2D coll)
    {
        return coll.CompareTag(GameConstants.ENEMY_TAG);
    }

    public static bool HpValidation(float currentHealth)
    {
        return currentHealth > 0;
    }

    public static bool BurnValidation(float currentHealth, int burnChance)
    {
        // Включаем эффект горения на персонаже, если это еще необходимо
        int chance = Random.Range(0, 100);
        return currentHealth > 0 && chance < burnChance;
    }

    private void Start()
    {
        enemies = new List<EnemyCharacter>();
        GetComponentInChildren<ParticleSystem>().Play();
    }

    public void SetFireExplosionParam(int _damage, int _burnChance, int _burnDamage, float _burnTime)
    {
        crit = LevelSettings.Current.criticalModifier();
        damage = (int)(((float)_damage) * crit);
        burnChance = _burnChance;
        burnDamage = _burnDamage;
        burnTime = _burnTime;
        gameObject.SetActive(true);
        StartCoroutine(DisableAfterDelay());
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        OnTriggerLogic(coll);
    }

    public void OnTriggerLogic(Collider2D coll)
    {
        if (!ColliderValidation(coll))
        {
            return;
        }
        EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
        if (!HpValidation(enemyCharacter.CurrentHealth) ||
            AlreadyAdded(enemyCharacter.gameObject.GetInstanceID()))
        {
            return;
        }

        enemies.Add(enemyCharacter);
        int calculatedDamage = DamageAOEHelper.Instance.CalculatedAOEDamage(damage, coll.transform); // Наносим урон персонажу

        enemyCharacter.Hit(calculatedDamage, !enemyCharacter.SpellEffects.FreezedOrParalysed, DamageType.FIRE, true, crit);
        UpdateKillCount(enemyCharacter.CurrentHealth);

        if (BurnValidation(enemyCharacter.CurrentHealth, burnChance))
            enemyCharacter.SpellEffects.AddEffect(SpellEffects.Effect.EffectTypes.FireBurn, burnTime, burnDamage);
    }

    private void UpdateKillCount(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            killCounter++;
        }
    }

    private void OnDestroy()
    {
       
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(EXPLOSION_DAMAGE_TIME);
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }
}