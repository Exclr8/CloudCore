using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using ProcessViewer.Library.Common;
using ProcessViewer.Library.Shapes;

namespace ProcessViewer.Library.Data
{
    public class Nodes
    {
        public static List<Node> GetStructureNodes(DBVersion version, String connectionString, ViewLevel viewLevel, List<Process> processes, bool getInstances = false)
        {

            switch (viewLevel)
            {
                case ViewLevel.Activity:
                    return GetActivityNodes(connectionString, processes, version, getInstances);
                case ViewLevel.SubProcess:
                    return GetTaskNodes(connectionString, processes, version, getInstances);
            }

            return null;
        }

        private static List<Node> GetTaskNodes(String connectionString, IEnumerable<Process> processess, DBVersion version, bool getInstances)
        {
         
                var db = new Data1.CloudCoreDB(connectionString);

                var nodes = from t in db.Cloudcoremodel_ActivityModel
                            join tsub in db.Cloudcoremodel_SubProcess on t.SubProcessId equals tsub.SubProcessId
                            join pr in db.Cloudcoremodel_ProcessRevision on t.ProcessRevisionId equals pr.ProcessRevisionId
                            join p in db.Cloudcoremodel_ProcessModel on pr.ProcessModelId equals p.ProcessModelId
                            where processess.Select(r => new { r.Id, Revision = r.RevisionId }).Contains(new { Id = p.ProcessModelId, Revision = pr.ProcessRevisionId }) || pr.ProcessModelId == 0
                            orderby t.SubProcessId
                            select new Node
                            {
                                ID = t.SubProcessId,
                                Title = tsub.SubProcessName,
                                GroupTitle = p.ProcessName,
                                GroupID = pr.ProcessModelId,
                                Startable = (from fm in db.Cloudcoremodel_FlowModel
                                             join fa in db.Cloudcoremodel_ActivityModel on fm.FromActivityModelId equals fa.ActivityModelId
                                             where fa.Startable
                                             select fa.SubProcessId).Contains(t.SubProcessId),
                                Decision = (from f in db.Cloudcoremodel_FlowModel
                                            join fa in db.Cloudcoremodel_ActivityModel on f.FromActivityModelId equals fa.ActivityModelId
                                            join ta in db.Cloudcoremodel_ActivityModel on f.ToActivityModelId equals ta.ActivityModelId
                                            where fa.SubProcessId != ta.SubProcessId && fa.SubProcessId == t.SubProcessId
                                            select ta.ActivityModelId).Distinct().Count() > 1,
                                Instances = -1
                                //Instances = getInstances ?
                                //                             (from wl in db.BTWorklist
                                //                              join a in db.BTActivity on wl.ActivityID equals a.ActivityID
                                //                              where a.TaskID == t.TaskModelId
                                //                              select a.ActivityID).Count()
                                //                : -1
                            };

                return nodes.ToList();
         
        }

        private static List<Node> GetActivityNodes(String connectionString, IEnumerable<Process> processess, DBVersion version, bool getInstances)
        {
                var db = new Data1.CloudCoreDB(connectionString);

                var nodes = from a in db.Cloudcoremodel_ActivityModel
                            join t in db.Cloudcoremodel_SubProcess on a.SubProcessId equals t.SubProcessId
                            join pr in db.Cloudcoremodel_ProcessRevision on t.ProcessRevisionId equals pr.ProcessRevisionId
                            join at in db.Cloudcoremodel_ActivityType on a.ActivityTypeId equals at.ActivityTypeId
                            where processess.Select(r => new { r.Id, Revision = r.RevisionId }).Contains(new { Id = pr.ProcessModelId, Revision = pr.ProcessRevisionId }) || pr.ProcessModelId == 0
                            select new Node
                            {
                                ID = a.ActivityModelId,
                                Title = a.ActivityName,
                                GroupID = t.SubProcessId,
                                GroupTitle = t.SubProcessName,
                                Startable = a.Startable,
                                ActivityType = at.ActivityTypeName,
                                Instances = -1
                                //Instances = getInstances ?
                                //                  (from wl in db.BTWorklist
                                //                   where a.ActivityModelId == wl.ActivityID
                                //                   select a.ActivityModelId).Count()
                                //     : -1
                                
                            };
                return nodes.ToList();
           
        }      
    }
}
