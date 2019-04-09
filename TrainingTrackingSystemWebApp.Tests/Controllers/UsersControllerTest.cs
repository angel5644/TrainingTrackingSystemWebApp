using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using TrainingTrackingSystemWebApp.Controllers;
using TrainingTrackingSystemWebApp.ViewModels;
using System.Threading.Tasks;

namespace TrainingTrackingSystemWebApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for UserControllerTest
    /// </summary>
    [TestClass]
    public class UsersControllerTest
    {
        public UsersControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        public void CreateUser()
        {
            //Arrange
            UsersController controller = new UsersController();

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Create()
        {
            var CreateUserVM = new createUserVM();
            //Arrange
            UsersController controller = new UsersController();

            //Act
            var result = await controller.CreateUser(CreateUserVM) as RedirectToRouteResult;

            result.RouteValues["action"].Equals("Index");
            result.RouteValues["controller"].Equals("Home");

            //Assert
            Assert.IsNotNull(result, "Not a direct result");
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);

        }
    }
}
