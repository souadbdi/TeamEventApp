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
            AddTab("", Resource.Drawable.Details, new EventDetailsFragment());
            AddTab("", Resource.Drawable.Important, new EventNotificationsFragment());
            AddTab("", Resource.Drawable.Comments_Filled, new EventComsFragment());
            AddTab("", Resource.Drawable.Members_Filled, new EventMembersFragment());
            
        }

        // Adding a dynamic tab

        private void AddTab(string tabText, int resourceIcon, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(resourceIcon);

            // Send event handler to replace tabs
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {        
                e.FragmentTransaction.Replace(Resource.Id.event_fragmentContainer, fragment);
            };

            //this.ActionBar.AddTab(tab);
        }
    }
}