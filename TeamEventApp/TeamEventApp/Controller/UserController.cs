using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp
{
    public class UserController
    {

        public static async Task<User> addUser(User user)
        {
            
            string queryString = "http://teamevent.azurewebsites.net/api/users";
            string content = JsonConvert.SerializeObject(user);
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<User>(results);

        }

        public static async Task<User> getUser(int id)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/users/"+id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<User>(results);

        }

        public static async Task<List<User>> getAllUsers()
        {

            string queryString = "http://teamevent.azurewebsites.net/api/users";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<User>>(results);

        }

        public static async void delUser(int id)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/users/"+id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<User> modifUser(User user)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/users";
            string content = JsonConvert.SerializeObject(user);
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<User>(results);

        }

        public static async Task<User> login(User user)
        {

            string queryString = "http://teamevent.azurewebsites.net/api/userLogin";
            string content = JsonConvert.SerializeObject(user);
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<User>(results);

        }

    }
}
