using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingTrackingSystemWebApp.DTOs
{
    public class UserDTO
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int type { get; set; }
    }
}