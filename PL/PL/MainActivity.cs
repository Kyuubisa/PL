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
using Java;
using static Android.Support.Design.Widget.BottomNavigationView;

namespace PL
{
    [Activity(MainLauncher = true,Theme = "@style/Theme.DesignDemo")]

    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            RequestedOrientation = ScreenOrientation.Portrait;
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView); //Calling Function
            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigation);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            LoadFragment(Resource.Id.books);
        }
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.nav_menu); //Navigation Drawer Layout Menu Creation  
            return true;
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
        public void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.books:
                    fragment = new BooksFragment();
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


