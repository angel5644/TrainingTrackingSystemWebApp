using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.Controllers;
using TrainingTrackingSystemWebApp.ViewModels;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.DTO;
using System.Web.Mvc;
using Moq;
using TrainingTrackingSystemWebApp.Utils;
using TrainingTrackingSystemWebApp.Services;
using Newtonsoft.Json;
using System.Net.Http;
using TrainingTrackingSystemWebApp.ViewModels.Categories;

namespace TrainingTrackingSystemWebApp.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        private UsersController controller;

        private Mock<IUserService> mockUserService;


        [TestInitialize]
        public void TestSetUp()
        {
            mockUserService = new Mock<IUserService>();

            controller = new UsersController(mockUserService.Object);

            controller.TempData = new TempDataDictionary();
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Dispose
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
        public async Task Index_Should_ReturnIndexView()
        {
            // Arrange           
            string expected = "Index"; // name of the view expected

            // Act
            ActionResult actionResult = await controller.Index();

            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName == expected || result.ViewName == string.Empty);
        }

        [TestMethod]
        public async Task Index_Should_ReturnNotNull()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Index_Should_ReturnViewResultType()
        {
            // Arrange          
            ActionResult actionResult = await controller.Index();

            // Act
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Details_Should_ReturnNotNull()
        {
            // Arrange
            UsersController controller = new UsersController();

            int id = 1;

            // Act
            ViewResult result = await controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Details_Should_ReturnDetailsView()
        {
            // Arrange
            UsersController controller = new UsersController();

            string expected = "Details";

            int id = 1;

            // Act
            ActionResult actionResult = await controller.Details(id);

            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName == expected || result.ViewName == string.Empty);
        }

        [TestMethod]
        public async Task Details_Should_Return()
        {
            mockUserService.Setup(service => service.Get(It.Is<string>(endpoint => endpoint == "users"), It.Is<int>(ids => ids == 5)))
               .Returns(Task.FromResult((UserDTO)null));

            // Arrange
            DetailsViewModel viewModel = new DetailsViewModel()
            {
                id = 5,
                first_name = "Luis",
                last_name = "Flores",
                email = "luisflores@gmail.com",
                type = 1
            };

            //UsersController controller = new UsersController();

            int id = 5;

            // Act
            ActionResult actionResult = await controller.Details(viewModel.id);

            ViewResult result = actionResult as ViewResult;
            DetailsViewModel resultVM = result.Model as DetailsViewModel;
            //ActionResult actionResult = await controller.Details(viewModel.id);
            //ViewResult result = actionResult as ViewResult;

            // Assert
            //Assert.AreEqual(expected, result);
            Assert.AreEqual(resultVM.id, id);

        }

        //[TestMethod]
        //public async Task Should_notReturnNull_whenUserExists()
        //{
        //    //Arrange
        //    int id = 1;

        //    //Act
        //    ViewResult view = await UserController.Edit(id) as ViewResult;

        //    //Assert
        //    Assert.IsNotNull(view);
        //}   


        //[TestMethod]
        //public void CreateUser()
        //{
        //    //Arrange
        //    user.Id = 1;
        //    user.FirstName = "Carlos";
        //    user.LastName = "";
        //    user.Email = "cm2019@4thsource.com";
        //    DTO.type = 1;
        //    user.Type = (UserType)DTO.type;

        //    //Act
        //    ViewResult view = await UserController.Edit(user) as ViewResult;

        //    //Assert
        //    Assert.IsNull(view);
        //}

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
