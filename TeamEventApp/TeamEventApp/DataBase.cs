using System.Collections.Generic;

namespace TeamEventApp
{
    public class DataBase
    {
        public static Dictionary<long, User> users_db = new Dictionary<long, User>();


        public DataBase()
        {

        }
        public static Dictionary<long, User> getUsers()
        {
            return users_db;
        }

    }
}