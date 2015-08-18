using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Architect.ScheduledTasks
{
    public partial class BaseScheduledTask
    {
        #region Calculated Properties

        public string GetDescriptiveIntervalValue()
        {
            return string.Format("Every {0} {1}", this.Interval, this.IntervalType.ToString());
        }

        public string GetStartDateOnlyValue()
        {
            return string.Format("Starts: {0}", this.StartDate.Date.ToString("dd MMM yyyy"));
        }

        public string GetStartTimeOnlyValue()
        {
            return string.Format("@ {0}", this.StartDate.TimeOfDay.ToString());
        }

        public TaskType GetTypeValue()
        {
            if (this is SqlScheduledTask)
                return TaskType.SQL;
            else
                return TaskType.CSharp;
        }

        public string GetTypeDisplayValue()
        {
            switch (this.Type)
            {
                case TaskType.CSharp:       return "C#";
                case TaskType.SQL:             return "SQL";
                default:                                return string.Empty;
            }
        }

        #endregion
    }
}
