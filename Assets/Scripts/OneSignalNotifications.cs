using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;
public class OneSignalNotifications : MonoBehaviour
{
    private const string _id = "67fc887b-bd15-4db4-a8cb-9fe60de7825e";
    private string _idUser = "";
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("user_id") == false)
        {
            _idUser = SystemInfo.deviceUniqueIdentifier;
            PlayerPrefs.SetString("user_id", _idUser);
        }
        else
        {
            _idUser = PlayerPrefs.GetString("user_id");
        }

        OneSignal.Default.Initialize(_id);
        OneSignal.Default.SetExternalUserId(_idUser);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
