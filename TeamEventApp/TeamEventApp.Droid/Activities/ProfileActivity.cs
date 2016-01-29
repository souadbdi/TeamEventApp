using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;

using TeamEventApp.Droid.Activities;

using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_profile")]
    public class ProfileActivity : Activity
    {
        private TextView prenom;
        private TextView nom;
        private TextView pseudo;
        private TextView email;
        private TextView adr;
        private TextView events_number;
        private TextView groups_number;
        private TextView status;
        private TextView demandes_groupes;
        private TextView contacts;
        private TextView contacts_number;
        private TextView logoutText;

        private TextView profile_events;
        private TextView profile_groups;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            //initialisation du profil
            prenom = FindViewById<TextView>(Resource.Id.profile_firstName);
            prenom.Text = DataBase.current_user.firstName + " " + DataBase.current_user.lastName;

            pseudo = FindViewById<TextView>(Resource.Id.profile_name);
            pseudo.Text = DataBase.current_user.pseudo;

            email = FindViewById<TextView>(Resource.Id.profile_email);
            email.Text = DataBase.current_user.email;

            adr = FindViewById<TextView>(Resource.Id.profile_location);
            adr.Text = DataBase.current_user.localisation;

            //nombre d'évènements du user (on parcoure tous ses groupes)
            events_number = FindViewById<TextView>(Resource.Id.profile_events_number);
            int nb_events = 0;
            foreach(Group grp in DataBase.current_user.groups)
            {
                nb_events += grp.events.Count;
            }
            events_number.Text = nb_events.ToString();

            //action nb events -> EventManager
            profile_events = FindViewById<TextView>(Resource.Id.profile_events_text);

            if (profile_events != null)
                profile_events.Click += delegate {
                    StartActivity(typeof(EventManagerActivity));
                };

            //nb de grp du current_user
            groups_number = FindViewById<TextView>(Resource.Id.profile_groups_number);
            groups_number.Text = DataBase.current_user.groups.Count.ToString();

            status = FindViewById<TextView>(Resource.Id.profile_status_text);
            status.Text = DataBase.current_user.status;

            profile_groups = FindViewById<TextView>(Resource.Id.profile_groups_text);

            if (profile_groups != null)
                profile_groups.Click += delegate
                {
                    StartActivity(typeof(GroupManagerActivity));
                };

            //demandes d'ajout groupe
            demandes_groupes = FindViewById<TextView>(Resource.Id.profile_req_number);
           

            //action edit profil
            ImageButton edit = FindViewById<ImageButton>(Resource.Id.profile_editProfile_btn);
            edit.Click += delegate
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                ProfilEditProfileFragment contactsDialog = new ProfilEditProfileFragment();
                contactsDialog.Show(tx, "Modifier le profil");
            };

            //action edit status
            ImageButton edit_status = FindViewById<ImageButton>(Resource.Id.profile_editStatus_btn);
            edit_status.Click += delegate
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                ProfilEditStatusFragment contactsDialog = new ProfilEditStatusFragment();
                contactsDialog.Show(tx, "Modifier votre statut");
            };

            // Actions pour la liste des demandes à des événements
            TextView textReqList = FindViewById<TextView>(Resource.Id.profile_req_text);
            textReqList.Click += delegate
            {
                StartActivity(typeof(UserGroupRequestActivity));
            };

            //
            logoutText = FindViewById<TextView>(Resource.Id.profile_logout);
            if (logoutText != null)
                logoutText.Click += delegate
                {
                    DataBase.Logout();
                    StartActivity(typeof(LoginActivity));
                };

            //nb de contacts
            contacts_number = FindViewById<TextView>(Resource.Id.profile_contacts_number);
            int nb_c = DataBase.current_user.contacts.Count;
            contacts_number.Text = nb_c.ToString();

            //Actions pour l'affichage des contacts
            contacts = FindViewById<TextView>(Resource.Id.profile_contacts_text);
            contacts.Click += delegate
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                ProfilContactsFragment contactsDialog = new ProfilContactsFragment();
                contactsDialog.Show(tx, "Contacts");
            };

        }

        // Adding the menu

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_home:
                    StartActivity(typeof(HomeActivity));
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
                    StartActivity(typeof(EventActivity));
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