using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingTrackingSystemWebApp.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            
        }

        public CategoryDTO(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}