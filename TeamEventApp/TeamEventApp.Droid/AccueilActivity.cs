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

namespace TeamEventApp.Droid
{
    [Activity(Label = "Accueil")]
    public class AccueilActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "accueil" layout resource
            SetContentView(Resource.Layout.Accueil);

            ListView lv = FindViewById<ListView>(Resource.Id.List);
            List<string> items = new List<string>();



            foreach (Group grp in users_db[1].groups)
            {
                items.Add(grp.groupName);
            }

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemActivated1, items);
            lv.Adapter = adapter;

            lv.ItemClick += OnListItemClick;
            Button agbutton = FindViewById<Button>(Resource.Id.addGroupButton);

            agbutton.Click += delegate {
                Intent intent = new Intent(this.ApplicationContext, typeof(AddGroupActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            };
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartActivity(typeof(GroupActivity));
        }
    }
}