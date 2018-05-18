using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using System;

namespace PL
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.DesignDemo", Label = "Настройки")]
    public class SettingsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.frag_settings, container, false);
            Button button = (Button)view.FindViewById(Resource.Id.notification);
            button.Click += (s, e) =>
            {
                var manager = (NotificationManager)inflater.Context.GetSystemService(Context.NotificationService);
                var notification = new Notification(Resource.Drawable.Notification_Fox_50, "Incoming Dart");
                var intent = new Intent();
                intent.SetComponent(new ComponentName(inflater.Context, "dart.androidapp.ContactsActivity"));
                var pendingIntent = PendingIntent.GetActivity(inflater.Context, 0, intent, 0);
                notification.SetLatestEventInfo(inflater.Context, "Языки программирования", "Вы давно не заходили в приложение, не упускайте возможность получить новые знания", pendingIntent);
                manager.Notify(0, notification);
                //Intent intent = new Intent(inflater.Context, typeof(SettingsFragment));
                //Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(inflater.Context);
                //stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SettingsFragment)));
                //stackBuilder.AddNextIntent(intent);
                //PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
                //NotificationCompat.Builder builder = new NotificationCompat.Builder(inflater.Context);
                //builder.SetAutoCancel(true)
                //.SetContentIntent(resultPendingIntent)
                //.SetContentTitle("Языки программирования")
                //.SetSmallIcon(Resource.Drawable.CPP)
                //.SetContentText("Вы давно не заходили в приложение, не забывайте получать новые знания");
                //NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
                //notificationManager.Notify(ButtonClickNotification, builder.Build());
            };
            return view;
        }
        
    }
}