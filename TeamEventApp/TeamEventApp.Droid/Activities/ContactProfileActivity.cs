
using Android.App;
using Android.OS;
using Android.Widget;
using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "ContactProfileActivity")]
    public class ContactProfileActivity : Activity
    {
        private User contact;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ContactProfile);

            //on affecte le contact selectionné dans la liste de contacts du current_user au user "contact"
            foreach(User user in DataBase.current_user.contacts)
            {
                if(user.pseudo == ProfilContactsFragment.contact_selected.pseudo)
                {
                    contact = user;
                }                   
            }

            //instanciation des champs
            TextView prenom = FindViewById<TextView>(Resource.Id.profile_contact_firstName);
            prenom.Text = contact.firstName;

            TextView nom = FindViewById<TextView>(Resource.Id.profile_contact_lastName);
            nom.Text = contact.lastName;

            TextView pseudo = FindViewById<TextView>(Resource.Id.profile_contact_name);
            pseudo.Text = contact.pseudo;

            TextView email = FindViewById<TextView>(Resource.Id.profile_contact_email);
            email.Text = contact.email;

            TextView adr = FindViewById<TextView>(Resource.Id.profile_contact_location);
            adr.Text = contact.localisation;

            TextView nb_events = FindViewById<TextView>(Resource.Id.profile_contact_events_number);
            int nb_e = 0;
            foreach(Group grp in contact.groups)
            {
                nb_e += grp.events.Count;
            }
            nb_events.Text = nb_e.ToString();

            TextView nb_groups = FindViewById<TextView>(Resource.Id.profile_contact_groups_number);
            int nb_g = contact.groups.Count;
            nb_groups.Text = nb_g.ToString();

            TextView nb_contacts = FindViewById<TextView>(Resource.Id.contacts_number);
            nb_contacts.Text = contact.contacts.Count.ToString();

            TextView statut = FindViewById<TextView>(Resource.Id.profile_contact_status);
            statut.Text = contact.status;

            //suppression du contact
            Button delete = FindViewById<Button>(Resource.Id.delete_contact_text);
            delete.Click += delegate 
            {
                DataBase.current_user.removeContact(contact);
                contact.removeContact(DataBase.current_user);
                StartActivity(typeof(ProfileActivity));
            };


        }
    }
}