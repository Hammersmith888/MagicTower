#if UNITY_WSA
//#if !UNITY_EDITOR
using UnityEngine;
using MarkerMetro.Unity.WinIntegration.LocalNotifications;
using System.Collections.Generic;

namespace Notifications
{
public class NotificationManagerWinStore : NotificationManager
{
	public const string NOTIFICATION_ID_LOADED = "notification_id_loaded";

	private const string PP_KEY = "AndroidNotificationManagerKey";
	private const string PP_ID_KEY = "AndroidNotificationManagerKey_ID";
	private const string DATA_SPLITTER = "|";

	public NotificationManagerWinStore( )
	{
		//
	}

	public override bool IsAvailable
	{
		get
		{
			return true;
		}
	}

	//public override void ClearAllLocalNotifications( )
	//{
	//	ReminderManager.SetRemindersStatus( false );
	//}

	public override void ScheduleLocalNotification(string title, string message, int delayInSeconds)
	{
		if( !ReminderManager.AreRemindersEnabled() )
		{
			ReminderManager.SetRemindersStatus( true );
		}

		int reminderId = GetNextId;

		List<LocalNotificationTemplate> scheduled = LoadPendingNotifications();
		LocalNotificationTemplate notification = new LocalNotificationTemplate( reminderId, title, message, System.DateTime.Now.AddSeconds( delayInSeconds ) );
		scheduled.Add( notification );

		SaveNotifications( scheduled );
		ReminderManager.RegisterReminder( reminderId.ToString(), title, message, System.DateTime.Now.AddSeconds( delayInSeconds ) );
	}

	public void CancelLocalNotification(int id, bool clearFromPrefs = true)
	{
		if( clearFromPrefs )
		{
			List<LocalNotificationTemplate> scheduled = LoadPendingNotifications();
			List<LocalNotificationTemplate> newList = new List<LocalNotificationTemplate>();

			foreach( LocalNotificationTemplate n in scheduled )
			{
				if( n.id != id )
				{
					newList.Add( n );
				}
			}

			SaveNotifications( newList );
		}
	}

	public override void ClearAllLocalNotifications( )
	{
		List<LocalNotificationTemplate> scheduled = LoadPendingNotifications();

		foreach( LocalNotificationTemplate n in scheduled )
		{
			CancelLocalNotification( n.id, false );
		}

		SaveNotifications( new List<LocalNotificationTemplate>() );
	}


	// --------------------------------------
	// Get / Set
	// --------------------------------------


	public int GetNextId
	{
		get
		{
			int id = 1;
			if( PlayerPrefs.HasKey( PP_ID_KEY ) )
			{
				id = PlayerPrefs.GetInt( PP_ID_KEY );
				id++;
			}

			PlayerPrefs.SetInt( PP_ID_KEY, id );
			return id;
		}

	}


	// --------------------------------------
	// Events
	// --------------------------------------


	//private void OnNotificationIdLoadedEvent(string data)
	//{
	//	int id = System.Convert.ToInt32( data );

	//	OnNotificationIdLoaded( id );
	//	dispatch( NOTIFICATION_ID_LOADED, id );

	//}

	//--------------------------------------
	//  PRIVATE METHODS
	//--------------------------------------



	private void SaveNotifications(List<LocalNotificationTemplate> notifications)
	{
		if( notifications.Count == 0 )
		{
			PlayerPrefs.DeleteKey( PP_KEY );
			return;
		}

		string serializedNotifications = "";
		int len = notifications.Count;
		for( int i = 0; i < len; i++ )
		{
			if( i != 0 )
			{
				serializedNotifications += DATA_SPLITTER;
			}

			serializedNotifications += notifications[i].SerializedString;
		}

		PlayerPrefs.SetString( PP_KEY, serializedNotifications );

	}


	public List<LocalNotificationTemplate> LoadPendingNotifications(bool includeAll = false)
	{

		string data = string.Empty;
		if( PlayerPrefs.HasKey( PP_KEY ) )
		{
			data = PlayerPrefs.GetString( PP_KEY );
		}
		List<LocalNotificationTemplate> tpls = new List<LocalNotificationTemplate>();

		if( data != string.Empty )
		{
			string[ ] notifications = data.Split( DATA_SPLITTER[0] );
			foreach( string n in notifications )
			{
				byte[ ] bytes = System.Convert.FromBase64String( n );
				string templateData = System.Text.Encoding.UTF8.GetString( bytes, 0, bytes.Length );

				try
				{
					LocalNotificationTemplate notification = new LocalNotificationTemplate( templateData );

					if( !notification.IsFired || includeAll )
					{
						tpls.Add( notification );
					}
				}
				catch( System.Exception e )
				{
					Debug.Log( "AndroidNative. AndroidNotificationManager loading notification data failed: " + e.Message );
				}

			}
		}
		return tpls;
	}
}
}
//#else
//public class NotificationManagerWinStore : NotificationManager
//{
//	public NotificationManagerWinStore( )
//	{
//		//
//	}

//	public override bool IsAvailable
//	{
//		get
//		{
//			return false;
//		}
//	}

//	//public override void ClearAllLocalNotifications( )
//	//{
//	//	ReminderManager.SetRemindersStatus( false );
//	//}

//	public override void ScheduleLocalNotification(string title, string message, int delayInSeconds)
//	{
//	}

//	public void CancelLocalNotification(int id, bool clearFromPrefs = true)
//	{
//	}

//	public override void ClearAllLocalNotifications( )
//	{
//	}

//}
//#endif
#endif