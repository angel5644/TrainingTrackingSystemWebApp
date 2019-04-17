using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingTrackingSystemWebApp.ViewModels
{
    public class DetailsViewModel
    {
        [ReadOnly(true)]
        public int id { get; set; }

        [ReadOnly(true)]
        public string first_name { get; set; }

        [ReadOnly(true)]
        public string last_name { get; set; }

        [ReadOnly(true)]
        public string email { get; set; }

        [ReadOnly(true)]
        public int type { get; set; }

    }
}