using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

using TeamEventApp.Droid.Adapters;
using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_group")]
    public class GroupActivity : Activity
    {
        public static Group current_group;
        //tableItems va contenir "membres","admins","events"
        List<GroupRow> tableItems = new List<GroupRow>();
        List<GroupRowItem> mb = new List<GroupRowItem>();
        List<GroupRowItem> adm = new List<GroupRowItem>();
        List<GroupRowItem> ev = new List<GroupRowItem>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            ExpandableListView elv = FindViewById<ExpandableListView>(Resource.Id.ExLV);
            TextView gntv = FindViewById<TextView>(Resource.Id.groupNameTextView);

            //on récupère le nom du grp selectionné dans GroupManagerActivity
            foreach (Group grp in DataBase.current_user.groups)
            {
                if (grp.groupName == GroupManagerActivity.current_group_selected.groupName)
                    gntv.Text =grp.groupName;
            }

            string group_name = GroupManagerActivity.current_group_selected.groupName;
            //on affecte le groupe courant au groupe selectionné
            foreach (Group grp in DataBase.current_user.groups)
            {
                if (grp.groupName == group_name)
                {
                    current_group = grp;
                }
            }             
            //liste avec noms des membres
            foreach (User us in current_group.members)
            {
                GroupRowItem gri = new GroupRowItem();
                gri.Name = us.pseudo;
                mb.Add(gri);
            }
            tableItems.Add(new GroupRow() {
               Row = "Membres",
               RowItems = mb
            });
            //liste avec noms des admins
            foreach (User us in current_group.admins)
            {
               GroupRowItem gri = new GroupRowItem();
               gri.Name = us.pseudo;
               adm.Add(gri);
            }
            tableItems.Add(new GroupRow()
            {
               Row = "Admins",
               RowItems = adm
            });
            //liste avec noms des events
            foreach (Event e in current_group.events)
            {
               GroupRowItem gri = new GroupRowItem();
               gri.Name = e.eventName;
               ev.Add(gri);
             }
             tableItems.Add(new GroupRow()
               {
                  Row = "Evènements",
                  RowItems = ev
               });
            ExpandableListAdapter adapter = new ExpandableListAdapter(this, tableItems);
            elv.SetAdapter(adapter);
        }

        // Adding the menu

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

                case Resource.Id.action_addEvent:
                    //Fragment add event
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