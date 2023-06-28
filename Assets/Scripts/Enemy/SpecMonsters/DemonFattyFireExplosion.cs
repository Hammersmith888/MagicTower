using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DemonFattyFireExplosion : ExplosionBase
{
	[HideInInspector]
	public int damage; // Основной урон от заклинания

	void Start()
	{
		GetComponentInChildren<ParticleSystem> ().Play ();
		StartCoroutine( DisableAfterDelay() );
	}

	private IEnumerator DisableAfterDelay( )
	{
		yield return new WaitForSeconds( 0.2f );
		LevelSettings.Current.playerController.CurrentHealth -= damage;
		GetComponent<Collider2D>().enabled = false;
		enabled = false;

	}
}
