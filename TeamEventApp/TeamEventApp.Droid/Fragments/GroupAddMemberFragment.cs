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

using static TeamEventApp.DataBase;

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

            add_member.Click += delegate 
            {
                var test = false;
                foreach(User user in MainActivity.database.current_user.contacts)
                {
                    if(pseudo_membre.Text == user.pseudo)
                    {
                        test = true;
                        foreach(Group grp in MainActivity.database.current_user.groups)
                        {
                            if(grp.groupName == GroupActivity.current_group.groupName)
                            {
                                grp.addMember(user);
                                user.addGroup(grp);
                                Activity.StartActivity(typeof(GroupActivity));
                            }
                        }
                    }
                }
                if (!test)
                    pseudo_membre.SetError("Cet utilisateur ne fait pas partie de vos contacts !", null);
            };

            return view;
        }
    }
}