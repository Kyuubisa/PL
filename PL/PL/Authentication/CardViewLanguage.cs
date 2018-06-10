using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PL
{
    [Activity(Theme = "@style/Theme.DesignDemo")]
    public class CardViewLanguage : AppCompatActivity
    {
        public int lang;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CardViewLanguage);
            var cv1 = (CardView)FindViewById(Resource.Id.card_view_cpp);
            var cv2 = (CardView)FindViewById(Resource.Id.card_view_csharp);
            cv1.Click += (s, e) =>
            {
                lang = 1;
                StartActivity(typeof(MainActivity));
            };
            cv2.Click += (s, e) =>
            {
                lang = 2;
                StartActivity(typeof(MainActivity));
            };
        }

    }
}