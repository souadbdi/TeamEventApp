using System;
using System.Collections.Generic;

namespace TeamEventApp
{
    public class Event
    {
        public string eventName { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string address { get; set; }
        public List<Notification> notifications { get; set; }
        public List<Comment> comments { get; set; }
    }
}