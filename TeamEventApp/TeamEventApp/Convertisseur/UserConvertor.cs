using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamEvent;

namespace TeamEventApp.Convertisseur
{
    public class UserConvertor
    {
        public static User DBToUser(UserEntity userE)
        {
            User user = new User();

            user.userId = userE.ID;
            user.lastName = userE.LastName;
            user.firstName = userE.FistName;
            user.pseudo = userE.Pseudo;
            user.email = userE.Email;
            user.password = userE.PassWord;
            user.status = userE.Status;
            user.localisation = userE.Localisation;
            user.groups = new List<Group>();
            user.contacts = new List<User>();

            return user;
        }

        public static UserEntity UserToDB(User user)
        {
            UserEntity userE = new UserEntity();

            userE.ID = user.userId;
            userE.LastName = user.lastName;
            userE.FistName = user.firstName;
            userE.Pseudo = user.pseudo;
            userE.Email = user.email;
            userE.PassWord = user.password;
            userE.Status = user.status;
            userE.Localisation = user.localisation;
            userE.AppartienEntity = null;
            userE.CommentEntity = null;
            userE.EventUserStateEntity = null;
            userE.NotificationEntity = null;

            return userE;
        }
    }
}
