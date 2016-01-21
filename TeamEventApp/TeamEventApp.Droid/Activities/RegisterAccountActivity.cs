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
    [Activity(Label = "@string/label_register_account")]
    public class RegisterAccountActivity : Activity, IFacebookCallback
    {
        private ICallbackManager mCallbackManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);

            // Setting Layout
            SetContentView(Resource.Layout.RegisterAccount);

            // Login if already have an account
            TextView loginTextView = FindViewById<TextView>(Resource.Id.reg_signin_text);

            loginTextView.Click += delegate
            {
                StartActivity(typeof(LoginActivity));
            };

            // Facebook Configuration

            LoginButton facebookButton = FindViewById<LoginButton>(Resource.Id.reg_cnxFacebook_btn);
            facebookButton.SetReadPermissions("user_friends");
            mCallbackManager = CallbackManagerFactory.Create();
            facebookButton.RegisterCallback(mCallbackManager, this);


            // bouton enregistrement inscription
            Button registerButton = FindViewById<Button>(Resource.Id.register_btn);
            registerButton.Click += delegate
            {

                EditText nom = FindViewById<EditText>(Resource.Id.reg_fname_text);
                EditText prenom = FindViewById<EditText>(Resource.Id.reg_lname_text);
                EditText email = FindViewById<EditText>(Resource.Id.reg_email_text);
                EditText mdp = FindViewById<EditText>(Resource.Id.reg_pwd_text);
                EditText mdp2 = FindViewById<EditText>(Resource.Id.reg_confPwd_text);
                //FindViewById<EditText>(Resource.Id.reg_fname_text).SetError("error", null);
                
                // verification 
                bool error = false;
                if (!error)
                    error = verifText("prenom", prenom);
                if (!error)
                    error = verifText("nom", nom);
                if (!error)
                    error = verifText("email", email);
                if (!error)
                    error = verifText("mot de passe", mdp);
                if (!error)
                    error = verifText("confirmation de mot de passe", mdp2);
                
                if (!error && mdp.Text.ToString() == mdp2.Text.ToString())
                {
                    error = true;
                    mdp2.SetError("Les mots de passe ne correspondent pas", null);
                }


                // Vérification de la saisie !!!

                if (!error)
                    StartActivity(typeof(Notification));
                error = false;
            };
        }

        // fonction de verification des informations
         public bool verifText(string name, EditText edittext)
         {
             if(edittext.Text.ToString() == "")
            {
                edittext.SetError("Vous n'avez pas entré votre " + name, null);
                return true;
             }
             return false;
             
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
            mCallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
    }
}