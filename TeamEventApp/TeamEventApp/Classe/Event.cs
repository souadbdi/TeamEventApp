using System;
using System.Collections.Generic;

namespace TeamEventApp
{
    public class Event
    {
        public long eventId { get; set; }
        public string eventName { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string address { get; set; }
        public long groupId { get; set; }
        public List<Notification> notifications { get; set; }
        public List<Comment> comments { get; set; }
        public List<User> userList { get; set; }
        public List<User> userYesList { get; set; }
        public List<User> userMaybeList { get; set; }
        public List<User> userNoList { get; set; }
        public User userAdmin { get; set;  }



        // Return start-end date to string format
        public string toStringStartEndDate()
        {
            string _dateFormat = "dd MMM yyyy, H:mm";

            return this.startDate.ToString(_dateFormat) + " - " + this.endDate.ToString(_dateFormat);
        }

        // Ajouter utilisateur

        public List<User> addUser(User user)
        {
            userList.Add(user);
            return userList;
        }

        // Ajouter un YES
        public List<User> addYesUser(User user)
        {
            // Supprimer des maybe et de no
            userNoList.Remove(user);
            userMaybeList.Remove(user);

            userYesList.Add(user);
            return userYesList;
        }

        // Ajouter MAYBE
        public List<User> addMaybeUser(User user)
        {
            // Supprimer des yes et de no
            userNoList.Remove(user);
            userYesList.Remove(user);

            userMaybeList.Add(user);
            return userMaybeList;
        }

        // Ajouter NO user
        public List<User> addNoUser(User user)
        {

            // Supprimer des yes et de maybe
            userYesList.Remove(user);
            userMaybeList.Remove(user);

            userNoList.Add(user);
            return userNoList;
        }

        // Enlever un utilisateur
        public List<User> deleteUser(User user)
        {
            userList.Remove(user);
            return userList;
        }

        // Vérification si un utilisateur à répondu à propos l'événement: YES? NO? MAYBE?
        // Renvoie un int pour connaitre sa réponse
        public int hasAnsweredUser(User user)
        {
            foreach(User eventUser in userYesList)
            {
                if (user.userId == eventUser.userId)
                    return 1;
            }

            foreach (User eventUser in userNoList)
            {
                if (user.userId == eventUser.userId)
                    return 2;
            }

            foreach (User eventUser in userMaybeList)
            {
                if (user.userId == eventUser.userId)
                    return 3;
            }

            return 0;
        }



        // Get username by id
        public string getUserNameById(long userID)
        {
            string username = "no-user";

            foreach (User user in userList)
            {
                if (userID == user.userId)
                {
                    return user.pseudo;
                }
            }

            return username;
        }


        // Ajout d'un commentaire

        public List<Comment> addComment(Comment comment)
        {
            comments.Add(comment);
            return comments;
        }

        // Ajout d'une notification

        public List<Notification> addNotification(Notification notif)
        {
            notifications.Add(notif);
            return notifications;
        }

    }

    
}