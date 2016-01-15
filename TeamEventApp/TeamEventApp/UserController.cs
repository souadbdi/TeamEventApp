using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp
{
    class UserController
    {
        public static async Task<string> addUser()
        {

            string queryString = "";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            return "personne ajoutée";

        }

        public static async Task<string> getUser(int id)
        {

            string queryString = "";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            return "personne ajoutée";

        }

        public static async Task<string> getAllUsers()
        {

            string queryString = "";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            return "personne ajoutée";

        }

        public static async Task<string> delUser(int id)
        {

            string queryString = "";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            return "personne ajoutée";

        }

        public static async Task<string> modifUser(int id)
        {

            string queryString = "";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            return "personne ajoutée";

        }

    }
}
