using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace Btomic.Classes.Designer
{
    public class DbObjects
    {
        public Guid Id { get; set; }
        public String Content { get; set; }
        public Boolean Startable { get; set; }
    }

    public class SubProcess : IComparable
    {
        public virtual String EntityField { get; set; }

        public virtual String EntityName { get; set; }

        public virtual String Name { get; set; }

        public virtual Int32 SubProcessID { get; set; }

        public IList<Activity> Activities { get; set; }

        public virtual Guid Guid { get; set; }

        public virtual IList<DbObjects> StoredProcedures { get; set; }

        public virtual IList<DbObjects> Functions { get; set; }

        public virtual IList<DbObjects> Triggers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>-1 = Prompt input, 0 = No Change, 1 = Silent
        /// </returns>
        public int CompareTo(object obj)
        {
            int dt = 0;

            if (obj is Model_BTProcessRevision)
            {
                Model_BTProcessRevision p2 = (Model_BTProcessRevision)obj;
                BtomicDB db = new BtomicDB();

                var p = (from pm in db.Model_BTProcessModel
                         join pr in db.Model_BTProcessRevision
                         on pm.ProcessModelId equals pr.ProcessModelId
                         where pm.ProcessModelId == p2.ProcessModelId &&
                         pr.ProcessRevisionId == p2.ProcessRevisionId
                         select pm).SingleOrDefault();

                var t = from tm in db.Model_BTActivityModel
                        where tm.ProcessRevisionId == p2.ProcessRevisionId
                        select tm;

                if (Name != p.ProcessName ||
                    EntityName != p.TableName ||
                    EntityField != p.KeyField)
                {
                    if (dt != -1)
                        dt = 1;
                }

                if (Activities.Count() > t.Count())
                {
                    if (dt != -1)
                        dt = 1;
                }

                foreach (Model_BTActivityModel tt in t)
                {
                    string activity = null; /*(from tk in Tasks
                                where tk.Guid == tt.TaskGuid 
                                select tk).SingleOrDefault();*/

                    if (activity != null)
                    {
                        int i = activity.CompareTo(tt);

                        if (i == -1)
                        {
                            dt = i;
                            return dt;
                        }

                        if (i == 1 && dt == 0)
                            dt = i;

                        if (dt == -1)
                            return dt;
                    }
                    else
                    {
                        dt = -1;
                        return dt;
                    }
                }
            }
            else
                throw new ArgumentException("Object is not a Model_BTProcessRevision.");

            return dt;
        }

        public void Deploy(BtomicDB db, int userId, string checksum)
        {
            int processModelId;

            var proc = (from pm in db.Model_BTProcessModel
                        where pm.ProcessGuid == Guid
                        select pm).SingleOrDefault();

            if (proc == null)
                processModelId = db.Model_BTProcessModelCreate(Guid, Name, EntityName, EntityField);
            else
                processModelId = proc.ProcessModelId;

            int processRevisionId = db.Model_BTProcessRevisionCreate(processModelId, checksum, userId, DateTime.Now);

            foreach (Activity a in Activities)
            {
                a.Deploy(db, SubProcessID, processRevisionId);
            }

            foreach (Activity a in Activities)
                foreach (Flow f in a.OutFlows)
                    f.Deploy(db, processRevisionId);
        }

        public void DeployLive(BtomicDB db, int systemModuleId)
        {
            db.Model_BTProcessModelDeploy(Guid, systemModuleId);
        }

        public void DeployProcedures(string server, string database, string username,
                                     string password)
        {
            IDictionary<string, DataType> parameters = null;

            foreach (DbObjects db in StoredProcedures)
            {
                try
                {
                    if (!db.Startable)
                    {
                        parameters = new Dictionary<string, DataType>
                                     {
                                         {"InstanceID", DataType.BigInt},
                                         {"KeyValue", DataType.BigInt}
                                     };
                    }
                    CreateProcedure(server, database, "BTEvent_" + db.Id, username, password, parameters, db.Content);
                }
                catch (Exception ex)
                {
                    //EventLogger.LogEvent(string.Format("Event 'BTEvent_{0}' Deployment Error to Database '{1}' - {2}", db.Id, database, ex.InnerException.InnerException.Message));
                    throw new Exception(string.Format("Event 'BTEvent_{0}' Deployment Error to Database '{1}' - {2}", db.Id, database, ex.InnerException.InnerException.Message));
                }
            }

            foreach (DbObjects db in Functions)
            {

                try
                {
                    parameters = new Dictionary<string, DataType>
                                     {
                                         {"InstanceID", DataType.BigInt},
                                         {"KeyValue", DataType.BigInt}
                                     };
                    CreateFunction(server, database, "BTRule_" + db.Id, username, password, parameters, db.Content);
                }
                catch (Exception ex)
                {
                    //EventLogger.LogEvent(string.Format("Event 'BTRule_{0}' Deployment Error to Database '{1}' - {2}", db.Id, database, ex.Message));
                    throw new Exception(string.Format("Event 'BTRule_{0}' Deployment Error to Database '{1}' - {2}", db.Id, database, ex.Message));
                }
            }

            foreach (DbObjects db in Triggers)
            {
                try
                {
                    parameters = new Dictionary<string, DataType> {
                                                                      {"FlowID", DataType.Int},
                                                                      {"InstanceID", DataType.BigInt},
                                                                      {"KeyValue", DataType.BigInt}
                                                                  };
                    CreateProcedure(server, database, "BTTrigger_" + db.Id, username, password, parameters, db.Content);
                }
                catch (Exception ex)
                {
                    //EventLogger.LogEvent(string.Format("Event 'BTTrigger_{0}' Deployment Error to Database '{1}' - {2}", db.Id, database, ex.Message));
                    throw new Exception(string.Format("Event 'BTTrigger_{0}' Deployment Error to Database '{1}' - {2}", db.Id, database, ex.Message));
                }
            }
        }

        private void CreateProcedure(string server, string database, string name, string username,
                                     string password, IEnumerable<KeyValuePair<string, DataType>> parameters,
                                     string body)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                                                    server, database, username, password);

            var proc = new StringWriter();

            proc.WriteLine("if exists(select null");
            proc.WriteLine("from sys.sysobjects");
            proc.WriteLine("where type = 'P'");
            proc.WriteLine("and name = '{0}')", name);
            proc.WriteLine("drop procedure [{0}]", name);
            proc.WriteLine("go");
            proc.WriteLine("create procedure [dbo].[{0}]", name);

            if (parameters != null)
            {
                int paramCount = parameters.Count();
                int i = 1;
                foreach (var p in parameters)
                {
                    proc.Write("@{0} {1}", p.Key, p.Value);
                    if ((p.Value).MaximumLength > 0)
                        proc.Write("({0})", p.Value.MaximumLength);

                    if (i != paramCount)
                        proc.Write(",");

                    if (i == paramCount)
                        proc.WriteLine();
                    i++;
                }
            }

            proc.WriteLine("as");
            proc.WriteLine("begin");
            proc.WriteLine(body);
            proc.WriteLine("end");
            proc.WriteLine("go");

            var conn = new ServerConnection(new SqlConnection(connectionString));
            var Server = new Server(conn);
            Database Db = Server.Databases[database];

            Db.ExecuteNonQuery(proc.ToString());
        }

        private void CreateFunction(string server, string database, string name, string username,
                                     string password, IEnumerable<KeyValuePair<string, DataType>> parameters,
                                     string body)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                                                    server, database, username, password);

            var func = new StringWriter();

            func.WriteLine("if exists(select null");
            func.WriteLine("from sys.sysobjects");
            func.WriteLine("where type = 'FN'");
            func.WriteLine("and name = '{0}')", name);
            func.WriteLine("drop function [{0}]", name);
            func.WriteLine("go");
            func.Write("create function [dbo].[{0}](", name);

            int paramCount = parameters.Count();
            int i = 1;
            foreach (var p in parameters)
            {
                func.Write("@{0} {1}", p.Key, p.Value);
                if ((p.Value).MaximumLength > 0)
                    func.Write("({0})", p.Value.MaximumLength);

                if (i != paramCount)
                    func.Write(",");

                if (i == paramCount)
                    func.WriteLine(")");
                i++;
            }

            func.WriteLine("returns varchar(20)");
            func.WriteLine("begin");
            func.WriteLine(body);
            func.WriteLine("end");
            func.WriteLine("go");

            var conn = new ServerConnection(new SqlConnection(connectionString));
            var Server = new Server(conn);
            Database Db = Server.Databases[database];

            Db.ExecuteNonQuery(func.ToString());
        }
    }
}
