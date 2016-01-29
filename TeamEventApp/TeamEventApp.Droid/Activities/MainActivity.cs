using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace TeamEventApp.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/Icon")]
	public class MainActivity : Activity
	{
        bool connected = false;

        //Ajout de 2 utilisateurs dans users_db pour tester la connexion
        public static User user1 = new User("user", "one", "us1", "mail", "password");
        public static User user2 = new User("user2", "2", "us2", "mail2", "password2");

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            user1.userId = DataBase.users_db.Count + 1;
            DataBase.users_db.Add(user1.userId, user1);
            user2.userId = DataBase.users_db.Count + 1;
            DataBase.users_db.Add(user2.userId, user2);

            // Vérification de la connexion
            VerifyConnection();

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


