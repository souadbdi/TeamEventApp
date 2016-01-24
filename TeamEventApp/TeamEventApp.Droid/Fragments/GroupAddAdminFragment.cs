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

            add_admin.Click += delegate
            {
                var test = false;
                foreach (User user in MainActivity.database.current_user.contacts)
                {
                    if (pseudo_admin.Text == user.pseudo)
                    {
                        test = true;
                        foreach (Group grp in MainActivity.database.current_user.groups)
                        {
                            if (grp.groupName == GroupActivity.current_group.groupName)
                            {
                                grp.addAdmin(user);
                                grp.addMember(user);
                                var testGroup = false;
                                foreach(Group group in user.groups)
                                {
                                    if (group.groupName == grp.groupName)
                                        testGroup = true ;
                                }
                                if(!testGroup)
                                    user.addGroup(grp);
                                Activity.StartActivity(typeof(GroupActivity));
                            }
                        }
                    }
                }
                if (!test)
                    pseudo_admin.SetError("Cet utilisateur ne fait pas partie de vos contacts !", null);
            };

            return view;
        }
    }
}