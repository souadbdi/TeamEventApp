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


        // Views

        TextView eventNameText;
        TextView eventGroupText;
        TextView eventDateText;
        TextView eventLocationText;

        
        TextView yesNumberText;
        TextView maybeNumberText;
        TextView guestsNumberText;

        RadioButton yesRadio;
        RadioButton noRadio;
        RadioButton maybeRadio;

        TextView inviteFriendsText;

        TextView eventDescriptionText;

        TextView notifsText;
        TextView notifsNumber;
        TextView commentsText;
        TextView commentsNumber;

        // Service

        UserService uService;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventLayout);


            // Service
            uService = new UserService(DataBase.current_user);

            initAndDisplayViews();

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
                    UsersDialogFragment usersDialog = new UsersDialogFragment(DataBase.currentEvent.userList);
                    usersDialog.Show(tx, "Les participants");
                };

            // Les intéréssés 

            if (maybeNumberText != null)
                maybeNumberText.Click += delegate {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    UsersDialogFragment usersDialog = new UsersDialogFragment(DataBase.currentEvent.userList);
                    usersDialog.Show(tx, "Les intéréssés");
                };

            // Tous les invités à l'événement

            if (guestsNumberText != null)
                guestsNumberText.Click += delegate {
                    FragmentTransaction tx = FragmentManager.BeginTransaction();
                    UsersDialogFragment usersDialog = new UsersDialogFragment(DataBase.currentEvent.userList);
                    usersDialog.Show(tx, "Les invités");
                };

            if (inviteFriendsText != null)
                inviteFriendsText.Click += delegate
                {
                    StartActivity(typeof(InviteContactActivity));
                };

        }


        private void initAndDisplayViews()
        {
            // Nom 
            eventNameText = FindViewById< TextView > (Resource.Id.event_name);
            if (eventNameText != null)
                eventNameText.Text = DataBase.currentEvent.eventName;

            // Groupe hôte
            eventGroupText = FindViewById<TextView>(Resource.Id.event_groupName);
            if (eventGroupText != null)
            {
                Group grp = uService.GetUserGroupById(DataBase.currentEvent.groupId);

                if (grp != null)
                    eventGroupText.Text = grp.groupName;
            }
                
            // Date 
            eventDateText = FindViewById<TextView>(Resource.Id.event_date);
            if (eventDateText != null)
                eventDateText.Text = DataBase.currentEvent.toStringStartEndDate();

            // Location
            eventLocationText = FindViewById<TextView>(Resource.Id.event_location);
            if (eventLocationText != null)
                eventLocationText.Text = DataBase.currentEvent.address;


            // Description
            eventDescriptionText = FindViewById<TextView>(Resource.Id.event_about_text);
            if (eventDescriptionText != null)
                eventDescriptionText.Text = DataBase.currentEvent.description;

            // Notifs
            notifsText = FindViewById<TextView>(Resource.Id.event_notifs);

            notifsNumber = FindViewById<TextView>(Resource.Id.event_notifs_number);
            if (notifsNumber != null)
                notifsNumber.Text = "(" + DataBase.currentEvent.notifications.Count() + ")";

            // Comments
            commentsText = FindViewById<TextView>(Resource.Id.event_comments);

            commentsNumber = FindViewById<TextView>(Resource.Id.event_comments_number);
            if (commentsNumber != null)
                commentsNumber.Text = "(" + DataBase.currentEvent.comments.Count() + ")";

            // Yes mumber
            yesNumberText = FindViewById<TextView>(Resource.Id.event_yes_number);

            if (yesNumberText != null)
            {
                yesNumberText.Text = "" + DataBase.currentEvent.userList.Count();
            }

            // Maybe number
            maybeNumberText = FindViewById<TextView>(Resource.Id.event_maybe_number);

            if (maybeNumberText != null)
            {
                maybeNumberText.Text = "" + DataBase.currentEvent.userList.Count();
            }

            // Guests number
            guestsNumberText = FindViewById<TextView>(Resource.Id.event_guests_number);

            if (guestsNumberText != null)
            {
                guestsNumberText.Text = "" + DataBase.currentEvent.userList.Count();
            }
            
            // Invite friends
            inviteFriendsText = FindViewById<TextView>(Resource.Id.event_invite_friends);


            // Radio group
            yesRadio = FindViewById<RadioButton>(Resource.Id.event_yes_radio);
            noRadio = FindViewById<RadioButton>(Resource.Id.event_no_radio);
            maybeRadio = FindViewById<RadioButton>(Resource.Id.event_maybe_radio);

            if (yesRadio != null && noRadio != null && maybeRadio != null)
            {
                // Si a répondu oui
                if (DataBase.currentEvent.hasAnsweredUser(DataBase.current_user))
                    yesRadio.Checked = true;

                // Sinon il a répondu non
                else
                    noRadio.Checked = false;

                // Actions : si on clique sur oui, on ajoute dans la liste
                // Si on clique sur non, on enlève de la liste

                yesRadio.CheckedChange += delegate
                {
                    DataBase.currentEvent.addUser(DataBase.current_user);
                };

                maybeRadio.CheckedChange += delegate
                {
                    DataBase.currentEvent.addUser(DataBase.current_user);
                };

                noRadio.CheckedChange += delegate
                {
                    DataBase.currentEvent.deleteUser(DataBase.current_user);
                };
            }
        }
        




    }
}