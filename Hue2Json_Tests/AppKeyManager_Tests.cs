using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Hue2Json;

namespace Hue2Json_Tests
{
    [TestClass]
    public class AppKeyManager_Tests
    {
        [TestMethod, TestCategory("AppKeyManager")]
        public void Serialize()
        {
            string bridgeName = "Test Brideg1";
            var expectedResult = new AppKeyManager();

            expectedResult.AddKey(bridgeName, "TestKey-123");

            

            var testObj = new AppKeyManager(true);

            Assert.AreEqual(expectedResult.GetKey(bridgeName), testObj.GetKey(bridgeName));

        }
    }
}
