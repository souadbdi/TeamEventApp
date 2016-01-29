using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamEvent;
using TeamEvent.Models;

namespace TeamEventApp.Convertisseur
{
    public class EventConvertor
    {
        public static Event DBToEvent(EventEntity eventE)
        {
            Event events = new Event();

            events.eventId = eventE.ID;
            events.eventName = eventE.Name;
            events.description = eventE.Description;
            events.startDate = eventE.StarteDate;
            events.endDate = eventE.EndDate;
            events.address = eventE.Adresse;
            events.groupId = eventE.GroupID;
            events.notifications = new List<Notification>();
            events.comments = new List<Comment>();
            events.userList = new List<User>();


            return events;
        }

        public static EventEntity EventToDB(Event events)
        {
            EventEntity eventE = new EventEntity();



            return eventE;
        }
    }
}
