using Android.App;
using Android.OS;
using Android.Widget;
using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "GroupAdminActivity")]
    public class GroupAdminActivity : Activity
    {
        public User admin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GroupAdmin);

            //on affecte l'admin selectionné dans la liste des adm du grp au user "adm"
            foreach (User user in GroupAdminsFragment.current_group.admins)
            {
                if (user.pseudo == GroupAdminsFragment.adm_selected.pseudo)
                {
                    admin = user;
                }
            }

            //instanciation des champs
            TextView prenom = FindViewById<TextView>(Resource.Id.group_admin_firstName);
            prenom.Text = admin.firstName;

            TextView nom = FindViewById<TextView>(Resource.Id.group_admin_lastName);
            nom.Text = admin.lastName;

            TextView pseudo = FindViewById<TextView>(Resource.Id.group_admin_name);
            pseudo.Text = admin.pseudo;

            TextView email = FindViewById<TextView>(Resource.Id.group_admin_email);
            email.Text = admin.email;

            TextView adr = FindViewById<TextView>(Resource.Id.group_admin_location);
            adr.Text = admin.localisation;

            TextView nb_events = FindViewById<TextView>(Resource.Id.group_admin_events_number);
            int nb_e = 0;
            foreach (Group grp in admin.groups)
            {
                nb_e += grp.events.Count;
            }
            nb_events.Text = nb_e.ToString();

            TextView nb_groups = FindViewById<TextView>(Resource.Id.group_admin_groups_number);
            int nb_g = admin.groups.Count;
            nb_groups.Text = nb_g.ToString();

            TextView nb_contacts = FindViewById<TextView>(Resource.Id.group_admin_contacts_number);
            nb_contacts.Text = admin.contacts.Count.ToString();

            TextView statut = FindViewById<TextView>(Resource.Id.group_admin_status);
            statut.Text = admin.status;

        }
    }
}