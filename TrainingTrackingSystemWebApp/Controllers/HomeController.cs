﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Models;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class HomeController : Controller
    {
        public class UserViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int Type { get; set; }
        }

        private HttpClientUtils clientUtils;

        public HomeController()
        {
            clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/UsersJsonData/");
        }

        public async Task<ActionResult> Index()
        {
            UsersIndexViewModel viewModel = new UsersIndexViewModel();

            var users = await clientUtils.Get("users");

            viewModel.Users = users;

            return View("Index", viewModel);

        }

        [HttpGet]
        public async Task<JsonResult> FindUsers(string searchField, string searchValue, string orderType)
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