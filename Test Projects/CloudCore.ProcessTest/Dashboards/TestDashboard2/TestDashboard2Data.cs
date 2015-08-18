using CloudCore.VirtualWorker.DashboardKpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudCore.ProcessTest.Dashboards
{
    //public class _6e76b8bb_caa2_4cfb_85d7_8aedc0e7ecbf : HighChartImgKpiScheduledTask
    //{
    //    public override Guid UniqueId
    //    {
    //        get
    //        {
    //            return new Guid("6e76b8bb-caa2-4cfb-85d7-8aedc0e7ecbf");
    //        }
    //    }

    //    public override int IntervalInMinutes
    //    {
    //        get { return 2; }
    //    }

    //    public override string Name
    //    {
    //        get
    //        {
    //            return "TestDashboard2";
    //        }
    //    }

    //    public override string Title
    //    {
    //        get
    //        {
    //            return "Test Dashboard 2";
    //        }
    //    }

    //    public override string Description
    //    {
    //        get
    //        {
    //            return "My Dashboard Description";
    //        }
    //    }

    //    public override string Options
    //    {
    //        get
    //        {
    //            var barChart = BarChartOptionsFactory
    //                .Define()
    //                    .AddTitle("Test Dashboard 2")
    //                    .AddSubTitle("This is the second test")
    //                    .AddXAxis("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")
    //                    .AddYAxis(0, "", "high", "justify")
    //                    .AddTooltip("")
    //                    .AddPlotOptions(true)
    //                    .AddLegend("vertical", "right", "top", true, 1, true)
    //                    .AddCredits(false)
    //                .Construct();

    //            return SerializeToJson(barChart);
    //        }
    //    }

    //    protected override void GetKpiData(long userId, BarChartSeries series)
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
