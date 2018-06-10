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
    [Activity(Label = "ForgotPassword",Theme ="@style/AppTheme")]
    public class ForgotPassword : AppCompatActivity, IOnClickListener, IOnCompleteListener
    {
        private EditText input_email;
        private Button btnResentPass;
        private TextView btnBack;
        private RelativeLayout activity_forgot;

        FirebaseAuth auth;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ForgotPassword);

            //Init Firebase
            auth = FirebaseAuth.GetInstance(Loading.app);
            //View 
            input_email = FindViewById<EditText>(Resource.Id.forgot_email);
            btnResentPass = FindViewById<Button>(Resource.Id.forgot_btn_resent);
            btnBack = FindViewById<TextView>(Resource.Id.forgot_btn_back);
            activity_forgot = FindViewById<RelativeLayout>(Resource.Id.authentication_forgot);

            btnResentPass.SetOnClickListener(this);
            btnBack.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if(v.Id==Resource.Id.forgot_btn_back)
            {
                StartActivity(new Intent(this, typeof(Authentication_users)));
                Finish();
            }
            else if (v.Id==Resource.Id.forgot_btn_resent)
            {
                ResetPassword(input_email.Text);
            }
        }

        private void ResetPassword(string email)
        {
            if (input_email.Text.Length <= 5)
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Ошибка")
                .SetMessage("Введён неверный e-mail.");
                builder.Show();
            }
            else
            {
                auth.SendPasswordResetEmail(email)
                    .AddOnCompleteListener(this, this);
            }
        }

        

        public void OnComplete(Task task)
        {
           if(task.IsSuccessful==false)
            {
                Snackbar snackbar = Snackbar.Make(activity_forgot, "Reset password failed", Snackbar.LengthShort);
                snackbar.Show();
            }
           else
            {
                Snackbar snackbar = Snackbar.Make(activity_forgot, "Reset password link send to email"+input_email.Text, Snackbar.LengthShort);
                snackbar.Show();
            }
        }
    }
}