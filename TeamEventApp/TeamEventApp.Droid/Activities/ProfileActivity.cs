using Android.App;
using Android.OS;
using Android.Widget;
using TeamEventApp.Droid.Activities;

using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid
{
    [Activity(Label = "@string/label_profile")]
    public class ProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            // Actions pour la liste des demandes à des événements
            TextView textReqList = FindViewById<TextView>(Resource.Id.profile_req_text);

            textReqList.Click += delegate
            {
                StartActivity(typeof(UserGroupRequestActivity));
            };

            //Actions pour l'affichage des contacts

            TextView ctextview = FindViewById<TextView>(Resource.Id.contact_tv);
            ctextview.Click += delegate
            {
                FragmentTransaction tx = FragmentManager.BeginTransaction();
                ProfilContactsFragment contactsDialog = new ProfilContactsFragment();
               contactsDialog.Show(tx, "Contacts");
            };
        }        
    }
}