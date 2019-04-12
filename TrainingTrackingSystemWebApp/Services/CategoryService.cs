using Newtonsoft.Json;
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
    public class CategoryService : BaseService<CategoryDTO>, ICategoryService
    {
        IHttpClientUtils _clientUtils;

        public CategoryService(IHttpClientUtils clientUtils) : base(clientUtils)
        {
            this._clientUtils = clientUtils;
        }

        /// <summary>
        /// Verify if a category name exists
        /// </summary>
        /// <param name="endPoint">The categories end point</param>
        /// <param name="name">The category name</param>
        /// <returns>True if the category exists, otherwise false.</returns>
        public async Task<bool> Exists(string endPoint, string name)
        {
            // Get all the categories
            HttpResponseMessage res = await _clientUtils.GetAsync(endPoint);

            if (res.IsSuccessStatusCode)
            {
                string categoriesData = await res.Content.ReadAsStringAsync();

                List<CategoryDTO> categoriesDTO = JsonConvert.DeserializeObject<List<CategoryDTO>>(categoriesData);

                bool exists = categoriesDTO.Any(category => category.Name == name);

                return exists;
            }
            else
            {
                string errMsg = await res.Content.ReadAsStringAsync();

                throw new ApplicationException("An unkown error was encountered while checking if the category exists. Message: " + errMsg);
            }
        }
    }
}