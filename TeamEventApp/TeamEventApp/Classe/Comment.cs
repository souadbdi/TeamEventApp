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


        // Take the userName
        public string userName()
        {
            return "User Name";
        }

        //Convert the date to string
        public string toStringDate()
        {
            return this.date.ToString();
        }
    }
}