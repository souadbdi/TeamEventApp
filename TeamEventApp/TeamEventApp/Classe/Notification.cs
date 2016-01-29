using System;

namespace TeamEventApp
{
    public class Notification
    {
        public int notificationId { get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }
        public string note { get; set; }
        public DateTime date { get; set; }
        public string views { get; set; }


        // Take the username
        public string userName()
        {
            return "User Name";
        }

        // Convert date to string
        public string toStringDate()
        {
            return this.date.ToString();
        }

        // Convert views number to string
        public string toStringCommentsNumber()
        {
            return "" + this.views;
        }
    }
}