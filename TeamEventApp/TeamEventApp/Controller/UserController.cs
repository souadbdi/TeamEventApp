using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeamEvent;
using TeamEventApp.Convertisseur;

namespace TeamEventApp
{
    public class UserController
    {

        public static async Task<User> addUser(User user)
        {
            
            string queryString = Url.urlLink+ "Users";
            string content = JsonConvert.SerializeObject(UserConvertor.UserToDB(user));
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            UserEntity userE = JsonConvert.DeserializeObject<UserEntity>(results);
            return UserConvertor.DBToUser(userE);
        }

        public static async Task<User> getUser(int id)
        {

            string queryString = Url.urlLink + "Users/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            UserEntity userE = JsonConvert.DeserializeObject<UserEntity>(results);
            return UserConvertor.DBToUser(userE);

        }

        public static async Task<List<User>> getAllUsers()
        {

            string queryString = Url.urlLink + "Users";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<UserEntity> ListUserE = JsonConvert.DeserializeObject<List<UserEntity>>(results);
            List<User> listUser = new List<User>();
            for (var i=0; i< ListUserE.Count; i++)
            {
                listUser.Add(UserConvertor.DBToUser(ListUserE[i]));
            }
            return listUser;

        }

        public static async Task<List<User>> getUsersContact()
        {

            string queryString = Url.urlLink + "UserContact/"+DataBase.current_user.userId;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<UserEntity> ListUserE = JsonConvert.DeserializeObject<List<UserEntity>>(results);
            List<User> listUser = new List<User>();
            for (var i = 0; i < ListUserE.Count; i++)
            {
                listUser.Add(UserConvertor.DBToUser(ListUserE[i]));
            }
            return listUser;

        }

        public static async void delUser(int id)
        {

            string queryString = Url.urlLink + "Users/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<User> modifUser(User user)
        {

            string queryString = Url.urlLink + "Users";
            string content = JsonConvert.SerializeObject(UserConvertor.UserToDB(user));
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            UserEntity userE = JsonConvert.DeserializeObject<UserEntity>(results);
            return UserConvertor.DBToUser(userE);

        }

        public static async Task<User> login(User user)
        {

            string queryString = Url.urlLink + "UsersLogin";
            string content = JsonConvert.SerializeObject(UserConvertor.UserToDB(user));
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            UserEntity userE = JsonConvert.DeserializeObject<UserEntity>(results);
            return UserConvertor.DBToUser(userE);

        }

    }
}
