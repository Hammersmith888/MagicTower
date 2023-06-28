using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestScript : MonoBehaviour
{
    public string node;
    public string id;
    public string UPDATE_DATA_REQUES_FORMAT = "https://magic-siege-57930146.firebaseio.com/users/{0}.json";
    public string CREATE_USER_DATA_NODE_FORMAT = "https://magic-siege-57930146.firebaseio.com/users/{0}/.json";
    public string data;
    public bool loadDataForNode;
    [Header("")]
    public string format;
    public string[] values;
    public bool testFormat;
    //#if UNITY_EDITOR
    [Header("")]
    public bool createUserDataRequest;
    public bool createOrUpdateUserDataNodeRequest;
    [Header("")]
    public bool getUserDataNodeData;
    public bool getUserData;

    [Space(20f)]
    public bool TestGems;


    //private void Awake( )
    //{
    //	this.CallActionAfterDelayWithCoroutine( 0.5f, ( ) =>
    //	{
    //		Debug.Log( "0.5 action " );
    //	} );

    //	this.CallActionAfterDelayWithCoroutine( 1f, ( ) =>
    //	{
    //		Debug.Log( "1 action_1" );
    //	} );

    //	this.CallActionAfterDelayWithCoroutine( 1f, ( ) =>
    //	{
    //		Debug.Log( "1 action_2" );
    //	} );
    //}

    private void DefaultGemSaves()
    {
        int totalGems = 20;
        Gem_Items gemItems = new Gem_Items(totalGems);

        if (PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems) == null)
        {
            int k = 0;
            int length = System.Enum.GetValues(typeof(GemType)).Length;
            for (int i = 0; i < totalGems; i++)
            {
                gemItems[i] = new GemItem();
                gemItems[i].gem.type = (GemType)k;
                k++;
                if (k >= length)
                {
                    k = 0;
                }
            }

            for (int i = 0; i < gemItems.Length; i++)
            {
                gemItems[i].gem.gemLevel = i;
                while (gemItems[i].gem.gemLevel > 9)
                {
                    gemItems[i].gem.gemLevel -= 10;
                }
                print(gemItems[i].count.ToString() + " / " + gemItems[i].gem.type.ToString() + " / " + gemItems[i].gem.gemLevel.ToString());
            }

            PPSerialization.Save(EPrefsKeys.Gems, gemItems);
        }
        for (int i = 0; i < gemItems.Length; i++)
        {
            print("<size=15>" + gemItems[i].count.ToString() + " / " + gemItems[i].gem.type.ToString() + " / " + gemItems[i].gem.gemLevel.ToString() + "</size>");
        }

    }

    public void OnDrawGizmosSelected()
    {
        if (TestGems)
        {
            TestGems = false;
            DefaultGemSaves();
        }
        if (testFormat)
        {
            testFormat = false;
            Debug.Log(string.Format(format, values));
        }
        if (createUserDataRequest)
        {
            createUserDataRequest = false;
            string dataToSend = "{\"" + node + "\":\"" + (loadDataForNode ? PlayerPrefs.GetString(node, "") : data) + "\"}";

            Debug.Log(dataToSend);

            UnityWebRequest www = UnityWebRequest.Put(string.Format(UPDATE_DATA_REQUES_FORMAT, id), dataToSend);
            StartCoroutine(WaitForRequest(www));
        }

        if (createOrUpdateUserDataNodeRequest)
        {
            createOrUpdateUserDataNodeRequest = false;
            string dataToSend = "{\"" + node + "\":\"" + (loadDataForNode ? PlayerPrefs.GetString(node, "") : data) + "\"}";


            //SaveManager.GameProgress progress = new SaveManager.GameProgress();
            //progress.bestScoreOnLevel = new int[ 10 ];
            //progress.finishCount = new int[ 10 ];
            //progress.tutorial = new bool[ 10 ];
            //progress.freeResurrectionUsedOnLevel = new int[ 10 ];
            //progress.tutorial[ 1 ] = true;

            //dataToSend = "{\"" + node + "\":"+JsonUtility.ToJson( progress ) +"}";


            Debug.Log(dataToSend);
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(dataToSend);

            UnityWebRequest www = new UnityWebRequest(string.Format(CREATE_USER_DATA_NODE_FORMAT, id), "PATCH", null, new UploadHandlerRaw(postData));
            StartCoroutine(WaitForRequest(www));
        }

        if (getUserDataNodeData)
        {
            getUserDataNodeData = false;
            Native.FirebaseManager.Instance.ReadUserDataByNode(id, node, OnDowloaded);
        }

        if (getUserData)
        {
            getUserData = false;
            //Native.FirebaseManager.Instance.ReadUserData( id, OnAllDataDownload );
        }
    }

    private void OnAllDataDownload(string data, bool isError)
    {
        Debug.Log("OnAllDataDownload: " + data);
        Debug.Log(JSON.JsonDecode(data).GetType());
        Hashtable storageData = JSON.JsonDecode(data) as Hashtable;
        DictionaryEntry dicEntry;
        foreach (var entry in storageData)
        {
            dicEntry = (DictionaryEntry)entry;
            Debug.Log(dicEntry.Key.ToString() + " - " + dicEntry.Value + "  " + JSON.JsonEncode(dicEntry.Value));
            if (dicEntry.Key.ToString() == EPrefsKeys.Progress.ToString())
            {
                Debug.Log(JsonUtility.FromJson<SaveManager.GameProgress>(JSON.JsonEncode(dicEntry.Value)).ToString());
            }
        }
    }

    private void OnDowloaded(string data)
    {
        //data = data.Substring( 1, data.Length - 2 );
        //Debug.Log( data );
        //data = "{" + data.Remove( 0, data.IndexOf( ':' ) + 1 ) + "}";
        //Debug.Log( "Edited: "+ data );
        //Debug.Log( "OnDownloaded: " + Encryption.Decrypt( data ) );
        SaveManager.GameProgress result = JsonUtility.FromJson<SaveManager.GameProgress>(data);
        if (result != null)
        {
            Debug.Log(result.ToString());
        }

    }

    private IEnumerator WaitForRequest(UnityWebRequest webRequest)
    {
        yield return webRequest.Send();

        // check for errors
        if (!string.IsNullOrEmpty(webRequest.error))
        {
            Debug.Log("<color=red>Upload data Error:</color> " + webRequest.error);
        }
        else
        {
            Debug.Log("UnityWebRequest ResponceCode: " + webRequest.responseCode);
        }
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload data Error: " + www.error);
        }
        else
        {
            Debug.Log("WWWRequest is ok");
        }
    }
    //#endif
}
