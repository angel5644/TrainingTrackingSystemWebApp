using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.ViewModels.Categories;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel viewModel)
        {
            // Validate the data received is correct
            if (ModelState.IsValid)
            {
                // If data is valid

                // Make call rest service to create category
                bool isCreated = true; // call service

                // Validate response
                if (isCreated)
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
                return View("Create", viewModel);
            }
            
        }
    }
}