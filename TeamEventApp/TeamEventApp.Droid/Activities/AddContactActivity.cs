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

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "Ajouter un Contact")]
    public class AddContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddContact);

            EditText editText = FindViewById<EditText>(Resource.Id.nomUtilisateurEditText);

            Button add_button = FindViewById<Button>(Resource.Id.validContact);

            add_button.Click += delegate
            {
                var test = false;
                User user = new User();
                foreach(User us in users_db.Values)
                {
                    if(editText.Text == us.pseudo)
                    {
                        test = true;
                        user = us;
                    }
                }
                if(test == true)
                {
                    users_db[1].contacts.Add(user);
                    StartActivity(typeof(ProfileActivity));
                }
                else
                {
                    Toast.MakeText(this, "Utilisateur Introuvable", Android.Widget.ToastLength.Short).Show();
                }
            };
            
        }
    }
}