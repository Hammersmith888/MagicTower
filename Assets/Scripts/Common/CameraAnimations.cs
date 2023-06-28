using System.Collections;
using System.Collections.Generic;
using ToolShed.Android.OS;
using UnityEngine;

public class CameraAnimations : MonoBehaviour {

	private ICameraOrthoSizeHolder cameraOrthoSizeHolder;

	void Start()
	{
		cameraOrthoSizeHolder = GetComponent<ICameraOrthoSizeHolder>();
	}

	public void CameraGeater(){
		StopCoroutine (AnimateGeater());
		StartCoroutine (AnimateGeater());
	}

	private IEnumerator AnimateGeater()
	{
		//print ("geater");
		//if (CameraObj != null) {
		cameraOrthoSizeHolder.SetCameraOrthoSizeScale( 0.97f);
		yield return new WaitForSeconds (0.05f);
		cameraOrthoSizeHolder.SetCameraOrthoSizeScale( 1f );
		yield return new WaitForSeconds (0.05f);
		cameraOrthoSizeHolder.SetCameraOrthoSizeScale( 0.97f );
		yield return new WaitForSeconds (0.05f);
		cameraOrthoSizeHolder.SetCameraOrthoSizeScale( 1f );
		yield return new WaitForSeconds (0.05f);
		//}
		//yield return new WaitForSeconds (0.201f);
		yield break;
	}

	public void VibrateIt()
	{
#if !UNITY_STANDALONE_WIN && !UNITY_EDITOR
		//if (UISettingsPanel.vibroIsOn)
		//	Handheld.Vibrate ();
        if (UISettingsPanel.vibroIsOn)
         Vibrator.Vibrate(100, 64);
#endif
       // Vibrator.Vibrate(200, 128);
    }
}
