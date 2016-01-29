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

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "InviteContactActivity")]
    public class InviteContactActivity : Activity
    {

        private List<User> usersList;
        private ListView listView;

        // Service

        UserService uService;


        // Views

        ImageButton addContactImageButton;
        Button validListButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserContactListView);

            // Service
            uService = new UserService(DataBase.current_user);

            // Notifications list initialement vide
            usersList = new List<User> { };

            // AutoCompleteTextView
            AutoCompleteTextView pseudoAutoText = FindViewById<AutoCompleteTextView>(Resource.Id.userContact_pseudo_autoText);

            // ImageButton

            addContactImageButton = FindViewById<ImageButton>(Resource.Id.userContact_add_button);

            if (addContactImageButton != null)
                addContactImageButton.Click += delegate
                {
                    if (pseudoAutoText.Text != "")
                    {
                        // Ajouter à la liste
                        usersList = addUserToList(pseudoAutoText.Text);

                        // Vider le champ
                        pseudoAutoText.Text = "";

                        // Mettre à jour la liste
                        UserContactListAdapter updatedAdapter = new UserContactListAdapter(this, usersList);

                        if (listView != null)
                            listView.Adapter = updatedAdapter;
                    }
                };
                
            
            // ListView
            listView = FindViewById<ListView>(Resource.Id.userContact_listView);


            // Valider la liste
            validListButton = FindViewById<Button>(Resource.Id.userContact_valid_button);

            if (validListButton != null)
                validListButton.Click += delegate
                {
                    // Inviter les contacts
                    inviteAddedContact(usersList);

                    //Revenir sur l'activité
                    StartActivity(typeof(EventActivity));
                };



            // Create and set the adapters of
            UserContactListAdapter adapter = new UserContactListAdapter(this, usersList);


            // On construit la liste des noms pour l'autocomplétion à partir des contacts de l'utilisateur
            ArrayAdapter<string> itemsAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, getUserNamesTab(uService.GetAllUserContacts()));

            if (pseudoAutoText != null)
                pseudoAutoText.Adapter = itemsAdapter;

            if (listView != null)
                listView.Adapter = adapter;


            // Modification de la liste après clic sur le bouton +

        }


        // Ajouter un nom dans la liste
        public List<User> addUserToList(string pseudoUser)
        {
            User user = uService.GetUserContactByPseudo(pseudoUser);

            // Si on le trouve, on l'ajoute à la liste des utilisteurs temporaires
            if (user != null)
                usersList.Add(user);

            return usersList;
        }

        // Setting of the namesList des amis du même groupe
        private string[] getUserNamesTab(List<User> userList)
        {
            string[] namesTab = new string[userList.Count];
            int i = 0;

            // Dans la liste d'amis de l'utilisateur
            // Si un ami fait parti du groupe de l'événement, le proposer

            foreach(User user in userList)
            {
                Group eventGroup = uService.GetUserGroupById(DataBase.currentEvent.groupId);
                bool isMember = false;

                if (eventGroup != null)
                    foreach (User us in eventGroup.members)
                    {
                        if (us == user)
                        {
                            isMember = true;
                            break;
                        }
                    }

                // S'il est concerné
                if (isMember)
                {
                    namesTab[i] = user.pseudo;
                    i++;
                }
            }

            return namesTab;
        }


        // Inviter les contacts après validation

        private void inviteAddedContact(List<User> userList)
        {
            foreach (User user in userList)
            {
                // On ajoute l'utilisateur dans la liste des invités
                DataBase.currentEvent.addUser(user);

                // On ajout l'événement dans la liste des
            }
        }


        // Supprimer un contact

        public void deleteUser(User user)
        {
            usersList.Remove(user);

            // Mettre à jour la liste
            UserContactListAdapter updatedAdapter = new UserContactListAdapter(this, usersList);

            if (listView != null)
                listView.Adapter = updatedAdapter;
        }
    }
}