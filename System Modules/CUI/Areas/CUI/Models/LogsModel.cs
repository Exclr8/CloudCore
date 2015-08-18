using System.Collections.Generic;

namespace CloudCore.Web.Models
{
    //TODO: This feature is not implemented. Have discussion
    public class LogsModel
    {
        public IEnumerable<LogItemModel> LogItems { get; private set; }

        public LogsModel()
        {
            LogItems = new List<LogItemModel>();
        }

       
        public void LoadLogs()
        {
        }
    }
}