using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.Controllers;
using TrainingTrackingSystemWebApp.ViewModels;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.DTO;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.Services;

namespace TrainingTrackingSystemWebApp.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        HttpClientUtils clientUtils;
        UsersController UserController = new UsersController();
        EditUserViewModel user = new EditUserViewModel();
        UserDTO DTO = new UserDTO();

        [TestInitialize]
        public void TestSetUp()
        {
            clientUtils = new HttpClientUtils(baseAddress: "https://my-json-server.typicode.com/angel5644/UsersJsonData/");
            UserService service = new UserService();
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Dispose
        }
        [TestMethod]
        public async Task Should_notReturnNull_whenUserExists()
        {
            //Arrange
            int id = 1;

            //Act
            ViewResult view = await UserController.Edit(id) as ViewResult;

            //Assert
            Assert.IsNotNull(view);
        }   

        [TestMethod]
        public async Task Shoud_BeNull_WhenFieldsAreIncomplete()
        {
            //Arrange
            user.Id = 1;
            user.FirstName = "Carlos";
            user.LastName = "";
            user.Email = "cm2019@4thsource.com";
            DTO.type = 1;
            user.Type = (UserType)DTO.type;
               
            //Act
            ViewResult view = await UserController.Edit(user) as ViewResult;

            //Assert
            Assert.IsNull(view);
        }

        [TestMethod]
        public async Task Get()
        {
            //Arrange

        }
        //[TestMethod]
        //public async Task Should_ReturnIndex_WhenUserDoesntExist()
        //{
        //    int id = 31;

        //    ViewResult expected = await UserController.Index() as ViewResult;
        //    ViewResult view = await UserController.Edit(id) as ViewResult;

        //    Assert.AreSame(expected, view);
        //}
    }
}
