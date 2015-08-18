using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Btomic.Classes.Designer
{
    public class Flow : IComparable
    {
        public virtual string Outcome { get; set; }

        public virtual string Storyline { get; set; }

        public virtual bool HasTrigger { get; set; }

        public virtual Guid Guid { get; set; }

        public virtual Guid FromActivity { get; set; }

        public virtual Activity ToActivity { get; set; }

        public virtual bool NegativeFlow { get; set; }

        public virtual bool OptimalFlow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>-1 = Prompt input, 0 = No Change, 1 = Silent
        /// </returns>
        public int CompareTo(object obj)
        {
            int dt = 0;

            if (obj is Model_BTFlowModel)
            {
                var db = new BtomicDB();

                Model_BTFlowModel f2 = (Model_BTFlowModel)obj;

                var flow = (from f in db.Model_BTFlowModel
                            join fromAct in db.Model_BTActivityModel
                                on f.FromActivityModelId equals fromAct.ActivityModelId
                            join toAct in db.Model_BTActivityModel
                                on f.ToActivityModelId equals toAct.ActivityModelId
                            where f.FlowModelId == f2.FlowModelId
                            select new
                                       {
                                           f.Outcome,
                                           f.Storyline,
                                           FromActGuid = fromAct.ActivityGuid,
                                           ToActGuid = toAct.ActivityGuid,
                                           ToActModelId = toAct.ActivityModelId
                                       }).SingleOrDefault();

                if (Outcome != flow.Outcome ||
                    Storyline != flow.Storyline  ||
                    FromActivity != flow.FromActGuid   ||
                    (ToActivity.Indicator == 99 ? flow.ToActModelId != 0 : ToActivity.Guid != flow.ToActGuid))
                {
                    if (dt != -1)
                        dt = 1;
                }
            }
            else
                throw new ArgumentException("Object is not a Model_BTFlowModel.");

            return dt;
        }

        public void Deploy(BtomicDB db, int processRevisionId)
        {
            int iToAct;

            if (ToActivity.Indicator == 99)
            {
                iToAct = 0;
            }
            else
            {
                var toAct = (from a in db.Model_BTActivityModel
                             join t in db.Model_BTSubProcess
                                 on a.SubProcessId equals t.SubProcessId
                             where a.ActivityGuid == ToActivity.Guid &&
                                   t.ProcessRevisionId == processRevisionId
                             select a).SingleOrDefault();
                iToAct = toAct.ActivityModelId;
            }

            var fromAct = (from a in db.Model_BTActivityModel
                           join t in db.Model_BTSubProcess
                               on a.SubProcessId equals t.SubProcessId
                           where a.ActivityGuid == FromActivity &&
                                 t.ProcessRevisionId == processRevisionId
                           select a).SingleOrDefault();

            db.Model_BTFlowModelCreate(Guid, processRevisionId, fromAct.ActivityModelId, Outcome, iToAct, OptimalFlow, NegativeFlow, Storyline);
        }

    }
}
