using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.Services;
using Moq;
using TrainingTrackingSystemWebApp.Utils;
using System.Threading.Tasks;
using System.Net.Http;
using TrainingTrackingSystemWebApp.DTO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TrainingTrackingSystemWebApp.Tests.Services
{
    /// <summary>
    /// Should_ExpectedBehavior_When_StateUnderTest
    /// </summary>
    [TestClass]
    public class CategoryServiceTests
    {
        private CategoryService _categoryService;
        private Mock<IHttpClientUtils> mockHttpClientUtils;
        //private Mock<HttpClient> mockHttpClient;

        [TestInitialize]
        public void Setup()
        {
            mockHttpClientUtils = new Mock<IHttpClientUtils>();
            
            _categoryService = new CategoryService(mockHttpClientUtils.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public async Task Exists_Should_ReturnTrue_When_CategoryExists()
        {
            // Arrange
            #region categories table data as json content
            List<CategoryDTO> categoriesDTO = new List<CategoryDTO>()
            {
                new CategoryDTO()
                {
                    Name = "Smash"
                },
                new CategoryDTO()
                {
                    Name = "Unit Testing"
                }
            };
            string categoriesAsJson = JsonConvert.SerializeObject(categoriesDTO);

            HttpContent content = new StringContent(categoriesAsJson, UnicodeEncoding.UTF8, "application/json");
            //responseExpected.Content = content;
            #endregion

            HttpResponseMessage responseExpected = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = content
            };
            
            // Mock data for GetAsync
            mockHttpClientUtils.Setup(client => client.GetAsync(It.Is<string>(endpoint => endpoint == "categories")))
                .Returns(Task.FromResult(responseExpected));

            string categoryName = "Smash"; // this category should exists in the db
            string endPoint = "categories";
            bool expected = true;

            // Act 
            bool result = await _categoryService.Exists(endPoint, categoryName);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task Exists_Should_ReturnFalse_When_CategoryDoesNotExists()
        {
            // Arrange
            #region categories data - setup expected response
            List<CategoryDTO> categoriesDTO = new List<CategoryDTO>()
            {
                new CategoryDTO()
                {
                    Name = "Smash"
                },
                new CategoryDTO()
                {
                    Name = "Unit Testing"
                }
            };
            string categoriesAsJson = JsonConvert.SerializeObject(categoriesDTO);

            HttpContent content = new StringContent(categoriesAsJson, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage responseExpected = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = content
            };

            // Mock data for GetAsync
            mockHttpClientUtils.Setup(client => client.GetAsync(It.Is<string>(endpoint => endpoint == "categories")))
                .Returns(Task.FromResult(responseExpected));
            #endregion

            string categoryName = "non_exising_category"; // this category should exists in the db
            string endPoint = "categories";
            bool expected = false;

            // Act 
            bool result = await _categoryService.Exists(endPoint, categoryName);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
