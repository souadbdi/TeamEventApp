
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid.Fragments
{
    class GroupAddAdminFragment : DialogFragment
    {
        EditText pseudo_admin;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.AddGroupAdmin, container, false);

            Button add_admin = view.FindViewById<Button>(Resource.Id.add_admin_btn);
            pseudo_admin = view.FindViewById<EditText>(Resource.Id.admin_pseudo_editText);

            //action ajoiter admin
            add_admin.Click += delegate
            {
                var isMySelf = false;
                if (pseudo_admin.Text == DataBase.current_user.pseudo)
                {
                    isMySelf = true;
                }
                //on vérifie que l'utilisateur qu'on ajoute est dans current_user.conatcts
                var isUserContact = false;
                foreach (User user in DataBase.current_user.contacts)
                {
                    if (pseudo_admin.Text == user.pseudo)
                    {
                        isUserContact= true;
                        //on se place dans le groupe selectionné
                        foreach (Group grp in DataBase.current_user.groups)
                        {
                            if (grp.groupName == GroupActivity.current_group.groupName)
                            {
                                //on vérifie qu'il ne fait pas déjà partie des admins
                                var isAlreadyAdmin = false;
                                foreach(User ad in grp.admins)
                                {
                                    if (pseudo_admin.Text == ad.pseudo)
                                        isAlreadyAdmin = true;
                                }
                                if(isAlreadyAdmin)
                                    pseudo_admin.SetError("Cet utilisateur est déjà administrateur du groupe", null);

                                //on vérifie qu'il ne fait pas déjà partie des membres
                                var isAlreadyMember = false;
                                foreach (User ad in grp.members)
                                {
                                    if (pseudo_admin.Text == ad.pseudo)
                                        isAlreadyMember = true;
                                }

                                if(!isAlreadyAdmin && !isMySelf)
                                {
                                    grp.addAdmin(user);
                                    if (!isAlreadyMember)
                                    {
                                        grp.addMember(user);
                                        user.addGroup(grp);
                                    }
                                    Activity.StartActivity(typeof(GroupActivity));
                                }

                            }
                        }
                    }
                }
                if(isMySelf)
                    pseudo_admin.SetError("Vous êtes déja administrateur du groupe !", null);
                else if (!isUserContact)
                    pseudo_admin.SetError("Cet utilisateur ne fait pas partie de vos contacts !", null);
            };

            return view;
        }
    }
}