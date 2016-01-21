using System.Collections.Generic;

namespace TeamEventApp
{
    public class Group
    {
        public string groupName { get; set; }
        public List<User> members { get; set; } = new List<User>();
        public List<User> admins { get; set; } = new List<User>();
        public List<Event> events { get; set; }

        public Group()
        { }

        public Group(string name, User user)
        {
            this.groupName = name;
            this.events = new List<Event>();
            this.admins.Add(user);
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

        public List<User> addAdmin(User user)
        {
            this.admins.Add(user);
            return admins;
        }

        public List<User> removeAdmin(User user)
        {
            this.admins.Remove(user);
            return admins;
        }

    }
}