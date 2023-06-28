using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinDoubleHelper : MonoBehaviour, IPoolObject
{
	[SerializeField]
	private Text textComponent;
	private Transform transf;

	const float FADE_OUT_TIME = 0.5f;

	public bool canBeUsed
	{
		get {
			return !gameObject.activeSelf;
		}
	}

	public void Init( )
	{
		transf = transform;
		if( textComponent == null )
		{
			textComponent = gameObject.GetComponent<Text>();
		}
		textComponent.text = "x2";
		gameObject.SetActive( false );
	}

	public void Spawn( Vector3 pos )
	{
        transf.position = new Vector3(pos.x, pos.y, 10);
		gameObject.SetActive( true );
		StartCoroutine( AnimateIt() );
	}
	
	private IEnumerator AnimateIt()
	{
		Color color = textComponent.color + new Color( 0f, 0f, 0f, 1f );
		textComponent.color = color;
		int steps = 50;
		float yUp = 80f;
		for (int i = 0; i < steps; i++)
		{
			float colorDec = (float)((float)(steps - i)/(float)steps);
			yield return new WaitForSecondsRealtime ( FADE_OUT_TIME / (float)steps);
			gameObject.transform.position += new Vector3 (0f, yUp/(float)steps, 0f);
			color.a = colorDec;
			textComponent.color = color;
		}
		gameObject.SetActive( false );
		yield break;
	}
	
}
