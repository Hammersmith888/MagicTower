
public class ObfuscatedFloat : ObfuscatedType<float>
{
	public ObfuscatedFloat( float val ) : base()
	{
		Encrypt( val );
	}

	override protected float ParseValueFromString( string strValue )
	{
		float result = 0;
		float.TryParse( strValue, out result );
		//UnityEngine.Debug.LogFormat( "Decrypt {0} {1}", strValue, result );
		return result;
	}


	public static implicit operator ObfuscatedFloat( float val )
	{
		return new ObfuscatedFloat( val );
	}
}
