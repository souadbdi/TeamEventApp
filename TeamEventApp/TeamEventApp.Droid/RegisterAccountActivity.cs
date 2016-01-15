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

using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;
using Java.Lang;
using Xamarin.Facebook.Login;


namespace TeamEventApp.Droid
{
    [Activity(Label = "RegisterAccountActivity")]
    public class RegisterAccountActivity : Activity, IFacebookCallback
    {
        private ICallbackManager mCallbackManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);

            // Setting Layout
            SetContentView(Resource.Layout.RegisterAccount);

            // Facebook Configuration

            LoginButton facebookButton = FindViewById<LoginButton>(Resource.Id.reg_cnxFacebook_btn);
            facebookButton.SetReadPermissions("user_friends");
            mCallbackManager = CallbackManagerFactory.Create();
            facebookButton.RegisterCallback(mCallbackManager, this);


            // bouton enregistrement inscription
            Button registerButton = FindViewById<Button>(Resource.Id.register_btn);
            registerButton.Click += delegate
            {

                string nom = FindViewById<EditText>(Resource.Id.reg_fname_text).Text;
                string prenom = FindViewById<EditText>(Resource.Id.reg_lname_text).Text;
                string email = FindViewById<EditText>(Resource.Id.reg_email_text).Text;
                string mdp = FindViewById<EditText>(Resource.Id.reg_pwd_text).Text;
                string mdp2 = FindViewById<EditText>(Resource.Id.reg_confPwd_text).Text;

                if (nom == "")
                {
                    Toast.MakeText(this, "Vous n'avez pas entré votre nom", ToastLength.Short).Show();
                }
                if (prenom == "")
                {
                    Toast.MakeText(this, "Vous n'avez pas entré votre prénom", ToastLength.Short).Show();
                }
                if (email == "")
                {
                    Toast.MakeText(this, "Vous n'avez pas entré votre email", ToastLength.Short).Show();
                }
                if (mdp == "")
                {
                    Toast.MakeText(this, "Vous n'avez pas entré votre mot de passe", ToastLength.Short).Show();
                }
                if (mdp2 == "")
                {
                    Toast.MakeText(this, "Vous n'avez pas entré votre confirmation de mot de passe", ToastLength.Short).Show();
                }
                if (mdp == mdp2)
                {
                    Toast.MakeText(this, "Les mots de passe ne correspondent pas", ToastLength.Short).Show();
                }


                // Vérification de la saisie !!!

                if (true)
                    StartActivity(typeof(Notification));
            };
        }

        // Facebook Interface methods

        public void OnCancel()
        {
            //throw new NotImplementedException();
        }

        public void OnError(FacebookException error)
        {
            //throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            LoginResult loginResult = result as LoginResult;
            Console.WriteLine(loginResult.AccessToken.UserId);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            mCallbackManager.OnActivityResult(requestCode, (int)requestCode, data);
        }
    }
}