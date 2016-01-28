using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp.Controller
{
    public class NotificationController
    {
        public static async Task<Notification> addNotification(Notification notification)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/notification";
            string content = JsonConvert.SerializeObject(notification);
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Notification>(results);

        }

        public static async Task<Notification> getNotification(int id)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/notification/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Notification>(results);

        }

        public static async Task<List<Notification>> getAllNotification()
        {

            string queryString = "http://teamevent.azurewebsites.net/api/notification";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<Notification>>(results);

        }

        public static async void delNotification(int id)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/notification/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<Notification> modifNotification(Notification notification)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/notification";
            string content = JsonConvert.SerializeObject(notification);
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Notification>(results);

        }
    }
}
