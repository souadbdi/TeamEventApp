using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid.Fragments
{
    public class GroupAdminsFragment : DialogFragment
    {
        List<string> admins = new List<string>();
        ListView admins_listview;
        public static Group current_group;
        public static User adm_selected;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.GroupAdmins, container, false);

            admins_listview = view.FindViewById<ListView>(Resource.Id.adminsList);

            //on se place dans le bon groupe
            foreach (Group grp in DataBase.current_user.groups)
            {
                if (grp.groupName == GroupActivity.current_group.groupName)
                    current_group = grp;
            }

            //on remplit la liste d'admins
            foreach (User user in current_group.admins)
            {
                admins.Add(user.pseudo);
            }

            // Create and set the adapter
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, admins);
            admins_listview.Adapter = adapter;


            //affichage du membre
            admins_listview.ItemClick += OnListItemClick;

            // Actions pour l'ajout de contact
            TextView addAdmin = view.FindViewById<TextView>(Resource.Id.add_admin_text);

            addAdmin.Click += delegate
            {

            };

            // Return
            return view;
        }

        public void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // on affecte le adm_selected avec l'item selectionné
            foreach (User us in current_group.admins)
            {

                if (us.pseudo == admins[e.Position])
                {

                    if (us != DataBase.current_user)
                    {
                        adm_selected = us;
                        Activity.StartActivity(typeof(GroupAdminActivity));
                    }

                }

            }
        }
    }
}