using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid.Fragments
{
    public class GroupMembersFragment : DialogFragment
    {
        List<string> membres = new List<string>();
        ListView membres_listview;
        public static Group current_group;
        public static User mb_selected;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.GroupMembers, container, false);

            membres_listview = view.FindViewById<ListView>(Resource.Id.membersList);
            //on se place dans le bon groupe
            foreach(Group grp in DataBase.current_user.groups)
            {
                if (grp.groupName == GroupActivity.current_group.groupName)
                    current_group = grp;
            }

            //on remplit la liste de membres
            foreach (User user in current_group.members)
            {
                membres.Add(user.pseudo);
            }

            // Create and set the adapter
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, membres);
            membres_listview.Adapter = adapter;


            //affichage du membre
            membres_listview.ItemClick += OnListItemClick;

            // Actions pour l'ajout de contact
            TextView addMember = view.FindViewById<TextView>(Resource.Id.add_member_text);

            addMember.Click += delegate
            {
                
            };

            // Return
            return view;
        }

        public void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // on affecte le contact_selected avec l'item selectionné
            foreach (User us in current_group.members)
            {

                if (us.pseudo == membres[e.Position])
                {
                    
                    if (us != DataBase.current_user)
                    {
                        mb_selected = us;
                        Activity.StartActivity(typeof(GroupMemberActivity));
                    }
                        
                }
                
            }
           
            
        }
    }
}