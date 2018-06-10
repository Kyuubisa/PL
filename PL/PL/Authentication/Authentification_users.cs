using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using static Android.Views.View;

namespace PL
{
    [Activity(Theme = "@style/AppTheme")]
    class Authentication_users : AppCompatActivity, IOnClickListener, IOnCompleteListener
    {
        Button btnLogin;
        EditText input_email, input_password;
        TextView btnSignUp, btnForgotPassword;

        RelativeLayout activity_authentification;

        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Authentification);
            RequestedOrientation = ScreenOrientation.Portrait;
            //Init Firebase
            InitFirebaseAuth();
            //View
            btnLogin = FindViewById<Button>(Resource.Id.login_btn_login);
            input_email = FindViewById<EditText>(Resource.Id.login_email);
            input_password = FindViewById<EditText>(Resource.Id.login_password);
            btnSignUp = FindViewById<TextView>(Resource.Id.login_btn_sing_up);
            btnForgotPassword = FindViewById<TextView>(Resource.Id.login_btn_forgot_password);
            activity_authentification = FindViewById<RelativeLayout>(Resource.Id.authentification);
            
            btnSignUp.SetOnClickListener(this);
            btnLogin.SetOnClickListener(this);
            btnForgotPassword.SetOnClickListener(this);
        }

        private void InitFirebaseAuth()
        {
            auth = FirebaseAuth.GetInstance(Loading.app);

        }

        public void OnClick(View v)
        {
            if (v.Id==Resource.Id.login_btn_forgot_password)
            {
                StartActivity(typeof(ForgotPassword));
                Finish();
            }
           else if(v.Id==Resource.Id.login_btn_sing_up)
            {
                StartActivity(typeof(SingUp));
                Finish();
            }
            else if (v.Id == Resource.Id.login_btn_login)
            {
                LoginUser(input_email.Text,input_password.Text);
            }
        }

        private void LoginUser(string email, string password)
        {
            if (input_email.Text.Length <= 5 || input_password.Text.Length < 6)
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Ошибка")
                .SetMessage("Вы заполнили не все поля.");
                builder.Show();
            }
            else
            {
                auth.SignInWithEmailAndPassword(email, password)
                    .AddOnCompleteListener(this);
            }
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                StartActivity(typeof(DashBoard));
                Finish();
            }
            else
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Ошибка")
                .SetMessage("Вы ввели неверный логин или пароль.")
                .SetNeutralButton("OK", delegate { builder.Dispose(); });
                builder.Show();
            }
            //Snackbar snackbar = Snackbar.Make(activity_authentification, "Login Failed", Snackbar.LengthShort);
            //snackbar.Show();
        }

    }
}