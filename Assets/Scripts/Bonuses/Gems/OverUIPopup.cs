using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OverUIPopup : MonoBehaviour {
	[SerializeField]
	public GameObject backgroundObj, placeObject, extractBtn, replaceBtn;

	public bool hideOnMouseUp, hideOnAnyClick, lockBackground;
	private bool noTouches, activePhase;
	private Vector2 lastMousePosition;

	public bool isClose = true;

	void Update( )
	{
//		if (!activePhase)
//			return;
		// Taч
		int i;
		noTouches = true;
		Touch[ ] touches = Input.touches;
		for( i = 0; i < Input.touchCount; i++ )
		{
			noTouches = false;
			UpdateTouch( touches[ i ].fingerId, touches[ i ].phase, touches[ i ].position );
		}
		#if UNITY_EDITOR || UNITY_STANDALONE
		// Мышь
			Vector2 mousePosition = Input.mousePosition;
			if( Input.GetMouseButtonUp( 0 ) )
			{
				UpdateTouch( i, TouchPhase.Ended, mousePosition );
			}
			else if( Input.GetMouseButton( 0 ) )
			{
				noTouches = false;
				UpdateTouch( i, Input.GetMouseButtonDown( 0 ) ? TouchPhase.Began : ( mousePosition.Equals( lastMousePosition ) ? TouchPhase.Stationary : TouchPhase.Moved ), mousePosition );
			}
			lastMousePosition = mousePosition;
		#endif
	}

	void UpdateTouch( int num, TouchPhase phase, Vector2 position )
	{
		if( phase == TouchPhase.Began)
		{
		}

		if( (phase == TouchPhase.Stationary || phase == TouchPhase.Moved))
		{
		}

		if( phase == TouchPhase.Ended || noTouches)
		{
			if (hideOnAnyClick || (hideOnMouseUp && activePhase))
				CloseIt ();
		}
	}

	public void OpenIt(Vector3 newPosition)
	{
		activePhase = true;
		if (placeObject != null) {
			placeObject.transform.position = newPosition;
			placeObject.SetActive (true);
		}
		if (backgroundObj != null) {
			backgroundObj.SetActive (true);
			if (lockBackground)
				backgroundObj.GetComponent<UnityEngine.UI.Image> ().raycastTarget = true;
		}
		gameObject.SetActive (true);
		Debug.Log($"OpenIt: ---------------");
	}

	public void CloseIt()
	{
		if (!isClose)
			return;
		activePhase = false;
		gameObject.SetActive (false);
		transform.localScale = Vector3.one;
	}
}
