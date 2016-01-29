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
using TeamEventApp.Controller;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_event_manager")]
    public class EventManagerActivity : Activity
    {
        private List<Event> eventList;
        private ListView listView;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventManager);

            // ListView

            listView = FindViewById<ListView>(Resource.Id.evm_list_view);
            eventList = new List<Event> { };
            eventList = await EventController.getAllEvent();

            // Create events
            //eventList.Add(new Event
            //{
            //    eventName = "R�p�tition ICJ 2016",
            //    startDate = new DateTime(2016, 11, 1),
            //    endDate = new DateTime(2016, 11, 2),
            //    address = "19 rue Fustel de Coulanges, Paris",
            //});

            //eventList.Add(new Event
            //{
            //    eventName = "R�union Responsables",
            //    startDate = new DateTime(2016, 3, 10),
            //    endDate = new DateTime(2016, 3, 10),
            //    address = "Boissy, France"
            //});

            //eventList.Add(new Event
            //{
            //    eventName = "Restaurant",
            //    startDate = new DateTime(2016, 2, 14),
            //    endDate = new DateTime(2016, 2, 14),
            //    address = "Paris, France"
            //});

            //eventList.Add(new Event
            //{
            //    eventName = "Mariage Bribrik",
            //    startDate = new DateTime(2016, 12, 14),
            //    endDate = new DateTime(2016, 12, 14),
            //    address = "Paris, France"
            //});

            // Create the adapter
            EventAdapter adapter = new EventAdapter(this, eventList);

            // set the adapter
            listView.Adapter = adapter;
        }

        // Setting the Menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu_add_option, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        
    }
}