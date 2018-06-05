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
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using static Android.Support.Design.Widget.BottomNavigationView;
using Android.Locations;
using Android.Hardware.Usb;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

namespace PL
{
    [Activity(/*MainLauncher = true,*/Theme = "@style/Theme.DesignDemo")]

    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        BottomNavigationView bottomNavigation;
        public int lang;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            RequestedOrientation = ScreenOrientation.Portrait;

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigation);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.hamburger);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += Navigation_NavigationItemSelected;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) // Выбор элементов бокового меню.
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void Navigation_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadLanguage(e.MenuItem.ItemId);
        }
        public void LoadLanguage(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.nav_cpp:
                    lang = 1;
                    fragment = new BooksFragmentCPP();
                    drawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
                    break;
                case Resource.Id.nav_csharp:
                    lang = 2;
                    fragment = new BooksFragmentCSharp();
                    drawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
                    break;
                //case Resource.Id.nav_add:
                //    SetContentView(Resource.Layout.CardViewLanguage);
                //    drawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
                //    break;
            }
            if (fragment == null)
                return;
            FragmentManager fm = this.FragmentManager;
            fm.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).Commit();
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e) // Отправка ID нижнего меню в функцию.
        {
            LoadFragment(e.Item.ItemId);
        }
        public void LoadFragment(int id) // Выбор элементов нижнегом меню.
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.books:
                    if (lang == 1)
                        fragment = new BooksFragmentCPP();
                    else if (lang == 2)
                        fragment = new BooksFragmentCSharp();
                    break;
                case Resource.Id.video:
                    fragment = new VideoFragment();
                    break;
                case Resource.Id.settings:
                    fragment = new SettingsFragment();
                    break;
            }
            if (fragment == null)
                return;
            FragmentManager fm = this.FragmentManager;
            fm.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).Commit();
        }
    }
}


