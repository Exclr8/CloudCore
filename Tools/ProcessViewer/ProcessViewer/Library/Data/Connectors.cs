using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProcessViewer.Library.Shapes;

namespace ProcessViewer.Library.Data
{
    public static class Connectors
    {
        public static List<Connector> GetStructureConnectors(DBVersion version, String connectionString, ViewLevel viewLevel, List<Process> processes)
        {
            switch (viewLevel)
            {
                case ViewLevel.Activity:
                    return GetActivityConnectors(connectionString, processes, version);
                case ViewLevel.SubProcess:
                    return GetSubProcessConnectors(connectionString, processes, version);
            }

            return null;
        }

        private static List<Connector> GetSubProcessConnectors(string connectionString, IEnumerable<Process> processes, DBVersion version)
        {
                var db = new Data1.CloudCoreDB(connectionString);

                var connectors = (from f in db.Cloudcoremodel_FlowModel
                                  join fa in db.Cloudcore_Activity on f.FromActivityModelId equals fa.ActivityModelId
                                  join ta in db.Cloudcore_Activity on f.ToActivityModelId equals ta.ActivityModelId
                                  join fsub in db.Cloudcoremodel_SubProcess on fa.SubProcessGuid equals fsub.SubProcessGuid
                                  join tsub in db.Cloudcoremodel_SubProcess on ta.SubProcessGuid equals tsub.SubProcessGuid
                                  where fa.SubProcessGuid != ta.SubProcessGuid &&
                                        processes.Select(r => r.Id).Contains(fsub.SubProcessId)
                                  select new Connector
                                  {
                                      FromID = fsub.SubProcessId,
                                      ToID = tsub.SubProcessId,
                                      Title = "",
                                      FlowInd = 0
                                  }).Distinct();

                return connectors.ToList();
        }

        private static List<Connector> GetActivityConnectors(string connectionString, IEnumerable<Process> processes, DBVersion version)
        {
            var db = new Data1.CloudCoreDB(connectionString);

                var connectors = (from f in db.Cloudcoremodel_FlowModel
                                  join fa in db.Cloudcore_Activity on f.FromActivityModelId equals fa.ActivityModelId
                                  join t in db.Cloudcoremodel_SubProcess on fa.SubProcessGuid equals t.SubProcessGuid
                                  where processes.Select(r => r.Id).Contains(t.ProcessRevisionId)
                                  select new Connector
                                             {
                                                 Title = f.Outcome,
                                                 FromID = f.FromActivityModelId,
                                                 ToID = f.ToActivityModelId,
                                                 FlowInd = 0
                                  }).Distinct();
                return connectors.ToList();

        }
    }
}
