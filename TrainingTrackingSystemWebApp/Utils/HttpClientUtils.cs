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
using TrainingTrackingSystemWebApp.DTO;
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

        

       
        
    }
}