using System;
using CloudCore.Logging.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Logging.Tests
{
    [TestClass]
    public class LoggerTests
    {
        private static DebugLogger _debugLogger;

        [ClassInitialize]
        public static void LoggerTests_Setup(TestContext context)
        {
            _debugLogger = new DebugLogger();
            Logger.SetLogger(_debugLogger, VerbosityLevel.Debug);
        }

        [TestMethod]
        public void DebugLogger_CanWriteLine()
        {
            const string messageToLog = "WriteLine has been called!";
            string loggedMessage = string.Empty;
            Logger.LogGenericEntryWrittenEventHandler += (writtenText) => { loggedMessage = writtenText; };
            Logger.SetLogger(_debugLogger, VerbosityLevel.Debug);

            Logger.WriteLine(messageToLog);

            Assert.IsTrue(loggedMessage.Contains(messageToLog), "The logged entry did not contain the original message!");
        }

        [TestMethod]
        public void Logger_AlwaysLogFatals()
        {
            bool logWasWritten = false;
            const string errorMessageToLog = "Testing if logger logs fatals, no matter what the configured logging verbosity is. If you can see this message, it worked, when this entry was written.";
            Logger.LogFatalEntryWrittenEventHandler += (writtenText, exception, category) => { logWasWritten = true; };
            Logger.SetLogger(_debugLogger, VerbosityLevel.Errors);

            Logger.Fatal(errorMessageToLog, new Exception(errorMessageToLog), "TestingFatal");

            Assert.IsTrue(logWasWritten, "Logging fatal entry was not working correctly. The configured verbosity level had an impact on whether or not the log entry was written. It shouldn't.");
        }

        [TestMethod]
        public void Logger_LogFatalWhenDebuggingException()
        {
            bool logWasWritten = false;
            const string errorMessageToLog = "Testing if logger logs fatals, when logging an exception using Debug(). If you can see this message, it worked, when this entry was written.";
            Logger.LogFatalEntryWrittenEventHandler += (writtenText, exception, category) => { logWasWritten = true; };
            Logger.SetLogger(_debugLogger, VerbosityLevel.Debug);

            Logger.Fatal(errorMessageToLog, new Exception(errorMessageToLog), "TestingFatalDebug");

            Assert.IsTrue(logWasWritten, "Logging exception using Debug() entry was not working correctly. The configured verbosity level had an impact on whether or not the log entry was written. It shouldn't.");
        }

        [TestMethod]
        public void Logger_OnlyLogWhenVerbosityIsSpecifiedLevel_ExceptForFatal()
        {
            bool logWasWritten = false;
            const string errorMessageToLog = "Testing if logger only logs configured verbosity levels (except Fatals, which should always be logged). If you can see this message, it DID NOT work when this entry was written!";
            Logger.LogDebugErrorEntryWrittenEventHandler += (writtenText, exception, category) => { logWasWritten = true; };
            Logger.SetLogger(_debugLogger, VerbosityLevel.Information);

            Logger.Debug(errorMessageToLog,"TestingNormalDebugLog");

            Assert.IsFalse(logWasWritten, "Logging exception using Debug() entry was not working correctly. The configured verbosity level had an impact on whether or not the log entry was written. It shouldn't.");
        }
    }
}
