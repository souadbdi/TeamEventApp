using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

using TeamEventApp.Droid.Adapters;
using TeamEventApp.Droid.Fragments;
using TeamEventApp.Droid.Activities;
using System;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_group")]
    public class GroupActivity : Activity
    {
        public static Group current_group;


        // Attributes
        private List<Comment> commentList;
        private ListView listView;


        // Views

        EditText comContentET;
        ImageButton comValidButton;


        // Service
        UserService uService;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            string group_name = GroupManagerActivity.current_group_selected.groupName;
            //on affecte le groupe courant au groupe selectionné
            foreach (Group grp in DataBase.current_user.groups)
            {
                if (grp.groupName == group_name)
                {
                    current_group = grp;

                    if (grp != null)
                    Title = current_group.groupName;
                }
            }

            //click sur Membres
            TextView membres = FindViewById<TextView>(Resource.Id.groupMembersTextView);
            membres.Click += delegate 
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                GroupMembersFragment contactsDialog = new GroupMembersFragment();
                contactsDialog.Show(tx, "Membres");
            };

            //click sur Admins
            TextView admins = FindViewById<TextView>(Resource.Id.groupAdminsTextView);
            admins.Click += delegate
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                GroupAdminsFragment contactsDialog = new GroupAdminsFragment();
                contactsDialog.Show(tx, "Admins");
            };

            //click sur évènements
            TextView ev = FindViewById<TextView>(Resource.Id.groupEventsTextView);
            ev.Click += delegate 
            {
                UserService uService = new UserService(DataBase.current_user);
                StartActivity(typeof(GroupEventsActivity));
            };


            // 


            // Service
            uService = new UserService(DataBase.current_user);

            // views
            // Comment content
            comContentET =FindViewById<EditText>(Resource.Id.group_comment_text);

            // valid button
            comValidButton = FindViewById<ImageButton>(Resource.Id.group_commentSend_btn);

            if (comValidButton != null)
                comValidButton.Click += delegate
                {
                    if (comContentET != null)
                    { 
                        Comment comment = publishComment();

                    // Ajout du commentaire dans l'événement

                    if (current_group != null)
                        commentList = current_group.AddComment(comment);

                    // Refresh the list
                    EventCommentAdapter newAdapter = new EventCommentAdapter(this, commentList);
                    listView.Adapter = newAdapter;
                    }
                };

            // ListView
            listView = FindViewById<ListView>(Resource.Id.group_comment_listView);

            // Notifications list : liste de commentaires des événements
            commentList = current_group.GetAllComments();

            // Create and set the adapter
            EventCommentAdapter adapter = new EventCommentAdapter(this, commentList);

            if (listView != null)
                listView.Adapter = adapter;


        }


        // Publication d'un commentaire
        private Comment publishComment()
        {
            string content = "";

           
                content = comContentET.Text;
                comContentET.Text = "";         // flush the field


            // Object
            Comment comment = new Comment
            {
                message = content,
                date = DateTime.Now,
                userID = DataBase.current_user.userId,
                groupID = current_group.groupId
            };


            return comment;

        }


        // Adding the group menu

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.GroupMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_addMember:
                    {
                        FragmentTransaction tx = FragmentManager.BeginTransaction();
                        GroupAddMemberFragment contactsDialog = new GroupAddMemberFragment();
                        contactsDialog.Show(tx, "Ajouter un membre");
                    }
                    return true;

                case Resource.Id.action_addAdmin:
                    {
                        FragmentTransaction tx = FragmentManager.BeginTransaction();
                        GroupAddAdminFragment contactsDialog = new GroupAddAdminFragment();
                        contactsDialog.Show(tx, "Ajouter un administrateur");
                    }
                    return true;

                case Resource.Id.action_changeName:
                    {
                        FragmentTransaction tx = FragmentManager.BeginTransaction();
                        GroupChangeNameFragment contactsDialog = new GroupChangeNameFragment();
                        contactsDialog.Show(tx, "Nom du groupe");
                    }
                    
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}