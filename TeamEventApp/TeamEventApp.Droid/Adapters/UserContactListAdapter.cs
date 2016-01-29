using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid.Adapters
{
    public class UserContactListAdapter : BaseAdapter<User>
    {
        public List<User> usersList;
        public Context context;

        // Constructor
        public UserContactListAdapter(Context ctx, List<User> elist)
        {
            this.usersList = elist;
            this.context = ctx;
        }

        // 
        public override int Count
        {
            get
            {
                return usersList.Count;
            }
        }

        //
        public override long GetItemId(int position)
        {
            return position;
        }

        //
        public override User this[int position]
        {
            get
            {
                return usersList[position];
            }
        }

        // 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.UserContactListRow, null, false);
            }

            // Pseudo of the user        
            TextView textPseudo = row.FindViewById<TextView>(Resource.Id.userContact_pseudo_text);
            textPseudo.Text = usersList[position].pseudo;

            // Name of the user
            TextView textName = row.FindViewById<TextView>(Resource.Id.userContact_name_text);
            textName.Text = usersList[position].firstName + " " + usersList[position].lastName;

            // Bouton suppression d'un contact
            ImageButton removeContactButton = row.FindViewById<ImageButton>(Resource.Id.userContact_remove_button);

            if (removeContactButton != null)
                removeContactButton.Click += delegate
                {
                    // Appel à une fonction statique de Invite Activity pour supprimer le contact

                    ((InviteContactActivity) context).deleteUser(usersList[position]);

                };

            return row;
        }
    }
}