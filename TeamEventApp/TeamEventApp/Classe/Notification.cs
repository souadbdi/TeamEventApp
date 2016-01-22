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
    }
}