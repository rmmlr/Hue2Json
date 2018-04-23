using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Hue2Json.Settings;
using System.IO;

namespace Hue2Json_Tests
{
    /// <summary>
    /// Test für das ProgramSettings-Objekt
    /// </summary>
    [TestClass]
    public class ProgramSettings_Test
    {
        [TestMethod, TestCategory("ProgramSettings")]
        public void Serializing()
        {
            string fileName = "test.config";

            if (File.Exists(fileName))
                File.Delete(fileName);

            var expectedResult = new ProgramSettings
            {
                BridgeNameDisplay = BridgeNameDisplay.IpOnly
            };

            //Serialisierung
            expectedResult.ToFile(fileName);

            //Deserialisierung
            var testObj = ProgramSettings.FromFile(fileName);

            Assert.AreEqual(expectedResult.Version, testObj.Version, "Version stimmt nicht überein.");
            Assert.AreEqual(expectedResult.BridgeNameDisplay, testObj.BridgeNameDisplay, "BridgeNameDisplay stimmt nicht überein.");
        }
    }
}
