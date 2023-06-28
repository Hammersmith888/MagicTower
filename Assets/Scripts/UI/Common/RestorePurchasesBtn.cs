using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePurchasesBtn : MonoBehaviour {

	// Use this for initialization
	void Awake ()
	{
#if UNITY_IOS
		gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Purchaser.Instance.RestorePurchases);
#else
		gameObject.SetActive( false );
#endif
	}

}
