using System.Collections.Generic;
using System.Linq;

using static TeamEventApp.DataBase;

namespace TeamEventApp
{

    public class User
    {
        public long userId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string pseudo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Group> groups { get; set; }
        public List<User> contacts { get; set; }
        public string status { get; set; }
        public string localisation { get; set; }

        public User()
        {

        }
        public User(string firstname, string lastname, string Pseudo, string eMail, string passWord)
        {
            this.lastName = lastname;
            this.firstName = firstname;
            this.pseudo = Pseudo;
            this.email = eMail;
            this.password = passWord;
            this.groups = new List<Group>();
            this.contacts = new List<User>();
        }

        public void addUser(User user)
        {
            user.userId = (long)users_db.Count + 1;
            users_db.Add(user.userId, user);
        }

        public void removeUser(User user)
        {
            users_db.Remove(user.userId);
        }

        public void updateUser(User user, string newPseudo)
        {
            user.pseudo = newPseudo;
        }

        public void addGroup(Group grp)
        {
            this.groups.Add(grp);
        }
        public void removeGroup(Group grp)
        {
            this.groups.Remove(grp);
        }

        public void addContact(User user)
        {
            this.contacts.Add(user);
        }

        public void removeContact(User user)
        {
            this.contacts.Remove(user);
        }
    }
}