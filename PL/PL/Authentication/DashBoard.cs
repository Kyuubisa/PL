using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PL
{
    [Activity(Theme = "@style/Theme.DesignDemo")]
    public class DashBoard : AppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DashBoard);
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                StartActivity(typeof(CardViewLanguage));
            });
            
        }

    }
}