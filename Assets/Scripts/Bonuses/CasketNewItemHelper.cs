using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasketNewItemHelper : MonoBehaviour {

	// Use this for initialization
	public void SpawnEnded()
	{
		transform.parent.GetComponent<CasketWithNewItem> ().SetItSpawned ();
	}
}
