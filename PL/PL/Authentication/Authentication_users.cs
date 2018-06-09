using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;

namespace PL
{
    [Activity(Theme = "@style/AppTheme")]
    class Authentication_users : AppCompatActivity
    {
        Button btnLogin;
        EditText input_email, input_password;
        TextView btnSingUp, btnForgotPassword;

        RelativeLayout activity_authentication;

        public static FirebaseApp app;
        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Authentication);
            RequestedOrientation = ScreenOrientation.Portrait;
            //Init Firebase
            InitFirebaseAuth();
            //View
            btnLogin = FindViewById<Button>(Resource.Id.login_btn_login);
            input_email = FindViewById<EditText>(Resource.Id.login_email);
            input_password = FindViewById<EditText>(Resource.Id.login_password);
            btnSingUp = FindViewById<TextView>(Resource.Id.login_btn_sing_up);
            btnForgotPassword = FindViewById<TextView>(Resource.Id.login_btn_forgot_password);
            //activity_authentication=FindViewById<RelativeLayout>(Resource.Id.)


        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                 .SetApplicationId("1:380721416062:android:ff32b443cc4efdce")
                 .SetApiKey("AIzaSyAsM9-uxKH5Dcn2y2vx142lQPZlwn8sibg")
                 .Build();

            if (app == null)
                app = FirebaseApp.InitializeApp(this,options);
                auth = FirebaseAuth.GetInstance(app);

        }
    }
}