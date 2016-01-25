using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

using static TeamEventApp.DataBase;
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid.Fragments
{
    class ProfilContactsFragment : DialogFragment
    {
        List<string> contacts = new List<string>();
        ListView contacts_listview;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Contacts, container, false);

            contacts_listview = view.FindViewById<ListView>(Resource.Id.contactList);

            //populate the list contact
            foreach(User user in DataBase.current_user.contacts)
            {
                contacts.Add(user.pseudo);
            }

            // Create and set the adapter
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, contacts);

            if (contacts_listview != null)
                contacts_listview.Adapter = adapter;

            // Actions pour l'ajout de contact
            TextView addContact = view.FindViewById<TextView>(Resource.Id.add_contact_text);

            addContact.Click += delegate
            {
                Activity.StartActivity(typeof(AddContactActivity));
            };

            // Return
            return view;
        }
    }
}