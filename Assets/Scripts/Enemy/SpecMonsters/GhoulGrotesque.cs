using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulGrotesque : MonoBehaviour {
	private EnemyCharacter character;
	[SerializeField]
	private float shootDistance = 7.5f, minDistance = 0f, spawnerDelay = 5.5f;
	[SerializeField]
	private GameObject bullet;
	[HideInInspector]
	public bool shooting;

	// Use this for initialization
	void Start ()
	{
		character = GetComponent<EnemyCharacter> ();
		//character.SetShouldAttackPlayerWhenHitBarrier(true);
		//shootDistance = UnityEngine.Random.Range (minDistance, shootDistance);
		StartCoroutine (CheckFirstActiveZone());
	}

	private IEnumerator CheckFirstActiveZone()
	{
		while (transform.position.x > shootDistance) {
			yield return new WaitForSeconds (0.2f);
		}
		StartCoroutine(ProductWay());
		yield break;
	}
	private float spawnerTimer;

	private IEnumerator ProductWay()
	{
		while (transform.position.x > minDistance) {
			if (spawnerTimer <= 0)
				spawnerTimer = spawnerDelay;
			if (spawnerTimer >= spawnerDelay) 
			{
				character.Shoot();
			}
			spawnerTimer -= 0.2f;
			yield return new WaitForSeconds (0.2f);
		}
		yield break;
	}

	public void Shooting()
	{
		if (bullet != null)
			Instantiate (bullet, transform.position - new Vector3(1.6f, -0.6f, -0.5f), bullet.transform.rotation);
	}
}
