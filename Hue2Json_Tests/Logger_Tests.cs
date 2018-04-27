using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Hue2Json;
using Rca.Hue2Json.Logging;

namespace Hue2Json_Tests
{
    [TestClass]
    public class Logger_Tests
    {
        [TestMethod, TestCategory("Logger")]
        public void WriteNewLog()
        {
            Logger.WriteToLog("test");

            Assert.IsTrue(File.Exists(Logger.CurrentLogFilePath));
        }
    }
}
