using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Support.V7.App;

namespace PL
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class SettingsFragment : AppCompatActivity
    {
        private static readonly int ButtonClickNotification = 666;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var btnSend = FindViewById<Button>(Resource.Id.notification);
            btnSend.Click += (s, e) =>
            {
                Intent intent = new Intent(this, typeof(SettingsFragment));
                Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
                stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SettingsFragment)));
                stackBuilder.AddNextIntent(intent);
                PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
                NotificationCompat.Builder builder = new NotificationCompat.Builder(this);
                builder.SetAutoCancel(true)
                .SetContentIntent(resultPendingIntent)
                .SetContentTitle("Языки программирования")
                .SetSmallIcon(Resource.Drawable.CPP)
                .SetContentText("Вы давно не заходили в приложение, не забывайте получать новые знания");
                NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                notificationManager.Notify(ButtonClickNotification, builder.Build());
            };
        }
    }
}