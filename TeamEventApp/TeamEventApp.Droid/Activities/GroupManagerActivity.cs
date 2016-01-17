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
            SetContentView(Resource.Layout.GroupManager);

            //Vue qui va contenir la liste des groupes de l'utilisateur
            ListView lv = FindViewById<ListView>(Resource.Id.List);
            lv.ChoiceMode = ChoiceMode.Single;  //On ne peut selectionn� qu'un item
            
            //On remplit la liste items avec les noms de groupes du user

            foreach (Group grp in users_db[1].groups)
            {
                items.Add(grp.groupName);
            }

            //on remplit le ListView avec la liste items
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemActivated1, items);
            lv.Adapter = adapter;
            
            lv.ItemClick += OnListItemClick;

        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           // on affect le nom de l'item selectionn� � groupSelect
            groupSelect = items[e.Position];

            //apparition d'un ToastMessage avec le nom de l'item selectionn�
            Android.Widget.Toast.MakeText(this, groupSelect, Android.Widget.ToastLength.Short).Show();

            //On lance l'activit� GroupActivity en r�cup�rant la valeur de groupSelect pour 
            //pouvoir la r�utiliser dans GroupActivity
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
                case Resource.Id.action_notifications:
                    StartActivity(typeof(NotificationActivity));
                    return true;

                case Resource.Id.action_profile:
                    StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.action_event_manager:
                    StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.action_group_manager:
                    StartActivity(typeof(GroupManagerActivity));
                    return true;

                case Resource.Id.action_about:
                    StartActivity(typeof(AboutActivity));
                    return true;

                case Resource.Id.action_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;

                case Resource.Id.action_search:
                    // afficher la barre de recherche
                    return true;

                case Resource.Id.action_add:
                    startAddActivity();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        // Switch to AddGroupActivity

        private void startAddActivity()
        {
            Intent intent = new Intent(this.ApplicationContext, typeof(AddGroupActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }

    }
}