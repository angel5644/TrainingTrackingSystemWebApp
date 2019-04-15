using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Services;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Tests.ServicesTest
{
    [TestClass]
    public class BaseServiceTest
    {
        IUserService _userService;


        [TestInitialize]
        public void Setup()
        {
            
            var clientUtils = new HttpClientUtils("https://my-json-server.typicode.com/angel5644/UsersJsonData/");

            _userService = new UserService(clientUtils);
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public async Task Get_Should_ReturnRecords()
        {
            //Arrange
            string endPoint = "users";

            //Act
            List<UserDTO> result = await _userService.GetMany(endPoint);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<UserDTO>));
            Assert.IsNotNull(result);
        }
    }
}
