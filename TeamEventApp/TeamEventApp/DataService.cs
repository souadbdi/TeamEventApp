using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp
{
    public class DataService
    {
            public static async Task<dynamic> getDataFromService(string queryString, HttpMethod method, string content)
            {

                HttpRequestMessage request = new HttpRequestMessage(method, queryString);
                request.Content = new StringContent(content);
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

                string responseText = await httpResponse.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(responseText);
                return data;
            }
       
    }

}
