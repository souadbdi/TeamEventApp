using System;
using System.Collections.Generic;

namespace TeamEventApp
{
    public class Event
    {
        public int eventId { get; set; }
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
            return this.startDate.ToString() + " à " + this.endDate.ToString();
    }
    }

    
}