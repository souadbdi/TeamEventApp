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

        private EditText email;
        private EditText pwd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            // Connexion du bouton
            loginButton = FindViewById<Button>(Resource.Id.cnx_connection_btn);
            registerTextView = FindViewById<TextView>(Resource.Id.cnx_register_text);
            noPwdTextView = FindViewById<TextView>(Resource.Id.cnx_fpwd_text);

            email = FindViewById<EditText>(Resource.Id.cnx_email_text);
            pwd = FindViewById<EditText>(Resource.Id.cnx_pwd_text);

            // Connecting actions

            loginButton.Click += async delegate
            {
                //bool error = false;
                //if (!error)
                //    error = verifText("email", email);
                //if (!error)
                //    error = verifText("mot de passe", pwd);



                //if (!error)
                //{
                //    User user = new User();
                //    if (VerifConnection.CheckInternetConnection())
                //    {
                //        user.password = pwd.Text;
                //        user.email = email.Text;
                //        user = await UserController.login(user);
                //    }
                //    else
                //    {
                //        user = DataBase.Connect(email.Text, pwd.Text);
                //    }
                   
                //    if (user == null)
                //    {
                //        Toast.MakeText(this, "Mot de passe ou email incorrect", ToastLength.Long).Show();
                //    }
                //    else
                        StartActivity(typeof(Notification));
                //}

                //pwd.Text = "";
            };

            registerTextView.Click += delegate
            {
                StartActivity(typeof(RegisterAccountActivity));
            };

            noPwdTextView.Click += delegate
            {
                StartActivity(typeof(ResetPasswordActivity));
            };
        }

        // fonction de verification des informations
        public bool verifText(string name, EditText edittext)
        {
            if (edittext.Text.ToString() == "")
            {
                Toast.MakeText(this, "Vous n'avez pas entré votre " + name, ToastLength.Long).Show();
                return true;
            }
            return false;
        }
    }
}