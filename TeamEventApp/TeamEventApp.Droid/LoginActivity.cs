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

            // Connexion du bouton
            loginButton = FindViewById<Button>(Resource.Id.cnx_connection_btn);
            registerTextView = FindViewById<TextView>(Resource.Id.cnx_register_text);
            noPwdTextView = FindViewById<TextView>(Resource.Id.cnx_fpwd_text);


            // Connecting actions

            loginButton.Click += delegate {
                StartActivity(typeof(NotificationActivity));
            };

            registerTextView.Click += delegate {
                StartActivity(typeof(RegisterAccountActivity));
            };

            noPwdTextView.Click += delegate {
                StartActivity(typeof(ResetPasswordActivity));
            };

            Button button = FindViewById<Button>(Resource.Id.versAccueilButton);

            button.Click += delegate {
                Intent intent = new Intent(this.ApplicationContext, typeof(AccueilActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            };
        }
    }
}