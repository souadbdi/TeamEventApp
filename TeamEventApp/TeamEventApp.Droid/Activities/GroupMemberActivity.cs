
using Android.App;
using Android.OS;
using Android.Widget;
using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "GroupMemberActivity")]
    public class GroupMemberActivity : Activity
    {
        public User membre;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GroupMember);

            //on affecte le membre selectionné dans la liste des mb du grp au user "membre"
            foreach (User user in GroupMembersFragment.current_group.members)
            {
                if (user.pseudo == GroupMembersFragment.mb_selected.pseudo)
                {
                    membre = user;
                }
            }

            //instanciation des champs
            TextView prenom = FindViewById<TextView>(Resource.Id.group_member_firstName);
            prenom.Text = membre.firstName;

            TextView nom = FindViewById<TextView>(Resource.Id.group_member_lastName);
            nom.Text = membre.lastName;

            TextView pseudo = FindViewById<TextView>(Resource.Id.group_member_name);
            pseudo.Text = membre.pseudo;

            TextView email = FindViewById<TextView>(Resource.Id.group_member_email);
            email.Text = membre.email;

            TextView adr = FindViewById<TextView>(Resource.Id.group_member_location);
            adr.Text = membre.localisation;

            TextView nb_events = FindViewById<TextView>(Resource.Id.group_member_events_number);
            int nb_e = 0;
            foreach (Group grp in membre.groups)
            {
                nb_e += grp.events.Count;
            }
            nb_events.Text = nb_e.ToString();

            TextView nb_groups = FindViewById<TextView>(Resource.Id.group_member_groups_number);
            int nb_g = membre.groups.Count;
            nb_groups.Text = nb_g.ToString();

            TextView nb_contacts = FindViewById<TextView>(Resource.Id.group_member_contacts_number);
            nb_contacts.Text = membre.contacts.Count.ToString();

            TextView statut = FindViewById<TextView>(Resource.Id.group_member_status);
            statut.Text = membre.status;

            //suppression du contact
            TextView delete = FindViewById<TextView>(Resource.Id.delete_member_text);
            delete.Click += delegate
            {
                GroupMembersFragment.current_group.members.Remove(membre);
                membre.removeGroup(GroupMembersFragment.current_group);
                StartActivity(typeof(GroupActivity));
            };

        }
    }
}