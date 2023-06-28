using System;
using System.Collections.Generic;
using System.Linq;
using Unity.RemoteConfig;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
    public static RemoteController Instance { get; private set; }
    public struct userAttributes { }
    public struct appAttributes { }
    // Start is called before the first frame update
    private void OnEnable()
    {
        Debug.LogError("Start");
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        Debug.LogError(ConfigManager.appConfig.GetInt("START", 4) +"  "+ ConfigManager.appConfig.GetInt("CYCLE", 3));
    }

    public int GetStartLevel()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        Debug.LogError(ConfigManager.appConfig.GetInt("START", 4));
        return ConfigManager.appConfig.GetInt("START", 4);
    }

    public int GetRateRound()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        Debug.LogError(ConfigManager.appConfig.GetInt("CYCLE", 3));
        return ConfigManager.appConfig.GetInt("CYCLE", 3);
    }

}