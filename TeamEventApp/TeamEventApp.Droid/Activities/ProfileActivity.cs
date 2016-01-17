using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_profile")]
    public class ProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            // Enable navigation mode to suppot tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            // Adding tabs
            AddTab("Evénements", new ProfileEventFragment());
            AddTab("Groupes", new ProfileGroupFragment());

        }

        private void AddTab(string tabText, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);

            // Send event handler to replace tabs
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Replace(Resource.Id.profile_fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}