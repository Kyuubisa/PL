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

namespace PL
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class Loading : AppCompatActivity, IOnSeekBarChangeListener
    {
        WaveLoadingView waveLodingView;
        SeekBar seekBar;
        int progress = 0;

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
                        StartActivity(typeof(MainActivity));
                    }
                }
            });
        }
    }
}

