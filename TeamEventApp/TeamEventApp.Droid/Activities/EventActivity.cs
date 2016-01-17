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

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "@string/label_infos_event")]
    public class EventActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EventLayout);

            // Enable navigation mode to suppot tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            // Adding tabs
            AddTab("Détails", new EventDetailsFragment());
            AddTab("Notifications", new EventNotificationsFragment());
            AddTab("Commentaires", new EventComsFragment());
            AddTab("Participants", new EventMembersFragment());
            
        }

        // Adding a dynamic tab

        private void AddTab(string tabText, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);            

            // Send event handler to replace tabs
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Replace(Resource.Id.event_fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}