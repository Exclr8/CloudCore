using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Btomic;
using EnvDTE80;
using FrameworkOne.Btomic.CustomCode.Helpers;

namespace FrameworkOne.EditorExtentions.Diagram
{
    public class DiagramGenerator
    {
        private static readonly List<ActivityType> ActTypes = new List<ActivityType>
                                                                  {
                                                                      new ActivityType { Id = 0, Type = "BTPage" },
                                                                      new ActivityType { Id = 2, Type = "BTEvent" },
                                                                      new ActivityType { Id = 4, Type = "BTRule" },
                                                                      new ActivityType { Id = 5, Type = "BTOutPort" },
                                                                      new ActivityType { Id = 6, Type = "BTInPort" },
                                                                      new ActivityType { Id = 7, Type = "BTStop" },
                                                                      new ActivityType { Id = 8, Type = "BTStart" }
                                                                  };

        private readonly Dictionary<string, int> _instanceCounts = new Dictionary<string, int>();

        private readonly int _processID;
        private readonly int? _revisionID;
        private readonly BtomicDB _db;
        private readonly DTE2 _applicationObject;

        private List<Task> _tasks;
        private List<Activity> _activities;
        private Process _process;
        private List<FlowMap> _flowMaps;

        public DiagramGenerator(int processID, int? revisionID, DTE2 applicationObject)
        {
            _processID = processID;
            _revisionID = revisionID;
            _applicationObject = applicationObject;
            _db = new BtomicDB();

            GetProcess();
            PopulateActivities();
            PopulateFlowMaps();
            CreateContent();
        }


        private void GetProcess()
        {
            _process = (from p in _db.Model_BTProcessModel
                        where p.ProcessModelId == _processID
                        select new Process
                                    {
                                        ProcessName = p.ProcessName,
                                        Guid = p.ProcessGuid
                                    }).SingleOrDefault();
        }

        private void PopulateActivities()
        {
            _activities = (from a in _db.Model_BTActivityModel
                            where a.ProcessRevisionId == _revisionID
                                    && ActTypes.Select(at => at.Id).Contains(a.ActivityInd)
                            select new Activity
                            {
                                ActivityID = a.ActivityModelId,
                                ActivityInd = (a.ActivityInd == 0 ? (a.Startable ? (byte)8 : a.ActivityInd) : a.ActivityInd),
                                ActivityName = a.ActivityName,
                                SubProcessID = a.SubProcessId,
                                Guid = a.ActivityGuid,
                                Startable = a.Startable
                            }).ToList();
        }

        private void PopulateFlowMaps()
        {
            _flowMaps = (from f in _db.Model_BTFlowModel
                            join a in _db.Model_BTActivityModel
                                on f.FromActivityModelId equals a.ActivityModelId
                            where a.ProcessRevisionId == _revisionID
                            select new FlowMap
                                    {
                                        FlowID = f.FlowModelId,
                                        FromActivity = f.FromActivityModelId,
                                        Outcome = f.Outcome,
                                        Storyline = f.Storyline,
                                        ToActivity = f.ToActivityModelId,
                                        OptimalFlow = f.OptimalFlow,
                                        NegativeFlow = f.NegativeFlow,
                                        FlowGuid = f.FlowGuid,
                                        HasTrigger = (bool)_db.BTFlowHasTrigger(f.FlowGuid)
                                    }).ToList();
        }

        private void CreateContent()
        {
            var selectedItem = _applicationObject.SelectedItems.Item(1);
            var project = selectedItem.Project;

            foreach (var item in _activities.Where(a => (a.ActivityInd == 2 || a.ActivityInd == 4)))
            {
                using (var con = new SqlConnection(_db.Connection.ConnectionString))
                {
                    using (var cmd = con.CreateCommand())
                    {

                        cmd.CommandText = "sp_helptext @procName";
                        cmd.CommandType = CommandType.Text;

                        switch (item.ActivityInd)
                        {
                            case 2:
                                cmd.Parameters.AddWithValue("procName", "BTEvent_" + (item.Guid.HasValue ? item.Guid.Value.ToString().Replace("-", "_") : ""));
                                break;
                            case 4:
                                cmd.Parameters.AddWithValue("procName", "BTRule_" + (item.Guid.HasValue ? item.Guid.Value.ToString().Replace("-", "_") : ""));
                                break;
                            default:
                                continue;
                        }

                        try
                        {
                            con.Open();

                            var content = String.Empty;

                            using (var rdr = cmd.ExecuteReader())
                            {
                                String line;
                                var depth = 0;
                                while (rdr.Read())
                                {
                                    line = rdr.GetString(0);

                                    if (String.Compare(line.Trim(), "end", true) == 0) depth--;

                                    if (depth > 0)
                                        content += line;

                                    if (String.Compare(line.Trim(), "begin", true) == 0) depth++;
                                }
                            }

                            switch (item.ActivityInd)
                            {
                                case 2:
                                    BtomicFiles.AddEvent(project, item.Guid.ToString(), _process.Guid.ToString(), content, true);
                                    break;
                                case 4:
                                    BtomicFiles.AddRule(project, item.Guid.ToString(), _process.Guid.ToString(), content, true);
                                    break;
                                default:
                                    continue;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            foreach (var item in _flowMaps.Where(t => t.HasTrigger))
            {
                using (var con = new SqlConnection(_db.Connection.ConnectionString))
                {
                    using (var cmd = con.CreateCommand())
                    {

                        cmd.CommandText = "sp_helptext @procName";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("procName", "BTTrigger_" + (item.FlowGuid.HasValue ? item.FlowGuid.Value.ToString().Replace("-", "_") : ""));

                        try
                        {
                            con.Open();

                            var content = String.Empty;

                            using (var rdr = cmd.ExecuteReader())
                            {

                                String line;
                                var depth = 0;
                                while (rdr.Read())
                                {
                                    line = rdr.GetString(0);

                                    if (String.Compare(line.Trim(), "end", true) == 0) depth--;

                                    if (depth > 0)
                                        content += line;

                                    if (String.Compare(line.Trim(), "begin", true) == 0) depth++;
                                }

                            }

                            BtomicFiles.AddTrigger(project, item.FlowGuid.ToString(), _process.Guid.ToString(), content, true);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name of the Btomic Diagram
        /// </summary>
        /// <returns>process name of the selected process</returns>
        public string GetName()
        {
            return _process.ProcessName;
        }

        /// <summary>
        /// Generates a btomic process diagram to file
        /// </summary>
        /// <param name="filePath">The file path to where this document must be written to</param>
        public void GenerateDiagram(string filePath)
        {
            try
            {
                //make sure all entities has a Guid

                _process.Guid = _process.Guid ?? Guid.NewGuid();

                foreach (var item in _tasks)
                    item.Guid = item.Guid ?? Guid.NewGuid();

                foreach (var item in _activities)
                    item.Guid = item.Guid ?? Guid.NewGuid();

                foreach (var item in _flowMaps)
                    item.FlowGuid = item.FlowGuid ?? Guid.NewGuid();


                var xmlWriter = new XmlTextWriter(filePath, Encoding.UTF8) { Formatting = Formatting.Indented };

                WriteDocument(xmlWriter);

                xmlWriter.Flush();
                xmlWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Unable to write document: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Writes the main document for the xml file
        /// </summary>
        /// <param name="writer">Xml writer for writing the process</param>
        private void WriteDocument(XmlWriter writer)
        {
            writer.WriteStartDocument();

            //Writes the process of the selected process to the XmlWriter
            WriteProcess(writer);

            writer.WriteEndDocument();
        }

        /// <summary>
        /// Writes the selected process to the xml writer
        /// </summary>
        /// <param name="writer">XmlWriter to use for writing the process</param>
        private void WriteProcess(XmlWriter writer)
        {
            try
            {
                writer.WriteStartElement("BTProcess");

                WriteAttribute(writer, "xmlns:dm0", @"http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core");
                WriteAttribute(writer, "xmlns", "http://schemas.microsoft.com/dsltools/Btomic");
                WriteAttribute(writer, "dslVersion", "1.0.0.0");
                WriteAttribute(writer, "Id", XmlConvert.ToString(_process.Guid.Value));
                WriteAttribute(writer, "processName", _process.ProcessName);

                //Writes the elements of the process to the XlmWriter
                WriteElements(writer);

                writer.WriteEndElement(); //BTProcess

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Unable to write process {1}: {0}", ex.Message, _process.ProcessName));
            }
        }

        /// <summary>
        /// Writes all the elements of the process to the xml writer
        /// </summary>
        /// <param name="writer">XmlWriter to use for writing the elements</param>
        private void WriteElements(XmlWriter writer)
        {
            writer.WriteStartElement("elements");
            writer.WriteStartElement("BTActivity");

            foreach (var activity in _activities)
                WriteActivity(writer, activity);

            writer.WriteEndElement(); //BTActivity
            writer.WriteEndElement(); //elements
        }

        /// <summary>
        /// Writes an activity in xml format
        /// </summary>
        /// <param name="writer">Xml writer where the activity must be written to</param>
        /// <param name="activity">The activity that must be written to xml</param>
        private void WriteActivity(XmlWriter writer, Activity activity)
        {
            try
            {
                writer.WriteStartElement("BTProcessHasBTActivity");

                var newGuid = Guid.NewGuid();
                WriteAttribute(writer, "Id", XmlConvert.ToString(newGuid));

                //Activity Type
                writer.WriteStartElement(ActTypes.Where(at => at.Id == activity.ActivityInd).Select(at => at.Type).SingleOrDefault());
                WriteAttribute(writer, "Id", XmlConvert.ToString(activity.Guid.Value));
                WriteAttribute(writer, "name", activity.ActivityName);
                WriteAttribute(writer, "isMenuItem", XmlConvert.ToString(activity.IsMenuItem));

                writer.WriteStartElement("targetBTActs");

                //Check if the Moniker set will be valid
                var flowmaps = from fm in _flowMaps
                               join ta in _activities on fm.ToActivity equals ta.ActivityID
                               where fm.FromActivity == activity.ActivityID
                                  && _activities.Contains(ta)
                               select fm;

                foreach (var flowMap in flowmaps)
                    WriteFlowMap(writer, flowMap, activity.ActivityInd);

                writer.WriteEndElement(); //targetBTActs

                writer.WriteEndElement(); //Activity Type

                writer.WriteEndElement(); //BTProcessHasBTActivity

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Unable to write activity {1}: {0}", ex.Message, activity.ActivityName));
            }
        }

        /// <summary>
        /// Writes an flowMap in xml
        /// </summary>
        /// <param name="writer">XmlWriter where the flowMap must be written to</param>
        /// <param name="flowMap">The flowMap that must be written to xml</param>
        /// <param name="activityInd">The activity indicator</param>
        private void WriteFlowMap(XmlWriter writer, FlowMap flowMap, int activityInd)
        {
            try
            {
                if (flowMap.FlowGuid == null)
                    return;

                writer.WriteStartElement(activityInd == 4 ? "flow" : "flowMinimal");

                WriteAttribute(writer, "hasTrigger", flowMap.HasTrigger ? "Yes" : "No");
                WriteAttribute(writer, "storyline", flowMap.Storyline ?? "");
                WriteAttribute(writer, "outcome", flowMap.Outcome);

                WriteAttribute(writer, "Id", XmlConvert.ToString(flowMap.FlowGuid.Value));
                WriteAttribute(writer, "type", (flowMap.OptimalFlow ? "Optimal" : (flowMap.NegativeFlow ? "Negative" : "none")));

                WriteMoniker(writer, _activities.Where(act => act.ActivityID == flowMap.ToActivity).SingleOrDefault());

                writer.WriteEndElement(); //FlowMap

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Unable to write flow map {1}: {0}", ex.Message, flowMap.Storyline));
            }
        }


        /// <summary>
        /// Creates an moniker in a flowmMap
        /// </summary>
        /// <param name="writer">XmlWriter where the Moniker must be written to</param>
        /// <param name="toActivity">The activity that the floMap flows to</param>
        private static void WriteMoniker(XmlWriter writer, Activity toActivity)
        {
            try
            {
                if (toActivity.Guid == null)
                    return;

                writer.WriteStartElement(String.Format(@"{0}Moniker", ActTypes.Where(at => at.Id == toActivity.ActivityInd).Select(at => at.Type).SingleOrDefault()));

                WriteAttribute(writer, "Id", XmlConvert.ToString(toActivity.Guid.Value));
                writer.WriteEndElement(); //Moniker
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Unable to write moniker {1}: {0}", ex.Message, toActivity.Guid));
            }
        }

        /// <summary>
        /// Creates an attribute in a xml element
        /// </summary>
        /// <param name="writer">Xml writer of the element</param>
        /// <param name="name">Name of the attribute</param>
        /// <param name="value">Value of the attribute</param>
        private static void WriteAttribute(XmlWriter writer, String name, String value)
        {
            try
            {
                writer.WriteStartAttribute(name);
                writer.WriteString(value);
                writer.WriteEndAttribute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Unable to write attribute {1}: {0}", ex.Message, name));
            }
        }

        private string GetUniqueName(string baseName)
        {
            int count;

            if (!_instanceCounts.TryGetValue(baseName, out count))
            {
                _instanceCounts.Add(baseName, 1);
                return baseName;
            }

            _instanceCounts[baseName] = ++count;
            return String.Format(@"{0} {1}",baseName, count);

        }
    }
}
