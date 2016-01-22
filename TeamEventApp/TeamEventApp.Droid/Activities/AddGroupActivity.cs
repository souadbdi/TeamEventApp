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
    [Activity(Label = "@string/label_add_group")]
    public class AddGroupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "addGroup" layout resource
            SetContentView(Resource.Layout.AddGroup);

            //Création du group avec nom
            EditText nomGrp = FindViewById<EditText>(Resource.Id.nomGrpEditText);

            //retour sur la page d'accueil et affichage du groupe

            Button button = FindViewById<Button>(Resource.Id.validGroup);

            button.Click += delegate
            {
                Group grp = new Group(nomGrp.Text, users_db[1]);
                users_db[1].addGroup(grp);

                StartActivity(typeof(GroupManagerActivity));
            };

        }
    }
}