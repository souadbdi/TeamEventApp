using Android.App;
using Android.OS;
using Android.Widget;
using TeamEventApp.Droid.Activities;

using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_profile")]
    public class ProfileActivity : Activity
    {
        private TextView pseudo;
        private TextView email;
        private TextView adr;
        private TextView events_number;
        private TextView groups_number;
        private TextView status;
        private TextView demandes_groupes;
        private TextView contacts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            //initialisation du profil
            pseudo = FindViewById<TextView>(Resource.Id.profile_name);
            pseudo.Text = MainActivity.database.current_user.pseudo;

            email = FindViewById<TextView>(Resource.Id.profile_email);
            email.Text = MainActivity.database.current_user.email;

            adr = FindViewById<TextView>(Resource.Id.profile_location);
            adr.Text = MainActivity.database.current_user.localisation;

            events_number = FindViewById<TextView>(Resource.Id.profile_events_number);
            //nombre d'�v�nements du user (parcourir tous ses groupes)

            groups_number = FindViewById<TextView>(Resource.Id.profile_groups_number);
            groups_number.Text = MainActivity.database.current_user.groups.Count.ToString();

            status = FindViewById<TextView>(Resource.Id.profile_status_text);
            status.Text = MainActivity.database.current_user.status;

            demandes_groupes = FindViewById<TextView>(Resource.Id.profile_req_number);
            //demandes d'ajout groupe

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
                contactsDialog.Show(tx, "Modifier votre status");
            };

            // Actions pour la liste des demandes � des �v�nements
            TextView textReqList = FindViewById<TextView>(Resource.Id.profile_req_text);
            textReqList.Click += delegate
            {
                StartActivity(typeof(UserGroupRequestActivity));
            };

            //Actions pour l'affichage des contacts
            contacts = FindViewById<TextView>(Resource.Id.profile_contacts_text);
            contacts.Click += delegate
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                ProfilContactsFragment contactsDialog = new ProfilContactsFragment();
                contactsDialog.Show(tx, "Contacts");
            };
        }        
    }
}