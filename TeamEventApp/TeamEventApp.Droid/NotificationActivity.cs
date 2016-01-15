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
                case Resource.Id.notifications_item:
                    StartActivity(typeof(NotificationActivity));
                    return true;

                case Resource.Id.profile_item:
                    //StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.event_manager_item:
                    StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.group_manager_item:
                    //StartActivity(typeof(GroupManagerActivity));
                    return true;

                case Resource.Id.about_item:
                    //StartActivity(typeof(AboutActivity));
                    return true;

                case Resource.Id.action_settings:
                    //StartActivity(typeof(SettingNotifActivity));
                    return true;


                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
    }
}