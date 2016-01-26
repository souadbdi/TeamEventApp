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

namespace TeamEventApp.Droid.Adapters
{
    public class ProfileContactAdapter : BaseAdapter<UserList>
    {
        List<UserList> contactList;
        Activity context;

        // Constructor
        public ProfileContactAdapter(Activity context, List<UserList> cList) :base()
        {
            this.contactList = cList;
            this.context = context;
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        public override UserList this[int position]
        {
            get
            {
                return contactList[position];
            }
        }

        // 
        public override int Count
        {
            get
            {
                return contactList.Count;
            }
        }

        // 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var contact = contactList[position];
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ProfileContactRow,null);
            }

            view.FindViewById<TextView>(Resource.Id.contact_pseudo_text).Text = contact.Heading;
            view.FindViewById<TextView>(Resource.Id.contact_name_text).Text = contact.SubHeading;
            view.FindViewById<ImageButton>(Resource.Id.delete_contact_btn).SetImageResource(contact.ImageResourceId);

            return view;
        }
    }
}