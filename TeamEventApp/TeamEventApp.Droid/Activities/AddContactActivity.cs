
using Android.App;
using Android.OS;
using Android.Widget;

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
            add_button.Click += delegate
            {
                //on ne peut pas s'ajouter sois même
                var isMySelf = false;
                if (editText.Text == DataBase.current_user.pseudo)
                {
                    Toast.MakeText(this,"Vous ne pouvez pas vous ajoutez vous même !!!", ToastLength.Short).Show();
                    isMySelf = true;
                }
                //on vérifie si le user à ajouter fait partie des users de l'appli
                var isAppUser = false;
                User user = new User();
                foreach(User us in DataBase.users_db.Values)
                {
                    if(editText.Text == us.pseudo)
                    {
                        isAppUser = true;
                        user = us;
                    }
                }
                if(isAppUser)
                {
                    //on vérifie maintenant qu'il ne fait pas déjà partie des contacts du current_user
                    var isUserContact = false;
                    foreach(User contact in DataBase.current_user.contacts)
                    {
                        if (editText.Text == contact.pseudo)
                            isUserContact = true;
                    }
                    if (!isUserContact && !isMySelf)
                    {
                        DataBase.current_user.contacts.Add(user);
                        StartActivity(typeof(ProfileActivity));
                    }
                    else
                        Toast.MakeText(this,"Cet utilisateur fait déjà partie de vos contacts", ToastLength.Short).Show();                   
                }
                else
                {
                    Toast.MakeText(this, "Utilisateur Introuvable", ToastLength.Short).Show();
                }
            };
            
        }
    }
}