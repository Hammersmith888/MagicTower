using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonsAura : MonoBehaviour {
	private GameObject Aura;
	private EnemyCharacter character;
	private bool auraActive;
	[HideInInspector]
	public bool AuraActive{
		get {
			return auraActive;
		}
		set {
			auraActive = value;
			if (Aura != null && Aura.activeSelf != auraActive)
				ReSetAura ();
		}
	}

	private float auraTimeout = 5f, auraTimer;
	// Use this for initialization
	void Start () {
		Aura = transform.Find( "Aura3" ).gameObject;
		character = GetComponent<EnemyCharacter> ();
		Aura.SetActive (false);
		StartCoroutine (CheckAuraActive());
	}

	private IEnumerator CheckAuraActive()
	{
		while (!character.IsDead) {
			yield return new WaitForSeconds (0.2f);
			if (AuraActive){
				auraTimer -= 0.2f;
				if (auraTimer <= 0f)
					AuraActive = false;
			}
		}
		Aura.SetActive (false);
		yield break;
	}

	private void ReSetAura()
	{
		Aura.SetActive (AuraActive);
		if (AuraActive) {
			character.attackspeed_aura_modifier = 0.3f;
			character.enemyMover.movespeed_aura_modifier = 0.3f;
			auraTimer = auraTimeout;
		} else {
			character.attackspeed_aura_modifier = 0f;
			character.enemyMover.movespeed_aura_modifier = 0f;
		}

	}
}
