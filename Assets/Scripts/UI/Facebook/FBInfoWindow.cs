using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FBInfoWindow : MonoBehaviour
{
	[SerializeField]
	private List<UISettingsPanel.FlagPos> textSprites = new List<UISettingsPanel.FlagPos>();
	[SerializeField]
	private Image textSprite;

	void OnEnable( )
	{
		AnalyticsController.Instance.LogMyEvent("Press_LogInFB");
		ChangeFBInnerText();
	}


	private void ChangeFBInnerText( )
	{
		string currentLangId = PlayerPrefs.GetString( "CurrentLanguage" );
		int currentId = 0;
		for( int i = 0; i < textSprites.Count; i++ )
		{
			if( textSprites[ i ].Id == currentLangId )
			{
				currentId = i;
				break;
			}
		}
		textSprite.sprite = textSprites[ currentId ].flag;
	}
}
