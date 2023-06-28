using System.Collections;
using System.Reflection;
using UnityEngine;

public class DisableAllLogs : MonoBehaviour
{
    //bad thing but ill put it on top of script execution order
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Debug.unityLogger.logEnabled = false;
        StartCoroutine(CleanConsole());
        Debug.ClearDeveloperConsole();
        if(Logger.m_Instance)
            Logger.m_Instance.Clear();
    }


    IEnumerator CleanConsole()
    {
        while (true)
        {
           yield return new WaitForSeconds(120);
           yield return null;
           Debug.ClearDeveloperConsole();
           if(Logger.m_Instance)
                Logger.m_Instance.Clear();
        }
    }
}


     
