using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Mvc;
using CloudCore.Core.Reporting;
using CloudCore.Web.Core.Extensions;
using Microsoft.Reporting.WebForms;

namespace CloudCore.Web.Core.Reporting
{
    public class SqlReport
    {
        public FileContentResult CreateReport(SqlReportType type, string reportName, string area, string datasetName,
            IEnumerable dataList)
        {
            string mimeType;
            var report = new LocalReport();

            report.LoadReportDefinition(AssetResolver.GetEmbeddedResourceStream(reportName, area));

            var reportDataSource = new ReportDataSource(datasetName, dataList);
            report.DataSources.Add(reportDataSource);
            byte[] reportBytes = GenerateReport(type, report, out mimeType);
            return new FileContentResult(reportBytes, mimeType);
        }

        public FileContentResult CreateReport(SqlReportType type, string reportName, string area, string datasetName,
            IEnumerable dataList, List<ReportParameter> myparams)
        {
            string mimeType;
            var report = new LocalReport();

            report.LoadReportDefinition(AssetResolver.GetEmbeddedResourceStream(reportName, area));
            report.SetParameters(myparams);
            var reportDataSource = new ReportDataSource(datasetName, dataList);
            report.DataSources.Add(reportDataSource);

            byte[] reportBytes = GenerateReport(type, report, out mimeType);
            return new FileContentResult(reportBytes, mimeType);
        }

        public FileContentResult CreateReport(SqlReportType type, string reportName, string area,
            List<SqlReportDataSource> reportDataSources)
        {
            string mimeType;
            Stream stream = AssetResolver.GetEmbeddedResourceStream(reportName, area);
            byte[] reportBytes = GetReportBytes(type, reportDataSources, stream, out mimeType);
            return new FileContentResult(reportBytes, mimeType);
        }

        public FileContentResult CreateReport(SqlReportType type, string reportName, string area, string datasetName,
            DataTable dataTable)
        {
            string mimeType;
            Stream stream = AssetResolver.GetEmbeddedResourceStream(reportName, area);

            var reportDataSource = new List<ReportDataSource>
            {
                new ReportDataSource(datasetName, dataTable)
            };

            byte[] reportBytes = GetReportBytes(type, reportDataSource, stream, out mimeType);
            return new FileContentResult(reportBytes, mimeType);
        }

        public FileContentResult CreateReport(SqlReportType type, string reportPath,
            IEnumerable<SqlReportDataSource> reportDataSources)
        {
            string mimeType;
            var fileStream = new FileStream(reportPath, FileMode.Open, FileAccess.Read);
            byte[] reportBytes = GetReportBytes(type, reportDataSources, fileStream, out mimeType);
            return new FileContentResult(reportBytes, mimeType);
        }

        private byte[] GetReportBytes(SqlReportType type, IEnumerable<ReportDataSource> reportDataSources, Stream stream,
            out string mimeType)
        {
            LocalReport report = LoadReportFromStream(stream);
            AddReportResource(reportDataSources, report);
            byte[] reportBytes = GenerateReport(type, report, out mimeType);
            return reportBytes;
        }

        private byte[] GetReportBytes(SqlReportType type, IEnumerable<SqlReportDataSource> reportDataSources,
            Stream stream, out string mimeType)
        {
            LocalReport report = LoadReportFromStream(stream);
            AddReportResource(reportDataSources, report);
            byte[] reportBytes = GenerateReport(type, report, out mimeType);
            return reportBytes;
        }

        private static LocalReport LoadReportFromStream(Stream stream)
        {
            var report = new LocalReport();
            report.LoadReportDefinition(stream);
            return report;
        }

        private static void AddReportResource(IEnumerable<SqlReportDataSource> reportDataSources, LocalReport report)
        {
            foreach (SqlReportDataSource rds in reportDataSources)
            {
                var reportDataSource = new ReportDataSource(rds.DataSetName, rds.DataList);
                report.DataSources.Add(reportDataSource);
            }
        }

        private static void AddReportResource(IEnumerable<ReportDataSource> reportDataSources, LocalReport report)
        {
            foreach (ReportDataSource rds in reportDataSources)
                report.DataSources.Add(rds);
        }

        private byte[] GenerateReport(SqlReportType type, LocalReport report, out string mimeType)
        {
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            byte[] bytes = report.Render(type.ToString(), null, out mimeType, out encoding, out fileNameExtension,
                out streams, out warnings);
            return bytes;
        }
    }
}