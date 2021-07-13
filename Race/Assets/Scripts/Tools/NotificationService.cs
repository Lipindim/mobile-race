using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine;


public class NotificationService
{
    private const string ANDROID_NOTIFIER_ID = "android_notifier_id";


    public void CreateNotification(string title, string body)
    {
#if UNITY_ANDROID
        var androidSettingsChanel = new AndroidNotificationChannel
        {
            Id = ANDROID_NOTIFIER_ID,
            Name = title,
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            Description = body,
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);

        var androidSettingsNotification = new AndroidNotification
        {
            Color = Color.white
        };

        AndroidNotificationCenter.SendNotification(androidSettingsNotification, ANDROID_NOTIFIER_ID);
#elif UNITY_IOS
       var iosSettingsNotification = new iOSNotification
       {
           Identifier = "android_notifier_id",
           Title = title,
           Body = body,
           Badge = 1,
           ForegroundPresentationOption = PresentationOption.Alert,
           ShowInForeground = false
       };
      
       iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
    }
}
