using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class HomeController : Controller
    {
        public class UsersIndexViewModel
        {
            public List<UserViewModel> Users { get; set; }
        }

        public class UserViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int Type { get; set; }
        }
        //jhsj
        public ActionResult Index()
        {
            UsersIndexViewModel viewModel = new UsersIndexViewModel();

            // Call rest service
            viewModel.Users = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    FirstName = "Victor",
                    LastName = "Leon"
                },
                new UserViewModel()
                {
                    FirstName = "Eder",
                    LastName = "Leon"
                },
            };

            return View("Index", viewModel);
        }

        [HttpGet]
        public JsonResult FindUsers(string searchField, string searchValue, string orderType)
        {
            // Call rest service to filter users
            List<UserViewModel> usersFiltered = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    FirstName = "Victor",
                    LastName = "Leon"
                }
            };

            return Json(
                new { data = usersFiltered },
                JsonRequestBehavior.AllowGet
                );
        }

        public ActionResult About()
        {
            // adding a comment
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}