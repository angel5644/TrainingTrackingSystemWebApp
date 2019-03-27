using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Models;

namespace TrainingTrackingSystemWebApp.Utils
{
    public class HttpClientUtils : IHttpClientUtils
    {
        private HttpClient _client;

        public HttpClient Client
        {
            get
            {
                return _client;
            }
            //set { _client = value; }
        }

        private string _baseUrl;

        public string BaseUrl
        {
            get { return _baseUrl; }
            //set { _baseUrl = value; }
        }

        public HttpClientUtils(string baseAddress, bool authorization = true, string bearerToken = "")
        {
            _client = new HttpClient();

            _baseUrl = baseAddress;
            _client.BaseAddress = new Uri(baseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();

            if (authorization)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }
        }

        public async Task<List<UserDTO>> Get(string endPoint)
        {
            // endpoint = users
            // userId = 1
            // posts?userId=1
            string url = endPoint;

            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Get data
                string data = await response.Content.ReadAsStringAsync();

                List<UserDTO> posts = JsonConvert.DeserializeObject<List<UserDTO>>(data);


                return posts;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException("The request was not in the correct format.");
            }

            return null;
        }
    }

}
       