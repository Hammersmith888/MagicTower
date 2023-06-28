using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossPromoWindowController : MonoBehaviour
{
	[System.Serializable]
	private class CrossPromoData
	{
		public string url;
		public Sprite image;
	}

	#region VARIABLES
	[SerializeField]
	private GameObject		mainWindowObject;
	[SerializeField]
	private Image	        crossPromoImageComponent;
	[SerializeField]
	private BoxCollider2D	imageCollider;
	[SerializeField]
	private Vector3			closeBtnPosOffset;
	[SerializeField]
	private Transform		closeBtnTransf;
	[SerializeField]
	private Transform		downloadBtnTransf;
	[SerializeField]
	private string			crosspromoConfigProjectName;
	[SerializeField]
	[Tooltip( "Can be empty" )]
	private CrossPromoData	defaultCrossPromoData;
	[SerializeField]
	private float			spritePixelsPerUnit = 100f;
	[SerializeField]
	private Camera			guiCamera;
	[SerializeField][Tooltip("Maximum size")]
	private float			maxScreenSizePercent;

	[Header( "Animation" )]
	[SerializeField]
	private float				animationTime;
	[SerializeField]
	private SpriteRenderer		backgroundDarkness;
	[SerializeField]
	private Gradient			backgroundDarknessAnimationGradient;
	[SerializeField]
	private AnimationCurve		mainWindowScaleCurve;
	private bool				inLoadingState;
	private bool				showWhenLoaded;
	//private Animations.Tweener tweener;
	private bool				isClosing;

	const string STORAGE_URL_FORMAT = "https://firebasestorage.googleapis.com/v0/b/lamphead-de0fe.appspot.com/o/{0}?alt=media";

	const string CONFIG_FILE_PATH_FORMAT = "{0}%2FConfig.txt";
	const string PROJECT_CONFIG_FILE_FORMAT = "{0}.txt";
	const string IMAGE_FILE_PATH_FORMAT = "{0}%2F{1}";
	const string DEFAULT_PROJECT_NAME = "Default";
	const string IMAGE_PATH_NODE = "promoImage";
	const string PROMO_INDEX_PREFS = "promoIndex";
#if UNITY_ANDROID || UNITY_EDITOR_WIN
	const string TARGET_URL_NODE = "Android_Url";
#elif UNITY_IOS || UNITY_EDITOR_OSX
	const string TARGET_URL_NODE = "IOS_Url";
#elif UNITY_WSA
	const string TARGET_URL_NODE = "WSA_Url";
#else
	const string TARGET_URL_NODE = "undefined";
#endif

	private List<CrossPromoData> crossPromoDataList;
	private CrossPromoData		currentCrossPromoData;
	private int startedCount;
	private int index;
	#endregion

	public void Init( )
	{
		mainWindowObject.SetActive( false );
		//backgroundDarkness.gameObject.SetActive( false );
		if( imageCollider == null )
		{
			imageCollider = crossPromoImageComponent.GetComponent<BoxCollider2D>();
		}
		index = PlayerPrefs.GetInt( PROMO_INDEX_PREFS, 0 );
		currentCrossPromoData = defaultCrossPromoData;
		LoadCrossPromoData();
		//tweener = new Animations.Tweener( animationTime, UpdateAnimation );
	}

	public void OpenWindow( bool showWhenLoaded = true )
	{
		//temp disable
		bool disableIt = true;
		if (disableIt)
			return;
		/*if( Logic.is	GameStarted )
		{
			return;
		}*/
		isClosing = false;
		this.showWhenLoaded = showWhenLoaded;
		if( currentCrossPromoData.image != null )
		{
			SetupPromoWindow();
			mainWindowObject.SetActive( true );
			//backgroundDarkness.gameObject.SetActive( true );
			//tweener.TweenValue( true );
			//tweener.Update(Time.deltaTime);
			//UpdatableHolder.instance.AddToUpdate( tweener );
		}
	}

	public void CloseWindow( )
	{
		mainWindowObject.SetActive( false );
		if( isClosing )
		{
			return;
		}
		isClosing = true;

		/*tweener.TweenValue( false );
		tweener.AddOnCompleteListener( ( ) =>
		{
			mainWindowObject.SetActive( false );
			backgroundDarkness.gameObject.SetActive( false );
		} );
		UpdatableHolder.instance.AddToUpdate( tweener );*/
	}

	public void OnOpenUrl( )
	{
		if( isClosing )
		{
			return;
		}
		CloseWindow();
		if( !string.IsNullOrEmpty( currentCrossPromoData.url ) )
		{
			Application.OpenURL( currentCrossPromoData.url );
		}
	}

	private void SetupPromoWindow()
	{
		crossPromoImageComponent.sprite = currentCrossPromoData.image;
		/*Vector2 spriteSizeInWorldUnits = new Vector2( currentCrossPromoData.image.rect.width / spritePixelsPerUnit, currentCrossPromoData.image.rect.height / spritePixelsPerUnit );

		float screenHeight = guiCamera.orthographicSize * 2f * maxScreenSizePercent;
		float screenWidth = screenHeight * guiCamera.aspect;
		float imageTransfScale = 1f;

		float heightRatio = spriteSizeInWorldUnits.y / screenHeight;
		float widthRatio = spriteSizeInWorldUnits.x / screenWidth;

		if( heightRatio > 1f || widthRatio > 1f )
		{
			if( heightRatio > widthRatio )
			{
				imageTransfScale = screenHeight / spriteSizeInWorldUnits.y;
			}
			else
			{
				imageTransfScale = screenWidth / spriteSizeInWorldUnits.x;
			}
		}
		spriteSizeInWorldUnits *= imageTransfScale;
		crossPromoImageComponent.transform.localScale = new Vector3( imageTransfScale, imageTransfScale, imageTransfScale );
		//imageCollider.size = spriteSizeInWorldUnits;
		//closeBtnTransf.localPosition = new Vector3( spriteSizeInWorldUnits.x / 2f, spriteSizeInWorldUnits.y / 2f, -1f ) + closeBtnPosOffset;
		//downloadBtnTransf.localPosition = new Vector3( 0f, -spriteSizeInWorldUnits.y / 2f, -1f );*/
	}

	private void SwitchImage( )
	{
		if( crossPromoDataList != null && crossPromoDataList.Count > 0 )
		{
			currentCrossPromoData = crossPromoDataList[index];
			index++;
			if( crossPromoDataList.Count == index )
			{
				index = 0;
			}
			PlayerPrefs.SetInt( PROMO_INDEX_PREFS, index );
		}
	}

	#region Animation
	private void UpdateAnimation(float progress)
	{
		backgroundDarkness.color = backgroundDarknessAnimationGradient.Evaluate( progress );
		float scale = mainWindowScaleCurve.Evaluate( progress );
		mainWindowObject.transform.localScale = new Vector3(scale, scale, scale );
	}
	#endregion

	#region Data Loading
	private string FormatUrl(string filePath)
	{
		return filePath.Replace( "/", "%2F" ).Replace( " ", "%20" );
	}

	public void LoadCrossPromoData( bool showAfterLoaded = false )
	{
		if( !inLoadingState )
		{
			this.showWhenLoaded = showAfterLoaded;
			inLoadingState = true;
			crossPromoDataList = new List<CrossPromoData>();
			WWW www = new WWW( string.Format( STORAGE_URL_FORMAT, string.Format( PROJECT_CONFIG_FILE_FORMAT, string.IsNullOrEmpty( crosspromoConfigProjectName ) ? DEFAULT_PROJECT_NAME : crosspromoConfigProjectName ) ) );
			StartCoroutine( WaitForRequest( www, ProjectConfigFileLoaded ) );
		}
	}

	private void OnDownnloadComlete( )
	{
		startedCount--;
		if( startedCount <= 0 )
		{
			inLoadingState = false;
			SwitchImage();
			if( showWhenLoaded )
			{
				showWhenLoaded = false;
				OpenWindow(false);
			}
		}
	}

	private IEnumerator WaitForRequest(WWW www, System.Action<WWW> onLoaded)
	{
		yield return www;

		// check for errors
		if( www.error == null )
		{
//			Debug.Log( "WWW Ok!: " + www.text );
			onLoaded( www );
		}
		else
		{
//			Debug.Log( "WWW Error: " + www.error );
		}
	}

	private void ProjectConfigFileLoaded(WWW www)
	{
		Hashtable decoded = ( Hashtable )JSON.JsonDecode( www.text );
		inLoadingState = false;
		if( decoded == null )
		{
			Debug.LogError( "server returned null or malformed response ):" + www.text );
			return;
		}
		foreach( DictionaryEntry json in decoded )
		{
			ArrayList values = ( ArrayList )json.Value;
			startedCount = values.Count;
			foreach( var v in values )
			{
				inLoadingState = true;
				//Debug.Log( v.ToString()+ " " + string.Format( STORAGE_URL_FORMAT, string.Format( CONFIG_FILE_PATH_FORMAT, FormatUrl( v.ToString() ) ) ) );
				WWW crossPromoDataWWW = new WWW( string.Format( STORAGE_URL_FORMAT, string.Format( CONFIG_FILE_PATH_FORMAT, FormatUrl( v.ToString() ) ) ) );
				StartCoroutine( CrossPromoConfigFileLoaded( crossPromoDataWWW, v.ToString() ) );
			}
		}
		//Debug.Log("Can't find any node in config file for project with name "+projectName );
	}

	private IEnumerator CrossPromoConfigFileLoaded(WWW www, string crossPromoFolderPath)
	{
		yield return www;
		Hashtable decoded = ( Hashtable )JSON.JsonDecode( www.text );
		if( decoded == null )
		{
			Debug.LogError( "No Config.txt at " + crossPromoFolderPath );
		}
		else
		{
			foreach( DictionaryEntry json in decoded )
			{
				if( json.Key.ToString() == TARGET_URL_NODE )
				{
//					Debug.Log( json.Value.ToString() );
					CrossPromoData crossPromoData = new CrossPromoData();
					crossPromoData.url = json.Value.ToString();
					string promoImageFileName = GetPromoFileStoragePath( decoded );
					if( string.IsNullOrEmpty( promoImageFileName ) )
					{
//						Debug.LogError( "Promo image file not specified " + crossPromoFolderPath );
					}
					else
					{
						WWW imageWWW = new WWW( string.Format( STORAGE_URL_FORMAT,
													string.Format( IMAGE_FILE_PATH_FORMAT,
														FormatUrl( crossPromoFolderPath ), FormatUrl( promoImageFileName ) ) ) );
						yield return imageWWW;
						if( imageWWW.error == null )
						{
							crossPromoData.image = ExtrackSprite( imageWWW );
							if( crossPromoData.image == null )
							{
								Debug.LogError( "Null sprite for  cross promo at: " + crossPromoFolderPath );
							}
							else
							{
								crossPromoDataList.Add( crossPromoData );
							}
						}
						else
						{
							Debug.LogError( "WWW Error: " + imageWWW.error );
						}
					}
				}
			}
		}
		OnDownnloadComlete();
	}

	private string GetNodeValue(Hashtable values, string targetKey)
	{
		foreach( DictionaryEntry json in values )
		{
			if( json.Key.ToString() == targetKey )
			{
				return json.Value.ToString();
			}
		}
		return null;
	}

	private string GetPromoFileStoragePath(Hashtable values)
	{
		return GetNodeValue( values, IMAGE_PATH_NODE );
	}

	private Sprite ExtrackSprite(WWW www)
	{
		Texture2D t2D = www.texture;
		if( www.texture == null )
		{
			return null;
		}
		return Sprite.Create( t2D, new Rect( 0f, 0f, t2D.width, t2D.height ), new Vector2( 0.5f, 0.5f ), spritePixelsPerUnit );
	}
	#endregion
}
