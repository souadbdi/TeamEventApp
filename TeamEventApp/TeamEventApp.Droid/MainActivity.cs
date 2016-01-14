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
            user1.userId = users_db.Count + 1;
            users_db.Add(user1.userId, user1);

            Group grp = new Group("Grp1",user1);
            user1.addGroup(grp);

            Group grp2 = new Group("Grp2", user1);
            users_db[1].addGroup(grp2);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.inscriptionButton);
            TextView tv = FindViewById<TextView>(Resource.Id.textviewTest);

            button.Click += delegate {
                Intent intent = new Intent(this.ApplicationContext, typeof(AccueilActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);

               /* tv.Text = string.Format("Prénom : {0}, Nom : {1}, Id : {2}, Groups : {3}",user1.firstName,
                                            user1.lastName,user1.userId,user1.groups[0].groupName);*/

            };
        }
    }
}


