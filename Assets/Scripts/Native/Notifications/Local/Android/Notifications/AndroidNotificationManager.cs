
using UnityEngine;
using System;
using System.Collections.Generic;
using SimpleAndroidNotifications = Assets.SimpleAndroidNotifications.NotificationManager;

public class AndroidNotificationManager
{
    public const int LENGTH_SHORT = 0; // 2 seconds 
    public const int LENGTH_LONG = 1; // 3.5 seconds

    private const string PP_KEY = "AndroidNotificationManagerKey";
    private const string PP_ID_KEY = "AndroidNotificationManagerKey_ID";
    private const string DATA_SPLITTER = "|";

    private static AndroidNotificationManager _Instance;
    public static AndroidNotificationManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new AndroidNotificationManager();
            }
            return _Instance;
        }
    }

    public int GetNextId
    {
        get
        {
            int id = 1;
            if (PlayerPrefs.HasKey(PP_ID_KEY))
            {
                id = PlayerPrefs.GetInt(PP_ID_KEY);
                id++;
            }

            PlayerPrefs.SetInt(PP_ID_KEY, id);
            return id;
        }

    }

    public int ScheduleLocalNotification(string title, string message, int seconds)
    {
        //AndroidNotificationBuilder builder = new AndroidNotificationBuilder( GetNextId, title, message, seconds );
        //return ScheduleLocalNotification( builder );
        int id = SimpleAndroidNotifications.SendWithAppIcon(TimeSpan.FromSeconds(seconds), title, message);
        LocalNotificationTemplate notification = new LocalNotificationTemplate(id, title, message, DateTime.Now.AddSeconds(seconds));
        List<LocalNotificationTemplate> scheduled = LoadPendingNotifications();
        scheduled.Add(notification);
        SaveNotifications(scheduled);
        return id;
    }

    public void CancelAllLocalNotifications()
    {
        List<LocalNotificationTemplate> scheduled = LoadPendingNotifications();

        foreach (LocalNotificationTemplate n in scheduled)
        {
            SimpleAndroidNotifications.Cancel(n.id);
        }

        SaveNotifications(new List<LocalNotificationTemplate>());
    }


    public List<LocalNotificationTemplate> LoadPendingNotifications(bool includeAll = false)
    {
#if UNITY_ANDROID
        string data = string.Empty;
        if (PlayerPrefs.HasKey(PP_KEY))
        {
            data = PlayerPrefs.GetString(PP_KEY);
        }
        List<LocalNotificationTemplate> tpls = new List<LocalNotificationTemplate>();

        if (data != string.Empty)
        {
            string[] notifications = data.Split(DATA_SPLITTER[0]);
            foreach (string n in notifications)
            {

                String templateData = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(n));

                try
                {
                    LocalNotificationTemplate notification = new LocalNotificationTemplate(templateData);

                    if (!notification.IsFired || includeAll)
                    {
                        tpls.Add(notification);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("AndroidNative. AndroidNotificationManager loading notification data failed: " + e.Message);
                }

            }
        }
        return tpls;
#else
		return null;
#endif
    }

    private void SaveNotifications(List<LocalNotificationTemplate> notifications)
    {
        if (notifications.Count == 0)
        {
            PlayerPrefs.DeleteKey(PP_KEY);
            return;
        }

        string srialzedNotifications = "";
        int len = notifications.Count;
        for (int i = 0; i < len; i++)
        {
            if (i != 0)
            {
                srialzedNotifications += DATA_SPLITTER;
            }

            srialzedNotifications += notifications[i].SerializedString;
        }

        PlayerPrefs.SetString(PP_KEY, srialzedNotifications);
    }
}
