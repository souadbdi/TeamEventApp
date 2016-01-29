using System.Collections.Generic;

namespace TeamEventApp
{
    public class Group
    {
        public long groupId { get; set; }
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

            // Ajout du groupe à la BDD
            DataBase.CreateGroup(this);
        }

        public List<User> addMember(User user)
        {
            this.members.Add(user);
            //user.addGroup(this);
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


        // Ajout d'un événement
        public List<Event> AddEvent(Event ev)
        {
            events.Add(ev);
            return events;
        }

    }
}