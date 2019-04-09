using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.ViewModels;
using TrainingTrackingSystemWebApp.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

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
            //set {_baseUrl = value; }
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

        //Post?
        public async Task<UserDTO> Post(string endPoint, UserDTO user)
        {
            string url = endPoint;

            string userAsJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(userAsJson, UnicodeEncoding.UTF8, "application/json");
            //GET?

            HttpResponseMessage response = await _client.PostAsync(url, content);
            
            string data = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                

                //List
                UserDTO posts = JsonConvert.DeserializeObject<UserDTO>(data);

                return posts;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string msg = data;

                throw new ArgumentException("The request was not in the correct format. Message: " + msg);
            }

            return null;
        }
    }
}
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

        public async Task<List<UserDTO>> Get(string endPoint, string searchField, string searchValue, string orderBy, string orderType, int pageNo, int numberRec)
        {
            // endpoint = users
            // userId = 1
            // pageNo = 1
            // posts?userId=1
            string url = string.Format("{0}?searchField={1}&searchValue={2}&orderBy={3}&orderType={4}&pageNo={5}&numberRec={6}", endPoint, searchField, searchValue, orderBy, orderType, pageNo, numberRec);

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
       