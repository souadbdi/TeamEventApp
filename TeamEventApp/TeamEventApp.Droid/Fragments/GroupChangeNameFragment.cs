using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid.Fragments
{
    public class GroupChangeNameFragment : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.ChangeGroupName, container, false);

            EditText name = view.FindViewById<EditText>(Resource.Id.newNameGrpEditText);
            Button modif = view.FindViewById<Button>(Resource.Id.validName);

            modif.Click += delegate
            {
                if (name.Text != "")
                {
                    // on affecte le nom du grp selectionné à _groupName
                    foreach (Group grp in MainActivity.database.current_user.groups)
                    {
                        if (grp.groupName == GroupActivity.current_group.groupName)
                        {
                            GroupActivity.current_group.groupName = name.Text;
                            grp.groupName = name.Text;
                            //On lance l'activité GroupActivity
                            Activity.StartActivity(typeof(GroupActivity));
                        }
                    }
                }
                else
                    name.SetError("Ce champs ne peut être vide", null);            
            };
            return view;
        }
    }
}