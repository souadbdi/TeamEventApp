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

        // Services
        private UserService userService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventManager);

            // Setting services
            userService = new UserService(DataBase.current_user);
            
            // Get views from Layout
            listView = FindViewById<ListView>(Resource.Id.evm_list_view);

            // Get the events List
            eventList = userService.GetUserAllEvents();


            // Create the adapter and Click action
            EventAdapter adapter = new EventAdapter(this, eventList);
            listView.Adapter = adapter;

            listView.ItemClick += OnListEventItemClick;
        }



        // List Event Item click handler

        void OnListEventItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Récupération de l'événement sélectionné --> DataBase CurrentEvent

            DataBase.currentEvent = eventList[e.Position];

            // ToastMessage avec nom de l'événement

            Toast.MakeText(this, DataBase.currentEvent.eventName, ToastLength.Short).Show();
            StartActivity(typeof(EventActivity));
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