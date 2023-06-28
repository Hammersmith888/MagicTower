using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationCrashTest : MonoBehaviour
{
	public UIBlackPatch BlackScreen;
	public GameObject	facebookObject;
	public UnityEngine.UI.Button activateNextBtn;
	public UnityEngine.UI.Button activateAllBtn;
	public UnityEngine.UI.Button toMainMenuBtn;
	public UnityEngine.UI.Button toSplashSceneBtn;
	public UnityEngine.UI.Button activateFacebookBtn;
	public Transform parentTransf;

	// Use this for initialization
	void Awake () {
		activateNextBtn.onClick.AddListener( ActivateNext );
		toMainMenuBtn.onClick.AddListener( ToMainMenu );
		toSplashSceneBtn.onClick.AddListener( ToSpashSceneBtn );
		activateAllBtn.onClick.AddListener( ActivateAllBtn );
		activateFacebookBtn.onClick.AddListener( ActivateFacebook );
	}

	private void ToSpashSceneBtn( )
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene( "Splash" );
	}

	private void ToMainMenu( )
	{
		if( !PlayerPrefs.HasKey( "Application_launch" ) )
		{
			PlayerPrefs.SetInt( "Application_launch", 0 );
			UIDailyRewardController.ResetVideoLimits();
		}
		else
		{
			PlayerPrefs.SetInt( "Application_launch", PlayerPrefs.GetInt( "Application_launch" ) + 1 );
			if( PlayerPrefs.GetInt( "Application_launch" ) > 6 )
				PlayerPrefs.SetInt( "Application_launch", 1 );
		}
		BlackScreen.Appear( "Menu" );
	}

	private void ActivateAllBtn( )
	{
		int length = parentTransf.childCount;
		for( int i = 0; i < length; i++ )
		{
			Transform transform = parentTransf.GetChild( 0 );
			transform.SetParent( null );
			Debug.Log( "Activating " + transform.gameObject.name );
			transform.gameObject.SetActive( true );
		}
	}

	private void ActivateNext( )
	{
		if( parentTransf.childCount == 0 )
		{
			Logger.Log("All activated");
			return;
		}

		Transform transform = parentTransf.GetChild( 0 );
		transform.SetParent( null );
		Debug.Log( "Activating " + transform.gameObject.name );
		transform.gameObject.SetActive( true );
	}

	private void ActivateFacebook( )
	{
		facebookObject.SetActive( true );
	}
}
