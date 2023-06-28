namespace Notifications
{
	public abstract class NotificationManager : AbstractSingleton<
NotificationManager,
#if UNITY_EDITOR
		NotificationManagerStub
#elif UNITY_ANDROID
		NotificationManagerAndroid
#elif UNITY_IOS
		NotificationManagerIOS
#elif UNITY_WP8 || UNITY_WSA
		NotificationManagerWinStore
#else
		NotificationManagerStub
#endif
>
	{
		public NotificationManager( )
		{
		}

		public abstract bool IsAvailable
		{
			get;
		}

		public abstract void ClearAllLocalNotifications( );
		public abstract void ScheduleLocalNotification( string title, string message, int delayInSeconds );
	}
}
