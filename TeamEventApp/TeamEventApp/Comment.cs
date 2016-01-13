using System;

namespace TeamEventApp
{
    public class Comment
    {
        public string message { get; set; }
        public User user;
        public DateTime date;
    }
}