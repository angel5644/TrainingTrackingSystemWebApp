using System;
using TrainingTrackingSystemWebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.ViewModels;
using Newtonsoft.Json;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Web.Mvc;

namespace TrainingTrackingSystemWebApp.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private UsersController usersController;
        IHttpClientUtils clientUtils;
        UserDTO user;
        EditUserViewModel editUserVM;

        [TestInitialize]
        public void TestSetUp()
        {
            clientUtils = new HttpClientUtils(baseAddress: "https://my-json-server.typicode.com/angel5644/UsersJsonData/");
            usersController = new UsersController(clientUtils);
            user = new UserDTO();
            editUserVM = new EditUserViewModel();
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Dispose
        }

        [TestMethod]
        public async Task Edit_Should_ReturnNotNull_When_ExistingUser()
        {
            // arrange
            int id = 1;

            // act
            var result = await usersController.Edit(id) as ViewResult;


            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public async Task Edit_Should_ReturnNull_When_NonExistingUser()
        {
            // arrange
            int id = -1;

            // act
            var result = await usersController.Edit(id) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Edit_Should_NotReturnNull_When_ListisCalled()
        {
            //arrange
            editUserVM.Id = 1;
            editUserVM.FirstName = "Charly";
            editUserVM.LastName = "Garcia";
            editUserVM.Email = "cg2019@4thsource.com";
            user.type = 1;
            editUserVM.Type = (UserType)user.type;

            //act
            var result = usersController.Edit(editUserVM) as ViewResult;

            Assert.IsNotNull(result.Model);
        }
    }
}
