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
    public class EventController
    {
        public static async Task<Event> addEvent(Event events)
        {

            string queryString = Url.urlLink + "Events";
            string content = JsonConvert.SerializeObject(EventConvertor.EventToDB(events));
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            EventEntity eventE = JsonConvert.DeserializeObject<EventEntity>(results);
            return EventConvertor.DBToEvent(eventE);

        }

        public static async Task<Event> getEvent(int id)
        {

            string queryString = Url.urlLink + "Events/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            EventEntity eventE = JsonConvert.DeserializeObject<EventEntity>(results);
            return EventConvertor.DBToEvent(eventE);

        }

        public static async Task<List<Event>> getAllEvent()
        {

            string queryString = Url.urlLink + "Events";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<EventEntity> ListEventE = JsonConvert.DeserializeObject<List<EventEntity>>(results);
            List<Event> listEvent = new List<Event>();
            for (var i = 0; i < ListEventE.Count; i++)
            {
                listEvent.Add(EventConvertor.DBToEvent(ListEventE[i]));
            }
            return listEvent;

        }

        public static async Task<List<Event>> getEventUser()
        {

            string queryString = Url.urlLink + "UsersEvenement/" + DataBase.current_user.userId;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<EventEntity> ListEventE = JsonConvert.DeserializeObject<List<EventEntity>>(results);
            List<Event> listEvent = new List<Event>();
            for (var i = 0; i < ListEventE.Count; i++)
            {
                listEvent.Add(EventConvertor.DBToEvent(ListEventE[i]));
            }
            return listEvent;

        }

        public static async Task<List<Event>> getEventGroup(int id)
        {

            string queryString = Url.urlLink + "GroupeEvent/" +id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<EventEntity> ListEventE = JsonConvert.DeserializeObject<List<EventEntity>>(results);
            List<Event> listEvent = new List<Event>();
            for (var i = 0; i < ListEventE.Count; i++)
            {
                listEvent.Add(EventConvertor.DBToEvent(ListEventE[i]));
            }
            return listEvent;

        }

        public static async void delEvent(int id)
        {

            string queryString = Url.urlLink + "Events/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<Event> modifEvent(Event events)
        {

            string queryString = Url.urlLink + "Events";
            string content = JsonConvert.SerializeObject(EventConvertor.EventToDB(events));
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            EventEntity eventE = JsonConvert.DeserializeObject<EventEntity>(results);
            return EventConvertor.DBToEvent(eventE);

        }
    }
}
