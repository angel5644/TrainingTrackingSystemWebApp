using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdministraGastos.Common.Utils
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
        }

        private string _baseUrl;

        public string BaseUrl
        {
            get { return _baseUrl; }
            //set { _baseUrl = value; }
        }
        /// <summary>
        /// Initializes a new http client utils with the given parameters
        /// </summary>
        /// <param name="baseAddress">The url base address</param>
        /// <param name="authorization">The authorization flag, true by default</param>
        /// <param name="bearerToken">The bearer token (if authorization is enabled)</param>
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

        /// <summary>
        /// Gets a token using username and password
        /// </summary>
        /// <param name="userName">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The token</returns>
        public async Task<string> GetToken(string userName, string password)
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("userName",userName),
                new KeyValuePair<string,string>("password",password),
            });

            // Call post api
            HttpResponseMessage response = await _client.PostAsync("token", content);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                object responseData = JsonConvert.DeserializeObject(result);

                string token = ((dynamic)responseData).access_token;

                Console.WriteLine("Token:" + token);

                return token;
            }
            else
            {
                Console.WriteLine("Not able to get token. Status code: {0}", response.StatusCode);
            }

            return string.Empty;
        }

        public async Task<T> Get<T>(string endPoint, params string[] parameters) where T : class
        {
            string url = parameters.Any() ? string.Format(endPoint, parameters) : endPoint;

            HttpResponseMessage response = await _client.GetAsync(url);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Read content response
                string obj = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(obj);
            }

            return default(T);
        }

        public async Task<List<TestPost>> Get(string endPoint, string userId)
        {
            // endpoint = posts
            // userId = 1
            // posts?userId=1
            string url = endPoint + "?userId=" + userId;

            url = string.Format("{0}?userId={1}", endPoint, userId);

            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Get data
                string data = await response.Content.ReadAsStringAsync();

                List<TestPost> posts = JsonConvert.DeserializeObject<List<TestPost>>(data);

                return posts;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException("The request was not in the correct format.");
            }

            return null;
        }
    }

    public class TestPost
    {
        public string userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}