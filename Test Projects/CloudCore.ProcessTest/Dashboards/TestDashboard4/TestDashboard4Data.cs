using CloudCore.VirtualWorker.DashboardKpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.ProcessTest.Dashboards.TestDashboard4
{
    //public class _62551c9a_626b_4841_b98b_b5c9c8e2e530 : HighChartImgKpiScheduledTask
    //{
    //    _62551c9a-626b-4841-b98b-b5c9c8e2e530
    //    public override Guid UniqueId
    //    {
    //        get { return new Guid("62551c9a-626b-4841-b98b-b5c9c8e2e530"); }
    //    }

    //    public override string Title
    //    {
    //        get { return "Test Dashboard 4"; }
    //    }

    //    public override string Name
    //    {
    //        get { return "TestDashboard3"; }
    //    }

    //    public override int IntervalInMinutes
    //    {
    //        get { return 5; }
    //    }

    //    public override string Description
    //    {
    //        get { return "Dummy Pie chart Dashboard"; }
    //    }

    //    public override string Options
    //    {
    //        get
    //        {
    //            var pieChart = PieChartOptionsFactory
    //            .Define()
    //                .AddTitle("Test Dashboard 4")
    //                .AddTooltip()
    //                .AddPlotOptions()
    //            .Construct();

    //            return SerializeToJson(pieChart);
    //        }
    //    }

    //    protected override void GetKpiData(long userId, PieChartSeries series)
    //    {
    //        var seedRnd = new Random();
    //        var seed = seedRnd.Next(0, 999999);
    //        var rnd = new Random(seed);

    //        series.SeriesName = "Dummy Data";

    //        series.ChartData.Add(new PieDataRow<double>
    //        {
    //            Name = "Tokyo",
    //            Value = Randomize(rnd)
    //        });
    //        series.ChartData.Add(new PieDataRow<double>
    //        {
    //            Name = "New York",
    //            Value = Randomize(rnd)
    //        });
    //        series.ChartData.Add(new PieDataRow<double>
    //        {
    //            Name = "Berlin",
    //            Value = Randomize(rnd)
    //        });
    //        series.ChartData.Add(new PieDataRow<double>
    //        {
    //            Name = "London",
    //            Value = Randomize(rnd)
    //        });
    //    }

    //    public double Randomize(Random rnd)
    //    {
    //        return rnd.Next(-5, 30);
    //    }
    //    public override Guid UniqueId
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override string Title
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override string Name
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override int IntervalInMinutes
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override string Description
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override string DashboardData
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}
}
