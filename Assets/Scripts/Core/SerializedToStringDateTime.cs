using System;

[Serializable]
public class SerializedToStringDateTime
{
	private bool        parseFirstTime = true;
	private DateTime    dateTime;
	public string       dateTimeAsStr;

	private static readonly System.Globalization.CultureInfo INVARIANT_CULTURE = System.Globalization.CultureInfo.InvariantCulture;

	private void ParseDateTimeIfNeeded( )
	{
		if( parseFirstTime )
		{
			parseFirstTime = false;
			if( !DateTime.TryParse( dateTimeAsStr, INVARIANT_CULTURE, System.Globalization.DateTimeStyles.None, out dateTime ) )
			{
				UnityEngine.Debug.LogError("Can't parse DateTime: "+ dateTimeAsStr );
			}
		}
	}

	public static implicit operator string( SerializedToStringDateTime serializedDateTime )
	{
		return serializedDateTime.dateTime.ToString( INVARIANT_CULTURE );
	}

	public static implicit operator DateTime( SerializedToStringDateTime serializedDateTime )
	{
		serializedDateTime.ParseDateTimeIfNeeded();
		return serializedDateTime.dateTime;
	}

	public static implicit operator SerializedToStringDateTime( DateTime serializedDateTime )
	{
		//UnityEngine.Debug.LogFormat("{0} {1}", serializedDateTime.ToString( INVARIANT_CULTURE ), serializedDateTime.ToString() );
		//string _dateTimeAsStr = serializedDateTime.ToString( INVARIANT_CULTURE );
		//DateTime result;
		//UnityEngine.Debug.LogFormat( DateTime.TryParse( _dateTimeAsStr, INVARIANT_CULTURE, System.Globalization.DateTimeStyles.None, out result ).ToString() );
		//UnityEngine.Debug.LogFormat( result == null ? "null": result.ToString() );
		return new SerializedToStringDateTime() { dateTime = serializedDateTime, dateTimeAsStr = serializedDateTime.ToString( INVARIANT_CULTURE ), parseFirstTime = false };
	}

	public static DateTime operator +( SerializedToStringDateTime serializedDateTime, TimeSpan timeSpan )
	{
		serializedDateTime.dateTime += timeSpan;
		serializedDateTime.dateTimeAsStr = serializedDateTime.dateTime.ToString( INVARIANT_CULTURE );
		return serializedDateTime.dateTime;
	}

	public override string ToString( )
	{
		ParseDateTimeIfNeeded();
		return dateTime.ToString( INVARIANT_CULTURE );
	}
}
