using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;
using Microsoft.VisualStudio.Modeling;

namespace Btomic.Classes.Designer
{
    public class Activity : IComparable 
    {
        public virtual Guid Guid { get; set; }

        public virtual string Name { get; set;  }

        public virtual bool IsMenuItem { get; set; }

        public virtual int Indicator { get; set;  }

        public virtual bool Startable { get; set;  }

        public virtual bool DocWait { get; set; }

        public virtual int Priority { get; set; }

        public virtual IList<Flow> OutFlows { get; set;  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>-1 = Prompt input, 0 = No Change, 1 = Silent
        /// </returns>
        public int CompareTo(object obj)
        {
            int dt = 0;

            if (obj is Model_BTActivityModel)
            {
                Model_BTActivityModel a2 = (Model_BTActivityModel)obj;

                if (Name != a2.ActivityName ||
                    Guid != a2.ActivityGuid ||
                    Indicator != a2.ActivityInd ||
                    Startable != a2.Startable)
                {
                    if (dt != -1)
                        dt = 1;
                }

                BtomicDB db = new BtomicDB();
                var flows = from f in db.Model_BTFlowModel
                           where f.FromActivityModelId == a2.ActivityModelId
                           select f;

                if (OutFlows.Where(a=>a.ToActivity.Indicator != 99).Count() > flows.Count())
                {
                    if (dt != -1)
                        dt = 1;
                }

                foreach (Model_BTFlowModel f in flows)
                {
                    var flow = (from fl in OutFlows
                               where fl.Guid == f.FlowGuid
                               select fl).SingleOrDefault();

                    if (flow != null)
                    {
                        int i = flow.CompareTo(f);

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
                throw new ArgumentException("Object is not a Model_BTActivityModel.");

            return dt;
        }

        public void Deploy(BtomicDB db, int subProcessId, int processRevisionId)
        {
            int activityModelId = db.Model_BTActivityModelCreate(processRevisionId, 0, Guid, Name, (byte)Indicator, subProcessId, Startable, (byte)Priority, DocWait);
        }

    }
}
