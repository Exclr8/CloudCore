using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Architect
{
    public partial class FlowBuilder
    {
        public static bool CanAcceptActivityAsSource(Activity candidate)
        {
            return candidate.TargetActs.Count == 0;
        }

        public static bool CanAcceptActivityAndActivityAsSourceAndTarget(Activity source, Activity target)
        {
            if (source is Stop)
            {
                return false;
            }
            else if (source == target)
            {
                return false;
            }
            else
            {
                return source.TargetActs.Count == 0;
            }
        }

        public static bool CanAcceptActivityAsTarget(Activity candidate)
        {
            return true;
        }
    }
}
