using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamEvent.Models;

namespace TeamEventApp.Convertisseur
{
    public class GroupConvertor
    {
        public static Group DBToGroup(GroupEntity groupE)
        {
            Group group = new Group();

            group.groupId = groupE.ID;
            group.groupName = groupE.Nom;
            group.members = new List<User>();
            group.admins = new List<User>();
            group.events = new List<Event>();
            group.comments = new List<Comment>();

            return group;
        }

        public static GroupEntity GroupToDB(Group group)
        {
            GroupEntity groupE = new GroupEntity();

            groupE.ID = group.groupId;
            groupE.Nom = group.groupName;
            groupE.CommentEntitys = null;
            groupE.AppartienEntity = null;
            groupE.CommentEntity = null;
            groupE.EventEntity = null;

            return groupE;
        }
    }
}
