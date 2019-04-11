using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Services;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.ViewModels;

namespace TrainingTrackingSystemWebApp.Controllers
{
    public class UsersController : Controller
    {

        //private IHttpClientUtils clientUtils;
        private IUserService _userService;

        public UsersController()
        {
            var clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/UsersJsonData/");

            _userService = new UserService(clientUtils);
        }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            UsersIndexViewModel viewModel = new UsersIndexViewModel();

            var users = await _userService.GetMany("users");

            viewModel.Users = users;

            return View("Index", viewModel);
        }

        // GET: Users
        public ActionResult Create()
        {
            return View();
        }

        //List
        [HttpPost]
        public async Task<ActionResult> CreateUser(createUserVM viewModel)
        {
            UserDTO user = new UserDTO();

            user.first_name = viewModel.FirstName;
            user.email = viewModel.Email;
            user.id = viewModel.Id;
            user.last_name = viewModel.LastName;
            user.type = (int)viewModel.Type;
            
            try
            {
                var response = await _userService.Post("users", user);
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

        //get the user to update
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            EditUserViewModel editUserVM = new EditUserViewModel();

            UserDTO userDTO = await _userService.Get("users", Id);

            if (userDTO == null)
            {
                TempData["Message"] = "The user does not exist";
                return RedirectToAction("Index", "Users");
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
            UserDTO DTO = new UserDTO();
            string userJson = JsonConvert.SerializeObject(user);

            DTO.id = user.Id;
            DTO.first_name = user.FirstName;
            DTO.last_name = user.LastName;
            DTO.email = user.Email;
            DTO.type = Convert.ToInt32(user.Type);

            Console.WriteLine(userJson);
            try
            {
                var response = await _userService.Put("users", DTO);
            }
            catch (ArgumentException ex)
            {
                // In case of an error, return to the currrent view where the user is being created 
                ViewBag.ErrorMessage = ex.Message;

                return View(user);
            }
            // In case of success, redirect to the users index page
            TempData["Success"] = "The user with the ID # " + DTO.id + " was edited";
            return RedirectToAction("Index");
        }     
 
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            bool isDeleted = false;
            string msg = string.Empty;

            try
            {
                isDeleted = await _userService.Delete("users", id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return Json(new { isDeleted = isDeleted, message = msg });
        }
    }
}
