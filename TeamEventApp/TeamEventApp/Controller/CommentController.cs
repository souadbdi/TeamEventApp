using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp.Controller
{
    public class CommentController
    {
        public static async Task<Comment> addComment(Comment comment)
        {

            string queryString = Url.urlLink + "Comments";
            string content = JsonConvert.SerializeObject(comment);
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Comment>(results);

        }

        public static async Task<Comment> getComment(int id)
        {

            string queryString = Url.urlLink + "Comments/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Comment>(results);

        }

        public static async Task<List<Comment>> getAllComment()
        {

            string queryString = Url.urlLink + "Comments";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<Comment>>(results);

        }

        public static async void delComment(int id)
        {

            string queryString = Url.urlLink + "Comments/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Delete;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

        }

        public static async Task<Comment> modifComment(Comment comment)
        {

            string queryString = Url.urlLink + "Comments";
            string content = JsonConvert.SerializeObject(comment);
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Comment>(results);

        }
    }
}
