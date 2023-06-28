using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlaySoundOnDisable : MonoBehaviour {

	void OnEnable()
	{
		SoundController.PlayWindowsAcivitySFX ();
	}

	void OnDisable()
	{
		SoundController.PlayWindowsAcivitySFX ();
	}
}
