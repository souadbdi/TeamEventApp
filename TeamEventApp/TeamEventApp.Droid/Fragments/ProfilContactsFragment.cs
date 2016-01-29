using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid.Fragments
{
    public class ProfilContactsFragment : DialogFragment
    {
        List<string> contacts = new List<string>();
        ListView contacts_listview;
        public static User contact_selected;

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
            contacts_listview.Adapter = adapter;


            //affichage du contact
            contacts_listview.ItemClick += OnListItemClick;
  
            // Actions pour l'ajout de contact
            TextView addContact = view.FindViewById<TextView>(Resource.Id.add_contact_text);

            addContact.Click += delegate
            {
                Activity.StartActivity(typeof(AddContactActivity));
            };

            // Return
            return view;
        }

        public void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
         {
            // on affecte le contact_selected avec l'item selectionné
            foreach (User us in DataBase.current_user.contacts)
                {
                
                    if (us.pseudo == contacts[e.Position])
                    {
                        contact_selected = us;
                    }
                }
            Activity.StartActivity(typeof(ContactProfileActivity));
          }
    }
}