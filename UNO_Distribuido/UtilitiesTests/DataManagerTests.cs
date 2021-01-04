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
        [TestMethod()]
        public void GenerateVerificationTokenTest()
        {
            string tokenGenerated = "";

            DataManager dataManager = new DataManager();

            tokenGenerated = dataManager.GenerateVerificationToken();

            Assert.IsNotNull(tokenGenerated);
        }


    }
}