using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using forrst_dotnet.Entities;

namespace forrst_dotnet_tests {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UsersTests {
        public UsersTests() {
        }
        
        [TestMethod]
        public void GetUserByID() {
            User user = Users.Get(9199);
            Assert.AreEqual("nickfloyd", user.username);
        }

        [TestMethod]
        public void GetUserByUserName() {
            User user = Users.Get("nickfloyd");
            Assert.AreEqual(9199, user.id);
        }
    }
}
