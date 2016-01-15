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
    [Activity(Label = "@string/label_group_manager")]
    public class GroupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            string names = "";
            string admins = "";
            string events = "";

            //on récupère dans gs le nom du group selectionné dans AccueilActivity
            string gs = this.Intent.GetStringExtra(GroupManagerActivity.groupSelect);

            TextView gntv = FindViewById<TextView>(Resource.Id.groupNameTextView);
            TextView mtv = FindViewById<TextView>(Resource.Id.membersTextView);
            TextView atv = FindViewById<TextView>(Resource.Id.adminTextView);
            gntv.Text = gs;

            foreach(Group grp in users_db[1].groups)
            {
                if (grp.groupName==gs)
                {
                    foreach (User user in grp.members)
                    {
                        names += user.firstName;
                    }

                    admins = grp.admin.firstName;

                    mtv.Text = names;
                    atv.Text = admins;
                
                }
            }
            

        }
    }
}