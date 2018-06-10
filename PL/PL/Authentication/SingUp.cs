using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using static Android.Views.View;

namespace PL
{
    [Activity(Label = "SingUp",Theme ="@style/AppTheme")]
    public class SingUp : AppCompatActivity,IOnClickListener,IOnCompleteListener
    {
        Button btnSignup;
        TextView btnLogin, btnForgotPass;
        EditText input_email, input_password;
        RelativeLayout activity_sing_up;

        FirebaseAuth auth;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SingUp);
            //InitFirebase
            auth = FirebaseAuth.GetInstance(Loading.app);
            //View 
            btnSignup = FindViewById<Button>(Resource.Id.singup_btn_register);
            btnLogin = FindViewById<TextView>(Resource.Id.singup_btn_login);
            btnForgotPass = FindViewById<TextView>(Resource.Id.singup_btn_forgot_password);
            input_email = FindViewById<EditText>(Resource.Id.singup_email);
            input_password = FindViewById<EditText>(Resource.Id.singup_password);
            activity_sing_up = FindViewById<RelativeLayout>(Resource.Id.authentication_sing_up);

            btnLogin.SetOnClickListener(this);
            btnForgotPass.SetOnClickListener(this);
            btnSignup.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.singup_btn_login)
            {
                StartActivity(new Intent(this, typeof(Authentication_users)));
                Finish();
            }
            else if (v.Id == Resource.Id.singup_btn_forgot_password)
            {
                StartActivity(new Intent(this, typeof(ForgotPassword)));
                Finish();
            }
            else if (v.Id == Resource.Id.singup_btn_register)
            {
                SignUpUser(input_email.Text, input_password.Text);
            }
        }

        private void SignUpUser(string email, string password)
        {
            if (input_email.Text.Length <= 5 || input_password.Text.Length < 6)
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Ошибка")
                .SetMessage("Пароль должен содержать не менее 6 символов.");
                builder.Show();
            }
            else
            {
                auth.CreateUserWithEmailAndPassword(email, password)
                    .AddOnCompleteListener(this, this);
            }
        }


        public void OnComplete(Task task)
        {
           if(task.IsSuccessful==true)
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Уведомление")
                .SetMessage("Регистрация успешно выполнена.");
                builder.Show();
            }
            else
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Ошибка")
                .SetMessage("Регистрация не выполнена.");
                builder.Show();
            }
        }
    }
}