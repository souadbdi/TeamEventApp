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
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_profile")]
    public class ProfileActivity : Activity
    {        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);


            // Actions pour la liste des demandes à des événements
            TextView textReqList = FindViewById<TextView>(Resource.Id.profile_req_text);

            textReqList.Click += delegate
            {
                StartActivity(typeof(UserGroupRequestActivity));
            };

        }

        
    }
}