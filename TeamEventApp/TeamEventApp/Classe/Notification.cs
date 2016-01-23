using System;

namespace TeamEventApp
{
    public class Notification
    {
        public long notificationId { get; set; }
        public long userId { get; set; }
        public long eventId { get; set; }
        public string note { get; set; }
        public DateTime date { get; set; }
        public int views { get; set; }


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