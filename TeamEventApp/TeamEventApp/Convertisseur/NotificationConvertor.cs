using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamEvent;

namespace TeamEventApp.Convertisseur
{
    public class NotificationConvertor
    {
        public static Notification DBToNotification(NotificationEntity NotificationE)
        {
            Notification notification = new Notification();

            notification.notificationId = NotificationE.ID;
            notification.userId = NotificationE.UserID;
            notification.eventId = NotificationE.EventID;
            notification.note = NotificationE.Note;
            notification.date = NotificationE.Date;
            notification.views = NotificationE.Views;

            return notification;
        }

        public static NotificationEntity NotificationToDB(Notification notification)
        {
            NotificationEntity notificationE = new NotificationEntity();

            notificationE.ID = notification.notificationId;
            notificationE.UserID = notification.userId;
            notificationE.EventID = notification.eventId;
            notificationE.Note = notification.note;
            notificationE.Date = notification.date;
            notificationE.Views = notification.views;

            return notificationE;
        }
    }
}
