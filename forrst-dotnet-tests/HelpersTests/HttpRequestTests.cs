using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using forrst_dotnet.Helpers;
using forrst_dotnet.Helpers.Enums;

namespace forrst_dotnet_tests.HelpersTests {
    [TestClass]
    public class HttpRequestTests {
        [TestMethod]
        public void GetContentForUserName() {
            string content = HttpRequest.GetContent("text/javascript", HttpMethod.GET, "http://api.forrst.com/api/v1/users/info?username=nickfloyd");
            Assert.IsNotNull(content);
        }
    }
}
