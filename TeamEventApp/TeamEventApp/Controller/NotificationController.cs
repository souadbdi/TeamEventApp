using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeamEvent;
using TeamEventApp.Convertisseur;

namespace TeamEventApp.Controller
{
    public class NotificationController
    {
        public static async Task<Notification> addNotification(Notification notification)
        {

            string queryString = Url.urlLink + "Notifications";
            string content = JsonConvert.SerializeObject(NotificationConvertor.NotificationToDB(notification));
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            NotificationEntity notificationE = JsonConvert.DeserializeObject<NotificationEntity>(results);
            return NotificationConvertor.DBToNotification(notificationE);

        }

        public static async Task<Notification> getNotification(int id)
        {

            string queryString = Url.urlLink + "Notifications/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            NotificationEntity notificationE = JsonConvert.DeserializeObject<NotificationEntity>(results);
            return NotificationConvertor.DBToNotification(notificationE);

        }

        public static async Task<List<Notification>> getAllNotification()
        {

            string queryString = Url.urlLink + "Notifications";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<NotificationEntity> listNotificationE = JsonConvert.DeserializeObject<List<NotificationEntity>>(results);
            List<Notification> listNotification = new List<Notification>();
            for (var i = 0; i < listNotificationE.Count; i++)
            {
                listNotification.Add(NotificationConvertor.DBToNotification(listNotificationE[i]));
            }
            return listNotification;

        }

        public static async void delNotification(int id)
        {

            string queryString = Url.urlLink + "Notifications/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<Notification> modifNotification(Notification notification)
        {

            string queryString = Url.urlLink + "Notifications";
            string content = JsonConvert.SerializeObject(NotificationConvertor.NotificationToDB(notification));
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            NotificationEntity notificationE = JsonConvert.DeserializeObject<NotificationEntity>(results);
            return NotificationConvertor.DBToNotification(notificationE);

        }
    }
}
