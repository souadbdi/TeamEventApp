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
using TeamEventApp.Droid.ListViewRows;
using TeamEventApp.Droid.Adapters;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "@string/label_group_requests")]
    public class UserGroupRequestActivity : Activity
    {
        private List<UserGroupRequest> uerList;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserGroupRequestList);

            // Ajout de la liste d'affichages des demandes
            listView = FindViewById<ListView>(Resource.Id.profile_req_list);

            uerList = new List<UserGroupRequest> { };

            uerList.Add(new UserGroupRequest
            {
                Title = "Friends du 78",
                Subtitle = "Ajouté par Leslie Kipole",
                Date = "20 Jan 16"
            });

            uerList.Add(new UserGroupRequest
            {
                Title = "Cercle des jeunes",
                Subtitle = "Ajouté par Henri Villard",
                Date = "10 Juin 16"
            });

            uerList.Add(new UserGroupRequest
            {
                Title = "AGAPE GI 78",
                Subtitle = "Ajouté par Franck Berger",
                Date = "5 Mars 16"
            });

            uerList.Add(new UserGroupRequest
            {
                Title = "Révélation",
                Subtitle = "Ajouté par Rollande DAN",
                Date = "20 Mars 16"
            });


            // Create the adapter
            UserGroupRequestAdapter adapter = new UserGroupRequestAdapter(this, uerList);

            // set the adapter
            listView.Adapter = adapter;
        }
    }
}