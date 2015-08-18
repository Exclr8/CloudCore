using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.Core.Utilities
{
    public static class DateTimeUtils
    {
        public static DateTime EndOfDay(DateTime date)
        {
            return date.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(998);
        }

    }
}
