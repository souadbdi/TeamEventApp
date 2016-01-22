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
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid.Fragments
{
    class ProfilContactsFragment : DialogFragment
    {
        List<string> contact = new List<string>();
        ListView clistview;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Contacts, container, false);

            clistview = view.FindViewById<ListView>(Resource.Id.contactList);

            //populate the list contact
            foreach(User user in users_db[1].contacts)
            {
                contact.Add(user.pseudo);
            }

            // Create and set the adapter
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, contact);

            if (clistview != null)
                clistview.Adapter = adapter;

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