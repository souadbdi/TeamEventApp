using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using static TeamEventApp.DataBase;

namespace TeamEventApp.Droid
{
	[Activity (Label = "TeamEventApp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            User user1 = new User("user", "one", "us1", "mail", "password");

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.inscriptionButton);
            TextView tv = FindViewById<TextView>(Resource.Id.textviewTest);

            button.Click += delegate {
                User.addUser(user1);
                button.Text = "L'utilisateur a bien été ajouté!";
                tv.Text = string.Format("{0} {1} a bien été ajouté à la liste", users_db[1L].firstName, users_db[1L].lastName);

            };
        }
    }
}


