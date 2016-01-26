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


namespace TeamEventApp.Droid
{
    [Activity(Label = "Connexion")]
    public class LoginActivity : Activity
    {
        private Button loginButton;
        private TextView registerTextView;
        private TextView noPwdTextView;

        private EditText emailET;
        private EditText passwordET;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            // Connexion du bouton
            loginButton = FindViewById<Button>(Resource.Id.cnx_connection_btn);
            registerTextView = FindViewById<TextView>(Resource.Id.cnx_register_text);
            noPwdTextView = FindViewById<TextView>(Resource.Id.cnx_fpwd_text);

            emailET = FindViewById<EditText>(Resource.Id.cnx_email_text);
            passwordET = FindViewById<EditText>(Resource.Id.cnx_pwd_text);

            // Connecting actions

            loginButton.Click += delegate 
            {
                //on vérifie que l'utilisateur qui se connecte existe bien et on l'affecte a current_user
                //par la fonction Connect()
                //if(DataBase.Connect(emailET.Text,passwordET.Text))
                    StartActivity(typeof(ProfileActivity));
                //else
                    //Toast.MakeText(this, "Vous n'êtes pas inscrit à TeamEvent. Veuillez vous enregistrer", ToastLength.Short).Show();
            };

            registerTextView.Click += delegate {
                StartActivity(typeof(RegisterAccountActivity));
            };

            noPwdTextView.Click += delegate {
                StartActivity(typeof(ResetPasswordActivity));
            };         
        }
    }
}