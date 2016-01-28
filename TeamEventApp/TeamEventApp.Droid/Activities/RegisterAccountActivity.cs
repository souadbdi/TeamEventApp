using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook.Login;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_register_account")]
    public class RegisterAccountActivity : Activity, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        private ICallbackManager mCallBackManager;
        private MyProfileTracker mProfileTracker;

        private EditText nom;
        private EditText prenom;
        private EditText email;
        private EditText mdp;
        private EditText mdp2;
        private EditText pseudo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FacebookSdk.SdkInitialize(this.ApplicationContext);

            mProfileTracker = new MyProfileTracker();
            mProfileTracker.mOnProfileChanged += mProfileTracker_mOnProfileChanged;
            mProfileTracker.StartTracking();

            // Setting Layout
            SetContentView(Resource.Layout.RegisterAccount);

            // getting editText
            nom = FindViewById<EditText>(Resource.Id.reg_lname_text);
            prenom = FindViewById<EditText>(Resource.Id.reg_fname_text);
            email = FindViewById<EditText>(Resource.Id.reg_email_text);
            mdp = FindViewById<EditText>(Resource.Id.reg_pwd_text);
            mdp2 = FindViewById<EditText>(Resource.Id.reg_confPwd_text);
            pseudo = FindViewById<EditText>(Resource.Id.reg_pseudo_text);


            // Login if already have an account
            TextView loginTextView = FindViewById<TextView>(Resource.Id.reg_signin_text);

            loginTextView.Click += delegate
            {
                StartActivity(typeof(LoginActivity));
            };

            // Facebook Configuration

            LoginButton button = FindViewById<LoginButton>(Resource.Id.reg_cnxFacebook_btn);
            button.SetReadPermissions(new List<string> { "public_profile", "user_friends", "email" });
            mCallBackManager = CallbackManagerFactory.Create();
            button.RegisterCallback(mCallBackManager, this);


            // bouton enregistrement inscription
            Button registerButton = FindViewById<Button>(Resource.Id.register_btn);
            registerButton.Click += delegate
            {            
                // verification des champs
                bool error = false;
                if (!error)
                    error = verifText("prenom", prenom);
                if (!error)
                    error = verifText("nom", nom);
                if (!error)
                    error = verifText("pseudo", pseudo);
                if (!error)
                    error = verifText("email", email);
                if (!error)
                    error = verifText("mot de passe", mdp);
                if (!error)
                    error = verifText("confirmation de mot de passe", mdp2);
                
                if (!error && mdp.Text.ToString() != mdp2.Text.ToString())
                {
                    error = true;
                    mdp2.SetError("Les mots de passe ne correspondent pas", null);
                }

                // Vérification de la saisie !!!
                if (!error)
                {
                    User user = new User(prenom.Text, nom.Text, pseudo.Text, email.Text, mdp.Text);
                    DataBase.Inscription(user);
                    StartActivity(typeof(ProfileActivity));
                }
            };
        }

        void mProfileTracker_mOnProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                GraphRequest request = GraphRequest.NewMeRequest(AccessToken.CurrentAccessToken, this);

                Bundle parameters = new Bundle();
                parameters.PutString("fields", "email");
                request.Parameters = parameters;
                request.ExecuteAsync();

                nom.Text = e.mProfile.FirstName;
                prenom.Text = e.mProfile.LastName;
                pseudo.Text = e.mProfile.Name;
            }

            else
            {
               
            }
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
            Console.WriteLine(AccessToken.CurrentAccessToken.UserId);
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            mCallBackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }

        protected override void OnDestroy()
        {
            mProfileTracker.StopTracking();
            base.OnDestroy();
        }

        public void OnCompleted(Org.Json.JSONObject json, GraphResponse response)
        {
            string data = json.GetString("email");
            email.Text = data;
        }
    }

    public class MyProfileTracker : ProfileTracker
    {
        public event EventHandler<OnProfileChangedEventArgs> mOnProfileChanged;

        protected override void OnCurrentProfileChanged(Profile oldProfile, Profile newProfile)
        {
            if (mOnProfileChanged != null)
            {
                mOnProfileChanged.Invoke(this, new OnProfileChangedEventArgs(newProfile));
            }
        }
    }

    public class OnProfileChangedEventArgs : EventArgs
    {
        public Profile mProfile;

        public OnProfileChangedEventArgs(Profile profile) { mProfile = profile; }
    }
}