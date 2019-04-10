using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Services
{
    public class UserService : BaseService<UserDTO>, IUserService 
    {
        public UserService(IHttpClientUtils clientUtils) : base(clientUtils)
        {

        }

        
    }
}