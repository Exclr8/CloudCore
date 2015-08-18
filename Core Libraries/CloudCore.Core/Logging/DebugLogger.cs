using System;

namespace CloudCore.Logging
{
    public class DebugLogger : ILogger
    {
        public void WriteLine(string message)
        {
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + message, "General");
        }

        public void WriteLine(string message, string category)
        {
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + message, category);
        }

        public void Info(string message, string category)
        {
            WriteLine(message, category);
        }

        public void Warn(string message, string category)
        {
            WriteLine(message, category);
        }

        public void Debug(string message, string category)
        {
            WriteLine(message, category);
        }

        public void Error(string loggerMessage, Exception exception, string category)
        {
            var exceptionMessage = string.Format("Exception: {0} -- Message: {1} -- Stack Trace: {2}", exception.GetType(), exception.Message, exception.StackTrace);
            if (exception.InnerException != null)
            {
                var innerException = exception.InnerException;
                exceptionMessage += string.Format(" -- Inner Exception: {0} -- Inner Message: {1} -- Inner Stack Trace: {2}", innerException.GetType(), innerException.Message, innerException.StackTrace);
            }
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + string.Format("{0} -- {1}", loggerMessage, exceptionMessage), category);
        }

        public void Fatal(string loggerMessage, Exception exception, string category)
        {
            var fullMessage = "FATAL EXCEPTION! " + loggerMessage;
            Error(fullMessage, exception, category);
        }
    }
}
