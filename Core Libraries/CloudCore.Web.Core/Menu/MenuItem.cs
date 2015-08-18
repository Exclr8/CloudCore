namespace CloudCore.Web.Core.Menu
{
    public class MenuItem
    {
        public int PID { get; set; }
        public int ID { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string MType { get; set; }
        public bool isFolder { get; set; }
    }


}
