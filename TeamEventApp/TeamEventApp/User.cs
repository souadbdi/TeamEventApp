using System.Linq;

using static TeamEventApp.DataBase;

namespace TeamEventApp
{
    public class User
    {
        public long userId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        private string pseudo { get; set; }
        private string email { get; set; }
        private string password { get; set; }

        public User(string firstname, string lastname, string Pseudo, string eMail, string passWord)
        {
            this.lastName = lastname;
            this.firstName = firstname;
            this.pseudo = Pseudo;
            this.email = eMail;
            this.password = passWord;
        }

        public static User addUser(User user)
        {
            user.userId = (long)users_db.Count + 1;
            users_db.Add(user.userId, user);
            return user;
        }

        public void removeUser(User user)
        {
            users_db.Remove(user.userId);
        }

        public void updateUser(User user, string newPseudo)
        {
            user.pseudo = newPseudo;
        }
    }
}