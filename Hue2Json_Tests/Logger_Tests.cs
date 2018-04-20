using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Hue2Json;

namespace Hue2Json_Tests
{
    [TestClass]
    public class Logger_Tests
    {
        [TestMethod, TestCategory("Logger")]
        public void WriteNewLog()
        {
            Logger.WriteToLog("test");
        }
    }
}
