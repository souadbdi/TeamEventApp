using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeamEvent.Models;
using TeamEventApp.Convertisseur;

namespace TeamEventApp.Controller
{
    public class CommentController
    {
        public static async Task<Comment> addComment(Comment comment)
        {

            string queryString = Url.urlLink + "Comments";
            string content = JsonConvert.SerializeObject(CommentConvertor.CommentToDB(comment));
            HttpMethod method = HttpMethod.Post;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            CommentEntity commentE = JsonConvert.DeserializeObject<CommentEntity>(results);
            return CommentConvertor.DBToComment(commentE);

        }

        public static async Task<Comment> getComment(int id)
        {

            string queryString = Url.urlLink + "Comments/" + id;
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            CommentEntity commentE = JsonConvert.DeserializeObject<CommentEntity>(results);
            return CommentConvertor.DBToComment(commentE);

        }

        public static async Task<List<Comment>> getAllComment()
        {

            string queryString = Url.urlLink + "Comments";
            string content = "";
            HttpMethod method = HttpMethod.Get;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            List<CommentEntity> ListCommentE = JsonConvert.DeserializeObject<List<CommentEntity>>(results);
            List<Comment> listComment = new List<Comment>();
            for (var i = 0; i < ListCommentE.Count; i++)
            {
                listComment.Add(CommentConvertor.DBToComment(ListCommentE[i]));
            }
            return listComment;

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
            string content = JsonConvert.SerializeObject(CommentConvertor.CommentToDB(comment));
            HttpMethod method = HttpMethod.Put;
            dynamic results = await DataService.getDataFromService(queryString, method, content).ConfigureAwait(false);

            CommentEntity commentE = JsonConvert.DeserializeObject<CommentEntity>(results);
            return CommentConvertor.DBToComment(commentE);

        }
    }
}
