using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorSetAurasOnEnemy : MonoBehaviour {
	[SerializeField]
	private DragHandler dragScript;
	[SerializeField]
	private List<GameObject> auraButtons = new List<GameObject> ();
	private Button[] buttons;
	//[HideInInspector]
	public int lastPickedAuraId = -1;

	void Start()
	{
		buttons = GetComponentsInChildren<Button> ();
		OnAuraButtonClick (lastPickedAuraId);
	}

	public void OnAuraButtonClick(int id)
	{
		if (auraButtons.Count <= id) {
			return;
		}
		if (lastPickedAuraId == id) {
			id = -1;
		}
		lastPickedAuraId = id;
		if (buttons != null && buttons.Length == auraButtons.Count){
			for (int i = 0; i < buttons.Length; i++) {
				buttons [i].transform.GetChild (0).GetChild (0).gameObject.SetActive (i == id);
			}
		}
		dragScript.giveAuraId = id;
	}


}
