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
using Java.Lang;
using TeamEventApp.Droid.ListViewRows;

namespace TeamEventApp.Droid.Adapters
{
    class UserEventRequestLVA : BaseAdapter<UserEventRequest>
    {
        public List<UserEventRequest> uerList;
        private Context context;

        // Constructor
        public UserEventRequestLVA (Context context, List<UserEventRequest> eList)
        {
            this.uerList = eList;
            this.context = context;
        }

        // 
        public override int Count
        {
            get
            {
                return uerList.Count;
            }
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        //
        public override UserEventRequest this[int position]
        {
            get
            {
                return uerList[position];
            }
        }

        // 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.UserRequestRow, null, false);
            }

            TextView textTitle = row.FindViewById<TextView>(Resource.Id.rowReq_title);
            textTitle.Text = uerList[position].Title;

            TextView textSubTitle = row.FindViewById<TextView>(Resource.Id.rowReq_subtitle);
            textSubTitle.Text = uerList[position].Subtitle;

            TextView textDate = row.FindViewById<TextView>(Resource.Id.rowReq_date);
            textDate.Text = uerList[position].Date;

            return row;
        }
    }
}