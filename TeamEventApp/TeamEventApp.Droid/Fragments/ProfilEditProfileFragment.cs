using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid.Fragments
{
    public class ProfilEditProfileFragment : DialogFragment
    {
        EditText prenom;
        EditText nom;
        EditText pseudo;
        EditText mdp;
        EditText mdp2;
        Button edit;
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.EditProfil, container, false);

            //instanciation des edit text
            prenom = view.FindViewById<EditText>(Resource.Id.edit_fname_text);
            nom = view.FindViewById<EditText>(Resource.Id.edit_lname_text);
            pseudo = view.FindViewById<EditText>(Resource.Id.edit_pseudo_text);
            mdp = view.FindViewById<EditText>(Resource.Id.edit_pwd_text);
            mdp2 = view.FindViewById<EditText>(Resource.Id.edit_confPwd_text);

            //action édition
            edit = view.FindViewById<Button>(Resource.Id.edit_btn);
            edit.Click += delegate
            {
                if (verifText(prenom))
                    DataBase.current_user.firstName = prenom.Text;
                if (verifText(nom))
                    DataBase.current_user.lastName = nom.Text;
                if (verifText(pseudo))
                    DataBase.current_user.pseudo = pseudo.Text;
                if (verifText(mdp) && verifText(mdp2))
                {
                    if (mdp.Text != mdp2.Text)
                    {
                        mdp2.SetError("Les mots de passe ne correspondent pas", null);
                    }
                    else
                        DataBase.current_user.password = mdp.Text;
                }
                Activity.StartActivity(typeof(ProfileActivity));
            };

            // Return
            return view;
        }

        // fonction de verification des informations
        public bool verifText(EditText edittext)
        {
            if (edittext.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}