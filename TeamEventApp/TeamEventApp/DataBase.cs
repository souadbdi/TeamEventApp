using System.Collections.Generic;

namespace TeamEventApp
{
    public class DataBase
    {
        public static User current_user; //Utilisateur courrant  
        public static Event currentEvent;
        public static bool connected = false;
        //A remplir à partir du web service

        public static Dictionary<long, User> users_db = new Dictionary<long, User>();

        public static Dictionary<long, Group> groups_db = new Dictionary<long, Group>();

        public static Dictionary<long, Event> events_db = new Dictionary<long, Event>();

        public static List<Group> current_user_groups_requests;
        
        
        //renvoie true si le user est bien enregistré dans la BD

        public static bool Connect(string mail, string password)
        {
            foreach (User us in users_db.Values)
            {
                if (us.email == mail && us.password == password)
                {
                    current_user = us;
                    connected = true;
                    return connected;
                }
            }

            return connected;
        }


        // S'inscrire

        public static void Inscription(User user)
        {
            user.userId = users_db.Count + 1;
            users_db.Add(user.userId, user); //ajout du nouvel utilisateur ds la db
            current_user = user;
        }

        // Se déconnecter

        public static void Logout()
        {
            current_user = null;
            connected = false;
        }


        // Ajouter un événement

        public static void CreateEvent(Event ev)
        {

            ev.eventId = events_db.Count + 1;
            events_db.Add(ev.eventId, ev);

        }

        // Ajouter un groupe

        public static void CreateGroup(Group grp)
        {
            grp.groupId = groups_db.Count + 1;
            groups_db.Add(grp.groupId, grp);

        }

        // Liste de tous les utilisateurs

        public List<User> GetAllUsers()
        {
            return new List<User>(users_db.Values);
        }

    }
}