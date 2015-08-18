using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudCore.Logging;
using System.Diagnostics;

namespace Core.Common.Tests
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void DebugTest()
        {
            Logger.Debug("Test", "Test");
        }

        public void WriteLineTest()
        {
            Logger.WriteLine("Test.WriteLine");
            Logger.WriteLine("Test.WriteLine.Category", "Category");
        }
    }
}
