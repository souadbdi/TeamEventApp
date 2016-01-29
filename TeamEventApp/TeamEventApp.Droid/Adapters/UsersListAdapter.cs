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

namespace TeamEventApp.Droid.Adapters
{
    class UsersListAdapter : BaseAdapter<User>
    {
        public List<User> usersList;
        public Context context;

        // Constructor
        public UsersListAdapter(Context ctx, List<User> elist)
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
                row = LayoutInflater.From(context).Inflate(Resource.Layout.UserListRow, null, false);
            }

            // Pseudo of the user        
            TextView textPseudo = row.FindViewById<TextView>(Resource.Id.user_pseudo_text);
            textPseudo.Text = usersList[position].pseudo;

            // Name of the user
            TextView textName = row.FindViewById<TextView>(Resource.Id.user_name_text);
            textName.Text = usersList[position].firstName + " " + usersList[position].lastName;

            // Bouton d'ajout
            Button addContactButton = row.FindViewById<Button>(Resource.Id.user_add_button);

            if (addContactButton != null)

            {
                // On vérifie si c'est un contact
                UserService uService = new UserService(DataBase.current_user);

                if (uService.isContactUser(usersList[position]))
                {
                    addContactButton.Visibility = ViewStates.Gone;
                }

                // Sinon on connecte l'action ajouter aux contacts et on réinitialise

                else
                {
                    addContactButton.Click += delegate
                    {
                        uService.addUserToContacts(usersList[position]);
                        addContactButton.Visibility = ViewStates.Gone;      // masquer ensuite
                    };
                        
                }

            }


            return row;
        }
    }
}