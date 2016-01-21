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

using static TeamEventApp.DataBase;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_group")]
    public class GroupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            //Vue qui va contenir la liste des membres du groupe
            List<string> membersNames = new List<string>();
            ListView members_lv = FindViewById<ListView>(Resource.Id.MemberList);

            //Vue qui va contenir la liste des membres du groupe
            List<string> adminsNames = new List<string>();
            ListView admins_lv = FindViewById<ListView>(Resource.Id.AdminList);

            //Vue qui va contenir la liste des membres du groupe
            List<string> eventsNames = new List<string>();
            ListView events_lv = FindViewById<ListView>(Resource.Id.EventList);

            //on récupère dans gs le nom du group selectionné dans AccueilActivity
            string gs = this.Intent.GetStringExtra(GroupManagerActivity.groupSelect);

            TextView gntv = FindViewById<TextView>(Resource.Id.groupNameTextView);
            gntv.Text = gs;

            foreach(Group grp in users_db[1].groups)
            {
                if (grp.groupName==gs)
                {
                    //listview avec noms des membres
                    foreach (User us in grp.members)
                    {
                        membersNames.Add(us.firstName);
                    }
                    ArrayAdapter<string> adapt = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, membersNames);
                    members_lv.Adapter = adapt;

                    //listview avec noms des admins
                    foreach (User us in grp.admins)
                    {
                        adminsNames.Add(us.firstName);
                    }
                    adminsNames.Add("julie");
                    adminsNames.Add("Marie");
                    ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, adminsNames);
                    admins_lv.Adapter = adapter;

                    //listview avec noms des events
                    foreach (Event e in grp.events)
                    {
                        eventsNames.Add(e.eventName);
                    }
                    ArrayAdapter<string> ad = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, eventsNames);
                    events_lv.Adapter = ad;

                }
            }          
        }

        // Adding the menu

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.GroupMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_addMember:
                    //StartActivity(typeof(NotificationActivity));
                    return true;

                case Resource.Id.action_addAdmin:
                    //StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.action_addEvent:
                    //StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.action_changeName:
                    //StartActivity(typeof(GroupManagerActivity));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

    }
}