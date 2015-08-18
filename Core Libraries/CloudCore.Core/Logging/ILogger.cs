using System;

namespace CloudCore.Logging
{
    public interface ILogger
    {
        void WriteLine(string message, string category);
        void Debug(string message, string category);
        void Warn(string message, string category);
        void Info(string message, string category);
        void Error(string loggerMessage, Exception exception, string category);
        void Fatal(string loggerMessage, Exception exception, string category);
        void WriteLine(string message);
    }
}
