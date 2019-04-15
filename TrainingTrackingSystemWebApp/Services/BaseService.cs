using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Services
{
    public class BaseService<T> : IBaseService<T> where T:class
    {
        public BaseService(IHttpClientUtils clienUtils)
        {
            _clientUtils = clienUtils;
        }

        private IHttpClientUtils _clientUtils;

        public async Task<T> Get(string endPoint, int Id) 
        {
            HttpResponseMessage res = await _clientUtils.Client.GetAsync(endPoint + "/" + Id.ToString());

            if (res.IsSuccessStatusCode)
            {
                string data = await res.Content.ReadAsStringAsync();

                T userDto = JsonConvert.DeserializeObject<T>(data);

                return userDto;
            }
            else
            {
                return default(T);
            }
        }

        public async Task<T> Put(string endPoint, T dtoObject)
        {
            string url = endPoint;

            string userAsJson = JsonConvert.SerializeObject(dtoObject);
            HttpContent content = new StringContent(userAsJson, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = await _clientUtils.Client.PutAsync(url, content);

            string data = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                T newEntity = JsonConvert.DeserializeObject<T>(data);

                return newEntity;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                T newEntity = JsonConvert.DeserializeObject<T>(data);

                return newEntity;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string msg = data;

                throw new ArgumentException("The request was not in the correct format. Message: " + msg);
            }
            return default(T);
        }

        //public async Task<List<UserDTO>> Get(string endPoint, string searchField, string searchValue, string orderBy, string orderType, int pageNo, int numberRec)
        public async Task<List<T>> GetMany(string endPoint) 
        {
            // endpoint = users
            // userId = 1
            // pageNo = 1
            // posts?userId=1
            //string url = string.Format("{0}?searchField={1}&searchValue={2}&orderBy={3}&orderType={4}&pageNo={5}&numberRec={6}", endPoint, searchField, searchValue, orderBy, orderType, pageNo, numberRec);

            HttpResponseMessage response = await _clientUtils.Client.GetAsync(endPoint);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Get data
                string data = await response.Content.ReadAsStringAsync();

                List<T> entities = JsonConvert.DeserializeObject<List<T>>(data);

                return entities;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException("The request was not in the correct format.");
            }

            return null;
        }

        public async Task<T> Post(string endPoint, T dtoObject) 
        {
            string url = endPoint;

            string userAsJson = JsonConvert.SerializeObject(dtoObject);
            HttpContent content = new StringContent(userAsJson, UnicodeEncoding.UTF8, "application/json");
            //GET?

            HttpResponseMessage response = await _clientUtils.Client.PostAsync(url, content);

            string data = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                T newEntity = JsonConvert.DeserializeObject<T>(data);

                return newEntity;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string msg = data;

                throw new ArgumentException("The request was not in the correct format. Message: " + msg);
            }

            return null;
        }

        public async Task<bool> Delete(string endPoint, int id)
        {
            // Call post api
            string url = string.Format("{0}/{1}", endPoint, id);
            HttpResponseMessage response = await _clientUtils.Client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string contentMsg = await response.Content.ReadAsStringAsync();
                string msg = "Error while deleting user. Status code: " + response.StatusCode + "Message: " + contentMsg;
                Console.WriteLine(msg);
                throw new ApplicationException(msg);
            }
        }
    }
}