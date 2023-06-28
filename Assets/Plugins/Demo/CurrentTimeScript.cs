using UnityEngine;
using System;

public class CurrentTimeScript : MonoBehaviour
{
	//[HideInInspector]
	public DateTime unbiasedTimerEndTimestamp;
	public string memoryId = "unbiasedTimer";

	void Awake( )
	{
		// Read PlayerPrefs to restore scheduled timers
		// By default initiliaze both timers in 60 seconds from now
		if( PlayerPrefs.HasKey( memoryId ) )
		{
			unbiasedTimerEndTimestamp = this.ReadTimestamp( memoryId, UnbiasedTime.Instance.Now() );
		}
		else
		{
			unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now();
			this.WriteTimestamp( memoryId, unbiasedTimerEndTimestamp );
		}
	}

	public void SetBigTimer( double _timer )
	{
		unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds( _timer );
		this.WriteTimestamp( memoryId, unbiasedTimerEndTimestamp );
	}

	public DateTime SetBigTimerDT(double _timer)
	{
		unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds(_timer);
		this.WriteTimestamp(memoryId, unbiasedTimerEndTimestamp);
		return unbiasedTimerEndTimestamp;
	}

	void OnApplicationPause( bool paused )
	{
		if( paused )
		{
			this.WriteTimestamp( memoryId, unbiasedTimerEndTimestamp );
		}
		else
		{
			unbiasedTimerEndTimestamp = this.ReadTimestamp( memoryId, UnbiasedTime.Instance.Now().AddSeconds( 60 ) );
		}
	}

	void OnApplicationQuit( )
	{
		this.WriteTimestamp( memoryId, unbiasedTimerEndTimestamp );
	}

	//void Update( )
	//{
	//	// Calculate remaining time
	//	//TimeSpan unbiasedRemaining = unbiasedTimerEndTimestamp - UnbiasedTime.Instance.Now();

	//	//unbiasedTimerEndTimestamp = unbiasedTimerEndTimestamp.AddSeconds(60);
	//	//this.WriteTimestamp(memoryId, unbiasedTimerEndTimestamp);
	//	//unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds(60);
	//	//this.WriteTimestamp(memoryId, unbiasedTimerEndTimestamp);
	//}

	private DateTime ReadTimestamp( string key, DateTime defaultValue )
	{
		long tmp = Convert.ToInt64( PlayerPrefs.GetString( key, "0" ) );
		if( tmp == 0 )
		{
			return defaultValue;
		}
		return DateTime.FromBinary( tmp );
	}

	private void WriteTimestamp( string key, DateTime time )
	{
		PlayerPrefs.SetString( key, time.ToBinary().ToString() );
	}
}
