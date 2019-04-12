﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Utils
{
  public interface IHttpClientUtils
    {
        HttpClient Client { get; set; }
        string BaseUrl
        {
            get;
        }

        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
        //Task<UserDTO> GetUser(string endPoint, int Id);
        //Task<UserDTO> Put(string v, UserDTO userDTO);
        //Task<UserDTO> Post(string endPoint, UserDTO user);
        ////Task<List<UserDTO>> Get(string endPoint, string searchField, string searchValue, string orderBy, string orderType, int pageNo, int numberRec);
        //Task<List<UserDTO>> Get(string endPoint);
        //Task<bool> Delete(string endPoint, int id);
    }
}
