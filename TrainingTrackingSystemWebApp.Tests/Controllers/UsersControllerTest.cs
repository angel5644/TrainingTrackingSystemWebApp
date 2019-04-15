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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateUser()
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
