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
    class UsersDialogFragment : DialogFragment
    {
        //Attributes
        private List<User> usersList;
        private ListView listView;



        // Constructeur qui prend en paramètres la liste des utilisateurs à afficher
        public UsersDialogFragment (List<User> uList)
        {
            this.usersList = uList;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.UserListView, container, false);

            // ListView
            listView = view.FindViewById<ListView>(Resource.Id.user_listView);

            // Notifications list

            // Create and set the adapter
            UsersListAdapter adapter = new UsersListAdapter(Activity, usersList);

            if (listView != null)
                listView.Adapter = adapter;

            return view;
        }
    }
}