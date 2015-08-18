using System;

namespace CloudCore.Web.Core.EditorTemplateAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinDateAttribute : Attribute
    {
        public DateTime MinimumValue { get; set; }

        public MinDateAttribute(int addYears)
        {
            AddTime(addYears);
        }

        public MinDateAttribute(int addYears, int addMonths)
        {
            AddTime(addYears, addMonths);
        }

        public MinDateAttribute(int addYears, int addMonths, int addDays)
        {
            AddTime(addYears, addMonths, addDays);
        }

        private void AddTime(int addYears, int addMonths = 0, int addDays = 0)
        {
            MinimumValue = DateTime.Now.AddYears(addYears).AddMonths(addMonths).AddDays(addDays);
        }
    }
}
