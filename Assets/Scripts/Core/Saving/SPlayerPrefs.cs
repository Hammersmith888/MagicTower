using UnityEngine;
#if !UNITY_WSA
using System.Security.Cryptography;
#endif
using System.Text;
using System.Collections.Generic;

public class SPlayerPrefs
{
	private static Dictionary<string, int> intValuesCach;

	private static void AddToCach(string key, int val)
	{
		if( intValuesCach == null )
		{
			intValuesCach = new Dictionary<string, int>() { { key, val } };
		}
		else
		{
			if( intValuesCach.ContainsKey( key ) )
			{
				intValuesCach[key] = val;
			}
			else
			{
				intValuesCach.Add( key, val );
			}
		}
	}

	public static void SetString(string key, string value)
	{
#if !UNITY_WSA
		PlayerPrefs.SetString( md5( key ), encrypt( value ) );
#else
		PlayerPrefs.SetString( Encryption.Encrypt( key ), Encryption.Encrypt( value ) );
#endif
	}

	public static string GetString(string key, string defaultValue)
	{
		if( !HasKey( key ) )
			return defaultValue;
#if !UNITY_WSA
		try
		{
			string s = decrypt( PlayerPrefs.GetString( md5( key ) ) );
			return s;
		}
		catch
		{
			return defaultValue;
		}
#else
		return Encryption.Decrypt( PlayerPrefs.GetString( Encryption.Encrypt( key ) ) );
#endif
	}

	public static string GetString(string key)
	{
		return GetString( key, "" );
	}

	public static void SetInt(string key, int value, bool cachValue = true)
	{
		if( cachValue )
		{
			AddToCach( key, value );
		}
#if !UNITY_WSA
		PlayerPrefs.SetString( md5( key ), encrypt( value.ToString() ) );
#else
		PlayerPrefs.SetString( Encryption.Encrypt( key ), Encryption.Encrypt( value.ToString() ) );
#endif
	}

	public static int GetInt(string key, int defaultValue)
	{
		if( !HasKey( key ) )
		{
			//Debug.Log("!HasKey for "+ key + " using default: "+ defaultValue );
			return defaultValue;
		}
#if !UNITY_WSA
		try
		{
			string s = decrypt( PlayerPrefs.GetString( md5( key ) ) );
			int i = int.Parse( s );
			return i;
		}
		catch
		{
			return defaultValue;
		}
#else
		try
		{
			string s = Encryption.Decrypt( PlayerPrefs.GetString( Encryption.Encrypt( key ) ) );
			int i = int.Parse( s );
			return i;
		}
		catch
		{
			return defaultValue;
		}
#endif
	}

	public static int GetIntFromCach(string key, int defaultValue = 0)
	{
		if( intValuesCach != null )
		{
			int result = defaultValue;
			if( intValuesCach.TryGetValue( key, out result ) )
			{
				//Debug.Log("Using cached value for "+key+"  "+ result );
				return result;
			}
		}
		return GetInt( key, defaultValue );
	}

	public static int GetInt(string key)
	{
		return GetInt( key, 0 );
	}

	public static void SetFloat(string key, float value)
	{
#if !UNITY_WSA
		PlayerPrefs.SetString( md5( key ), encrypt( value.ToString() ) );
#else
		PlayerPrefs.SetFloat(key, value);
#endif
	}

	public static float GetFloat(string key, float defaultValue)
	{
#if !UNITY_WSA
		if( !HasKey( key ) )
			return defaultValue;
		try
		{
			string s = decrypt( PlayerPrefs.GetString( md5( key ) ) );
			float f = float.Parse( s, System.Globalization.CultureInfo.InvariantCulture );
			return f;
		}
		catch
		{
			return defaultValue;
		}
#else
		return GetFloat(key, defaultValue);
#endif
	}

	public static float GetFloat(string key)
	{
		return GetFloat( key, 0 );
	}

	public static bool HasKey(string key)
	{
#if !UNITY_WSA
		return PlayerPrefs.HasKey( md5( key ) );
#else
		return PlayerPrefs.HasKey(Encryption.Encrypt( key ) );
#endif
	}

	public static void DeleteAll( )
	{
		PlayerPrefs.DeleteAll();
	}

	public static void DeleteKey(string key)
	{
#if !UNITY_WSA
		PlayerPrefs.DeleteKey( md5( key ) );
#else
		PlayerPrefs.DeleteKey(key);
#endif
	}

	public static void Save( )
	{
		PlayerPrefs.Save();
	}

#if !UNITY_WSA
	/*
     * Обязательно смените этот секретный код и числа в массивах для использования в другом проекте
     */
	private static string secretKey = "hfxarbqpu";
	private static byte[ ] key = new byte[8] { 88, 9, 32, 7, 11, 28, 100, 110 };
	private static byte[ ] iv = new byte[8] { 44, 189, 8, 1, 83, 67, 144, 33 };

	private static string encrypt(string s)
	{
		byte[ ] inputbuffer = Encoding.Unicode.GetBytes( s );
		byte[ ] outputBuffer = DES.Create().CreateEncryptor( key, iv ).TransformFinalBlock( inputbuffer, 0, inputbuffer.Length );
		return System.Convert.ToBase64String( outputBuffer );
	}

	private static string decrypt(string s)
	{
		byte[ ] inputbuffer = System.Convert.FromBase64String( s );
		byte[ ] outputBuffer = DES.Create().CreateDecryptor( key, iv ).TransformFinalBlock( inputbuffer, 0, inputbuffer.Length );
		return Encoding.Unicode.GetString( outputBuffer );
	}

	private static string md5(string s)
	{
		byte[ ] hashBytes = new MD5CryptoServiceProvider().ComputeHash( new UTF8Encoding().GetBytes( s + secretKey + SystemInfo.deviceUniqueIdentifier ) );
		string hashString = "";
		for( int i = 0; i < hashBytes.Length; i++ )
		{
			hashString += System.Convert.ToString( hashBytes[i], 16 ).PadLeft( 2, '0' );
		}
		return hashString.PadLeft( 32, '0' );
	}
#endif
}