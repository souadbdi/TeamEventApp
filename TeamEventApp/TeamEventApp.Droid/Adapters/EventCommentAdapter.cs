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
    

    class EventCommentAdapter : BaseAdapter<Comment>
    {
        //Attributes
        public List<Comment> commentList;
        public Context context;

        // Constructor
        public EventCommentAdapter(Context ctx, List<Comment> elist)
        {
            this.commentList = elist;
            this.context = ctx;
        }

        // 
        public override int Count
        {
            get
            {
                return commentList.Count;
            }
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        //
        public override Comment this[int position]
        {
            get
            {
                return commentList[position];
            }
        }

        // 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.EventCommentRow, null, false);
            }


            // Name of the event
            TextView textUserName = row.FindViewById<TextView>(Resource.Id.event_commentUser);

            if (DataBase.currentEvent != null)
                textUserName.Text = DataBase.currentEvent.getUserNameById(commentList[position].userID);

            else if (GroupActivity.current_group != null)
                textUserName.Text = GroupActivity.current_group.getUserNameById(commentList[position].userID);

            // Date start          
            TextView textDate = row.FindViewById<TextView>(Resource.Id.event_commentDate);
            textDate.Text = commentList[position].toStringDate();

            // Content of Event
            TextView textContent = row.FindViewById<TextView>(Resource.Id.event_commentContent);
            textContent.Text = commentList[position].message;

            return row;
        }

    }
}