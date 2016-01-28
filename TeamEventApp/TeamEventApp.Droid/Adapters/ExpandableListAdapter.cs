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
    public class ExpandableListAdapter : BaseExpandableListAdapter
    {
        // Context, usually set to the activity:
        private readonly Context _context;

        // List of produce objects 
        private readonly List<GroupRow> _grouprow;

        public ExpandableListAdapter(Context context, List<GroupRow> grouprow)
        {
            _context = context;
            _grouprow = grouprow;
        }

        public override bool HasStableIds
        {
            // Indexes are used for IDs:
            get { return true; }
        }

        //---------------------------------------------------------------------------------------
        // Group methods:

        public override long GetGroupId(int groupPosition)
        {
            // The index of the group is used as its ID:
            return groupPosition;
        }

        public override int GroupCount
        {
            // Return the number of produce  objects:
            get { return _grouprow.Count; }
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            // Recycle a previous view if provided:
            var view = convertView;

            // If no recycled view, inflate a new view as a simple expandable list item 1:
            if (view == null)
            {
                var inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem1, null);
            }

            // Grab the produce object at the group position:
            var grouprow = _grouprow[groupPosition];

            // Get the built-in first text view and insert the group name 
            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            textView.Text = grouprow.Row;

            return view;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return null;
        }

        //---------------------------------------------------------------------------------------
        // Child methods:

        public override long GetChildId(int groupPosition, int childPosition)
        {
            // The index of the child is used as its ID:
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            // Return the number of children (produce item objects) in the group (produce object):
            var grouprow = _grouprow[groupPosition];
            return grouprow.RowItems.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            // Recycle a previous view if provided:
            var view = convertView;

            // If no recycled view, inflate a new view as a simple expandable list item 2:
            if (view == null)
            {
                var inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem2, null);
            }

            // Grab the produce object at the group position:
            var grouprow = _grouprow[groupPosition];

            // Extract the produce item object at the child position:
            var rowItem = grouprow.RowItems[childPosition];

            // Get the built-in first text view and insert the child name
            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            textView.Text = rowItem.Name;

            return view;
        }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return null;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }



    }
}