using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnDisable : MonoBehaviour {

	private void OnDisable( )
	{
		Debug.LogFormat( "OnDisable {0}", gameObject.name );
	}
}
