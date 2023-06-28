using UnityEngine;
#if !UNITY_WSA
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileSerialization : MonoBehaviour
{
    public static string LevelsPath()
    {
#if LEVEL_EDITOR && UNITY_ANDROID && !UNITY_EDITOR
        string _path = Path.Combine(Application.persistentDataPath + "/Levels/");
#else
        string _path = "Levels/";
#endif
        return _path;
    }

    public static void Save(object _obj, string _fileName, bool share = false)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(LevelsPath() + "/" + _fileName + ".dat"));
        bf.Serialize(file, _obj);
        file.Close();

        if (share)
        {
            new NativeShare().AddFile(Path.Combine(LevelsPath() + "/" + _fileName + ".dat")).Share();
        }
    }

    public static object Load(string _fileName)
    {
        if (!CheckFileExists(Path.Combine(LevelsPath() + _fileName + ".dat")))
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        //#if UNITY_EDITOR_WIN
        FileStream file = File.Open(Path.Combine(LevelsPath() + _fileName + ".dat"), FileMode.Open);
        object loadObject = bf.Deserialize(file) as object;
        file.Close();
        return loadObject;
        //#endif
    }


    public static bool CheckFileExists(string _fileName)
    {
        if (File.Exists(_fileName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
#else
/// <summary>
///WARNING: This class is WSA platform stub!
/// </summary>
public class FileSerialization : MonoBehaviour
{

	public static string LevelsPath( )
	{
		string _path = "Levels/";

		return _path;
	}

	public static void Save( object _obj, string _fileName )
	{
	}

	public static object Load( string _fileName )
	{
		return null;
	}


	public static bool CheckFileExists( string _fileName )
	{
		return false;
	}
}
#endif