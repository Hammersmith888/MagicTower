using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Tutorials
{
	/// <summary>
	/// Tutorial on map after first lvl was completed, player must click on 2 level icon
	/// </summary>
	public class Tutorial_4 : MonoBehaviour
	{
		public GameObject needLevel, needLevel2;
		public GameObject needLevelArrow;
		public Animator _anim;

		[SerializeField]
		private Camera mapCanvasCamera;
		[SerializeField]
		private RectTransform overlayUIParent;
		[SerializeField]
		private Canvas tutorialCanvas;
		[SerializeField]
		private RectTransform lvlParent;
		[SerializeField]
		private RectTransform tutorialHandsParent;

		private Transform LevelStartParent;
		private Transform LevelArrowStartParent;
		private RectTransform needLvlArrowRectTransf;
		private RectTransform levelRectTransf;
		private Vector3 levelStartAnchoredPos;
		private Vector3 levelArrowAnchorPos;
        private Button levelShadow;

#if UNITY_EDITOR
		//[SerializeField]
		//private bool calculateOffsetInEditor;
		[SerializeField]
		private bool startTutorialEditor;
		private void OnDrawGizmosSelected( )
		{
			//if( calculateOffsetInEditor )
			//{
			//	calculateOffsetInEditor = false;
			//	Vector3 pos = tutorialHandsParent.anchoredPosition;
			//	pos.x += cameraDefaultX - mapCanvasCamera.GetComponent<RectTransform>().anchoredPosition.x;
			//	tutorialHandsParent.anchoredPosition = pos;
			//}

			//if( startTutorialEditor )
			//{
			//	startTutorialEditor = false;
			//	this.CallActionAfterDelayWithCoroutine( 1.5f, ShowMessage );
			//	tutorialCanvas.enabled = true;
			//}
		}
#endif

		void Awake( )
		{
			tutorialCanvas.enabled = false;
			if (SaveManager.GameProgress.Current.tutorial[3] && SaveManager.GameProgress.Current.tutorialClickLvl3)
				gameObject.SetActive(false);
		}

		void Start( )
		{
			// Если туториал (часть 3) еще не пройден
			//progress.tutorial[3] = false; // Для тестов

			/*if (PlayerPrefs.GetInt ("Application_launch") != 0) {
				StartTutor ();
			}*/
			// StartTutor();


			
		}

		public void Start3Lvl()
		{
			Debug.Log($"SaveManager.GameProgress.Current.tutorial[3]: {SaveManager.GameProgress.Current.tutorial[3]}, !SaveManager.GameProgress.Current.tutorialClickLvl3: {!SaveManager.GameProgress.Current.tutorialClickLvl3}");
			if (SaveManager.GameProgress.Current.tutorial[3] && !SaveManager.GameProgress.Current.tutorialClickLvl3)
			{
				Debug.Log("-------------- StartTutor 4 _ 2");
				_anim.Play("lvl3", 0);
				gameObject.SetActive(true);

				levelRectTransf = needLevel2.GetComponent<RectTransform>();
				needLvlArrowRectTransf = needLevelArrow.GetComponent<RectTransform>();
				LevelStartParent = levelRectTransf.parent;
				LevelArrowStartParent = needLevelArrow.transform.parent;
				levelShadow = needLevel2.transform.FindChildWithName<Button>("Shadow");

				Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
				AnalyticsController.Instance.Tutorial(3, 0);
				this.CallActionAfterDelayWithCoroutine(0.2f, ShowMessage);
				tutorialCanvas.enabled = true;
				//UIMap.Current.OpenLevelEffect(1);
			}
		}

		public void StartTutor( )
		{
			if(!SaveManager.GameProgress.Current.tutorial[3] && SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.DAILY_SPIN] )
			{
				Debug.Log("-------------- StartTutor 4 ");
				gameObject.SetActive(true);
                levelRectTransf = needLevel.GetComponent<RectTransform>();
                needLvlArrowRectTransf = needLevelArrow.GetComponent<RectTransform>();
                LevelStartParent = levelRectTransf.parent;
                LevelArrowStartParent = needLevelArrow.transform.parent;
                levelShadow = needLevel.transform.FindChildWithName<Button>("Shadow");

                Core.GlobalGameEvents.Instance.LaunchEvent( Core.EGlobalGameEvent.TUTORIAL_START );
				AnalyticsController.Instance.Tutorial( 3, 0 );
				this.CallActionAfterDelayWithCoroutine( 1.5f, ShowMessage );
				tutorialCanvas.enabled = true;
				UIMap.Current.OpenLevelEffect(1);
			}
			else
			{
				//gameObject.SetActive( false );
			}
		}

		private void ShowMessage( )
		{
            Debug.Log("-------------- ShowMessage");
			SaveManager.GameProgress.Current.tutorial[3] = true;
			SaveManager.GameProgress.Current.Save();
			Debug.Log($" !!!!!!!!!!!!!! SaveManager.GameProgress.Current.tutorial[3]: {SaveManager.GameProgress.Current.tutorial[3]}");
			UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher( false );
			//TODO: Проверить и убрать излишние вычисления корретной позиции, 
			//так как тутор перенесен под отдельный Canvas и скорей всего эти вычисления не нужны
			Vector3 overlayUIPos = overlayUIParent.position;
			Vector3 overlayUIScale = overlayUIParent.localScale;
			Vector3 overlayUISize = ( ( Vector3 ) overlayUIParent.sizeDelta ).MultiplyVector3( overlayUIScale );
			Vector3 centerOffset = new Vector3( 0.5f, 0.5f, 0f );

			Vector3 viewPortPos = ( mapCanvasCamera.WorldToViewportPoint( levelRectTransf.position ) - centerOffset );// Remap from 0 - 1 to -0.5 - 0.5f
			viewPortPos.z = 1f;
			//MultiplyVector3( offset, overlayUIScale );
			levelStartAnchoredPos = levelRectTransf.anchoredPosition;
			levelRectTransf.SetParent( lvlParent );
			levelRectTransf.localScale = new Vector3( 1f, 1f, 1f );
			//levelRectTransf.SetParent( overlayUIParent );
			levelRectTransf.position = overlayUIPos + overlayUISize.MultiplyVector3( viewPortPos );

			Vector3 pos = tutorialHandsParent.anchoredPosition;
			pos.x = levelRectTransf.anchoredPosition.x;
			tutorialHandsParent.anchoredPosition = pos;

			levelArrowAnchorPos = needLvlArrowRectTransf.anchoredPosition;
			viewPortPos = ( mapCanvasCamera.WorldToViewportPoint( needLvlArrowRectTransf.position ) - centerOffset );
			//MultiplyVector3( offset, overlayUIScale );
			needLvlArrowRectTransf.SetParent( lvlParent );
			needLvlArrowRectTransf.localScale = new Vector3( 1f, 1f, 1f );
			//needLvlArrowRectTransf.SetParent( overlayUIParent );
			needLvlArrowRectTransf.position = overlayUIPos + overlayUISize.MultiplyVector3( viewPortPos );

			GetComponentInChildren<Animator>().enabled = true;
			//GetComponent<Animator> ().Play ("map_tutor_animation");
			

			LevelShadowInteractable(false);
            UnityEngine.UI.Button lvlButton = needLevel.GetComponentInChildren<UnityEngine.UI.Button>();
            if ( lvlButton != null )
			{
				lvlButton.onClick.AddListener( OnLvlClick );
			}
		}

		private void OnLvlClick( )
		{
			UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher( true );
			needLevel.GetComponentInChildren<UnityEngine.UI.Button>().onClick.RemoveListener( OnLvlClick );
			AnalyticsController.Instance.Tutorial( 3, 1 );
            LevelShadowInteractable(true);
        }

        private void LevelShadowInteractable(bool enable)
        {
            if (levelShadow == null)
            {
                return;
            }
            levelShadow.interactable = enable;
        }

		private void OnDestroy( )
		{
			UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher( true );
		}

		public void ContinueGame( )
		{
			levelRectTransf.SetParent( LevelStartParent );
			levelRectTransf.anchoredPosition = levelStartAnchoredPos;
			needLevelArrow.transform.SetParent( LevelArrowStartParent );
			needLvlArrowRectTransf.anchoredPosition = levelArrowAnchorPos;
			Destroy( gameObject );
		}
	}
}