using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Tests.UtilsTest
{
    [TestClass]
    public class UnitTest1
    {
        HttpClientUtils clientUtils;

        [TestInitialize]
        public void TestSetUp()
        {
            clientUtils = new HttpClientUtils(baseAddress: "https://my-json-server.typicode.com/angel5644/UsersJsonData/", authorization: false);
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Dispose
        }

        [TestMethod]
        public async Task Get_Should_ReturnRecords()
        {
            // Arrange
            string endPoint = "users";

            // Act
           List<UserDTO> result = await clientUtils.Get(endPoint);
            //Task<List<UserDTO>> result = clientUtils.Get(endPoint);

            //Console.WriteLine("Response: " + result.ToString());

            // Assert
            //Assert.IsInstanceOfType(result, typeof(<List<UserDTO>>));
            Assert.IsInstanceOfType(result, typeof(List<UserDTO>));
            Assert.IsNotNull(result);
        }


        //[TestMethod]
        //public async Task Get_Should_ReturnSingleUser_When_GetRequestById()
        //{
        //    // Arrange 
        //    int id = 2;
        //    string[] parameters = new string[] { id.ToString() };
        //    string endPoint = "users/{0}"; // users/2

        //    // Act
        //    TestUser result = await clientUtils.Get<TestUser>(endPoint, parameters); // request to: https://jsonplaceholder.typicode.com/users/1

        //    Console.WriteLine("Response. id: " + result.id + ". name: " + result.first_name + ". email: " + result.last_name);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(TestUser));
        //    Assert.IsNotNull(result);
        //}


        //public class TestUser
        //{
        //    public int id { get; set; }
        //    public string first_name { get; set; }
        //    public string last_name { get; set; }


        //}
    }
}
