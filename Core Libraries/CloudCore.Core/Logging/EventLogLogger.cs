using System;
using System.Diagnostics;

namespace CloudCore.Logging.EventLog
{
    public class EventLogLogger : ILogger
    {
        private readonly System.Diagnostics.EventLog _eventLog;

        public EventLogLogger()
        {
            _eventLog = new System.Diagnostics.EventLog(); ;
            _eventLog.Source = Resources.EventLogSourceName;
            _eventLog.Log = Resources.EventLogName;
        }

        public void WriteLine(string message, string category)
        {
            _eventLog.WriteEntry(message, EventLogEntryType.Information, Numerize(message + category), Numerize(category));
        }

        private short Numerize(string message)
        {
            short eventId = 0;

            foreach (var charByte in GetBytes(message))
            {
                // ReSharper disable RedundantCast
                if (((int) charByte + (int) eventId) > short.MaxValue)
                {
                    eventId = (short)((((int) charByte + (int) eventId) - (int)short.MaxValue) * -1);
                }
                else
                {
                    eventId += charByte;
                }
                // ReSharper restore RedundantCast
            }
            return eventId;
        }

        public void Debug(string message, string category)
        {
            short eventId;
            short categoryId;
            GetEventLogIds(message, category, out eventId, out categoryId);
            _eventLog.WriteEntry(message, EventLogEntryType.Information, eventId, categoryId);
        }

        public void Warn(string message, string category)
        {
            System.Diagnostics.Debug.WriteLine(message, category);
            short eventId;
            short categoryId;
            GetEventLogIds(message, category, out eventId, out categoryId);
            _eventLog.WriteEntry(message, EventLogEntryType.Warning, eventId, categoryId);
        }

        private void GetEventLogIds(string message, string category, out short eventId, out short categoryId)
        {
            eventId = Numerize(message + category);
            categoryId = Numerize(category);
        }


        public void Info(string message, string category)
        {
            short eventId;
            short categoryId;
            GetEventLogIds(message, category, out eventId, out categoryId);
            _eventLog.WriteEntry(message, EventLogEntryType.Information, eventId, categoryId);
        }

        public void Error(string message, Exception exception, string category)
        {
            short eventId;
            short categoryId;
            GetEventLogIds(message, category, out eventId, out categoryId);
            _eventLog.WriteEntry(message, EventLogEntryType.Error, eventId, categoryId);
        }

        public void Fatal(string message, Exception exception, string category)
        {
            short eventId;
            short categoryId;
            GetEventLogIds(message, category, out eventId, out categoryId);

            var fullMessage = "FATAL EXCEPTION! " + message +
                              string.Format(" -- Exception: {0}, {1} -- Stack Trace: {2}", exception.Message,
                                  exception.GetType().ToString(), exception.StackTrace);
            _eventLog.WriteEntry(fullMessage, EventLogEntryType.Error, eventId, categoryId);
        }

        public void WriteLine(string message)
        {
            const string category = "General";
            short eventId;
            short categoryId;
            GetEventLogIds(message, category, out eventId, out categoryId);
            _eventLog.WriteEntry(message, EventLogEntryType.Information, eventId, categoryId);
        }

        private static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
