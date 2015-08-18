using System;
using System.Diagnostics;

namespace CloudCore.Logging
{
    public class TraceLogger : ILogger
    {
        public void WriteLine(string message, string category)
        {
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + message, category);
        }

        public void Info(string message, string category)
        {
            Trace.TraceInformation("{0}: {1}: {2}", new object[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), category, message });
        }

        public void Warn(string message, string category)
        {
            Trace.TraceWarning("{0}: {1}: {2}", new object[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), category, message });
        }

        public void Error(string message, Exception exception, string category)
        {
            var exceptionMessage = string.Format("Exception: {0} -- Message: {1} -- Stack Trace: {2}", exception.GetType(), exception.Message, exception.StackTrace);
            if (exception.InnerException != null)
            {
                var innerException = exception.InnerException;
                exceptionMessage += string.Format(" -- Inner Exception: {0} -- Inner Message: {1} -- Inner Stack Trace: {2}", innerException.GetType(), innerException.Message, innerException.StackTrace);
            }

            Trace.TraceError("{0}: {1}: {2}: {3}", new object[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), category, message, exceptionMessage });
        }

        public void Fatal(string message, Exception exception, string category)
        {
            var fullMessage = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + "FATAL EXCEPTION! {0}", message);
            Error(fullMessage, exception, category);
        }

        public void Debug(string message, string category)
        {
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + message, category);
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + message, category);
        }

        public void WriteLine(string message)
        {
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + message, "General");
        }
    }
}
