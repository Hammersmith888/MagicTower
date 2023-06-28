using UnityEditor;
using UnityEngine;

public class DeleteAllSaves : MonoBehaviour
{
    [MenuItem("Tools/Delete All Saves")]
    public static void DeleteAllPlayerPrefs()
    {
       PlayerPrefs.DeleteAll();
    }

}
