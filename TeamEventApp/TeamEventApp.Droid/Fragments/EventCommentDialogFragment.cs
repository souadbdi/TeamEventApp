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

namespace TeamEventApp.Droid.Fragments
{
    class EventCommentDialogFragment : DialogFragment
    {
        // Attributes
        private List<Comment> commentList;
        private ListView listView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.EventCommentList, container, false);

            // ListView
            listView = view.FindViewById<ListView>(Resource.Id.event_comment_listView);

            // Notifications list
            commentList = new List<Comment> { };

            commentList.Add(new Comment
            {
                user = "Fabrice",
                message = "Hey, RDV dans 5 minutes les mecs",
                date = new DateTime(),
            });

            commentList.Add(new Comment
            {
                user = "Fabrice",
                message = "Hey, RDV dans 5 minutes les mecs",
                date = new DateTime(),
            });

            commentList.Add(new Comment
            {
                user = "Fabrice",
                message = "Hey, RDV dans 5 minutes les mecs",
                date = new DateTime(),
            });

            commentList.Add(new Comment
            {
                user = "Fabrice",
                message = "Hey, RDV dans 5 minutes les mecs",
                date = new DateTime(),
            });

            commentList.Add(new Comment
            {
                user = "Fabrice",
                message = "Hey, RDV dans 5 minutes les mecs",
                date = new DateTime(),
            });

            // Create and set the adapter
            EventCommentAdapter adapter = new EventCommentAdapter(Activity, commentList);

            if (listView != null)
                listView.Adapter = adapter;

            // Return
            return view;
        }
     }
}