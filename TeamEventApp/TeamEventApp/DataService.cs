using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp
{
    class DataService
    {
            public static async Task<dynamic> getDataFromService(string queryString)
            {

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, queryString);
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

                string responseText = await httpResponse.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(responseText);
                return data;
            }
       
    }

}
