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

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "InviteContactActivity")]
    public class InviteContactActivity : Activity
    {

        private List<User> usersList;
        private ListView listView;
        private string[] nameItems = new string[] { "Hesron", "Tom", "Alexis", "Alex", "Hervet"};

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserContactListView);

            // AutoCompleteTextView
            AutoCompleteTextView pseudoAutoText = FindViewById<AutoCompleteTextView>(Resource.Id.userContact_pseudo_autoText);
            // ListView
            listView = FindViewById<ListView>(Resource.Id.userContact_listView);

            // Notifications list
            usersList = new List<User> { };

            usersList.Add(new User
            {
                pseudo = "hesrondev",
                firstName = "Louange",
                lastName = "Bizib"
            });

            usersList.Add(new User
            {
                pseudo = "hesrondev",
                firstName = "Paris",
                lastName = "Ville"
            });

            usersList.Add(new User
            {
                pseudo = "Louange",
                firstName = "Louange",
                lastName = "Bizib"
            });

            usersList.Add(new User
            {
                pseudo = "Makoma",
                firstName = "KIOp",
                lastName = "BEBE"
            });

            usersList.Add(new User
            {
                pseudo = "Marc25",
                firstName = "Fredine",
                lastName = "Marc"
            });

            // Create and set the adapters
            UserContactListAdapter adapter = new UserContactListAdapter(this, usersList);
            ArrayAdapter<string> itemsAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, nameItems);

            if (pseudoAutoText != null)
                pseudoAutoText.Adapter = itemsAdapter;

            if (listView != null)
                listView.Adapter = adapter;


            // Create your application here
        }
    }
}