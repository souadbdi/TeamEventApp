using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_group_manager")]
    public class GroupManagerActivity : Activity
    {
        public static Group current_group_selected;
        List<string> items = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "accueil" layout resource
            SetContentView(Resource.Layout.GroupManager);

            //Vue qui va contenir la liste des groupes de l'utilisateur
            ListView lv = FindViewById<ListView>(Resource.Id.List);
            lv.ChoiceMode = ChoiceMode.Single;  //On ne peut selectionné qu'un item
            
            //On remplit la liste items avec les noms de groupes du user

            foreach (Group grp in DataBase.current_user.groups)
            {
                items.Add(grp.groupName);
            }

            //on remplit le ListView avec la liste items
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            lv.Adapter = adapter;
            
            lv.ItemClick += OnListItemClick;

        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           // on affecte le group courant avec l'item selectionné
            foreach(Group grp in DataBase.current_user.groups)
            {
                if(grp.groupName == items[e.Position])
                {
                    current_group_selected = grp;
                }
            }

            //apparition d'un ToastMessage avec le nom de l'item selectionné et lancement de GroupActivity
            Toast.MakeText(this, current_group_selected.groupName, ToastLength.Short).Show();
            StartActivity(typeof(GroupActivity));
        }


        // Setting the Menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu_add_option, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        // Setting menu actions

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
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