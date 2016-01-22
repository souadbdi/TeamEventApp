using System.Collections.Generic;

namespace TeamEventApp
{
    public class DataBase
    {
        public static Dictionary<long, User> users_db = new Dictionary<long, User>();
        public static Dictionary<long, Group> groups_db = new Dictionary<long, Group>();
        public static Dictionary<long, Event> events_db = new Dictionary<long, Event>();


    }
}