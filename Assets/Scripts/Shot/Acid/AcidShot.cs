using UnityEngine;
using System.Collections;

public class AcidShot : BaseUpdatableObject
{
    private Vector3 direction;
    private float speed;
    private int damage;
    private int acidChance; // Вероятность эффекта отравления
    private int acidDamage; // Урон от эффекта отравления
    private float acidTime; // Длительность эффекта отравления

    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта

	private bool currentlyOnField;
	private float startXposition;

	const float DISABLE_OUT_OF_SCREEN_DELAY = 0.8f;
	const float DISABLE_ON_COLLISION_DELAY = 0.35f;

	public void SetAcidShotParam(Vector3 _direction, float _speed, int _damage, int _acidChance, int _acidDamage, float _acidTime)
    {
        direction = _direction.normalized;
		direction.z = 0;
		speed = _speed;
        damage = (int)((float)_damage);// * LevelSettings.Current.criticalModifier());
        acidChance = _acidChance;
        acidDamage = _acidDamage;
        acidTime = _acidTime;
		currentlyOnField = true;
		startXposition = transform.position.x;
		RegisterForUpdate();
    }

	Vector3 pos;
	override public void UpdateObject ()
	{
		pos = transform.position;
		pos += direction * ( Time.deltaTime * speed );
		transform.position = pos;
		if( currentlyOnField && pos.x - startXposition >  SpellBase.DefaultMaxShotFlyDistance)
		{
			OnOutOfGameField();
		}
	}

	private void OnOutOfGameField( )
	{
		currentlyOnField = false;
		gameObject.ToggleComponent<Collider2D>( false );
		StartCoroutine( DisableAfterDelay ( DISABLE_OUT_OF_SCREEN_DELAY ) );
	}

	private IEnumerator DisableAfterDelay( float delay )
	{
		yield return new WaitForSeconds( delay );
		UnregisterFromUpdate();
		Destroy( gameObject );
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();

            if (enemyCharacter.CurrentHealth > 0)
            {
                /// Эффекты на персонаже
                SpellEffects spellEffects = coll.GetComponent<SpellEffects>();
                // Наносим урон персонажу
                // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
                if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                    enemyCharacter.Hit(damage, false, DamageType.EARTH);
                else
                    enemyCharacter.Hit(damage, true, DamageType.EARTH);

                // Включаем эффект на персонаже, если это еще необходимо
                chance = Random.Range(0, 100);
                if (chance < acidChance)
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.PoisonBurn, acidTime, acidDamage);
            }
			UnregisterFromUpdate();
			gameObject.DisableParticlesEmission();
			gameObject.ToggleComponent<Collider2D>( false );
			StartCoroutine( DisableAfterDelay( DISABLE_ON_COLLISION_DELAY ) );
		}
    }
}