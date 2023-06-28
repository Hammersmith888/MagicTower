using UnityEngine;
using System;
using System.Collections.Generic;
using Assets.SimpleAndroidNotifications;
using OneSignalSDK;
public class LocalNotificationsController : MonoBehaviour
{
	private bool _isConnected = false;


	DateTime day1hour7;
	DateTime day1hour18;
	DateTime day2hour8;
	DateTime day2hour19;
	DateTime day3hour9;
	DateTime day3hour20;
	DateTime day4hour10;
	DateTime day4hour21;

	private const string TITLE = "Magic Siege";
	private const string FiveMinutesCounter = "FIVEMIN";
	private const string OneHourCounter = "ONEHOUR";

	private readonly List<string> MinutesMesseges = new List<string>()
{
	"👉 Продолжай 🎲 играть!",
	"🎮 Приглашай друзей в игру! ",
	"👉 Keep 🎲 playing!",
	"🎮 Inviting friends to Challenge!"
};
	private readonly List<string> FirstDayMesseges = new List<string>()
{
	"☝️Один мудрец сказал: тренируйся, чтобы стать мастером🏆",
	"Приближается ночь🌙. Время получить некоторые награды🕵️‍♂️",
	"☝️The old man said: train to become the master🏆",
	"The night is coming🌙. Time to steal some rewards🕵️‍♂️"
};
    private readonly List<string> SecondDayMesseges = new List<string>()
{
	"🎮 Вся жизнь игра, а мы в ней игроки 😈",
	"👉 Мы подготовили для вас новые уровни, приятной игры!",
	"🎮 All life is a game, and we are players in it 😈",
	"👉 We have prepared new levels for you, enjoy the game!"
};
    private readonly List<string> ThirdDayMesseges = new List<string>()
{
	"☝️Один мудрец сказал: тренируйся, чтобы стать мастером🏆",
	"👉 Желаем удачи!",
	"☝️The old man said: train to become the master🏆",
	"👉 We wish you good luck!"
};
	private readonly List<string> FourthDayMesseges = new List<string>()
{
	"🎮 Вся жизнь игра, а мы в ней игроки 😈",
	"👉 Мы подготовили для вас новые уровни, приятной игры!",
	"🎮 All life is a game, and we are players in it 😈",
	"👉 We have prepared new levels for you, enjoy the game!"
};

	private void Awake()
	{
		PlayerPrefs.SetInt(FiveMinutesCounter, PlayerPrefs.GetInt(FiveMinutesCounter, -1) + 1);
		PlayerPrefs.SetInt(OneHourCounter, PlayerPrefs.GetInt(OneHourCounter, -1) + 1);
		Application.quitting += () =>
		{
			StartNotifications();
		};
	}

	public void OnApplicationQuit()
	{
		StartNotifications();
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus)
		{
			NotificationManager.CancelAll();
		}
		else
		{
			StartNotifications();
		}

	}


	private void StartNotifications()
	{
		NotificationManager.CancelAll();
		day1hour7 = DateTime.Today.AddDays(1).AddHours(7).AddMinutes(30);
		day1hour18 = DateTime.Today.AddDays(1).AddHours(17).AddMinutes(30);
		day2hour8 = DateTime.Today.AddDays(2).AddHours(8).AddMinutes(30);
		day2hour19 = DateTime.Today.AddDays(2).AddHours(18).AddMinutes(30);
		day3hour9 = DateTime.Today.AddDays(6).AddHours(9).AddMinutes(30);
		day3hour20 = DateTime.Today.AddDays(6).AddHours(19).AddMinutes(30);
		day4hour10 = DateTime.Today.AddDays(7).AddHours(8).AddMinutes(30);
		day4hour21 = DateTime.Today.AddDays(7).AddHours(18).AddMinutes(30);
		if (Application.systemLanguage.ToString() == "Russian")
		{
			//CreateNotification(TITLE, MinutesMesseges[2], TimeSpan.FromSeconds(15));
			CreateNotification(TITLE, FirstDayMesseges[0], TimeSpan.FromMinutes((day1hour7 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, FirstDayMesseges[1], TimeSpan.FromMinutes((day1hour18 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, SecondDayMesseges[0], TimeSpan.FromMinutes((day2hour8 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, SecondDayMesseges[1], TimeSpan.FromMinutes((day2hour19 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, ThirdDayMesseges[0], TimeSpan.FromMinutes((day3hour9 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, ThirdDayMesseges[1], TimeSpan.FromMinutes((day3hour20 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, FourthDayMesseges[0], TimeSpan.FromMinutes((day4hour10 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, FourthDayMesseges[1], TimeSpan.FromMinutes((day4hour21 - DateTime.Now).TotalMinutes));
			if (PlayerPrefs.GetInt(FiveMinutesCounter, 0) % 10 == 0)
			{
				CreateNotification(TITLE, MinutesMesseges[0], TimeSpan.FromMinutes(5));
			}
			if (PlayerPrefs.GetInt(OneHourCounter, 0) % 5 == 0)
			{
				CreateNotification(TITLE, MinutesMesseges[1], TimeSpan.FromMinutes(60));
			}
		}
		else
		{
			//CreateNotification(TITLE, MinutesMesseges[2], TimeSpan.FromSeconds(15));
			CreateNotification(TITLE, FirstDayMesseges[2], TimeSpan.FromMinutes((day1hour7 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, FirstDayMesseges[3], TimeSpan.FromMinutes((day1hour18 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, SecondDayMesseges[2], TimeSpan.FromMinutes((day2hour8 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, SecondDayMesseges[3], TimeSpan.FromMinutes((day2hour19 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, ThirdDayMesseges[2], TimeSpan.FromMinutes((day3hour9 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, ThirdDayMesseges[3], TimeSpan.FromMinutes((day3hour20 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, FourthDayMesseges[2], TimeSpan.FromMinutes((day4hour10 - DateTime.Now).TotalMinutes));
			CreateNotification(TITLE, FourthDayMesseges[3], TimeSpan.FromMinutes((day4hour21 - DateTime.Now).TotalMinutes));
			if (PlayerPrefs.GetInt(FiveMinutesCounter, 0) % 10 == 0)
			{
				CreateNotification(TITLE, MinutesMesseges[2], TimeSpan.FromMinutes(5));

			}
			if (PlayerPrefs.GetInt(OneHourCounter, 0) % 5 == 0)
			{
				CreateNotification(TITLE, MinutesMesseges[3], TimeSpan.FromMinutes(60));
			}
		}
	}

	public void CreateNotification(string title, string body, TimeSpan time)
	{
		NotificationManager.SendWithAppIcon(time, title, body, new Color(0, 0.6f, 1), NotificationIcon.Bell);
	}
}
//using UnityEngine;
//using System;
//using System.Collections.Generic;
//#if UNITY_ANDROID
//using Unity.Notifications.Android;
//#endif

//namespace Notifications
//{
//	public class LocalNotificationsController : MonoBehaviour
//	{
//		private string messageTitle = "Magic Siege";

//		private const int NOTIFICATION_LATEST_HOUR = 20;
//		private const int NOTIFICATION_EARLIEST_HOUR = 11;
//		const int CHALLENGE_INVITE_NOTIFICATION_HOURS = 72;

//		public static LocalNotificationsController instance;

//		private void Awake()
//		{
//			if (instance != null && instance != this)
//			{
//				Destroy(gameObject);
//				return;
//			}


//			instance = this;
//            //NotificationManager.Instance.ClearAllLocalNotifications();
//#if UNITY_ANDROID
//			var channel = new AndroidNotificationChannel()
//			{
//				Id = "channel_id",
//				Name = "Default Channel",
//				Importance = Importance.Default,
//				Description = "Generic notifications",
//			};
//			AndroidNotificationCenter.RegisterNotificationChannel(channel);
//#endif
//		}

//		private void Start()
//		{
//			if (!String.IsNullOrEmpty(PlayerPrefs.GetString("push_InviteFriends_t")))
//			{
//				var utcSave = Int32.Parse(PlayerPrefs.GetString("push_InviteFriends_t"));
//				var utc = DailyReward.UnixTimeStampToDateTime(utcSave);
//				Int32 unixSave = (Int32)(utc.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
//				Int32 unixTimestamp = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
//				if ((unixTimestamp - unixSave) < 172800)
//				{
//#if UNITY_ANDROID
//					AndroidNotificationCenter.CancelNotification(PlayerPrefs.GetInt("push_InviteFriends"));
//#endif
//					PlayerPrefs.SetInt("push_InviteFriends", 0);
//				}
//			}
//			if (PlayerPrefs.GetInt("push_InviteFriends") == 0)
//			{
//				int id = Notifications.LocalNotificationsController.instance.ScheduleNotification(
//				   TextSheetLoader.Instance.GetString("t_0697"),
//				   TextSheetLoader.Instance.GetString("t_0698"),
//				   172800, "InviteFriends");
//				PlayerPrefs.SetInt("push_InviteFriends", id);
//				Int32 unixTimestamp = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
//				PlayerPrefs.SetString("push_InviteFriends_t", unixTimestamp.ToString());
//			}

//			CheckHowMuchSecondsTillTomorrow();

//		}

//		public void StartDailyRewardNotification( )
//		{

//		}

//		public void ReScheduledFullEnergyNotification( )
//		{

//		}

//		public void Remove(int id)
//		{
//#if UNITY_ANDROID
//            AndroidNotificationCenter.CancelNotification(id);
//#endif
//		}



//		public int ScheduleNotification(string label, string message, double secondsDelay, string type )
//		{
//            //NotificationManager.Instance.ScheduleLocalNotification( messageTitle, message, secondsDelay );
//#if UNITY_ANDROID
//			var notification = new AndroidNotification();
//			notification.Title = label;
//			notification.Text = message;
//			notification.IntentData = type;
//			notification.FireTime = System.DateTime.Now.AddSeconds(secondsDelay);
//			//notification.SmallIcon = "icon_0";
//			//notification.LargeIcon = "my_custom_large_icon_id"
//			var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
//			AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler =
//			delegate (AndroidNotificationIntentData data)
//			{
//				var msg = "Notification received : " + data.Id + "\n";
//				msg += "\n Notification received: ";
//				msg += "\n .Title: " + data.Notification.Title;
//				msg += "\n .Body: " + data.Notification.Text;
//				msg += "\n .IntentData: " + data.Notification.IntentData;
//				msg += "\n .Channel: " + data.Channel;
//				Debug.Log(msg);
//			};

//			//Debug.Log($"id of sended notification: {id}");
//			List<string> ids = new List<string>();
//			if(PlayerPrefs.GetString("notifications") == "")
//				PlayerPrefs.SetString("notifications", "[]");
//			var dt = LitJson.JsonMapper.ToObject<List<string>>(PlayerPrefs.GetString("notifications"));
//			dt.Add(id.ToString());
//			PlayerPrefs.SetString("notifications", LitJson.JsonMapper.ToJson(dt));

//			AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;

//#endif
//#if UNITY_ANDROID || UNITY_IOS
//			return id;
//#else
//            return 0;
//#endif
//        }

//		public double CheckHowMuchSecondsTillTomorrow()
//		{
//			DateTime now = DateTime.Now;
//			DateTime tomorrow = now.AddDays(1).Date;

//			return (tomorrow - now).TotalSeconds;
//		}

//	}
//}
