
using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "Ajouter un Contact")]
    public class AddContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddContact);

            EditText editText = FindViewById<EditText>(Resource.Id.nomUtilisateurEditText);

            Button add_button = FindViewById<Button>(Resource.Id.validContact);

            //action ajouter contact
            add_button.Click += async delegate
            {
                //on ne peut pas s'ajouter sois m�me
                var isMySelf = false;
                if (editText.Text == DataBase.current_user.pseudo)
                {
                    Toast.MakeText(this,"Vous ne pouvez pas vous ajoutez vous m�me !!!", ToastLength.Short).Show();
                    isMySelf = true;
                }
                //on v�rifie si le user � ajouter fait partie des users de l'appli
                var isAppUser = false;
                User user = new User();
                List<User> userListe = new List<User>();
                userListe = await UserController.getAllUsers();
                foreach (User us in userListe)
                {
                    if(editText.Text == us.pseudo)
                    {
                        isAppUser = true;
                        user = us;
                    }
                }
                if(isAppUser)
                {
                    //on v�rifie maintenant qu'il ne fait pas d�j� partie des contacts du current_user
                    var isUserContact = false;
                    List<User> contactListe = new List<User>();
                    contactListe = await UserController.getUsersContact();
                    foreach (User contact in contactListe)
                    {
                        if (editText.Text == contact.pseudo)
                            isUserContact = true;
                    }
                    if (!isUserContact && !isMySelf)
                    {
                        // manque la methode ajout contact vers le WS
                        DataBase.current_user.addContact(user);
                        //le contact ajout� a maintenant le current_user dans ses contacts
                        user.addContact(DataBase.current_user);

                        StartActivity(typeof(ProfileActivity));
                    }
                    else
                        Toast.MakeText(this,"Cet utilisateur fait d�j� partie de vos contacts", ToastLength.Short).Show();                   
                }
                else
                {
                    Toast.MakeText(this, "Utilisateur Introuvable", ToastLength.Short).Show();
                }
            };
            
        }
    }
}