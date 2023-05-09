using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;

namespace Library_Project
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {

        ArrayAdapter adapter_word;

        private List<AndroidX.Fragment.App.Fragment> fragment = new List<AndroidX.Fragment.App.Fragment>()
        {

            new DictionaryFragment(),
            new ShortStoriesFragment(),
            new BookFragment(),
            new PoemsFragment(),
            new QuotesFragment(),
            new AdviseFragment()

        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);


            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[1]).Commit();

            _=AuthorsQuote();
        }




        private async Task AuthorsQuote()
        {

            Stream stream = null;
            StreamReader reader = null;



            stream = Assets.Open(@"AuthorsQuotes.txt");

            using (reader = new StreamReader(stream))
            {

                string line;

                while ((line = reader.ReadLine()) != null)
                {

                    Variables.Authors_quotes.Add(line);

                }

                //Log.Info("Authors_quotes", "Done");

            }


            stream = Assets.Open(@"nouns_two.txt");

            using (reader = new StreamReader(stream))
            {

                string line;

                while ((line = reader.ReadLine()) != null)
                {

                    Variables.nouns_quotes.Add(line);


                }

                //Log.Info("nouns_quotes", "Done");

            }

            
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

      

      

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;


            switch (id)
            {
                case Resource.Id.Dictionary:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[0]).Commit();
                    break;
                case Resource.Id.Short_stories:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[1]).Commit();
                    break;
                case Resource.Id.Book:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[2]).Commit();
                    break;
                case Resource.Id.Poems:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[3]).Commit();
                    break;
                case Resource.Id.Quotes:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[4]).Commit();
                    break;
                    /*case Resource.Id.Advise:
                        SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragment[5]).Commit();
                        break;
                    <item
                    android:id="@+id/Advise"
                    android:icon="@drawable/Advise"
                    android:title="Advise" />
                        */

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

