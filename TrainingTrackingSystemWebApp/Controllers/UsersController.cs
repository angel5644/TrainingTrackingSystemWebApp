using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using TrainingTrackingSystemWebApp.DTOs;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
   
    public class UsersController : Controller
    {
        private HttpClientUtils clientUtils;

        public  UsersController()
        {
            clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/UsersJsonData/Users/");
        }

        //get the user to update
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            EditUserViewModel editUserVM = new EditUserViewModel();

            var user = await clientUtils.GetUser(Id);

            editUserVM.Id = user.id;
            editUserVM.FirstName = user.first_name;
            editUserVM.LastName = user.last_name;
            editUserVM.Email = user.email;
            editUserVM.Type = (UserType)user.type;

            return View(editUserVM);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel user)
        {
            string userJson = JsonConvert.SerializeObject(user);

            Console.WriteLine(userJson);

            return View();
        }
    }
}