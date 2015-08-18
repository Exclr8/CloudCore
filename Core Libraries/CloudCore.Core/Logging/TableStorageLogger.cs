using System;
using CloudCore.Logging.AzureTableStorage;

namespace CloudCore.Logging
{
    public class TableStorageLogger : CloudCoreStoredTable<LogEntry>, ILogger
    {
        public void WriteLine(string message)
        {
            Insert(new LogEntry { LogMessage = message, Type = "WriteLine", Category = "General" });
        }

        public void WriteLine(string message, string category)
        {
            Insert(new LogEntry { LogMessage = message, Type = "WriteLine", Category = category });
        }

        public void Warn(string message, string category)
        {
            Insert(new LogEntry { LogMessage = message, Type = "Warn", Category = category });
        }

        public void Info(string message, string category)
        {
            Insert(new LogEntry { LogMessage = message, Type = "Info", Category = category });
        }

        public void Error(string loggerMessage, Exception exception, string category)
        {
            loggerMessage = "FATAL EXCEPTION! " + loggerMessage;

            var innerExceptionMessage = string.Empty;
            var innerExceptionStackTrace = string.Empty;
            if (exception.InnerException != null)
            {
                innerExceptionMessage = exception.InnerException.Message;
                innerExceptionStackTrace = exception.InnerException.StackTrace;
            }
            Insert(new LogEntry
            {
                LogMessage = loggerMessage,
                Type = "Fatal",
                ExceptionMessage = exception.Message,
                ExceptionStackTrace = exception.StackTrace,
                InnerExceptionMessage = innerExceptionMessage,
                InnerExceptionStackTrace = innerExceptionStackTrace,
                Category = category
            });
        }

        public void Fatal(string loggerMessage, Exception exception, string category)
        {
            var fullMessage = "FATAL EXCEPTION! " + loggerMessage;
            Error(fullMessage, exception, category);
        }

        public void Debug(string message, string category)
        {
            System.Diagnostics.Debug.WriteLine(message, category);
            Insert(new LogEntry { LogMessage = message, Type = "Debug", Category = category });
        }
    }
}
