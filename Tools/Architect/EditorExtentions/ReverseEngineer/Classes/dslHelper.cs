using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic
{
    public class BtomicDiagram
    {
        public string name { get; set; }
        public string content { get; set; }
    }

    public class dslHelper
    {
        public static List<ActivityType> ActTypes = new List<ActivityType>();
        public static List<BtomicDiagram> BtomicDiagrams = new List<BtomicDiagram>();

        public static void AddPorts(ref Process process, ref List<Task> allTask, ref List<Activity> allActivity,
                              ref List<FlowMap> allFlow)
        {

            //BtomicDB db = new BtomicDB();
            int iAct = 100000;

            List<Task> lt = allTask;

            for (int t = allTask.Count() - 1; t >= 0; t--)
            {

                List<Activity> activities = allActivity.Where(a => a.TaskID == lt[t].TaskID).ToList();

                for (int a = activities.Count() - 1; a >= 0; a--)
                {
                    List<FlowMap> flowmaps = allFlow.Where(f => f.FromActivity == activities[a].ActivityID).ToList();

                    for (int f = flowmaps.Count() - 1; f >= 0; f--)
                    {

                        Activity fromAct = allActivity.Where(act => act.ActivityID == flowmaps[f].FromActivity).SingleOrDefault();
                        Activity toAct = allActivity.Where(act => act.ActivityID == flowmaps[f].ToActivity).SingleOrDefault();

                        if (toAct == null && flowmaps[f].ToActivity == 0)
                        {
                            allActivity.Add(new Activity { ActivityID = iAct++, ActivityInd = 5, Guid = Guid.NewGuid(), ActivityName = "Stop", TaskID = fromAct.TaskID });

                            allFlow.Add(new FlowMap { FlowID = 0, FromActivity = flowmaps[f].FromActivity, FromTaskID = flowmaps[f].ToActivity, Outcome = flowmaps[f].Outcome, ToActivity = iAct - 1, ToTaskID = flowmaps[f].FromTaskID });
                            allFlow.Remove(allFlow.Where(fm => fm.FlowID == flowmaps[f].FlowID).SingleOrDefault());
                        }
                        else if (flowmaps[f].FromTaskID != flowmaps[f].ToTaskID && flowmaps[f].ToTaskID != 0)
                        {
                            //add activities for ports
                            allActivity.Add(new Activity { ActivityID = iAct++, ActivityInd = 3, ActivityName = "Outport", ActivityType = "port", Guid = Guid.NewGuid(), IsMenuItem = false, Outdated = false, Startable = false, TaskID = flowmaps[f].FromTaskID });
                            allActivity.Add(new Activity { ActivityID = iAct++, ActivityInd = 4, ActivityName = "Inport", ActivityType = "port", Guid = Guid.NewGuid(), IsMenuItem = false, Outdated = false, Startable = false, TaskID = flowmaps[f].ToTaskID });

                            //delete old flow add new flows
                            allFlow.Add(new FlowMap { FlowID = 0, FromActivity = flowmaps[f].FromActivity, FromTaskID = flowmaps[f].ToTaskID, Outcome = flowmaps[f].Outcome, ToActivity = iAct - 2, ToTaskID = flowmaps[f].FromTaskID });
                            allFlow.Add(new FlowMap { FlowID = 0, FromActivity = iAct - 1, FromTaskID = flowmaps[f].ToTaskID, Outcome = "", ToActivity = flowmaps[f].ToActivity, ToTaskID = flowmaps[f].ToTaskID });
                            allFlow.Add(new FlowMap { FlowID = 0, FromActivity = iAct - 2, FromTaskID = flowmaps[f].FromTaskID, Outcome = "", ToActivity = iAct - 1, ToTaskID = 0 });
                            allFlow.Remove(allFlow.Where(fm => fm.FlowID == flowmaps[f].FlowID).SingleOrDefault());

                        }
                    }
                }
            }
        }

        public static string GenerateDiagram(ref Process process, ref List<Task> allTask, ref List<Activity> allActivity, ref List<FlowMap> allFlow)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.Append(string.Format(@"<process xmlns:dm0=""http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core"" dslVersion=""1.0.0.0"" Id=""{0}"" processName=""{1}"" xmlns=""http://schemas.microsoft.com/dsltools/Btomic"">", process.Guid, process.ProcessName));
            sb.Append(@"<elements>");
            //do code))

            foreach (Task task in allTask)
            {
                //task.Guid = new Guid();

                //do code
                sb.Append(string.Format(@"<task Id=""{0}"" name=""{1}"" priority=""{2}"" docWait=""{3}"" taskAllocation="""">",
                                        task.Guid, task.TaskName, task.Priority, task.DocWait));

                sb.Append("<activities>");

                List<Activity> activities = allActivity.Where(a => a.TaskID == task.TaskID).ToList();

                foreach (Activity activity in activities)
                {
                    List<FlowMap> flowmaps = allFlow.Where(f => f.FromActivity == activity.ActivityID).ToList();

                    sb.Append(string.Format(@"<taskHasActivities Id=""{0}"">", Guid.NewGuid()));
                    sb.Append(string.Format(@"<{0} Id=""{1}"" name=""{2}"" startable=""{3}"" isMenuItem=""{4}"">",
                                            ActTypes.Where(at => at.Id == activity.ActivityInd).Select(at => at.Type).SingleOrDefault(),
                                            activity.Guid,
                                            activity.ActivityName,
                                            activity.Startable,
                                            activity.IsMenuItem));

                    sb.Append("<targetActivities>");

                    foreach (FlowMap flowMap in flowmaps)
                    {
                        sb.Append(string.Format(@"<flow Id=""{0}"" outcome=""{1}"">", Guid.NewGuid(), flowMap.Outcome));

                        Activity toAct = allActivity.Where(act => act.ActivityID == flowMap.ToActivity).SingleOrDefault();

                        sb.Append(string.Format(@"<{0}Moniker Id=""{1}"" />",
                                                ActTypes.Where(at => at.Id == toAct.ActivityInd).Select(at => at.Type).SingleOrDefault(),
                                                toAct.Guid));
                        sb.Append("</flow>");

                    }

                    sb.Append("</targetActivities>");
                    sb.Append(string.Format("</{0}>", ActTypes.Where(at => at.Id == activity.ActivityInd).Select(at => at.Type).SingleOrDefault()));
                    sb.Append("</taskHasActivities>");
                }
                sb.Append("</activities>");
                sb.Append("</task>");
            }
            sb.Append("</elements>");
            sb.Append("</process>");

            return sb.ToString();
        }

    }
}
