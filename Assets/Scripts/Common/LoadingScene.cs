using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private static int nextId;
    private static string next;

    private static bool isID = false;

    public static void Load(int nextScene)
    {
        nextId = nextScene;
        isID = true;
        SceneManager.LoadScene(nextScene);
    }

    public static void Load(string nextScene)
    {
        next = nextScene;
        isID = false;
        SceneManager.LoadScene(nextScene);
    }


}
