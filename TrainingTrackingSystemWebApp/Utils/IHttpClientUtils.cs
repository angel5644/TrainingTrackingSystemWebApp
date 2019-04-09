using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.DTOs;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Utils
{
  public interface IHttpClientUtils
    {
        HttpClient Client { get; }
        string BaseUrl
        {
            get;
        }
        Task<UserDTO> GetUser(string endPoint, int Id);
        Task<UserDTO> Put(string v, UserDTO userDTO);
    }
}
