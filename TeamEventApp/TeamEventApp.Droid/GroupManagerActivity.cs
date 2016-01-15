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
    [Activity(Label = "@string/label_group_manager")]
    public class GroupManagerActivity : Activity
    {
        public static string groupSelect;
        List<string> items = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "accueil" layout resource
            SetContentView(Resource.Layout.Accueil);

            //Vue qui va contenir la liste des groupes de l'utilisateur
            ListView lv = FindViewById<ListView>(Resource.Id.List);
            lv.ChoiceMode = ChoiceMode.Single;  //On ne peut selectionné qu'un item
            
            //On remplit la liste items avec les noms de groupes du user
            foreach (Group grp in users_db[1].groups)
            {
                items.Add(grp.groupName);
            }

            //on remplit le ListView avec la liste items
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
           // on affect le nom de l'item selectionné à groupSelect
            groupSelect = items[e.Position];

            //apparition d'un ToastMessage avec le nom de l'item selectionné
            Android.Widget.Toast.MakeText(this, groupSelect, Android.Widget.ToastLength.Short).Show();

            //On lance l'activité GroupActivity en récupérant la valeur de groupSelect pour 
            //pouvoir la réutiliser dans GroupActivity
            Intent intent = new Intent(this.ApplicationContext, typeof(GroupActivity));
            intent.PutExtra(groupSelect, items[e.Position]);
            StartActivity(intent);
        }


        // Setting the Menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu_add_option, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.notifications_item:
                    StartActivity(typeof(NotificationActivity));
                    return true;

                case Resource.Id.profile_item:
                    StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.event_manager_item:
                    StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.group_manager_item:
                    StartActivity(typeof(GroupManagerActivity));
                    return true;

                case Resource.Id.about_item:
                    StartActivity(typeof(AboutActivity));
                    return true;

                case Resource.Id.action_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
    }
}