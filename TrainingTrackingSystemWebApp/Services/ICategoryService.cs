using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.DTO;

namespace TrainingTrackingSystemWebApp.Services
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        /// <summary>
        /// Verify if a category name exists
        /// </summary>
        /// <param name="endPoint">The categories end point</param>
        /// <param name="name">The category name</param>
        /// <returns>True if the category exists, otherwise false.</returns>
        Task<bool> Exists(string endPoint, string name);
    }
}
