using Newtonsoft.Json;
using System;
using System.Collections;
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
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class HomeController : Controller
    {
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
        /*public ActionResult Register()
        {
            return View();
        }*/
    }
}