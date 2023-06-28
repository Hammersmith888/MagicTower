using Facebook.Unity.Mobile.IOS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger1 : MonoBehaviour
{
    public static Logger1 Instance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(gameObject);
         Application.logMessageReceived += HandleLog;
    }
    private void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    [System.Obsolete]
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        var loggingForm = new WWWForm();

        //Add log message to WWWForm
        loggingForm.AddField("LEVEL", mainscript.CurrentLvl);
        loggingForm.AddField("Message", logString);
        loggingForm.AddField("Stack_Trace", stackTrace);

        //Add any User, Game, or Device MetaData that would be useful to finding issues later
        loggingForm.AddField("Device_Model", SystemInfo.deviceModel);
        StartCoroutine(SendData(loggingForm));
    }

    [System.Obsolete]
    public IEnumerator SendData(WWWForm form)
    {
        //Send WWW Form to Loggly, replace TOKEN with your unique ID from Loggly
        WWW sendLog = new WWW("https://logs-01.loggly.com/inputs/f9bf3c27-d989-46bd-9300-bde4aadbb190/tag/Unity3D", form);
        yield return sendLog;
    }
}
