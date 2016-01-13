using System.Collections.Generic;

namespace TeamEventApp
{
    public class Group
    {
        public string groupName { get; set; }
        public List<User> members { get; set; }
        public User admin { get; set; }
        public List<Event> events { get; set; }

        public Group(string name, User user)
        {
            this.groupName = name;
            this.events = null;
            this.admin = user;
            this.members.Add(user);
        }

        public List<User> addMember(User user)
        {
            this.members.Add(user);
            return members;
        }

        public List<User> removeMember(User user)
        {
            this.members.Remove(user);
            return members;
        }


    }
}