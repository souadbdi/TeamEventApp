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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            // recuperation des champs
            EditText email = FindViewById<EditText>(Resource.Id.cnx_email_text);
            EditText pwd = FindViewById<EditText>(Resource.Id.cnx_pwd_text);

            // Connexion du bouton
            loginButton = FindViewById<Button>(Resource.Id.cnx_connection_btn);
            registerTextView = FindViewById<TextView>(Resource.Id.cnx_register_text);
            noPwdTextView = FindViewById<TextView>(Resource.Id.cnx_fpwd_text);


            // Connecting actions

            loginButton.Click += delegate {
                bool error = false;
                if (!error)
                    error = verifText("email", email);
                if (!error)
                    error = verifText("mot de passe", pwd);

                if (!error)
                    StartActivity(typeof(Notification));
                error = false;
            };

            registerTextView.Click += delegate {
                StartActivity(typeof(RegisterAccountActivity));
            };

            noPwdTextView.Click += delegate {
                StartActivity(typeof(ResetPasswordActivity));
            };         
        }
        public bool verifText(string name, EditText edittext)
        {
            if (edittext.Text.ToString() == "")
            {
                edittext.SetError("Vous n'avez pas entré votre " + name, null);
                return true;
            }
            return false;

        }
    }
}