using System.Collections;
using UnityEngine;

public class EnemyGoldText : MonoBehaviour, IPoolObject
{
	[SerializeField]
	private UnityEngine.UI.Text textComponent;

	private Transform transf;

	const float DISABLE_DELAY = 1f;

	public bool canBeUsed
	{
		get {
			return	!gameObject.activeSelf;
		}
	}

	public void Init( )
	{
		if( textComponent == null )
		{
			textComponent = GetComponent<UnityEngine.UI.Text>();
		}
		transf = transform;
		gameObject.SetActive( false );
	}

	public void Spawn( Vector3 pos, string text )
	{
		transf.position = pos;
		transf.SetAsFirstSibling();
		textComponent.text = text;
		gameObject.SetActive( true );
		StartCoroutine( DisableAfterDelay() );
	}

	private IEnumerator DisableAfterDelay( )
	{
		yield return new WaitForSeconds( DISABLE_DELAY );
		gameObject.SetActive( false );
	}
}
