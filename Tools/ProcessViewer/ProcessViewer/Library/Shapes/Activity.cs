using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessViewer.Library.Shapes
{
    public abstract class IActivity : BaseShape
    {
        private ActivityProperties Properties { get; set; }
        public SubProcess Parent { get; set; }

        public void AddProperty(ActivityProperties property)
        {
            Properties |= property;
        }

        public void RemoveProperty(ActivityProperties property)
        {
            //make sure it is removed by adding it first before the xor, maybe a better solution?
            Properties = (Properties & property) ^ property;
        }

        public void FlipProperty(ActivityProperties property)
        {
            Properties ^= property;
        }

        public bool HasProperty(ActivityProperties property)
        {
            return (property & Properties) == property;
        }

        public override bool HasTitle
        {
            get
            {
                if ((ActivityProperties.Startable & Properties) == ActivityProperties.Startable)
                    return false;
                if ((ActivityProperties.Terminate & Properties) == ActivityProperties.Terminate)
                    return false;

                return true;
            }
        }

        public override string TemplateShapeName
        {
            get { return null; }
        }

        public override bool IsDrawable
        {
            get { return true; }
        }
    }

    public class PageActivity : IActivity
    {
        public override string TemplateShapeName
        {
            get { return "Page Activity"; }
        }
    }

    public class DatabaseActivity : IActivity
    {
        public override string TemplateShapeName
        {
            get { return "Database Activity"; }
        }
    }

    public class BusinessRule : IActivity
    {
        public override string TemplateShapeName
        {
            get { return "Business Rule"; }
        }
    }

    public class StopActivity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Process Stop";
            }
        }
    }

    //new Shapes RSL
    public class Custom_User_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Custom User Activity";
            }
        }
    }

    public class Cloud_Batch_Wait : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Cloud Batch Wait";
            }
        }
    }

    public class Cloud_Costing : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Cloud Costing";
            }
        }
    }

    public class Cloud_Parked_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Cloud Parked Activity";
            }
        }
    }

    public class CloudCore_User_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "CloudCore User Activity";
            }
        }
    }

    public class Database_Costing : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Database Costing";
            }
        }
    }

    public class Cloud_Batch_Start : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Cloud Batch Start";
            }
        }
    }

    public class Database_Batch_Start : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Database Batch Start";
            }
        }
    }

    public class Cloud_Custom_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Cloud Custom Activity";
            }
        }
    }

    public class Database_Batch_Wait : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Database Batch Wait";
            }
        }
    }

    public class Corticon_Business_Rule : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Corticon Business Rule";
            }
        }
    }

    public class Email_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Email Activity";
            }
        }
    }

    public class SMS_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "SMS Activity";
            }
        }
    }

    public class Database_Custom_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Database Custom Activity";
            }
        }
    }

    public class Process_Stop : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Process Stop";
            }
        }
    }

    public class Database_Parked_Activity : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Database Parked Activity";
            }
        }
    }

    public class Flow_Connector : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Flow Connector";
            }
        }
    }

    public class Flow_Rule : IActivity
    {
        public override string TemplateShapeName
        {
            get
            {
                return "Flow Rule";
            }
        }
    }

    [Flags]
    public enum ActivityProperties
    {
        None = 0,
        Startable = 1,
        Parked = 2,
        Email = 4,
        Delay = 8,
        Batching = 16,
        Branching = 32,
        DocumentWait = 64,
        Recuring = 128,
        Terminate = 256
    }

    public enum ActivityType
    {
        None = 0,
        TaskItem = 1,
        PageActivity = 2,
        DatabaseActivity = 3,
        BusinessRule = 4
    }
}

