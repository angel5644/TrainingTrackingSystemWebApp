using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Services;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.ViewModels.Categories;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _categorySevice;

        public CategoriesController()
        {
            IHttpClientUtils clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/TTSData/");

            _categorySevice = new CategoryService(clientUtils);
        }

        public CategoriesController(ICategoryService categoryService)
        {
            _categorySevice = categoryService;
        }

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            // Get categories from db 
            List<CategoryDTO> categories = await _categorySevice.GetMany("categories");

            // Categories view models
            List<CategoryViewModel> categoriesVM = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                // Create new category view model
                CategoryViewModel newCategoryVM = new CategoryViewModel()
                {
                    Name = category.Name,
                    Description = category.Description
                };

                // Add to the list
                categoriesVM.Add(newCategoryVM);
            }


            return View("Index", categoriesVM);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryViewModel viewModel)
        {
            // Validate the data received is correct
            if (ModelState.IsValid)
            {
                // Copy data from view model to the categody dto that i want to create
                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                // Validate that the category name does not exist yet
                var exist = await _categorySevice.Exists("categories", categoryDTO.Name);

                if (!exist)
                {
                    // Category does not exists, create the category 
                    CategoryDTO newCategoryDTO = await _categorySevice.Post("categories", categoryDTO);

                    // Validate response
                    if (newCategoryDTO != null)
                    {
                        TempData["Success"] = "The category was created";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "An error occured while creating category.";

                        return View(viewModel);
                    }
                }
                else
                {
                    TempData["Error"] = "This category already exists";

                    return View(viewModel);
                }
            }
            else
            {
                return View("Create", viewModel);
            }
            
        }
    }
}