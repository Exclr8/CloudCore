using System;
using System.Globalization;
using Microsoft.WindowsAzure.Storage.Table;

namespace CloudCore.Logging
{
    public class LogEntry : TableEntity
    {
        public LogEntry()
        {
            EventTime = DateTime.Now;
            PartitionKey = EventTime.Ticks.ToString(CultureInfo.InvariantCulture);
            RowKey = EventTime.Ticks.ToString(CultureInfo.InvariantCulture);
        }

        public string LogMessage { get; set; }
        public string Category { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string InnerExceptionStackTrace { get; set; }
        public string Type { get; set; }
        public DateTime EventTime { get; set; }
    }
}