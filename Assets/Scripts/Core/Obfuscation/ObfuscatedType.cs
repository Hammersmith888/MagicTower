using System.Text;

public class ObfuscatedType<T>
{
    private string obfuscatedValue;

    private int charOffset;

    public T getValue
    {
        get
        {
            return Decrypt();
        }
    }

    public T setValue
    {
        set
        {
            Encrypt(value);
        }
    }

    public ObfuscatedType()
    {
        var random = new System.Random();
        charOffset = random.Next(-8, 8);
        //UnityEngine.Random.Range(-8, 8);//Юнити рандом вызывает ошибки в редакторе, так как его нельзя вызывать в момент сериализации
    }

    virtual protected T ParseValueFromString(string strValue)
    {
        return default(T);
    }

    protected void Encrypt(T value)
    {
        obfuscatedValue = value.ToString();
        StringBuilder stringBuilder = new StringBuilder(obfuscatedValue.Length);
        int _charOffset = charOffset;
        for (int i = 0; i < obfuscatedValue.Length; i++)
        {
            stringBuilder.Append((char)(obfuscatedValue[i] + _charOffset));
            _charOffset *= -1;
        }
        obfuscatedValue = stringBuilder.ToString();
        //UnityEngine.Debug.LogFormat( "{0} {1} {2} {3}", charOffset, value, obfuscatedValue, Decrypt() );
    }

    protected T Decrypt()
    {
        StringBuilder stringBuilder = new StringBuilder(obfuscatedValue.Length);
        int _charOffset = -charOffset;
        for (int i = 0; i < obfuscatedValue.Length; i++)
        {
            stringBuilder.Append((char)(obfuscatedValue[i] + _charOffset));
            _charOffset *= -1;
        }
        return ParseValueFromString(stringBuilder.ToString());
    }

    public override string ToString()
    {
        return Decrypt().ToString();
    }

    public static implicit operator T(ObfuscatedType<T> b)
    {
        return b.Decrypt();
    }

}
