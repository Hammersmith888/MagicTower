#if UNITY_IOS

using System;
using UnityEngine;

namespace Notifications
{
	public class NotificationManagerIOS : NotificationManager 
	{
		private int badgeNumberCounter = 0;

		public NotificationManagerIOS() : base() 
		{
			UnityEngine.iOS.NotificationServices.RegisterForNotifications(UnityEngine.iOS.NotificationType.Alert | UnityEngine.iOS.NotificationType.Badge | UnityEngine.iOS.NotificationType.Sound, true);
		}

		public override bool IsAvailable {
			get {
				return true;
			}
		}

		public override void ClearAllLocalNotifications() {
			badgeNumberCounter = 0;
			if (IsAvailable) {
				UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();
				UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
				UnityEngine.iOS.NotificationServices.ClearRemoteNotifications();
				UnityEngine.iOS.LocalNotification clearBadge = new UnityEngine.iOS.LocalNotification();
				clearBadge.applicationIconBadgeNumber = -1;
				UnityEngine.iOS.NotificationServices.PresentLocalNotificationNow(clearBadge);
			}
		}

		public override void ScheduleLocalNotification(string title, string message, int delayInSeconds) {
			if (IsAvailable) {
				UnityEngine.iOS.NotificationServices.ScheduleLocalNotification( new UnityEngine.iOS.LocalNotification()
				{
					alertBody = string.Format( "{0}", message ),
					applicationIconBadgeNumber = ++badgeNumberCounter,
					fireDate = DateTime.Now.AddSeconds( delayInSeconds ),
					hasAction = false,
					soundName = "notification_sound",// UnityEngine.iOS.LocalNotification.defaultSoundName,
				});
			}
		}
	}
}

#endif