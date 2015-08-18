using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProcessViewer.Library.Shapes;

namespace ProcessViewer.Library.Data
{
    class Processes
    {
        public static List<Process> GetProcesses(DrawItem drawItem)
        {
            var db = new Data1.CloudCoreDB(drawItem.ConnectionString);

            var processes = from pm in db.Cloudcoremodel_ProcessModel
                            where pm.ProcessModelId != 0
                            select new Process(drawItem)
                            {
                                Id = pm.ProcessModelId,
                                Title = pm.ProcessName
                            };

            return processes.ToList();
        }        

        public static List<Revision> GetRevisions(DrawItem drawItem)
        {
            var db = new Data1.CloudCoreDB(drawItem.ConnectionString);
            var revisions = from pv in db.Cloudcoremodel_ProcessRevision
                            select new Revision
                                       {
                                           ID = pv.ProcessRevisionId,
                                           Name = pv.ProcessRevision.ToString(),
                                           ProcessID = pv.ProcessModelId,
                                           Date = String.Format("{0:dd MMMM yyyy}", pv.Changed),
                                           User = pv.UserId.ToString()
                                       };
            return revisions.ToList();
        }        
    }
}
