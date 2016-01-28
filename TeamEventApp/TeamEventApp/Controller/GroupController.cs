using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp.Controller
{
    public class GroupController
    {
        public static async Task<Group> addGroup(Group group)
        {

            string queryString = Url.urlLink + "Groups";
            string content = JsonConvert.SerializeObject(group);
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Group>(results);

        }

        public static async Task<Group> getGroup(int id)
        {

            string queryString = Url.urlLink + "Groups/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Group>(results);

        }

        public static async Task<List<Group>> getAllGroup()
        {

            string queryString = Url.urlLink + "Groups";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<Group>>(results);

        }

        public static async void delGroup(int id)
        {

            string queryString = Url.urlLink + "Groups/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<Group> modifGroup(Group group)
        {

            string queryString = Url.urlLink + "Groups";
            string content = JsonConvert.SerializeObject(group);
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Group>(results);

        }
    }
}
