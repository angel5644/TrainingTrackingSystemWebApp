using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TrainingTrackingSystemWebApp.DTOs;
using TrainingTrackingSystemWebApp.ViewModels;

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
        private string baseAddress;
        private bool authorization;

        public string BaseUrl
        {
            get { return _baseUrl; }
            //set { _baseUrl = value; }
        }

        public HttpClientUtils(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public HttpClientUtils(string baseAddress)
        {
            _client = new HttpClient();

            _baseUrl = baseAddress;
            _client.BaseAddress = new Uri(baseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        public T Get<T>(string endPoint, string[] parameters)
        {
            throw new NotImplementedException();
        }

       
        public async Task<UserDTO> GetUser(string endPoint, int Id)
        {
            HttpResponseMessage res = await _client.GetAsync(endPoint + "/" + Id.ToString());

            if (res.IsSuccessStatusCode)
            {
                //EditUserViewModel editUserVM = new EditUserViewModel();
                string data = await res.Content.ReadAsStringAsync();

                UserDTO userDto = JsonConvert.DeserializeObject<UserDTO>(data);

                return userDto;
            }
            else
            {
                return ((UserDTO)null);
            }
        }

        public async Task<UserDTO> Put(string endPoint, UserDTO user)
        {
            string url = endPoint;

            string userAsJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(userAsJson, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(url, content);

            string data = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
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