
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid.Fragments
{
    public class ProfilEditStatusFragment : DialogFragment
    {
        EditText status;
        Button edit;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.EditProfileStatus, container, false);

            //instanciation des edit text
            status = view.FindViewById<EditText>(Resource.Id.edit_status_text);

            //action édition
            edit = view.FindViewById<Button>(Resource.Id.edit_status_btn);
            edit.Click += delegate
            {
                DataBase.current_user.status = status.Text;
                Activity.StartActivity(typeof(ProfileActivity));
            };

            // Return
            return view;
        }
    }
}