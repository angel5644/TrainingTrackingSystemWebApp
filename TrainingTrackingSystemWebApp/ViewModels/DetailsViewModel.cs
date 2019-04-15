using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingTrackingSystemWebApp.ViewModels
{
    public class DetailsViewModel
    {
        [Editable(false)]
        public int id { get; set; }

        [Editable(false)]
        public string first_name { get;  set; }

        [Editable(false)]
        public string last_name { get; set; }

        [Editable(false)]
        public string email { get;  set; }

        [Editable(false)]
        public int type { get;  set; }

    }
}