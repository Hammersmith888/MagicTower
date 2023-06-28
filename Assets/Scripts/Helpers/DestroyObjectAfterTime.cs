using System.Collections;
using UnityEngine;

public class DestroyObjectAfterTime : MonoBehaviour {

	[SerializeField]
	private float dealy;

	private void Awake( )
	{
		StartCoroutine( WaitAndDestroy() );
	}

	private IEnumerator WaitAndDestroy( )
	{
		yield return new WaitForSeconds( dealy );
		Destroy( gameObject );
	}
}
