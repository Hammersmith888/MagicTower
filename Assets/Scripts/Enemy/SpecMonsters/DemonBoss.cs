using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
	private EnemyCharacter character;
	[SerializeField]
	private float enrageTimer = 5f, attackDistance = 1.5f, actionDelay = 5f;
	private float actionTimer;
	[SerializeField]
	const float CHECK_DISTANCE = 2.5f * 2.5f;

	float[] levelsHealth = new float[3];

	private bool wasDead = false;
	public bool WasDead
    {
		get
        {
			return wasDead;
        }
    }

	// Use this for initialization
	void Start( )
	{
		character = GetComponent<EnemyCharacter>();
		StartCoroutine( CheckActiveZone() );

		levelsHealth[0] = character.health / 100 * 75;
		levelsHealth[1] = character.health / 100 * 50;
		levelsHealth[2] = character.health / 100 * 25;
	}

    private void Update()
    {
		if (character.currentHealth <= levelsHealth[0] && character.currentHealth > levelsHealth[1])
			character.SetAuraModifier(1);
		else if (character.currentHealth <= levelsHealth[1] && character.currentHealth > levelsHealth[2])
			character.SetAuraModifier(1);
		else if (character.currentHealth <= levelsHealth[2])
			character.SetAuraModifier(2);
	}

    private IEnumerator CheckActiveZone( )
	{
		while( transform.position.x > character.invunarableDistance - 0.5f )
		{
			yield return new WaitForSeconds( 0.2f );
		}
		yield return new WaitForSeconds( enrageTimer );
		while( transform.position.x > attackDistance )
		{
			if(!character.IsDead && !character.IsDeadBeforeSpawn)
			{
				if( actionTimer <= 0 )
					actionTimer = actionDelay;
				if( actionTimer >= actionDelay )
				{
					Action();
				}
				actionTimer -= 0.2f;
			}
			yield return new WaitForSeconds( 0.2f );
		}
		yield break;
	}

	private EnemyCharacter enemyToEat;
	public List<DemonsAura> littleDemons = new List<DemonsAura> ();

	private void Action( )
	{
		if( character.CurrentHealth < character.health * 3 / 4 )
		{
			float minDistance = CHECK_DISTANCE;
			int minId = -1;
			for( int i = 0; i < EnemiesGenerator.Instance.enemiesOnLevelComponents.Count; i++ )
			{
				if( EnemiesGenerator.Instance.enemiesOnLevelComponents[ i ].enemyType == EnemyType.demon_bomb || EnemiesGenerator.Instance.enemiesOnLevelComponents[ i ].enemyType == EnemyType.demon_imp )
				{
					float distance = Vector3.SqrMagnitude( transform.position - EnemiesGenerator.Instance.enemiesOnLevelComponents[ i ].transform.position );
					if( distance < minDistance )
					{
						minDistance = distance;
						minId = i;
					}
				}
			}

			if( minId >= 0 )
			{
				enemyToEat = EnemiesGenerator.Instance.enemiesOnLevelComponents[ minId ];
				character.SetShouldEnrage(true, 1);
				return;
			}
		}
		littleDemons.Clear();
		for( int i = 0; i < EnemiesGenerator.Instance.enemiesOnLevel.Count; i++ )
		{
			if( EnemiesGenerator.Instance.enemiesOnLevel[ i ].GetComponent<DemonsAura>() != null )
				littleDemons.Add( EnemiesGenerator.Instance.enemiesOnLevel[ i ].GetComponent<DemonsAura>() );
		}
		if( littleDemons.Count != 0 )
		{
			character.SetShouldEnrage(true, 0);
		}
	}

	public void GiveAuras( )
	{
		for( int i = 0; i < littleDemons.Count; i++ )
		{
			littleDemons[ i ].AuraActive = true;
		}
	}

	[SerializeField]
	private Transform mouth;
	//public IEnumerator GrabSomeone( )
	//{
	//	//float timer = 0.3f;
	//	//int steps = 5;
	//	//float speed = Vector3.Distance( mouth.position, enemyToEat.transform.position ) / timer;
	//	//for( int i = 0; i < steps; i++ )
	//	//{
	//	//	enemyToEat.transform.position = Vector3.MoveTowards( enemyToEat.transform.position, mouth.position, timer / ( float ) steps * speed );
	//	//	enemyToEat.transform.localScale = new Vector3( ( float ) ( steps - i - 1 ) / ( float ) steps, ( float ) ( steps - i - 1 ) / ( float ) steps, ( float ) ( steps - i - 1 ) / ( float ) steps );
	//	//	yield return new WaitForSeconds( timer / ( float ) steps );
	//	//}
	//	//enemyToEat.enemyMover.UnregisterFromUpdate();
	//	//enemyToEat.death_begin = true;
	//	//EnemiesGenerator.Instance.RemoveEnemy( enemyToEat.GetInstanceID() );
	//	//Destroy( enemyToEat.gameObject );
	//	yield break;
	//}

	public void EatSomeone( )
	{
		character.CurrentHealth += 500;
	}

	public void OnEnrageAnimationFinished()
    {
		character.SetShouldEnrage(false, 0);
	}

	public void OnDiedFirstTime()
	{
		if (wasDead)
			return;
		wasDead = true;

		littleDemons.Clear();
		for( int i = 0; i < EnemiesGenerator.Instance.enemiesOnLevel.Count; i++ )
		{
			if( EnemiesGenerator.Instance.enemiesOnLevel[ i ].GetComponent<DemonsAura>() != null )
				littleDemons.Add( EnemiesGenerator.Instance.enemiesOnLevel[ i ].GetComponent<DemonsAura>() );
		}

		character.SpellEffects.enabled = false;
	
		UI.ReplicaUI.ShowReplica(UI.EReplicaID.Level_kill_boss_demon, UIControl.Current.transform);
		character.getEnemySoundController.PlayDeathBoss();
		SoundController.Instanse.FadeOutCurrentMusic();
	}

	public void Replica()
	{
		StartCoroutine(_Replica());
	}

	IEnumerator _Replica()
	{
		yield return new WaitForSecondsRealtime(1.0f);
		ReplicaUI.ShowReplica(EReplicaID.Level_95_killBoss,UIControl.Current.transform);

	}

	public void OnDeathAnimationFinished()
	{
		if (!character.IsDeadBeforeSpawn)
		{
			KillAllEnemies();
			return;
		}

		var effect = Instantiate(Resources.Load("Effects/DaemonBossRessurect")) as GameObject;
		effect.transform.position = transform.position + new Vector3(-0.6f, -0.3f, 0);

		StartCoroutine(Respawn());
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(2);

		character.SetShouldPerformSpawn(true);
		character.currentHealth = character.health / 100 * 25;
		character.SpellEffects.enabled = true;

		littleDemons.Clear();
		for (int i = 0; i < EnemiesGenerator.Instance.enemiesOnLevel.Count; i++)
		{
			if (EnemiesGenerator.Instance.enemiesOnLevel[i].GetComponent<DemonsAura>() != null)
				littleDemons.Add(EnemiesGenerator.Instance.enemiesOnLevel[i].GetComponent<DemonsAura>());
		}
		for (int i = littleDemons.Count - 1; i >= 0; i--)
		{
			EnemyCharacter littleChar = littleDemons[i].GetComponent<EnemyCharacter>();
			littleChar.Death();
		}

		yield return new WaitForSeconds(1f);
		UI.ReplicaUI.ShowReplica(UI.EReplicaID.Level95_BossHp, UIControl.Current.transform);

		yield return new WaitForSeconds(0.9f);
		character.SetShouldPerformSpawn(false);

	}

	void KillAllEnemies()
    {
		for (int i = EnemiesGenerator.Instance.enemiesOnLevelComponents.Count - 1; i >= 0; i--)
		{
			EnemiesGenerator.Instance.enemiesOnLevelComponents[i].Death();
		}
	}
}
