using System;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine;

public class NotificationView 
{
    private const string AndroidNotificationID = "android_notification_id";

    

    

    public void CreatNotification()
    {
#if UNITY_ANDROID
        CreatNotificationAndroid();
#elif UNITY_IOS
        CreatNotificationIOS();
#endif
    }

    private void CreatNotificationAndroid()
    {
        var androidNotificationChennal = new AndroidNotificationChannel
        {
            Id = AndroidNotificationID,
            Name = "Бро, Забери ресы!",
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChennal);

        var androidNotification = new AndroidNotification
        {
            Color = Color.red,
            RepeatInterval = TimeSpan.FromSeconds(86400)
        };

        AndroidNotificationCenter.SendNotification(androidNotification, AndroidNotificationID);
    }

    private void CreatNotificationIOS()
    {
        var iOSNotification = new iOSNotification
        {
            Identifier = "ios_notification_id",
            Title = "Ресы Ждут",
            Body = "Бро, ресы готовы, саме время их забрать",
            ForegroundPresentationOption = PresentationOption.Sound | PresentationOption.Alert,
            Data = "12/12/2112"
        };

        iOSNotificationCenter.ScheduleNotification(iOSNotification);

    }
}
