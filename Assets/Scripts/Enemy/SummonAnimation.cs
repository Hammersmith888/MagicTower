
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAnimation : MonoBehaviour
{
	[SerializeField]
	private GameObject body;

	[SerializeField]
	private GameObject auraAnimation;

	[SerializeField]
	private GameObject summonBorder;

	[SerializeField]
	private bool useAlphaAnim = true;

	[SerializeField]
	private float delay;

	void Start( )
	{
		body.SetActive( false );
		if( auraAnimation != null )
			auraAnimation.SetActive( true );
		if( summonBorder != null && useAlphaAnim )
			LeanTween.alpha( summonBorder, 1f, 1.2f );
		StartCoroutine( ShowBodyAfterSummon( delay ) );
	}

	private IEnumerator ShowBodyAfterSummon( float delay )
	{
		yield return new WaitForSeconds( delay );
		if( summonBorder != null && useAlphaAnim )
		{
			LeanTween.alpha( summonBorder, 0f, 1f );
		}
		//yield return new WaitForSeconds(1);
		body.SetActive( true );
	}

}
