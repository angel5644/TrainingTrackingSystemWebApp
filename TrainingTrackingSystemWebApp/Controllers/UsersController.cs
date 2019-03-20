using System;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult CreateUser()
        {
            return View();
        }

        //Create button URL
        [System.Web.Http.HttpPost]
        public ActionResult Create(createUserVM user)
        {
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String email = user.Email;
            UserType rol = user.Type;

            //List<CreateUserViewModel> lst;
            return RedirectToAction("Index","Home");
        }
    }
}
