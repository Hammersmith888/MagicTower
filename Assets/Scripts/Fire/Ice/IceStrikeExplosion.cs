using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceStrikeExplosion : ExplosionBase 
{
    private int damage; // Основной урон от заклинания
    private int slowdownValue; // Эффект замедления (на сколько замедляем в %)
    private float slowdownTime; // Длительность эффекта замедления
    private int freezingChance; // Вероятность эффекта заморозки
    private float freezingTime; // Длительность эффекта заморозки

    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта

	const float EXPLOSION_DAMAGE_TIME = 0.2f;
	private int killCounter;
    private float crit;

	void Start()
	{
		enemies = new List<EnemyCharacter>();
		GetComponent<ParticleSystem>().Play();
	}

    public void SetIceExplosionParam(int _damage, int _slowdownValue, float _slowdownTime, int _freezingChance, float _freezingTime)
    {
        crit = LevelSettings.Current.criticalModifier();
        damage = (int)(((float)_damage) * crit);

        slowdownValue = _slowdownValue*2;
        slowdownTime = _slowdownTime;
        freezingChance = _freezingChance;
        freezingTime = _freezingTime;
		gameObject.SetActive( true );
		StartCoroutine( DisableAfterDelay() );
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();

			if (!AlreadyAdded( enemyCharacter.gameObject.GetInstanceID() ) && enemyCharacter.CurrentHealth > 0)
			{
				enemies.Add( enemyCharacter );
				// Эффекты на персонаже
                SpellEffects spellEffects = coll.GetComponent<SpellEffects>();
                // Наносим урон персонажу
                int calculatedDamage = DamageAOEHelper.Instance.CalculatedAOEDamage(damage, coll.transform);
                enemyCharacter._slowDownTime = slowdownTime;
                // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
                if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                    enemyCharacter.Hit(calculatedDamage, false, DamageType.WATER, true, crit);
                else
                    enemyCharacter.Hit(calculatedDamage, true, DamageType.WATER, true, crit);
				
				if (enemyCharacter.CurrentHealth <= 0)
                {
                    killCounter++;
                }
				
                chance = Random.Range(0, 100);
                if (chance < freezingChance)
                {
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Freezing, freezingTime, isSpell: true);
                }
                else
                {
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.IceSlowdown, slowdownTime, slowdownValue);
                }
            }
        }
    }

	void OnDestroy()
	{
        
	}

	private IEnumerator DisableAfterDelay( )
	{
		yield return new WaitForSeconds( EXPLOSION_DAMAGE_TIME );
		GetComponent<Collider2D>().enabled = false;
		enabled = false;
	}
}
