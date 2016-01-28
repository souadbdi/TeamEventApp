using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp.Controller
{
    public class EventController
    {
        public static async Task<Event> addEvent(Event events)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/event";
            string content = JsonConvert.SerializeObject(events);
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Event>(results);

        }

        public static async Task<Event> getEvent(int id)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/event/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Event>(results);

        }

        public static async Task<List<Event>> getAllEvent()
        {

            string queryString = "http://teamevent.azurewebsites.net/api/event";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<Event>>(results);

        }

        public static async void delEvent(int id)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/event/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<Event> modifEvent(Event events)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/event";
            string content = JsonConvert.SerializeObject(events);
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Event>(results);

        }
    }
}
