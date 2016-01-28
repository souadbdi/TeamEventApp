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



        // Return start-end date to string format
        public string toStringStartEndDate()
        {
            string _dateFormat = "dd MMM yyyy, H:mm";
            //string _timeFormat = "H:mm";

            return this.startDate.ToString(_dateFormat) + " - " + this.endDate.ToString(_dateFormat);
        }

        // Ajouter utilisateur

        public List<User> addUser(User user)
        {
            userList.Add(user);
            return userList;
        }

        // Enlever un utilisateur

            public List<User> deleteUser(User user)
        {
            userList.Remove(user);
            return userList;
        }

        // Vérification si un utilisateur à répondu à propos l'événement

        public bool hasAnsweredUser(User user)
        {
            foreach(User eventUser in userList)
            {
                if (user.userId == eventUser.userId)
                    return true;
            }

            return false;
        }

    }

    
}