using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoc : MonoBehaviour {
	
	[SerializeField]
	private List<UISettingsPanel.FlagPos> textSprites = new List<UISettingsPanel.FlagPos>();

	void OnEnable(){
		ChangeFBInnerText ();
	}


	private void ChangeFBInnerText()
	{
		string currentLangId = PlayerPrefs.GetString ("CurrentLanguage");
		int currentId = 0;
		for (int i = 0; i < textSprites.Count; i++) {
			if (textSprites [i].Id == currentLangId) {
				currentId = i;
				break;
			}
		}
		GetComponent<SpriteRenderer>().sprite = textSprites [currentId].flag;
	}

}
