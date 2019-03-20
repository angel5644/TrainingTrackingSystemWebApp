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
                data.Type = 1;
                return View("EditUser", data);
            }
            else
            {
                return View("EditUser",data);
            }
        }
        [HttpPut]
        public ActionResult Update(EditUserViewModel user)
        {
            string userJson = JsonConvert.SerializeObject(user);

            Console.WriteLine(userJson);

            return View("List");
        }
    }
}