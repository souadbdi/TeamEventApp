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
    class EventNotifAdapter : BaseAdapter<Notification>
    {
        public List<Notification> notifList;
        public Context context;

        // Constructor
        public EventNotifAdapter(Context ctx, List<Notification> elist)
        {
            this.notifList = elist;
            this.context = ctx;
        }

        // 
        public override int Count
        {
            get
            {
                return notifList.Count;
            }
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        //
        public override Notification this[int position]
        {
            get
            {
                return notifList[position];
            }
        }

        // 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.EventNotifRow, null, false);
            }


            // Name of the event
            TextView textUserName = row.FindViewById<TextView>(Resource.Id.event_notif_user);
            textUserName.Text = notifList[position].userName();

            // Date start - end            
            TextView textDate = row.FindViewById<TextView>(Resource.Id.event_notif_date);
            textDate.Text = notifList[position].toStringDate();

            // Location
            TextView textComsNumber = row.FindViewById<TextView>(Resource.Id.event_notif_viewsNumber);
            textComsNumber.Text = notifList[position].toStringCommentsNumber();

            // Group of Event
            TextView textContent = row.FindViewById<TextView>(Resource.Id.event_notif_content);
            textContent.Text = notifList[position].note;

            return row;
        }
    }
}