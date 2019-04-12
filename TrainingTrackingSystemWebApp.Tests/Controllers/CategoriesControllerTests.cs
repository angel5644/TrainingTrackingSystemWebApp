using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainingTrackingSystemWebApp.Controllers;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Services;
using TrainingTrackingSystemWebApp.ViewModels.Categories;

namespace TrainingTrackingSystemWebApp.Tests.Controllers
{
    [TestClass]
    public class CategoriesControllerTests
    {
        private CategoriesController controller;
        private Mock<ICategoryService> mockCategoryService;

        [TestInitialize]
        public void Setup()
        {
            mockCategoryService = new Mock<ICategoryService>();

            controller = new CategoriesController(mockCategoryService.Object);

            controller.TempData = new TempDataDictionary();
        }

        #region Get_Create
        [TestMethod]
        public void Get_Create_Should_ReturnCreateView()
        {
            // Arrange           
            string expected = "Create"; // name of the view expected

            // Act
            ActionResult actionResult = controller.Create();
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName == expected || result.ViewName == string.Empty);
        }

        [TestMethod]
        public void Get_Create_Should_ReturnNotNull()
        {
            // Arrange           
            //string expected = "Create"; // name of the view expected

            // Act
            ActionResult actionResult = controller.Create();
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_Create_Should_ReturnViewResultType()
        {
            // Arrange           
            //string expected = "Create"; // name of the view expected

            // Act
            ActionResult actionResult = controller.Create();
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        #endregion

        #region Post_Create
        [TestMethod]
        public async Task Post_Create_Should_RedirectToIndex_When_CategoryIsCreated()
        {
            // Assert
            #region mock data
             // categories, cualquier string
            mockCategoryService.Setup(service => service.Exists(It.Is<string>(endpoint => endpoint == "categories"), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            CategoryDTO returnedCategoryDTO = new CategoryDTO();
            mockCategoryService.Setup(service => service.Post(It.Is<string>(endpoint => endpoint == "categories"), It.IsAny<CategoryDTO>()))
               .Returns(Task.FromResult(returnedCategoryDTO));
            #endregion

            CreateCategoryViewModel viewModel = new CreateCategoryViewModel();
            string redirectActionExpected = "Index";

            // Act 
            ActionResult actionResult = await controller.Create(viewModel);
            RedirectToRouteResult result = actionResult as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(redirectActionExpected, result.RouteValues["action"].ToString());
        }

        [TestMethod]
        public async Task Post_Create_Should_ReturnToCreateView_When_CategoryAlreadyExists()
        {
            // Assert
            #region mock data
            // categories, cualquier string
            mockCategoryService.Setup(service => service.Exists(It.Is<string>(endpoint => endpoint == "categories"), It.Is<string>(name => name == "Smash")))
                .Returns(Task.FromResult(true));

            CategoryDTO returnedCategoryDTO = new CategoryDTO();
            mockCategoryService.Setup(service => service.Post(It.Is<string>(endpoint => endpoint == "categories"), It.IsAny<CategoryDTO>()))
               .Returns(Task.FromResult((CategoryDTO)null));
            #endregion

            CreateCategoryViewModel viewModel = new CreateCategoryViewModel()
            {
                Name = "Smash"
            };
            string viewExpected = "Create";

            // Act 
            ActionResult actionResult = await controller.Create(viewModel);
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName == viewExpected || result.ViewName == string.Empty);
        }

        [TestMethod]
        public async Task Post_Create_Should_ReturnDuplicateMessage_When_CategoryAlreadyExists()
        {
            // Assert
            #region mock data
            // categories, cualquier string
            mockCategoryService.Setup(service => service.Exists(It.Is<string>(endpoint => endpoint == "categories"), It.Is<string>(name => name == "Smash")))
                .Returns(Task.FromResult(true));

            CategoryDTO returnedCategoryDTO = new CategoryDTO();
            mockCategoryService.Setup(service => service.Post(It.Is<string>(endpoint => endpoint == "categories"), It.IsAny<CategoryDTO>()))
               .Returns(Task.FromResult((CategoryDTO)null));
            #endregion

            CreateCategoryViewModel viewModel = new CreateCategoryViewModel()
            {
                Name = "Smash"
            };
            string expectedMessage = "This category already exists";

            // Act 
            ActionResult actionResult = await controller.Create(viewModel);
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.AreEqual(expectedMessage, controller.TempData["Error"]);
        }

        [TestMethod]
        public async Task Post_Create_Should_ReturnCreateView_When_CategoryNameExceeds50Characters()
        {
            // Assert
            #region mock data
            // categories, cualquier string
            mockCategoryService.Setup(service => service.Exists(It.Is<string>(endpoint => endpoint == "categories"), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            CategoryDTO returnedCategoryDTO = new CategoryDTO();
            mockCategoryService.Setup(service => service.Post(It.Is<string>(endpoint => endpoint == "categories"), It.IsAny<CategoryDTO>()))
               .Returns(Task.FromResult((CategoryDTO)null));
            #endregion

            CreateCategoryViewModel viewModel = new CreateCategoryViewModel()
            {
                Name = "Smash kjabskjbakjs aksjb kajs bkjas bkajsb kja bskajsb kjasbkajsb jkas bkajbs kajb"
            };
            string expectedView = "Create";

            // Act 
            ActionResult actionResult = await controller.Create(viewModel);
            ViewResult result = actionResult as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName == expectedView || result.ViewName == string.Empty);
        }
        #endregion
    }
}
