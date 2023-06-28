using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardSpell : SpellBase {

	public int minDamage, maxDamage; // min-max урон
	public float lifeTime; // Длительность эффекта возгорания
	private List<EnemyCharacter> enemies; // Каждого персонажа необходимо атаковать только один раз, здесь список персонажей, которых уже атаковали
	private float damage_timer;
	private int damage;
	public float freezingTime; // Время действия эффекта заморозки
	private Collider2D _collider;
	void Start( )
	{
		_collider = GetComponent<Collider2D> ();
		_collider.enabled = false;
		enemies = new List<EnemyCharacter>();

		damage = ( int ) ( ( float ) Random.Range( minDamage, maxDamage ));
		StartCoroutine (ColliderEnable());
		if (lifeTime > 0.01) {
			Destroy (gameObject, lifeTime);
		}
        SoundController.Instanse.playBlizzardSFX();
	}

	private IEnumerator ColliderEnable()
	{
		yield return new WaitForSeconds (0.2f);
		_collider.enabled = true;
		yield return new WaitForSeconds (0.1f);
		for (int j = 0; j < 3; j++) {
			int count = enemies.Count;
			for( int i = 0; i < count; i++ )
			{
				if( enemies[ i ] != null )
				{
					EnemyCharacter enemyCharacter = enemies[ i ];
					if (enemyCharacter.transform.position.x < enemyCharacter.invunarableDistance)
					{
						enemyCharacter.Hit ((int)((float)damage / 3f), false, DamageType.WATER);
						SpellEffects spellEffects = enemies[i].GetComponent<SpellEffects>();
						spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Freezing, freezingTime, 1.0f, true);
					}
				}
			}
			yield return new WaitForSeconds (0.5f);
		}
		_collider.enabled = false;
		yield break;
	}

	private bool AlreadyAdded( int _enemyID )
	{
		int count = enemies.Count;
		for(int i = 0; i < count; i++ )
		{
			if( enemies[ i ] != null && _enemyID == enemies[i].gameObject.GetInstanceID() )
				return true;
		}
		return false;
	}

	// Активируется после получения вектора направления движения
	public void Activation( Vector3 _targetDirection )
	{
		transform.position = new Vector3( _targetDirection.x, _targetDirection.y, 0 );
		//		transform.rotation = Quaternion.Euler( 0f, 0f, -15f ); // Поворачиваем FireWall, чтобы сохранить эффект перспективы
	}

	void OnTriggerEnter2D( Collider2D coll )
	{
		if( coll.CompareTag( GameConstants.ENEMY_TAG ) )
		{
			EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
			if( !AlreadyAdded( enemyCharacter.gameObject.GetInstanceID() ) )
			{
				enemies.Add( enemyCharacter );
			}
		}
	}

}
