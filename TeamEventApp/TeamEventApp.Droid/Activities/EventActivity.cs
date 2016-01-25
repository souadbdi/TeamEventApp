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
            TextView yesNumberText = FindViewById<TextView>(Resource.Id.event_yes_number);
            TextView maybeNumberText = FindViewById<TextView>(Resource.Id.event_maybe_number);
            TextView guestsNumberText = FindViewById<TextView>(Resource.Id.event_guests_number);

            // Show the dialog fragments


            // Notifications d'admin

            if (notifsText != null )
                notifsText.Click += delegate
                {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    EventNotifDialogFragment notifsDialog = new EventNotifDialogFragment();
                    notifsDialog.Show(tx, "Notifications");
                };

            // Commentaires sur l'événement

            if (commentsText != null)
                commentsText.Click += delegate
                {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    EventCommentDialogFragment commentsDialog = new EventCommentDialogFragment();
                    commentsDialog.Show(tx, "Commentaires");
                };

            // Les participants à l'événement

            if (yesNumberText != null)
                yesNumberText.Click += delegate {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    UsersDialogFragment usersDialog = new UsersDialogFragment();
                    usersDialog.Show(tx, "Les participants");
                };

            // Les intéréssés 

            if (maybeNumberText != null)
                maybeNumberText.Click += delegate {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    UsersDialogFragment usersDialog = new UsersDialogFragment();
                    usersDialog.Show(tx, "Les participants");
                };

            // Tous les invités à l'événements

            if (guestsNumberText != null)
                guestsNumberText.Click += delegate {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    UsersDialogFragment usersDialog = new UsersDialogFragment();
                    usersDialog.Show(tx, "Les participants");
                };

        }


    }
}