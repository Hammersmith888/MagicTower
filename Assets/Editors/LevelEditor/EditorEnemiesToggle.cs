using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorEnemiesToggle : MonoBehaviour {

	[SerializeField]
	private List<GameObject> panels = new List<GameObject> ();

	private Button[] toggles;
	// Use this for initialization
	void Start () {
		toggles = GetComponentsInChildren<Button> ();
		SwitchToEnemies (0);
	}
	
	public void SwitchToEnemies(int _id)
	{
		if (panels != null && toggles != null && toggles.Length == panels.Count && !toggles [_id].transform.GetChild(0).GetChild(0).gameObject.activeSelf) {
			for (int i = 0; i < toggles.Length; i++) {
				panels [i].SetActive (i == _id);
				toggles [i].transform.GetChild(0).GetChild(0).gameObject.SetActive(i == _id);
			}
		}
	}
}
