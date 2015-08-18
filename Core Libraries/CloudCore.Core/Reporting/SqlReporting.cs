namespace CloudCore.Core.Reporting
{
    public enum SqlReportType
    {
        Excel,
        PDF,
        Image
    }

    public class SqlReportDataSource
    {
        public string DataSetName { get; set; }
        public System.Collections.IEnumerable DataList { get; set; }
    }
}
