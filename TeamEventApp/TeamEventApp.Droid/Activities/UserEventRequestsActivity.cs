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
    [Activity(Label = "@string/label_event_requests")]
    public class UserEventRequestsActivity : Activity
    {
        private List<UserEventRequest> uerList;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserEventRequestList);

            // Ajout de la liste d'affichages des demandes
            listView = FindViewById<ListView>(Resource.Id.profile_req_list);

            uerList = new List<UserEventRequest> { };

            uerList.Add(new UserEventRequest
            {
                Title = "Partie Bowling",
                Subtitle = "Partie de bowling pour l'anniversaire de Dalie le vendredi",
                Date = "20 Jan 16"
            });

            uerList.Add(new UserEventRequest
            {
                Title = "Culte des jeunes",
                Subtitle = "Dernier culte des jeunes de l'année",
                Date = "10 Juin 16"
            });

            uerList.Add(new UserEventRequest
            {
                Title = "AGAPE GI 78",
                Subtitle = "Communion fraternelle du GI des Yvelines!!!",
                Date = "5 Mars 16"
            });

            uerList.Add(new UserEventRequest
            {
                Title = "Répétition ICJ 2016",
                Subtitle = "Répétition pour la conférence des jeunes du 28 Avril!!!",
                Date = "20 Mars 16"
            });


            // Create the adapter
            UserEventRequestLVA adapter = new UserEventRequestLVA(this, uerList);

            // set the adapter
            listView.Adapter = adapter;
        }
    }
}