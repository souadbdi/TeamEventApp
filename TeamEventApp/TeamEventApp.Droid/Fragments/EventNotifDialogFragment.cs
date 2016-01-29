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
        private List<Notification> notifList;
        private ListView listView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.EventNotifList, container, false);

            // ListView
            listView = view.FindViewById<ListView>(Resource.Id.event_notif_listView);

            // Notifications list
            notifList = new List<Notification> { };

            notifList.Add(new Notification
            {
                note = "Hey, RDV dans 5 minutes les mecs",
                date = new DateTime(),
                views = "5"
            });

            notifList.Add(new Notification
            {
                note = "Je suis là, je vous attends",
                date = new DateTime(),
                views = "1"
            });

            notifList.Add(new Notification
            {
                note = "Un commentaire assez long parce que je suis une femme. Je vais"
                + "de voir continuer sur cette ligne avec des erreurs, c'est pas grave",
                date = new DateTime(),
                views = "5"
            });

            notifList.Add(new Notification
            {
                note = "Je suis là, je vous attends",
                date = new DateTime(),
                views = "1"
            });

            notifList.Add(new Notification
            {
                note = "Je suis là, je vous attends",
                date = new DateTime(),
                views = "1"
            });

            notifList.Add(new Notification
            {
                note = "OK c'est noté!",
                date = new DateTime(),
                views = "1"
            });


            // Create and set the adapter
            EventNotifAdapter adapter = new EventNotifAdapter(Activity, notifList);

            if (listView != null)
                listView.Adapter = adapter;

            // Return
            return view;
        }
    }
}