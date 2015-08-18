using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;
using Architect.CustomCode.Helpers;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class Start
    {
        [ValidationMethod(ValidationCategories.Save)]
        private void ValidateAllStartFromFlow(ValidationContext context)
        {
            if (!this.IsStartable)
            {
                if (SourceActivities.Count == 0 && SourceActs.Count == 0 && SActivity.Count == 0)
                {
                    string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                        CustomCode.Validation.ValidationResources.ValidateInFlow, Name);
                    context.LogError("Start: " + error, "Flow", this);
                }
            }
        }

        [ValidationMethod(ValidationCategories.Save)]
        private void ValidateAllStartToFlow(ValidationContext context)
        {
            if (TargetActivities.Count == 0 && TargetActs.Count == 0 && TActivity.Count == 0)
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.ValidateOutFlow, Name);
                context.LogError("Start: " + error, "Flow", this);
            }
        }
    }

    [ValidationState(ValidationState.Enabled)]
    public partial class FlowBase
    {
        [ValidationMethod(ValidationCategories.Save)]
        private void ValidateOptimal(ValidationContext context)
        {
            string error = "";
            if (Type == FlowType.Optimal)
            {
                if (!(TargetActivity is Stop) && !(TargetActivity is ToProcessConnector))
                {
                    int iCount = GetLinksToTargetActs(TargetActivity).Where(a => a.Type == FlowType.Optimal).Count();
                    if (iCount > 1)
                    {
                        error = "Optimal path can not have more than one route";
                    }
                    else if (iCount == 0)
                        error = "Optimal path must preceed with another optimal path from start to stop";
                    else
                        error = "";

                    if (error != string.Empty)
                    {
                        context.LogError("FlowBase: " + error, "Flow", this);
                    }
                }

                if (!(SourceActivity is Start) && !(TargetActivity is FromProcessConnector))
                {

                    int iCount = GetLinksToSourceActs(SourceActivity).Where(a => a.Type == FlowType.Optimal).Count();
                    if (iCount == 0)
                        error = "Optimal path must preceed with another optimal path from start to stop";
                    else
                        error = "";

                    if (error != string.Empty)
                    {
                        context.LogError("FlowBase: " + error, "Flow", this);
                    }
                }
            }

            if (SourceActivity is Start && ((Start)SourceActivity).IsStartable && !(TargetActivity is Stop))
            {
                int iCount = GetLinksToTargetActs(TargetActivity).Where(a => a.Type == FlowType.Optimal).Count();
                if (iCount > 0)
                {
                    var iiCount = GetLinksToTargetActs(SourceActivity).Where(a => a.Type == FlowType.Optimal).Count();
                    if (iiCount == 0)
                        error = "Optimal path must preceed with another optimal path from start to stop";
                    else
                        error = "";

                    if (error != string.Empty)
                    {
                        context.LogError("FlowBase: " + error, "Flow", this);
                    }
                }
            }
        }
    }
}
