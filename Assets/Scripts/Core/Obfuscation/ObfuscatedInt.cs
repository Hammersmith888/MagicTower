
public class ObfuscatedInt : ObfuscatedType<int>
{
    public ObfuscatedInt() : base() { }

    public ObfuscatedInt(int val) : base()
    {
        Encrypt(val);
    }

    override protected int ParseValueFromString(string strValue)
    {
        int result = 0;
        int.TryParse(strValue, out result);
        //UnityEngine.Debug.LogFormat( "Decrypt {0} {1}", strValue, result );
        return result;
    }

    public static implicit operator ObfuscatedInt(int val)
    {
        return new ObfuscatedInt(val);
    }
}
