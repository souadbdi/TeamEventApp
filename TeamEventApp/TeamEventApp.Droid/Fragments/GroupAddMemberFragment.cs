
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid.Fragments
{
    class GroupAddMemberFragment : DialogFragment
    {
        EditText pseudo_membre;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.AddGroupMember, container, false);

            Button add_member = view.FindViewById<Button>(Resource.Id.add_member_btn);
            pseudo_membre = view.FindViewById<EditText>(Resource.Id.member_pseudo_editText);

            //action ajouter membre
            add_member.Click += delegate 
            {
                var isMySelf = false;
                if(pseudo_membre.Text == DataBase.current_user.pseudo)
                {
                    isMySelf = true;
                }
                var isUserContact = false;
                //on parcourt la liste des contacts du current_user et on regarde si celui qu'on ajoute en fait partie
                foreach(User user in DataBase.current_user.contacts)
                {
                    if(pseudo_membre.Text == user.pseudo)
                    {
                        isUserContact = true;
                        //on parcourt tous les grp du current_user et on se place dans celui qu'on a sélectionné
                        foreach(Group grp in DataBase.current_user.groups)
                        {
                            if(grp.groupName == GroupActivity.current_group.groupName)
                            {
                                //on vérifie que le contact qu'on ajoute n'est pas déjà membre du grp
                                var isAlreadyMember = false;
                                foreach(User us in grp.members)
                                {
                                    if (pseudo_membre.Text == us.pseudo)
                                    {
                                        isAlreadyMember = true;
                                        pseudo_membre.SetError("Cet utilisateur fais déjà partie du groupe !", null);
                                    }
                                }
                                if (!isAlreadyMember && !isMySelf)
                                {
                                    grp.addMember(user);
                                    user.addGroup(grp);
                                    Activity.StartActivity(typeof(GroupActivity));
                                }                                  
                            }
                        }
                    }
                }
                if(isMySelf)
                    pseudo_membre.SetError("Vous êtes déjà membre du groupe !", null);
                else if (!isUserContact)
                    pseudo_membre.SetError("Cet utilisateur ne fait pas partie de vos contacts !", null);
            };

            return view;
        }
    }
}