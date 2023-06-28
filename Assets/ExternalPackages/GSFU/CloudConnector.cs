using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;


public class CloudConnector : MonoBehaviour
{
    // Моя тестовая таблица баланса
    //private string webServiceUrl = "https://script.google.com/macros/s/AKfycbzV6HFt3IgV94izMRriizEm0g2XlKDUVN3hGnxmaIiXQ-Xa1deB/exec";
    //private string spreadsheetId = "13x0zuRYPaBSHFvcIvZVEic_5lyta0rP2HeNPU_8UAkk";
    
    // Реальная таблица баланса
	private string webServiceUrl = "https://script.google.com/macros/s/AKfycbzc93zTnjcRUtbqtlBtzJkEbkwhlMP8W-iuOnCn/exec";
	private string spreadsheetId = "1vJjzBRWOzRUPwEuuzN9VS4_uT4-KTbz9N8mTWOjJUR0";

	private string servicePassword = "bibizot2017";
	private float timeOutLimit = 30f;
	public bool usePOST = true;
	// --

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	private static CloudConnector _Instance;
	public static CloudConnector Instance
	{
		get
		{
			return _Instance ?? (_Instance = new GameObject("CloudConnector").AddComponent<CloudConnector>());
		}
        set {
            _Instance = value;
        }
	}
	
	private UnityWebRequest www;
	
	public void CreateRequest(Dictionary<string, string> form)
	{
		form.Add("ssid", spreadsheetId);
		form.Add("pass", servicePassword);
		
		if (usePOST)
		{
			CloudConnectorCore.UpdateStatus("Establishing Connection at URL " + webServiceUrl);
			www = UnityWebRequest.Post(webServiceUrl, form);
		}
		else // Use GET.
		{
			string urlParams = "?";
			foreach (KeyValuePair<string, string> item in form)
			{
				urlParams += item.Key + "=" + item.Value + "&";
			}
			CloudConnectorCore.UpdateStatus("Establishing Connection at URL " + webServiceUrl + urlParams);
			www = UnityWebRequest.Get(webServiceUrl + urlParams);
		}
		
		StartCoroutine(ExecuteRequest(form));
	}
	
	IEnumerator ExecuteRequest(Dictionary<string, string> postData)
	{
		www.Send();
		
		float elapsedTime = 0.0f;
		
		while (!www.isDone)
		{
			elapsedTime += Time.deltaTime;			
			if (elapsedTime >= timeOutLimit)
			{
				CloudConnectorCore.ProcessResponse("TIME_OUT", elapsedTime);
				break;
			}
			
			yield return null;
		}
		
		if (www.isNetworkError)
		{
			CloudConnectorCore.ProcessResponse(CloudConnectorCore.MSG_CONN_ERR + "Connection error after " + elapsedTime.ToString() + " seconds: " + www.error, elapsedTime);
			yield break;
		}	
		
		CloudConnectorCore.ProcessResponse(www.downloadHandler.text, elapsedTime);
	}
	
}

	