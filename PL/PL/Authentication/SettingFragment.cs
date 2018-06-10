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
    [Activity(Theme ="@style/AppTheme")]
    public class SettingsFragment : AppCompatActivity, IOnClickListener, IOnCompleteListener
    {
       
        TextView txtWelcome;
        EditText input_new_password;
        Button btnChagePass, btnLogout;
        RelativeLayout activity_dashboard;

        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.frag_settings);

            //init Firebase
            auth = FirebaseAuth.GetInstance(Loading.app);
            //View
            txtWelcome = FindViewById<TextView>(Resource.Id.dashboard_welcome);
            input_new_password = FindViewById<EditText>(Resource.Id.dashboard_newpassword);
            btnChagePass = FindViewById<Button>(Resource.Id.dashbord_btn_change_pass);
            btnLogout = FindViewById<Button>(Resource.Id.dashbord_btn_logout);
            activity_dashboard = FindViewById<RelativeLayout>(Resource.Id.authentification_dashBoard);

            btnChagePass.SetOnClickListener(this);
            btnLogout.SetOnClickListener(this);

        }

        public void OnClick(View v)
        {
            if(v.Id==Resource.Id.dashbord_btn_change_pass)
            {
                ChangePassword(input_new_password.Text);
            }
            else if(v.Id==Resource.Id.dashbord_btn_logout)
            {
                LogoutUser();
            }
        }

        private void LogoutUser()
        {
            auth.SignOut();
            if(auth.CurrentUser==null)
            {
                StartActivity(new Intent(this, typeof(Authentication_users)));
                Finish();
            }
        }

        private void ChangePassword(string newPassword)
        {
           FirebaseUser user = auth.CurrentUser;
            if (newPassword.Length < 6)
            {
                Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                builder
                .SetTitle("Ошибка")
                .SetMessage("Пароль должен содержать не менее 6 символов.");
                builder.Show();
            }
            else
            {
                user.UpdatePassword(newPassword)
                    .AddOnCompleteListener(this);
            }
        }

        
        public void OnComplete(Task task)
        {
            if(task.IsSuccessful==true)
            {
                Snackbar snackbar = Snackbar.Make(activity_dashboard, "Register has been chaged", Snackbar.LengthShort);
                snackbar.Show();
            }
        }
    }
}