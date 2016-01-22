using System;

namespace TeamEventApp
{
    public class Comment
    {
        public string message { get; set; }
        public string user { get; set; }
        public DateTime date { get; set; } 

        // Date en format string
        public string toStringDate()
        {
            return this.date.ToString();    
        }

        // Nom de l'utilisateur
        public string userName ()
        {
            return user;
        }
    }
}