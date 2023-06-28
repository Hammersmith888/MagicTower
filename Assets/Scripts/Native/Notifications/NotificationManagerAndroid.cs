#if UNITY_ANDROID

namespace Notifications
{
	public class NotificationManagerAndroid : NotificationManager
	{
		public override bool IsAvailable
		{
			get {
                return AndroidNotificationManager.Instance != null;
			}
		}

		public override void ClearAllLocalNotifications( )
		{
			if( IsAvailable )
			{
				AndroidNotificationManager.Instance.CancelAllLocalNotifications();
			}
		}

		public override void ScheduleLocalNotification( string title, string message, int delayInSeconds )
		{
			if( IsAvailable )
			{
				AndroidNotificationManager.Instance.ScheduleLocalNotification( title, message, delayInSeconds );
			}
		}
	}
}

#endif