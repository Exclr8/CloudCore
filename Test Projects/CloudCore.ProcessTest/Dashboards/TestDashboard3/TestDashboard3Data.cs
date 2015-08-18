using CloudCore.VirtualWorker.DashboardKpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.ProcessTest.Dashboards.TestDashboard3
{
    //public class _7c196087_f79a_4af8_9d25_babd1f6d56e6 : HighChartImgKpiScheduledTask
    //{
    //    _7C196087-F79A-4AF8-9D25-BABD1F6D56E6
    //    public override Guid UniqueId
    //    {
    //        get { return new Guid("7c196087-f79a-4af8-9d25-babd1f6d56e6"); }
    //    }

    //    public override string Title
    //    {
    //        get { return "Test Dashboard 3"; }
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
    //        get { return "Dummy Column Dashboard"; }
    //    }

    //    public override string Options
    //    {
    //        get
    //        {
    //            var columnChart = ColumnChartOptionsFactory
    //            .Define()
    //                .AddTitle("Test Dashboard 3")
    //                .AddSubTitle("This is the third test")
    //                .AddXAxis("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")
    //                .AddYAxis("")
    //                .AddPlotOptions()
    //            .Construct();

    //            return SerializeToJson(columnChart);
    //        }
    //    }

    //    protected override void GetKpiData(long userId, ColumnChartSeries series)
    //    {
    //        var seedRnd = new Random();
    //        var seed = seedRnd.Next(0, 999999);

    //        var rnd = new Random(seed);

    //        var tokyo = new SeriesDataRow<List<double>>
    //        {
    //            Name = "Tokyo",
    //            Data = Randomize(rnd)
    //        };

    //        series.Data.Add(tokyo);

    //        var newYork = new SeriesDataRow<List<double>>
    //        {
    //            Name = "New York",
    //            Data = Randomize(rnd)
    //        };

    //        series.Data.Add(newYork);

    //        var berlin = new SeriesDataRow<List<double>>
    //        {
    //            Name = "Berlin",
    //            Data = Randomize(rnd)
    //        };

    //        series.Data.Add(berlin);

    //        var london = new SeriesDataRow<List<double>>
    //        {
    //            Name = "London",
    //            Data = Randomize(rnd)
    //        };

    //        series.Data.Add(london);
    //    }

    //    public List<double> Randomize(Random rnd)
    //    {
    //        var ret = new List<double>();

    //        for (int i = 0; i < 12; i++)
    //        {
    //            ret.Add(rnd.Next(-5, 30));
    //        }
    //        return ret;
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
