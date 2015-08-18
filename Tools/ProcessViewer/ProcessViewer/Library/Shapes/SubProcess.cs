using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessViewer.Library.Shapes
{
    public class SubProcess : BaseShape
    {
        public SubProcess()
        {
            Activities = new List<IActivity>();
        }

        public Process Parent { get; set; }
        
        public List<IActivity> Activities { get; set; }

        public override string TemplateShapeName
        {
            get { return "SubProcess"; }
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
