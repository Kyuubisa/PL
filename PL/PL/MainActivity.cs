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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            RequestedOrientation = ScreenOrientation.Portrait;
            //drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Create ActionBarDrawerToggle button and add it to the toolbar  
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            //drawerLayout.SetDrawerListener(drawerToggle);
            //drawerToggle.SyncState();
            //navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            //setupDrawerContent(navigationView); //Calling Function
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.navigation_menu);
            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.books:
                        loadFragment(new BooksFragment());
                        break;
                    case Resource.Id.video:
                        loadFragment(new VideoFragment());
                        break;
                    case Resource.Id.settings:
                        loadFragment(new SettingsFragment());
                        break;
                }
            };
            loadFragment(new BooksFragment());
        }
        //void setupDrawerContent(NavigationView navigationView)
        //{
        //    navigationView.NavigationItemSelected += (sender, e) =>
        //    {
        //        e.MenuItem.SetChecked(true);
        //        drawerLayout.CloseDrawers();
        //    };
        //}
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    navigationView.InflateMenu(Resource.Menu.nav_menu); //Navigation Drawer Layout Menu Creation  
        //    return true;
        //}

        private bool loadFragment(Fragment fragment)
        {
            FragmentManager fm = this.FragmentManager;
            fm.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).Commit();
            return true;
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            Fragment fragment = null;
                switch (item.ItemId)
                {
                    case Resource.Id.books:
                        loadFragment(new BooksFragment());
                        break;
                    case Resource.Id.video:
                        loadFragment(new VideoFragment());
                        break;
                    case Resource.Id.settings:
                        loadFragment(new SettingsFragment());
                        break;
                }
            return loadFragment(fragment);
        }
    }
}


