using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Content.PM;
using Android.Support.V7.CardView;
using System.Threading;
using System.Collections.Generic;
using Android.Support.V7.App;
using ME.Itangqi.Waveloadingview;
using static Android.Widget.SeekBar;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;

namespace PL
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class Loading : AppCompatActivity, IOnSeekBarChangeListener
    {
        WaveLoadingView waveLodingView;
        SeekBar seekBar;
        int progress = 0;

        public static FirebaseApp app;
        FirebaseAuth auth;

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            waveLodingView.ProgressValue = progress;
        }
        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }
        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Loading);
            this.RequestedOrientation = ScreenOrientation.Portrait;

            var options = new FirebaseOptions.Builder()
                 .SetApplicationId("1:380721416062:android:ff32b443cc4efdce")
                 .SetApiKey("AIzaSyAsM9-uxKH5Dcn2y2vx142lQPZlwn8sibg")
                 .Build();
            app = FirebaseApp.InitializeApp(Application.Context, options, "PL");
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);

            waveLodingView = FindViewById<WaveLoadingView>(Resource.Id.waveLoadingView);
            seekBar = FindViewById<SeekBar>(Resource.Id.seekbar);
            waveLodingView.ProgressValue = 0;
            seekBar.SetOnSeekBarChangeListener(this);
            await Task.Run(() =>
            {
                for (progress = 0; progress <= 100; progress++)
                {
                    seekBar.Progress = progress;
                    Thread.Sleep(100);

                    if (progress == 100)
                    {
                        auth = FirebaseAuth.GetInstance(app);
                        if (auth.CurrentUser == null)
                        {
                            StartActivity(typeof(Authentication_users));
                            Finish();
                        }
                        else
                            StartActivity(typeof(MainActivity));
                    }
                }
            });
        }
    }
}

