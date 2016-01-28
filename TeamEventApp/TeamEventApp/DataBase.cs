using System.Collections.Generic;

namespace TeamEventApp
{
    public class DataBase
    {
        public static User current_user; //Utilisateur courrant      

        //A remplir à partir du web service / table User pour savoir si le user qui se connecte est déjà enregistré
        public static Dictionary<long, User> users_db = new Dictionary<long, User>();

        public static Dictionary<long, Group> groups_db = new Dictionary<long, Group>();

        public static List<Group> current_user_groups_requests;
        
        
        //renvoie true si le user est bien enregistré dans la BD
        public static bool Connect(string mail, string password)
        {
            foreach (User us in users_db.Values)
            {
                if(us.email == mail && us.password == password)
                {
                    current_user = us;
                    return true;
                }
            }
            return false;
        }

        public static void Inscription(User user)
        {
            user.userId = users_db.Count + 1;
            users_db.Add(user.userId, user); //ajout du nouvel utilisateur ds la db
            current_user = user;
        }
    }
}