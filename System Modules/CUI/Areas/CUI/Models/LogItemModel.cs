using System;

namespace CloudCore.Web.Models
{
    public class LogItemModel
    {
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}