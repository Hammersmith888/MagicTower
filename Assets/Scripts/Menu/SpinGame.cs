using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGame : MonoBehaviour
{
	[System.Serializable]
	private class SpinPlace
	{
		public int placeId;
		public int chance;
	}

	[SerializeField]
	private int OnePushCost;
	[SerializeField]
	private int placesNumber;
	[SerializeField]
	private Transform SpinWheel;
	[SerializeField]
	private List<SpinPlace> Variants = new List<SpinPlace> ();
	private int totalChances;
	private float stepAngle;
	// Use this for initialization
	void Start( )
	{
		if( OnePushCost == 0 )
			OnePushCost = 500;
		for( int i = 0; i < Variants.Count; i++ )
		{
			totalChances += Variants[ i ].chance;
		}
		stepAngle = 360f / ( float ) placesNumber;
	}

	public void PushSpin( )
	{
		bool canPush = false;
		if( !PlayerPrefs.HasKey( "TodaySpinPushed" ) || PlayerPrefs.GetInt( "TodaySpinPushed" ) != 1 )
		{
			PlayerPrefs.SetInt( "TodaySpinPushed", 1 );
			canPush = true;
		}
		else if( CoinsManager.Instance.BuySomething( OnePushCost ) )
		{
			SoundController.Instanse.PlayBuyCoinsSFX();
			canPush = true;
		}
		else
		{
		}
		if( canPush )
		{
			StartCoroutine( RotateSpin() );
		}
	}

	private IEnumerator RotateSpin( )
	{
		int seenChances = totalChances;
		int point = UnityEngine.Random.Range( 0, totalChances + 1 );
		int PlaceId = 0;
		for( int i = 0; i < Variants.Count; i++ )
		{
			if( point < Variants[ i ].chance )
			{
				PlaceId = i;
				break;
			}
			else
			{
				seenChances -= Variants[ i ].chance;
			}
		}
		float rotateAngle = 360f + stepAngle * ( float ) PlaceId;
		if( PlaceId == 0 )
			rotateAngle += 360f;
		float timer = 2.2f;
		//for (int i = 0; i < steps; i++) {
		SpinWheel.Rotate( Vector3.Lerp( Vector3.zero, new Vector3( 0f, 0f, rotateAngle ), timer ) );
		//}
		yield break;
	}
}
