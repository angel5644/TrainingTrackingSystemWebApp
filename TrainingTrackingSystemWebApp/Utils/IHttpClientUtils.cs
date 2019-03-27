using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdministraGastos.Common.Utils
{
    public interface IHttpClientUtils
    {
        HttpClient Client { get; }
        string BaseUrl { get; }

        Task<string> GetToken(string userName, string password);
        Task<T> Get<T>(string endPoint, params string[] parameters) where T : class;
    }
}
