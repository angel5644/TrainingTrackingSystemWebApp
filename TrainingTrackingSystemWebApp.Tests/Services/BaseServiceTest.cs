using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Services;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Tests.Services
{
    [TestClass]
    public class BaseServiceTest
    {
        private UserService _userService;
        private Mock<IHttpClientUtils> mockHttpClientUtils;

        [TestInitialize]
        public void Setup()
        {
            mockHttpClientUtils = new Mock<IHttpClientUtils>();

            _userService = new UserService(mockHttpClientUtils.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public async Task GetMany_Should_ReturnListRecords_When_ApiIsCalled()
        {
            //Arrange
            #region users data - setup expected response
            List<UserDTO> userDTO = new List<UserDTO>()
            {
                new UserDTO()
                {
                    id = 1,
                    first_name = "Pedro",
                    last_name = "Zarate",
                    email = "pedroZarate@4thsource.com",
                    type = 1
                },
                new UserDTO()
                {
                    id = 2,
                    first_name = "Elena",
                    last_name = "Maria",
                    email = "elenaMaria@4thsource.com",
                    type = 2
                }
            };
            string userAsJson = JsonConvert.SerializeObject(userDTO);

            HttpContent content = new StringContent(userAsJson, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage responseExpected = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = content
            };

            mockHttpClientUtils.Setup(client => client.GetAsync(It.Is<string>(endpoint => endpoint == "users")))
                .Returns(Task.FromResult(responseExpected));
            #endregion
            //Act
            string endPoint = "users";

            List<UserDTO> result = await _userService.GetMany(endPoint);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<UserDTO>));
        }

        [TestMethod]
        public async Task GetMany_Should_ReturnNotNull_When_ApiIsCalled()
        {
            //Arrange
            #region users data - setup expected response
            List<UserDTO> userDTO = new List<UserDTO>()
            {
                new UserDTO()
                {
                    id = 1,
                    first_name = "Pedro",
                    last_name = "Zarate",
                    email = "pedroZarate@4thsource.com",
                    type = 1
                },
                new UserDTO()
                {
                    id = 2,
                    first_name = "Elena",
                    last_name = "Maria",
                    email = "elenaMaria@4thsource.com",
                    type = 2
                }
            };
            string userAsJson = JsonConvert.SerializeObject(userDTO);

            HttpContent content = new StringContent(userAsJson, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage responseExpected = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = content
            };

            mockHttpClientUtils.Setup(client => client.GetAsync(It.Is<string>(endpoint => endpoint == "users")))
                .Returns(Task.FromResult(responseExpected));
            #endregion
            //Act
            string endPoint = "users";

            List<UserDTO> result = await _userService.GetMany(endPoint);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
