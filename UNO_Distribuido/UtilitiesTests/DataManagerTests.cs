using Microsoft.VisualStudio.TestTools.UnitTesting;
using UNO_Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UNO_Server.Utilities.Tests
{
    [TestClass()]
    public class DataManagerTests
    {
        private DataManager dataManager = new DataManager();

        [TestMethod()]
        public void GenerateVerificationTokenTest()
        {
            string tokenGenerated = "";

            tokenGenerated = dataManager.GenerateVerificationToken();

            Assert.IsNotNull(tokenGenerated);
        }
        
        [TestMethod()]
        public void EncryptPasswordTest()
        {
            string hashedPassword = dataManager.EncryptPassword("password");

            Console.WriteLine("Hashed password is: " + hashedPassword);

            Assert.IsNotNull(hashedPassword);
        }

        [TestMethod()]
        public void DecryptPasswordTest()
        {
            bool result = false;

            string hashedPassword = dataManager.EncryptPassword("password");

            Console.WriteLine("Hashed password is: " + hashedPassword);

            result = dataManager.VerifyPassword("password", hashedPassword);

            Assert.IsTrue(result);
        }
    }
}