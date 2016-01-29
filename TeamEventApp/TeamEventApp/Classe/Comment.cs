using System;

namespace TeamEventApp
{
    public class Comment
    {
        public int commentId {get; set; }
        public string message {get; set; }
        public int userID {get; set; }
        public DateTime date;
        public int eventId { get; set; }
        public int groupID { get; set; }


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