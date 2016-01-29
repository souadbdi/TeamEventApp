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

namespace TeamEventApp.Droid.Adapters
{
    class EventAdapter : BaseAdapter<Event>
    {
        public List<Event> eventList;
        public Context context;

        // Constructor
        public EventAdapter(Context ctx, List<Event> elist)
        {
            this.eventList = elist;
            this.context = ctx;
        }

        // 
        public override int Count
        {
            get
            {
                return eventList.Count;
            }
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        //
        public override Event this[int position]
        {
            get
            {
                return eventList[position];
            }
        }

        // 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.EventListRow, null, false);
            }


            // Name of the event
            TextView textTitle = row.FindViewById<TextView>(Resource.Id.evm_title_text);
            textTitle.Text = eventList[position].eventName;

            // Date start - end            
            TextView textDate = row.FindViewById<TextView>(Resource.Id.evm_date_text);
            textDate.Text = eventList[position].toStringStartEndDate();

            // Location
            TextView textLocation = row.FindViewById<TextView>(Resource.Id.evm_location_text);
            textLocation.Text = eventList[position].address;

            // Group of Event
            TextView textGroup = row.FindViewById<TextView>(Resource.Id.evm_group_text);

            // Get group Id and name
            long groupID = eventList[position].groupId;
            UserService uService = new UserService(DataBase.current_user);

            string groupName = uService.GetUserGroupById(groupID).groupName;

            textGroup.Text = "Du groupe " + groupName;

            // Vérification si l'utilisateur a répondu

            LinearLayout linearLayout = row.FindViewById<LinearLayout>(Resource.Id.evm_answer_layout);
            if (linearLayout != null)
            { 
                //if (eventList[position].hasAnsweredUser(DataBase.current_user) != 0)
                    linearLayout.Visibility = ViewStates.Gone;
                
                /* S'il n'a pas répondu
                else
                {
                    Button yesButton = row.FindViewById<Button>(Resource.Id.evm_yes_btn);
                    if (yesButton != null)
                        yesButton.Click += delegate
                        {
                            DataBase.currentEvent.addYesUser(DataBase.current_user);
                            //context.StartActivity(typeof(EventManagerActivity));
                        };

                    Button maybeButton = row.FindViewById<Button>(Resource.Id.evm_maybe_btn);
                    if (maybeButton != null)
                        maybeButton.Click += delegate
                        {
                            DataBase.currentEvent.addMaybeUser(DataBase.current_user);
                            context.StartActivity(typeof(EventManagerActivity));
                        };

                    Button noButton = row.FindViewById<Button>(Resource.Id.evm_no_btn);
                    if (noButton != null)
                        noButton.Click += delegate
                        {
                            DataBase.currentEvent.addNoUser(DataBase.current_user);
                            context.StartActivity(typeof(EventManagerActivity));
                        };

                }*/
            }

 

            return row;
        }
    }
}