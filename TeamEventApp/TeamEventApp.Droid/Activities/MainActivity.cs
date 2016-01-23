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
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        bool connected = false;
        //Appel de la db
        public static DataBase database = new DataBase();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Création d'un user avec 1 group pour tester l'appli
            /*User user1 = new User("user", "one", "us1", "mail", "password");
            user1.userId = users_db.Count + 1;
            users_db.Add(user1.userId, user1);
            
            Group grp = new Group("Grp1", user1);
            grp.groupId = groups_db.Count;
            user1.addGroup(grp);
            groups_db.Add(grp.groupId,grp);

            User user2 = new User("user2", "2", "us2", "mail2", "password2");
            user2.userId = users_db.Count + 1;
            users_db.Add(user2.userId, user2);

            user1.contacts.Add(user2);*/

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Vérification de la connexion
            VerifyConnection();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.versConnexionButton);

            button.Click += delegate {
                Intent intent = new Intent(this.ApplicationContext, typeof(LoginActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            VerifyConnection();
        }

        protected override void OnResume()
        {
            base.OnResume();
            VerifyConnection();
        }

        private void VerifyConnection()
        {
            if (!connected)
                StartActivity(typeof(LoginActivity));
        }
    }
}


