using UnityEngine;

public class EnableObjectInLevelEditorMode : MonoBehaviour {

	private void Awake( )
	{
#if LEVEL_EDITOR
		gameObject.SetActive( true );
#else
		gameObject.SetActive( false );
		Destroy( this );
#endif
	}
}
