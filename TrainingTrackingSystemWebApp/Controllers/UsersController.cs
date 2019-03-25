using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
   
    public class UsersController : Controller
    {
    
        // GET: User
        public ActionResult Edit(int Id)
        {
            EditUserViewModel data = new EditUserViewModel();
            if (Id==1)
            {
                data.FirstName = "Carlos Omar";
                data.LastName = "Sanchez Solorzano";
                data.Email = "mikol1326@gmail.com";
                data.Type = (UserType)2;

                return View(data);
            }
            else
            {
                return View(data);
            }
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