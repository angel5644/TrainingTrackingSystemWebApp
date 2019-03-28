using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Create()
        {
            return View();
        }

        private HttpClientUtils clientUtils;

        public UsersController()
        {
            clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/UsersJsonData/");
        }

        //List
        [HttpPost]
        public async Task<ActionResult> CreateUser(createUserVM viewModel)
        {
            //createUserVM viewModel = new createUserVM();
            UserDTO user = new UserDTO();

            user.first_name = viewModel.FirstName;
            user.email = viewModel.Email;
            user.id = viewModel.Id;
            user.last_name = viewModel.LastName;
            user.type = (int)viewModel.Type;

            //userId?
            

            try
            {
                var response = await clientUtils.Post("users", user);
            }
            catch (ArgumentException ex)
            {
                // In case of an error, return to the currrent view where the user is being created 
                ViewBag.ErrorMessage = ex.Message;

                return View(viewModel);
            }

            // In case of success, redirect to the users index page
            return RedirectToAction("Index");
        }
       

        /*
        //Create button URL
        [System.Web.Http.HttpPost]
        public ActionResult CreateUsr(createUserVM user)
        {
            int id = user.Id;
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String email = user.Email;
            UserType rol = user.Type;

            //List<CreateUserViewModel> lst;
            return RedirectToAction("Index","Home");
        }*/
    }
}
