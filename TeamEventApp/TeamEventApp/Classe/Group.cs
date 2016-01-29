using System.Collections.Generic;

namespace TeamEventApp
{
    public class Group
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public List<User> members { get; set; } = new List<User>();
        public List<User> admins { get; set; } = new List<User>();
        public List<Event> events { get; set; } = new List<Event>();
        public List<Comment> comments { get; set; } = new List<Comment>();

        public Group()
        { }

        public Group(string name, User user)
        {
            this.groupName = name;
            this.admins.Add(user);
            this.members.Add(user);
            this.groupId = DataBase.groups_db.Count + 1;
            DataBase.groups_db.Add(this.groupId, this);
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