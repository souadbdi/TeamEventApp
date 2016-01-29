using System;

namespace TeamEventApp
{
    public class Comment
    {
        public long commentId {get; set; }
        public string message {get; set; }
        public long userID {get; set; }
        public DateTime date;
        public long eventId { get; set; }
        public long groupID { get; set; }

        //Convert the date to string
        public string toStringDate()
        {
            string _dateFormat = "dd MMM yyyy, H:mm";
            return this.date.ToString(_dateFormat);
        }
    }
}