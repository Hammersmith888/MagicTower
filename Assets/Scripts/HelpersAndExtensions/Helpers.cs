using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
	private static Camera cachedMainCamera;
	public static Camera getMainCamera
	{
		get {
			if( cachedMainCamera == null )
			{
				cachedMainCamera = Camera.main;
			}
			return cachedMainCamera;
		}
	}

	public static Vector3 UIWorildPosToCameraWorldPos( Vector3 uiPos, RectTransform uiObjectCanvas, Camera camera = null )
	{
		Vector2 viewPortPos = uiPos - uiObjectCanvas.position;

		Vector2 sizeDelta = uiObjectCanvas.sizeDelta;
		sizeDelta.x *= uiObjectCanvas.localScale.x;
		sizeDelta.y *= uiObjectCanvas.localScale.y;

		viewPortPos += sizeDelta / 2f;
		viewPortPos.x /= sizeDelta.x;
		viewPortPos.y /= sizeDelta.y;

		if( camera == null )
		{
			return getMainCamera.ViewportToWorldPoint( viewPortPos );
		}
		else
		{
			return camera.ViewportToWorldPoint( viewPortPos );
		}
	}

}
