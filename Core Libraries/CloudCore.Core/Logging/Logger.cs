using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudCore.Logging.Configuration;

namespace CloudCore.Logging
{
    public enum LogEntryType
    {
        Info,
        Warning,
        Error,
        Debug,
        Fatal
    }

    #region Event Signatures

    public delegate void LogGenericEntryWrittenEvent(string writtenText);
    public delegate void LogNonErrorCategorizedEntryWrittenEvent(string writtenText, string category);
    public delegate void LogErrorEntryWrittenEvent(string writtenText, Exception exception, string category);
    public delegate void LogFatalEntryWrittenEvent(string writtenText, Exception exception, string category);
    public delegate void LogListEntryCategorizedWrittenEvent(List<string> listItems, string writtenText, string category, LogEntryType logEntryType);
    public delegate void LogDebugErrorEntryWrittenEvent(string writtenText, Exception exception, string category);

    #endregion

    public static class Logger
    {
        #region Initialization

        private static ILogger log;
        private static VerbosityLevel configuredVerbosityLevel = DefaultLogVerbosity;
#if DEBUG
        public const VerbosityLevel DefaultLogVerbosity = VerbosityLevel.Debug;
#else
        public const VerbosityLevel DefaultLogVerbosity = VerbosityLevel.Warnings;
#endif
        private const string GeneralLoggingCategory = "General";
        
        // TODO: Add the ability to have multiple loggers... for instance Logger.Add(), and then when writing entries, for each logger call their methods that log.
        public static ILogger SetLogger(ILogger logger, VerbosityLevel verbosityLevel)
        {
            log = logger;
            configuredVerbosityLevel = verbosityLevel;
            return log;
        }

        private static bool MustLog(VerbosityLevel fromMethodVerbosity)
        {
            return configuredVerbosityLevel >= fromMethodVerbosity;
        }

        #endregion

        #region Execution

        public static void WriteLine(string message, bool ignoreVerbosityConfig = false)
        {
            if (MustLog(VerbosityLevel.Information) || ignoreVerbosityConfig)
            {
                var task = new Task(() =>
				{
                     try
                    {
                        log.WriteLine(message, GeneralLoggingCategory);
                        OnLogEntryWritten(message);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                     @"-- Original log entry: {1} " +
                                                                     @"-- Original log category: {2}.",
                            ex.Message, message, GeneralLoggingCategory));
                    }
				});
				
				task.Start();
            }
        }

        public static void WriteLine(string message, string category, bool ignoreVerbosityConfig = false)
        {
            if (MustLog(VerbosityLevel.Information) || ignoreVerbosityConfig)
            {
                var task = new Task(() =>
				{
                try
                {
                    log.WriteLine(message, category);
                    OnLogNonErrorCategorizedEntryWritten(message, category);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                 @"-- Original log entry: {1} " +
                                                                 @"-- Original log category: {2}.",
                                                                 ex.Message, message, category));
                }
				});
				
				task.Start();
            }
        }

        public static void WriteFormat(string category, string message, params object[] args)
        {
            if (MustLog(VerbosityLevel.Information))
            {
                var fullMessage = message;

                var task = new Task(() =>
				{
                try
                {
                    fullMessage = string.Format(message, args);
                    log.WriteLine(fullMessage, category);
                    OnLogNonErrorCategorizedEntryWritten(fullMessage, category);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                 @"-- Original log entry: {1} " +
                                                                 @"-- Original log category: {2}.",
                                                                 ex.Message, fullMessage ?? message, category));
                }
				});
				
				task.Start();

            }
        }

        public static void Debug(string message, string category = "")
        {
            if (configuredVerbosityLevel == VerbosityLevel.Debug)
            {
                var task = new Task(() =>
				{
                try
                {
                    log.WriteLine(message, category);
                    OnLogDebugErrorEntryWritten(message, category);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                 @"-- Original log entry: {1} " +
                                                                 @"-- Original log category: {2}.",
                                                                 ex.Message, message, category));
                }
				});
				
				task.Start();
            }
        }

        public static void Warn(string message, string category = "", bool ignoreVerbosityConfig = false)
        {
            if (MustLog(VerbosityLevel.Warnings) || ignoreVerbosityConfig)
            {
                var task = new Task(() =>
				{
                try
                {
                    log.Warn(message, category);
                    OnLogNonErrorCategorizedEntryWritten(message, category);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                 @"-- Original log entry: {1} " +
                                                                 @"-- Original log category: {2}.",
                                                                 ex.Message, message, category));
                }
				});
				
				task.Start();

            }
        }

        public static void Info(string message, string category = "", bool ignoreVerbosityConfig = false)
        {
            if (MustLog(VerbosityLevel.Information) || ignoreVerbosityConfig)
            {
                var task = new Task(() =>
				{
                try
                {
                    log.Info(message, category);
                    OnLogNonErrorCategorizedEntryWritten(message, category);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                 @"-- Original log entry: {1} " +
                                                                 @"-- Original log category: {2}.",
                                                                 ex.Message, message, category));
                }
				});
				
				task.Start();
            }
        }

        public static void Error(string message, Exception exception, string category = "", bool ignoreVerbosityConfig = false)
        {
            if (MustLog(VerbosityLevel.Errors) || ignoreVerbosityConfig)
            {
                var task = new Task(() =>
				{
                try
                {

                    log.Error(message, exception, category);
                    OnLogErrorEntryWritten(message, exception, category);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                                 @"-- Original log entry: {1} " +
                                                                 @"-- Original log category: {2}.",
                                                                 ex.Message, message, category));
                }
				});
				
				task.Start();
            }
        }

        public static void Fatal(string message, Exception exception, string category = "")
        {
                var task = new Task(() =>
				{
            try
            {
                log.Fatal(message, exception, category);
                OnLogFatalEntryWritten(message, exception, category);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(string.Format(@"ERROR! Cannot write log entry. Reason: {0} " +
                                                             @"-- Original log entry: {1} " +
                                                             @"-- Original log category: {2}.",
                                                             ex.Message, message, category));
            }
				});
				
				task.Start();
        }

        public static void ListWrite(List<string> listItems, string message, string loggingCategory,
            LogEntryType logEntryType = LogEntryType.Info, Exception exception = null)
        {
            const string nullExceptionParamName = "exception";
            const string nullExceptionErrorMessageTemplate = @"Cannot write log entry. Parameter ""exception"" cannot be null when logEntryType is also ""{0}""";

            var printableList = string.Empty;
            listItems.ForEach(name => printableList += name + ", ");
            printableList = printableList.Remove(printableList.Length - 2);
            var fullMessage = string.Format("{0} ({1})", message, printableList);

            switch (logEntryType)
            {
                case LogEntryType.Fatal:

                    if (exception == null)
                        throw new ArgumentNullException(
                            nullExceptionParamName,
                            string.Format(nullExceptionErrorMessageTemplate, logEntryType));

                    Fatal(fullMessage, exception, loggingCategory);
                    break;

                case LogEntryType.Error:
                    
                    if (exception == null)
                        throw new ArgumentNullException(
                            nullExceptionParamName,
                            string.Format(nullExceptionErrorMessageTemplate, logEntryType));

                    Error(fullMessage, exception, loggingCategory);
                    break;

                case LogEntryType.Warning:
                    Warn(fullMessage, loggingCategory);
                    break;
                case LogEntryType.Info:
                    Info(fullMessage, loggingCategory);
                    break;
                default:
                    Debug(fullMessage, loggingCategory);
                    break;
            }
        }

        #endregion

        #region Callback Hooks

        public static LogGenericEntryWrittenEvent LogGenericEntryWrittenEventHandler;
        public static LogNonErrorCategorizedEntryWrittenEvent LogNonErrorCategorizedEntryWrittenEventHandler;
        public static LogErrorEntryWrittenEvent LogErrorEntryWrittenEventHandler;
        public static LogFatalEntryWrittenEvent LogFatalEntryWrittenEventHandler;
        public static LogListEntryCategorizedWrittenEvent LogListEntryCategorizedWrittenEventHandler;
        public static LogDebugErrorEntryWrittenEvent LogDebugErrorEntryWrittenEventHandler;


        private static void OnLogEntryWritten(string writtenText)
        {
            if (LogGenericEntryWrittenEventHandler != null)
            {
                LogGenericEntryWrittenEventHandler.Invoke(writtenText);
            }
        }

        private static void OnLogNonErrorCategorizedEntryWritten(string writtenText, string writtenCategory)
        {
            if (LogNonErrorCategorizedEntryWrittenEventHandler != null)
            {
                LogNonErrorCategorizedEntryWrittenEventHandler.Invoke(writtenText, writtenCategory);
            }
        }

        private static void OnLogDebugErrorEntryWritten(string writtenText, string writtenCategory)
        {
            if (LogNonErrorCategorizedEntryWrittenEventHandler != null)
            {
                LogNonErrorCategorizedEntryWrittenEventHandler.Invoke(writtenText, writtenCategory);
            }
        }

        private static void OnLogErrorEntryWritten(string writtenText, Exception exception, string writtenCategory)
        {
            if (LogErrorEntryWrittenEventHandler != null)
            {
                LogErrorEntryWrittenEventHandler.Invoke(writtenText, exception, writtenCategory);
            }
        }

        private static void OnLogFatalEntryWritten(string writtenText, Exception exception, string writtenCategory)
        {
            if (LogFatalEntryWrittenEventHandler != null)
            {
                LogFatalEntryWrittenEventHandler.Invoke(writtenText, exception, writtenCategory);
            }
        }

        #endregion
    }
}
