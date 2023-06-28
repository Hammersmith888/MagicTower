using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBomb : MonoBehaviour {

	[SerializeField]
	private float enrageTimer = 3f;
	[SerializeField]
	private EnemyCharacter character;
	[SerializeField]
	private GameObject Explosion;

	private float timeSinceVisible = 0.0f;
	private bool isFattyBomb = false;
	private float startTime;
	private Vector2 startPosition;
	private Vector3 defaultScale;

	// Use this for initialization
	void Start () {
		if (character == null)
		character = GetComponent<EnemyCharacter> ();
	}

	public void InitAsFattyBomb()
    {
		isFattyBomb = true;
		startTime = Time.time;
		startPosition = transform.position;
		defaultScale = transform.localScale;

		GetComponent<Collider2D>().enabled = false;
		GetComponent<EnemyCharacter>().disableDrop = true;
	}

    private void Update()
    {
		if (isFattyBomb)
		{
			float animProgress = (Time.time - startTime) / 0.8f;
			if (animProgress >= 1.0f)
            {
				character.SetPosition(startPosition - new Vector2(2.5f, 1.8f));
				transform.localScale = defaultScale;
				character.SetMovementType(EnemyMovementType.walk);
				GetComponent<Collider2D>().enabled = true;
				isFattyBomb = false;
			}
			else
            {
				character.SetPosition(Vector3.Lerp(startPosition, startPosition - new Vector2(2.5f, 1.8f), animProgress));
				transform.localScale = Vector3.Lerp(0.1f * Vector3.one, defaultScale, animProgress);
				character.SetMovementType(EnemyMovementType.specMove);
			}
		}

		if (transform.position.x < character.invunarableDistance)
			timeSinceVisible += Time.deltaTime;

		if (timeSinceVisible > enrageTimer)
			character.SetMovementType(EnemyMovementType.specMove);
	}

	public void Explode()
	{
		GameObject afterEffect = Instantiate (Explosion, transform.position - new Vector3(0f, -1.5f, 1f), Quaternion.identity) as GameObject;
		Destroy (afterEffect, 0.7f);
		//Explosion.gameObject.SetActive (true);
		//Explosion.GetComponentInChildren<ParticleSystem> ().Play ();
		Invoke("DeathAndDestroy", 0.209f);

	}

	private void DeathAndDestroy()
	{
		character.Death();
		EnemiesGenerator.Instance.RemoveEnemy(character.GetInstanceID());
		Destroy(gameObject);
	}
}
