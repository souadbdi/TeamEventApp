using System.Collections.Generic;

namespace TeamEventApp
{
    public class DataBase
    {
        public User current_user; //Utilisateur courrant
        
        public static List<User> current_user_contacts = new List<User>();
        public static List<Group> current_user_groups = new List<Group>();
        public static List<Event>current_user_events = new List<Event>();

        //A remplir à partir du web service / table User
        public static Dictionary<long, User> users_db = new Dictionary<long, User>();
        public static Dictionary<long, Group> groups_db = new Dictionary<long, Group>();
        public static Dictionary<long, Event> events_db = new Dictionary<long, Event>();

        //Ajout de 2 utilisateurs dans users_db pour tester la connexion
        public static User user1 = new User("user", "one", "us1", "mail", "password");
        public static User user2 = new User("user2", "2", "us2", "mail2", "password2");

        public DataBase()
        {
            user1.userId = users_db.Count + 1;
            users_db.Add(user1.userId,user1);
            user2.userId = users_db.Count + 1;
            users_db.Add(user2.userId, user2);
        }

        public bool Connect(string mail, string password)
        {
            foreach (User us in users_db.Values)
            {
                if(us.email == mail && us.password == password)
                {
                    this.current_user = us;
                    current_user_contacts = us.contacts;
                    current_user_groups = us.groups;
                    return true;
                }
            }
            return false;
        }

        public void Inscription(User user)
        {
            user.userId = users_db.Count + 1;
            users_db.Add(user.userId, user); //ajout du nouvel utilisateur ds la db
            this.current_user = user;
            current_user_contacts = user.contacts;
            current_user_groups = user.groups;
        }
    }
}