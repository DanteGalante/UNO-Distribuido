using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Server.Utilities.Tests
{
    [TestClass]
    public class DataManagerTests
    {
        [TestMethod]
        public void GenerateVerificationTokenTest()
        {
            string tokenGenerated = "";

            DataManager dataManager = new DataManager();

            tokenGenerated = dataManager.GenerateVerificationToken();

            Assert.IsNotNull(tokenGenerated);
        }
    }
}