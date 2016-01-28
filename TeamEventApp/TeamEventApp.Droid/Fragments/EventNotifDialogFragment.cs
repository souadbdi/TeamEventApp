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
using TeamEventApp.Droid.Adapters;

namespace TeamEventApp.Droid.Fragments
{
    class EventNotifDialogFragment : DialogFragment
    {

        // Attributes


        EditText notifContentET;
        ImageButton notifValidButton;


        // Service
        UserService uService;

        // Listes
        private List<Notification> notifList;
        private ListView listView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.EventNotifList, container, false);

            // Service
            uService = new UserService(DataBase.current_user);

            // ListView
            listView = view.FindViewById<ListView>(Resource.Id.event_notif_listView);

            // views
            // Comment content
            notifContentET = view.FindViewById<EditText>(Resource.Id.event_notifWrite_text);

            // valid button
            notifValidButton = view.FindViewById<ImageButton>(Resource.Id.event_notifSend_btn);
            if (notifValidButton != null)
                notifValidButton.Click += delegate
                {
                    Notification notif = publishNotification();

                    // Ajout du commentaire dans l'événement
                    notifList = DataBase.currentEvent.addNotification(notif);

                    // Refresh the list
                    EventNotifAdapter newAdapter = new EventNotifAdapter(Activity, notifList);
                    listView.Adapter = newAdapter;
                };

            // Notifications list : liste des notifications de l'événement courant
            notifList = DataBase.currentEvent.notifications;

            // Create and set the adapter
            EventNotifAdapter adapter = new EventNotifAdapter(Activity, notifList);

            if (listView != null)
                listView.Adapter = adapter;

            // Return
            return view;
        }

        // 
        private Notification publishNotification()
        {
            string content = "";

            if (notifContentET != null)
            {
                content = notifContentET.Text;
                notifContentET.Text = "";         // flush 
            }

            // Object
            Notification notif = new Notification
            {
                note = content,
                date = DateTime.Now,
                views = 0,
                userId = DataBase.current_user.userId,
                eventId = DataBase.currentEvent.eventId
            };


            return notif;
        }
   
    }
}