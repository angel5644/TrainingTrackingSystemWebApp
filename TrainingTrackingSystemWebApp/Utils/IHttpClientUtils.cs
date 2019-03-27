using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackingSystemWebApp.Models
{
    public interface IHttpClientUtils
    {
        HttpClient Client { get; }
        string BaseUrl { get; }

    }
}
