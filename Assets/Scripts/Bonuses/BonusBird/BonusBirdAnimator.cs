using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBirdAnimator : MonoBehaviour {
	[SerializeField]
	private BonusBirdCollider disableObj;
	// Use this for initialization

	public void Death(){
		disableObj.bonusBird.Restart ();
		disableObj.gameObject.SetActive (false);
	}

	public void OnStart()
	{
		GetComponent<Animator> ().SetTrigger (AnimationPropertiesCach.instance.walkAnim);
	}
}
