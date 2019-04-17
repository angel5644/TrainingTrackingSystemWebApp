using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TrainingTrackingSystemWebApp.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {

        }

        public UserDTO(int id, string first_name, string last_name, string email, int type)
        {
            this.id = id;

            this.first_name = first_name;

            this.last_name = last_name;

            this.email = email;

            this.type = type;

        }

        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public int type { get; set; }
    }

}