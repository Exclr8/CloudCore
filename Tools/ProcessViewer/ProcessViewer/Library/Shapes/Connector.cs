using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessViewer.Library.Shapes
{
    [Flags]
    public enum ConnectorProperties
    {
        None = 0,
        Trigger = 1,
        Optimal = 2,
        Negative = 4
    }

    public class Connector : BaseShape
    {
        private ConnectorProperties Properties { get; set; }
        public int FromActivityId;
        public int ToActivityId;

        public void AddProperty(ConnectorProperties property)
        {
            Properties |= property;
        }

        public void RemoveProperty(ConnectorProperties property)
        {
            //make sure it is removed by adding it first before the xor, maybe a better solution?
            Properties = (Properties & property) ^ property;
        }

        public void FlipProperty(ConnectorProperties property)
        {
            Properties ^= property;
        }

        public bool HasProperty(ConnectorProperties property)
        {
            return (property & Properties) == property;
        }

        public override string TemplateShapeName
        {
            get { return "Flow Connector"; }
        }

        public override bool HasTitle
        {
            get { return true; }
        }

        public override bool IsDrawable
        {
            get { return true; }
        }
    }
}
