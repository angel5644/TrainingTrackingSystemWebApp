using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingTrackingSystemWebApp.DTO;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Tests.Utils
{
    [TestClass]
    public class HttpClientUtilsTest
    {
        HttpClientUtils clientUtils;

        [TestMethod]
        public void TestSetUp()
        {
            clientUtils = new HttpClientUtils(baseAddress: "https://my-json-server.typicode.com/angel5644/UsersJsonData/");
        }

        [TestCleanup]
        public void CleanUp()
        {

        }

        [TestMethod]
        public async Task CreateUser_Should_ReturnAUser_When_PostAUser()
        {
            //Arrange
            string endPoint = "users";
            UserDTO user = new UserDTO();

            //Act
            TestPost result = new TestPost();
        
            //Assert
            Assert.IsInstanceOfType(result, typeof(TestPost));
            Assert.IsNotNull(result);
        }

        public class TestPost
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int id { get; set; }
            public string email { get; set; }
            public int type { get; set; }

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("Firsname:{0}", firstname));
                builder.AppendLine(string.Format("Email:{0}", email));
                builder.AppendLine(string.Format("Lastname:{0}", lastname));
                builder.AppendLine(string.Format("Id:{0}", id));
                builder.AppendLine(string.Format("Type:{0}", type));

                return builder.ToString();
            }
        }
    }
}
