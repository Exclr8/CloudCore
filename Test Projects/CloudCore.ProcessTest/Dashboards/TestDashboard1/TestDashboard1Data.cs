using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.VirtualWorker.DashboardKpi;
using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;

namespace CloudCore.ProcessTest.Dashboards
{
	public class _9cdb9226_cad7_4fda_bf54_9269d4b0ded0 : HighChartImgKpiScheduledTask
	{
        public override Guid UniqueId
        {
            get
            {
                return new Guid("9cdb9226-cad7-4fda-bf54-9269d4b0ded0");
            }
        }

        public override string ControllerActionName
        {
            get
            {
                return "Menu";
            }
        }

        public override string ControllerName
        {
            get
            {
                return "Main";
            }
        }

        public override string Name
        {
            get
            {
                return "TestDashboard1";
            }
        }

        public override int IntervalInMinutes
        {
            get { return 5; }
        }

        public override string Title
        {
            get
            {
                return "Test Dashboard 1";
            }
        }
        
        public override string Description
        {
            get
            {
                return "My Dashboard Description";
            }
        }

        public override string DashboardData
        {
            get { return BuildChart(); }
        }

        private string BuildChart()
        {
            Highcharts chart = new Highcharts(Name);
            chart.InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Type = ChartTypes.Line, ZoomType = ZoomTypes.X });
            chart.SetTitle(new Title { Text = this.Title });
            chart.SetSeries(DummyData());
            chart.SetXAxis(XAxisData());
            chart.SetYAxis(new YAxis
            {
                Title = new YAxisTitle { Text = "Average No of Days" }
            });

            var options = chart.GetOptions();
            var chartName = String.Format("renderTo:'{0}_container',", Name);
            options = options.Replace(chartName, "");
            return options;
        }

        private Series[] DummyData()
        {
            var seedRnd = new Random();
            var seed = seedRnd.Next(0, 999999);
            var rnd = new Random(seed);

            List<Series> series = new List<Series>();
            series.Add(new Series
            {
                Name = "Sick Person One",
                Data = new Data(Randomize(rnd).Cast<object>().ToArray()),
                Type = ChartTypes.Line
            });

            series.Add(new Series
            {
                Name = "Sick Person Two",
                Data = new Data(Randomize(rnd).Cast<object>().ToArray()),
                Type = ChartTypes.Line
            });

            series.Add(new Series
            {
                Name = "Sick Person Three",
                Data = new Data(Randomize(rnd).Cast<object>().ToArray()),
                Type = ChartTypes.Line
            });

            series.Add(new Series
            {
                Name = "Sick Person Four",
                Data = new Data(Randomize(rnd).Cast<object>().ToArray()),
                Type = ChartTypes.Line
            });

            return series.ToArray();
        }

        private XAxis XAxisData()
        {
            List<DateTime> dates = new List<DateTime>();

            for (var i = 0; i < 3; i++)
            {
                dates.Add(DateTime.Now.AddMonths((i * -1)));
            }

            return new XAxis
            {
                Type = AxisTypes.Category,
                Labels = new XAxisLabels() { Rotation = -70 },
                Min = 0,
                Categories = dates.Select(date => date.ToString("dd/MM/yyyy")).ToArray()
            };
        }

        private List<double> Randomize(Random rnd)
        {
            var ret = new List<double>();

            for (int i = 0; i < 3; i++)
            {
                ret.Add(rnd.Next(-5, 30));
            }
            return ret;
        }        
    }
}
