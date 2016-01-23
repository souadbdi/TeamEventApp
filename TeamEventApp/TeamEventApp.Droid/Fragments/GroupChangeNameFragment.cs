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
        public Group group = new Group();
        public static string _groupName;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.ChangeGroupName, container, false);

            EditText name = view.FindViewById<EditText>(Resource.Id.newNameGrpEditText);
            Button modif = view.FindViewById<Button>(Resource.Id.validName);

            modif.Click += (object sender, EventArgs e)=>
            {
                // on affecte le nom du grp selectionné à _groupName
                _groupName = name.Text;
                
                //On lance l'activité GroupActivity en récupérant la valeur de groupName
                Intent intent = new Intent(this.Context, typeof(GroupActivity));
                intent.PutExtra(_groupName, name.Text);
                StartActivity(intent);
            };


            return view;
        }
    }
}