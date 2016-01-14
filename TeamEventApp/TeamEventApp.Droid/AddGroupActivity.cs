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

namespace TeamEventApp.Droid
{
    [Activity(Label = "AddGroupActivity")]
    public class AddGroupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "addGroup" layout resource
            SetContentView(Resource.Layout.AddGroup);

            //Cr�ation du group avec nom
            EditText nomGrp = FindViewById<EditText>(Resource.Id.nomGrpEditText);

            //retour sur la page d'accueil et affichage du groupe

            Button button = FindViewById<Button>(Resource.Id.validGroup);
            TextView tv = FindViewById<TextView>(Resource.Id.tvTest);

            button.Click += delegate
            {
                Group grp = new Group(nomGrp.Text, users_db[1]);
                users_db[1].addGroup(grp);

                string groups = "";
                foreach (Group g in users_db[1].groups)
                {
                    groups += " " + g.groupName;
                }

               /* tv.Text = string.Format("Pr�nom : {0}, Nom : {1}, Id : {2}, Groups : "+ groups, users_db[1].firstName,
                                            users_db[1].lastName, users_db[1].userId); */
                StartActivity(typeof(AccueilActivity));
            };

        }
    }
}