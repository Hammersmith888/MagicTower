using UnityEngine;
using System.Collections;

public class ResolutionChangeMonitor : MonoSingleton<ResolutionChangeMonitor> {

	private int currentWidth;
	private int currentHeight;

	override protected void Awake( )
	{
		if( isOtherInstanceExists )
		{
			Destroy( this.gameObject );
			return;
		}
#if UNITY_EDITOR
		currentWidth = Helpers.getMainCamera.pixelWidth;
		currentHeight = Helpers.getMainCamera.pixelHeight;
#else
		currentWidth = Screen.width;
		currentHeight = Screen.height;
#endif
	}

	// Update is called once per frame
	void LateUpdate ()
	{
#if UNITY_EDITOR
		if(Helpers.getMainCamera != null && ( currentWidth != Helpers.getMainCamera.pixelWidth || currentHeight != Helpers.getMainCamera.pixelHeight ) )
#else
		if( currentWidth != Screen.width || currentHeight != Screen.height )
#endif
		{
#if UNITY_EDITOR
			currentWidth = Helpers.getMainCamera.pixelWidth;
			currentHeight = Helpers.getMainCamera.pixelHeight;
#else
			currentWidth = Screen.width;
			currentHeight = Screen.height;
#endif
			StopAllCoroutines();
			StartCoroutine( WaitForCanvasUpdateAndLaunchEvenent() );
		}
	}

	//Skip one frame before event sending so all canvas have time to make redraw
	private IEnumerator WaitForCanvasUpdateAndLaunchEvenent( )
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		Core.GlobalGameEvents.Instance.LaunchEvent( Core.EGlobalGameEvent.RESOLUTION_CHANGE );
	}
}
