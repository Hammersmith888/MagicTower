using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFatty : MonoBehaviour {
	private EnemyCharacter character;
	[SerializeField]
	private float shootDistance = 5f, minDistance = 3f, spawnerDelay = 4.5f;
	[SerializeField]
	private GameObject spawnEnemy, bullet;
	[HideInInspector]
	public bool shooting;

	private List<EnemyCharacter> spawnedCharacters;

	// Use this for initialization
	void Start () {
		shootDistance = UnityEngine.Random.Range (minDistance, shootDistance);
		character = GetComponent<EnemyCharacter> ();
		spawnedCharacters = new List<EnemyCharacter>();
		StartCoroutine (CheckFirstActiveZone());
	}


	private IEnumerator CheckFirstActiveZone()
	{
		while (transform.position.x > character.invunarableDistance - 0.5f) {
			yield return new WaitForSeconds (0.2f);
		}
		StartCoroutine(ProductWay());
		yield break;
	}

	private float spawnerTimer;

	private IEnumerator ProductWay()
	{
		while (transform.position.x > shootDistance) {
			if (spawnerTimer <= 0)
				spawnerTimer = spawnerDelay;
			if (spawnerTimer >= spawnerDelay)
				character.Shoot();
			spawnerTimer -= 0.2f;
			yield return new WaitForSeconds (0.2f);
		}
		character.SetMovementType(EnemyMovementType.walk);
	}

	public void Action()
	{
		int spawnedCharactersCount = spawnedCharacters.Count;
		for (int i = spawnedCharactersCount - 1; i >= 0; i--)
		{
			if (spawnedCharacters[i] == null)
				spawnedCharacters.RemoveAt(i);
		}

		if (transform.position.x < shootDistance) 
		{
			if (spawnedCharacters.Count < 2 && UnityEngine.Random.Range(0f, 1f) > 0.5f)
				Spawn ();
			else
				Shooting ();
		}
	}

	private void Shooting()
	{
		if (bullet != null)
			Instantiate (bullet, transform.position - new Vector3(1f, -1.8f, 0.5f), bullet.transform.rotation);
	}

	private void Spawn()
	{
		if (spawnEnemy == null)
			return;
		GameObject SpawnedEnemy = EnemiesGenerator.Instance.CreateEnemy (new Enemy { enemyNumber = EnemyType.demon_bomb }, transform.position - new Vector3(1f, -1.8f, 0.5f), true);

		if (SpawnedEnemy == null) return;
		SpawnedEnemy.GetComponent<DemonBomb>().InitAsFattyBomb();
		spawnedCharacters.Add(SpawnedEnemy.GetComponent<EnemyCharacter>());
	}

	
}
