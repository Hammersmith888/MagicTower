using UnityEngine;

namespace Notifications
{
	public class NotificationManagerStub : NotificationManager
	{
		public NotificationManagerStub( )
		{
//			Debug.LogWarning( "NotificationManager currenty not supported for this platform. Using stub-implementation." );
		}

		public override bool IsAvailable
		{
			get {
				return false;
			}
		}

		public override void ClearAllLocalNotifications( )
		{
//			Debug.Log( SingletonName + "::ClearAllLocalNotification invoked" );
		}

		public override void ScheduleLocalNotification( string title, string message, int delayInSeconds )
		{
//			Debug.Log( string.Format( SingletonName + "::ScheduleLocalNotification invoked with args: title={0} message={1} delay={2}", title, message, delayInSeconds ) );
		}
	}
}
