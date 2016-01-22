using System;

namespace TeamEventApp
{
    public class Notification
    {
        public string userName { get; set; }
        public string note { get; set; }
        public DateTime date { get; set; }
        public int commentsNumber { get; set; }

        public string toStringDate()
        {
            return this.date.ToString();
        }

        public string toStringCommentsNumber()
        {
            return "" + commentsNumber;
        }
    }

    
}