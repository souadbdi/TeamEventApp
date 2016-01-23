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

using static TeamEventApp.DataBase;
using TeamEventApp.Droid.Adapters;
using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_group")]
    public class GroupActivity : Activity
    {
        public Group group = new Group();
        public string gs;
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

            //on récupère dans gs le nom du group selectionné dans AccueilActivity
            gs = this.Intent.GetStringExtra(GroupManagerActivity.groupSelect);

            TextView gntv = FindViewById<TextView>(Resource.Id.groupNameTextView);
            gntv.Text = gs;

            ExpandableListView elv = FindViewById<ExpandableListView>(Resource.Id.ExLV);

            foreach (Group grp in users_db[1].groups)
            {
                if (grp.groupName == gs)
                {
                    //liste avec noms des membres
                    foreach (User us in grp.members)
                    {
                        GroupRowItem gri = new GroupRowItem();
                        gri.Name = us.firstName;
                        mb.Add(gri);
                    }
                    tableItems.Add(new GroupRow() {
                        Row = "Membres",
                        RowItems = mb
                        });

                    //liste avec noms des admins
                    foreach (User us in grp.admins)
                    {
                        GroupRowItem gri = new GroupRowItem();
                        gri.Name = us.firstName;
                        adm.Add(gri);
                    }

                    tableItems.Add(new GroupRow()
                    {
                        Row = "Admins",
                        RowItems = adm
                    });

                    //liste avec noms des events
                    foreach (Event e in grp.events)
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
                }
                group = grp;
            }
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
                    //Fragment add member
                    return true;

                case Resource.Id.action_addAdmin:
                    //Fragment add admin
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