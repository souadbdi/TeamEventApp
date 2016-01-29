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


        // Views

        EditText comContentET;
        ImageButton comValidButton;



        // Service
        UserService uService;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.EventCommentList, container, false);

            // Service
            uService = new UserService(DataBase.current_user);

            // views
            // Comment content
            comContentET = view.FindViewById<EditText>(Resource.Id.event_comment_text);

            // valid button
            comValidButton = view.FindViewById<ImageButton>(Resource.Id.event_commentSend_btn);
            if (comValidButton != null)
                comValidButton.Click += delegate
                {
                    Comment comment = publishComment();

                    // Ajout du commentaire dans l'événement
                    commentList = DataBase.currentEvent.addComment(comment);

                    // Refresh the list
                    EventCommentAdapter newAdapter = new EventCommentAdapter(Activity, commentList);
                    listView.Adapter = newAdapter;
                };

            // ListView
            listView = view.FindViewById<ListView>(Resource.Id.event_comment_listView);

            // Notifications list : liste de commentaires des événements
            commentList = DataBase.currentEvent.comments;

            // Create and set the adapter
            EventCommentAdapter adapter = new EventCommentAdapter(Activity, commentList);

            if (listView != null)
                listView.Adapter = adapter;

            // Return
            return view;
        }

        // Publication d'un commentaire
        private Comment publishComment()
        {
            string content = "";

            if (comContentET != null)
            {
                content = comContentET.Text;
                comContentET.Text = "";         // flush the field
            }
                

            // Object
            Comment comment = new Comment {
                message = content,
                date = DateTime.Now,
                userID = DataBase.current_user.userId,
                eventId = DataBase.currentEvent.eventId
            };


            return comment;
        }

     }
}