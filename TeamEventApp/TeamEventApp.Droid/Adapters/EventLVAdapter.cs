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
    class EventLVAdapter : BaseAdapter<Event>
    {
        public List<Event> eventList;
        public Context context;

        // Constructor
        public EventLVAdapter(Context ctx, List<Event> elist)
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
            textGroup.Text = "Du groupe " + eventList[position].group;

            return row;
        }
    }
}