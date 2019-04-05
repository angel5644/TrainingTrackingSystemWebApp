using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
        private IHttpClientUtils clientUtils;

        public UsersController()
        {
            clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/UsersJsonData/");
        }

        public UsersController(IHttpClientUtils httpClientUtils)
        {
            clientUtils = httpClientUtils;
        }

        //get the user to update
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            EditUserViewModel editUserVM = new EditUserViewModel();

            UserDTO userDTO = await clientUtils.GetUser("users", Id);

            if (userDTO == null) {
                TempData["Message"] = "The user does not exist";
                return RedirectToAction("Index", "Home");
            }

            editUserVM.Id = userDTO.id;
            editUserVM.FirstName = userDTO.first_name;
            editUserVM.LastName = userDTO.last_name;
            editUserVM.Email = userDTO.email;
            editUserVM.Type = (UserType)userDTO.type;

            return View(editUserVM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditUserViewModel user)
        {
            string userJson = JsonConvert.SerializeObject(user);

            // var response = await clientUtils.Put("users", userDTO);

            Console.WriteLine(userJson);

            if (Response.StatusCode >= 200 && Response.StatusCode <= 299) //Status ok
                return View();
            else 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //Bad request
        }
    }
}