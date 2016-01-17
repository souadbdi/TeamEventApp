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

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_notifications")]
    public class NotificationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        // Adding the menu

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_notifications:
                    StartActivity(typeof(NotificationActivity));
                    return true;

                case Resource.Id.action_profile:
                    StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.action_event_manager:
                    StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.action_group_manager:
                    StartActivity(typeof(GroupManagerActivity));
                    return true;

                case Resource.Id.action_about:
                    StartActivity(typeof(AboutActivity));
                    return true;

                case Resource.Id.action_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}