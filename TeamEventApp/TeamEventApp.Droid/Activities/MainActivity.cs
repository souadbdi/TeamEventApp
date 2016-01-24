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
          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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


