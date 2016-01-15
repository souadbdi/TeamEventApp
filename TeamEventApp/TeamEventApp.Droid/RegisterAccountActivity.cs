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

                string nom = FindViewById<EditText>(Resource.Id.reg_fname_text).Text.ToString();
                string prenom = FindViewById<EditText>(Resource.Id.reg_lname_text).Text.ToString();
                string email = FindViewById<EditText>(Resource.Id.reg_email_text).Text.ToString();
                string mdp = FindViewById<EditText>(Resource.Id.reg_pwd_text).Text.ToString();
                string mdp2 = FindViewById<EditText>(Resource.Id.reg_confPwd_text).Text.ToString();
                FindViewById<EditText>(Resource.Id.reg_fname_text).SetError("error", null);
                
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
                
                if (!error && mdp == mdp2)
                {
                    error = true;
                    Toast.MakeText(this, "Les mots de passe ne correspondent pas", ToastLength.Short).Show();
                }


                // Vérification de la saisie !!!

                if (!error)
                    StartActivity(typeof(Notification));
                error = false;
            };
        }

        // fonction de verification des informations
         public bool verifText(string name, string champs)
         {
             if(champs == "")
             {
                 Toast.MakeText(this, "Vous n'avez pas entré votre " +name, ToastLength.Short).Show();
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