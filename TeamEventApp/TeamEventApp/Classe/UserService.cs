using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp.Classe
{
    class UserService
    {
        private User currentUser;

        public UserService(User user)
        {
            this.currentUser = user;
        }

        // Ajout d'un événement / ID
        public void addUserEvent(long groupID, Event newEvent)
        {
            Group group = GetUserGroupById(groupID);

            if (group != null)
                group.AddEvent(newEvent);
        }


        // Récupération des événements de l'utilisateur
        public List<Event> GetUserAllEvents()
        {
            List<Event> events = new List<Event>();

            foreach (Group group in this.currentUser.groups)
            {
                foreach (Event groupEvent in group.events)
                {
                    events.Add(groupEvent);
                }
            }

            return events;
        }

        // Récupération des événements par groupe

        public List<Event> GetUserEventsByGroup(long groupID)
        {
            List<Event> events = new List<Event>();

            foreach (Group group in this.currentUser.groups)
            {
                // Si on trouve le groupe
                if (groupID == group.groupId)
                {
                    foreach (Event groupEvent in group.events)
                    {
                        events.Add(groupEvent);
                    }
                }
            }

            return events;
        }

        // Récupération d'un événement


        // Récupération d'un groupe

        public List<Group> GetUserAllGroups()
        {
            return this.currentUser.groups;
        }

        public Group GetUserGroupById(long groupID)
        {
            foreach (Group group in currentUser.groups)
            {
                if (groupID == group.groupId)
                {
                    return group;
                }
            }

            return null;
        }

        // Get group by name
        public Group GetUserGroupByName(string groupName)
        {
            foreach (Group group in currentUser.groups)
            {
                if (groupName == group.groupName)
                {
                    return group;
                }
            }

            return null;
        }

        // Get group id by name
        public long GetUserGroupIdByName(string groupName)
        {
            foreach (Group group in currentUser.groups)
            {
                if (groupName == group.groupName)
                {
                    return group.groupId;
                }
            }

            return -1;
        }
    }
}
