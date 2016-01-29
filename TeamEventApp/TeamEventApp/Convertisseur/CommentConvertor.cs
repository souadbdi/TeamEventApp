using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamEvent;
using TeamEvent.Models;

namespace TeamEventApp.Convertisseur
{
    public class CommentConvertor
    {
        public static Comment DBToComment(CommentEntity commentE)
        {
            Comment comment = new Comment();

            comment.commentId = commentE.ID;
            comment.message = commentE.Message;
            comment.userID = commentE.UserID;
            comment.date = commentE.Date;
            comment.eventId = commentE.EventID;
            comment.groupID = commentE.GroupID;

            return comment;
        }

        public static CommentEntity CommentToDB(Comment comment)
        {
            CommentEntity commentE = new CommentEntity();

            commentE.ID = comment.commentId;
            commentE.Message = comment.message;
            commentE.UserID = comment.userID;
            commentE.Date = comment.date;
            commentE.EventID = comment.eventId;
            commentE.GroupID = comment.groupID;

            return commentE;
        }
    }
}
