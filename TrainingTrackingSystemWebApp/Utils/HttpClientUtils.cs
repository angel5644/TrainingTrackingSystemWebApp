using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public string BaseUrl
        {
            get { return _baseUrl; }
            //set { _baseUrl = value; }
        }

        public HttpClientUtils(string baseAddress)
        {
            _client = new HttpClient();

            _baseUrl = baseAddress;
            _client.BaseAddress = new Uri(baseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<UserDTO> GetUser(int Id)
        {
            HttpResponseMessage res = await _client.GetAsync(Id.ToString());

            if (res.IsSuccessStatusCode)
            {
                EditUserViewModel editUserVM = new EditUserViewModel();
                string data = await res.Content.ReadAsStringAsync();

                UserDTO userDto = JsonConvert.DeserializeObject<UserDTO>(data);

                return userDto;
            }
            else
            {
                return ((UserDTO)null);
            }
        }
    }
}