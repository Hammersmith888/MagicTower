using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPauseAnimation: MonoBehaviour
{
	[SerializeField]
	private Text currentLvl;
	[SerializeField]
	private GameObject pauseBackground;
	[SerializeField]
	private UIPauseController pauseMain;

	private CanvasGroup cg;
	public void SwitchPauseBackground()
	{
		pauseBackground.SetActive( pauseBackground.activeSelf ? false : true );

		if( !pauseBackground.activeSelf && pauseMain != null )
		{
			pauseMain.pauseCalled = false;
			Time.timeScale = LevelSettings.Current.usedGameSpeed;
			pauseMain.currentState = UIPauseController.StateOfPause.PLAING;
			SoundController.Instanse.ResumeGamePlaySFX();
			Core.BattleEventsMono.BattleEvents.LaunchEvent( Core.EBattleEvent.PAUSE, false );
		}
	}

	void Start()
	{
		//устанавливаем номер текущего уровня
		string currentLvltext = currentLvl.transform.Find( "StageText" ).GetComponent<Text>().text.ToString() + " - " + (LevelSettings.Current.currentLevel + 1); // можна добавить STAGE или что то
		ReSetLevelText();
	}

	public void ReSetLevelText()
	{
		currentLvl.text = currentLvl.GetComponent<LocalTextLoc>().CurrentText.Replace( "#", (LevelSettings.Current.currentLevel + 1).ToString() );
	}
}
