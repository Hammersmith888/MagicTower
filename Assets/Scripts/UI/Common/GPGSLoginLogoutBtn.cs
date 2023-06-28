using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSLoginLogoutBtn : MonoBehaviour {

	// Use this for initialization
	void Awake( )
	{
#if UNITY_ANDROID
		gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener( ToggleLoginState );
#else
		gameObject.SetActive( false );
#endif
	}

	private void ToggleLoginState( )
	{
		Native.PlayServices.ToggleAuthenticationState();
	}
}
