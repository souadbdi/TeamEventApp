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
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_event_manager")]
    public class EventManagerActivity : Activity
    {
        private List<Event> eventList;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventManager);

            // ListView

            listView = FindViewById<ListView>(Resource.Id.evm_list_view);
            eventList = new List<Event> { };

            // Create events
            eventList.Add(new Event {
                eventName = "Répétition ICJ 2016",
                startDate = new DateTime(2016, 11, 1),
                endDate = new DateTime(2016, 11, 2),
                address = "19 rue Fustel de Coulanges, Paris",               
            });

            eventList.Add(new Event
            {
                eventName = "Réunion Responsables",
                startDate = new DateTime(2016, 3, 10),
                endDate = new DateTime(2016, 3, 10),
                address = "Boissy, France"
            });

            eventList.Add(new Event
            {
                eventName = "Restaurant",
                startDate = new DateTime(2016, 2, 14),
                endDate = new DateTime(2016, 2, 14),
                address = "Paris, France"
            });

            eventList.Add(new Event
            {
                eventName = "Mariage Bribrik",
                startDate = new DateTime(2016, 12, 14),
                endDate = new DateTime(2016, 12, 14),
                address = "Paris, France"
            });

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
        // Setting menu actions

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_home:
                    StartActivity(typeof(HomeActivity));
                    return true;

                case Resource.Id.action_profile:
                    StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.action_event_manager:
                    StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.action_group_manager:
                    StartActivity(typeof(GroupManagerActivity));
                    return true;

                case Resource.Id.action_about:
                    StartActivity(typeof(AboutActivity));
                    return true;

                case Resource.Id.action_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;

                case Resource.Id.action_search:
                    // afficher la barre de recherche
                    return true;

                case Resource.Id.action_add:
                    StartActivity(typeof(CreateEventActivity));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        }
}