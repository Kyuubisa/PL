using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using System;

namespace PL
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.DesignDemo", Label = "Настройки")]
    public class SettingsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.frag_settings, container, false);
            return view;
        }
        
    }
}