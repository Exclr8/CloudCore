namespace CloudCore.Admin.Models
{
    public class SystemApplicationActivity
    {
        public long ActivityId { get; set; }
        public string ModuleName { get; set; }
        public string ActivityName { get; set; }
        public string SubProcessName { get; set; }
        public string ProcessName { get; set; }
    }
}