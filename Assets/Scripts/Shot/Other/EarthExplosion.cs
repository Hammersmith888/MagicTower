using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EarthExplosion : ExplosionBase
{
    private const float EXPLOSION_DAMAGE_TIME = 0.2f;

    private int damage; // Основной урон от заклинания
    private int burnChance; // Вероятность эффекта возгорания
    private int burnDamage; // Урон от эффекта возгорания
    private float burnTime; // Длительность эффекта возгорания

    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта
    private float crit;


	void Start()
	{
		enemies = new List<EnemyCharacter>();
		GetComponentInChildren<ParticleSystem>().Play();
        SoundController.Instanse.playEarthBallSFX();
	}

    public void SetEarthExplosionParam(int _damage, int _burnChance, int _burnDamage, float _burnTime)
    {
        crit = LevelSettings.Current.criticalModifier();
        damage = (int)(((float)_damage) * crit);
        burnChance = _burnChance;
		burnDamage = _burnDamage;
        burnTime = _burnTime;
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
                // Наносим урон персонажу
                int calculatedDamage = DamageAOEHelper.Instance.CalculatedAOEDamage(damage, coll.transform);
				enemyCharacter.Hit(calculatedDamage, true, DamageType.EARTH, true, crit);

                // Включаем эффект горения на персонаже, если это еще необходимо
				chance = 0;//Random.Range(0, 100);
                if (chance < burnChance)
                {
                    SpellEffects spellEffects = coll.GetComponent<SpellEffects>();
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.EarthBurn, burnTime, burnDamage);
                }
            }   
        }
    }

	private IEnumerator DisableAfterDelay( )
	{
		yield return new WaitForSeconds( EXPLOSION_DAMAGE_TIME );
		GetComponent<Collider2D>().enabled = false;
		enabled = false;

	}
}
