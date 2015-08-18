using System;

namespace CloudCore.Web.Core.EditorTemplateAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxDateAttribute : Attribute
    {
        public DateTime MaximumValue { get; set; }

        public MaxDateAttribute(int addYears)
        {
            AddTime(addYears);
        }

        public MaxDateAttribute(int addYears, int addMonths)
        {
            AddTime(addYears, addMonths);
        }
        
        public MaxDateAttribute(int addYears, int addMonths, int addDays)
        {
            AddTime(addYears, addMonths, addDays);            
        }

        private void AddTime(int addYears, int addMonths = 0, int addDays = 0)
        {
            MaximumValue = DateTime.Now.AddYears(addYears).AddMonths(addMonths).AddDays(addDays);
        }
    }
}
