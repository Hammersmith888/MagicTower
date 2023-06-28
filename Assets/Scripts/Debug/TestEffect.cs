using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffect : MonoBehaviour {

	[SerializeField]
	private float xRandomizeRange;
	[SerializeField]
	private float yRandomizeRange;
	[SerializeField]
	private float lifeTime;

	private void Awake( )
	{
		Vector3 position = transform.position;
		position.x += Random.Range( -xRandomizeRange, xRandomizeRange );
		position.y += Random.Range( -yRandomizeRange, yRandomizeRange );
		transform.position = position;

		Destroy( gameObject, lifeTime );
	}
}
