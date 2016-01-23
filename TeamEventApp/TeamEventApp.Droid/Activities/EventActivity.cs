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
using TeamEventApp.Droid.Adapters;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "@string/label_infos_event")]
    public class EventActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventLayout);

            // TextViews
            TextView notifsText = FindViewById<TextView>(Resource.Id.event_notifs);
            TextView commentsText = FindViewById<TextView>(Resource.Id.event_comments);            

            // Show the dialog fragments

            if (notifsText != null )
                notifsText.Click += delegate
                {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    EventNotifDialogFragment notifsDialog = new EventNotifDialogFragment();
                    notifsDialog.Show(tx, "Notifications");
                };

            if (commentsText != null)
                commentsText.Click += delegate
                {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    EventCommentDialogFragment commentsDialog = new EventCommentDialogFragment();
                    commentsDialog.Show(tx, "Commentaires");
                };

        }


    }
}