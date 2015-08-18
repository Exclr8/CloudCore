using System;
using System.Collections.Generic;
using CloudCore.VirtualWorker.ScheduledTasks;
using Newtonsoft.Json;
using CloudCore.VirtualWorker.DashboardKpi;

namespace KpiDashboardTests
{
    public class TestKpiImgDashboard : HighChartImgKpiScheduledTask
    {

        //public override Guid UniqueId
        //{
        //    get { return new Guid("F898F569-6736-4645-BE53-ADEEDC8C361F"); }
        //}

        //public override string Title
        //{
        //    get { return "Test Title"; }
        //}

        //public override string Name
        //{
        //    get { return "Test Name"; }
        //}

        //public override int IntervalInMinutes
        //{
        //    get { return 2; }
        //}

        //public override string Description
        //{
        //    get { return "Test Description"; }
        //}

        //public override string Options
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //protected override void GetKpiData(long userId, LineChartSeries series)
        //{
        //    var seedRnd = new Random();
        //    var seed = seedRnd.Next(0, 999999);

        //    var rnd = new Random(seed);

        //    var y = new List<double>();

        //    y.AddRange(Randomize(rnd));

        //    var tokyo = new SeriesDataRow<List<double>>
        //    {
        //        Name = "Tokyo",
        //        Data = y
        //    };

        //    series.Data.Add(tokyo);

        //    y.Clear();
        //    y.AddRange(Randomize(rnd));

        //    var newYork = new SeriesDataRow<List<double>>
        //    {
        //        Name = "New York",
        //        Data = y
        //    };

        //    series.Data.Add(newYork);

        //    y.Clear();
        //    y.AddRange(Randomize(rnd));

        //    var berlin = new SeriesDataRow<List<double>>
        //    {
        //        Name = "Berlin",
        //        Data = y
        //    };

        //    series.Data.Add(berlin);

        //    y.Clear();
        //    y.AddRange(Randomize(rnd));

        //    var london = new SeriesDataRow<List<double>>
        //    {
        //        Name = "London",
        //        Data = y
        //    };

        //    series.Data.Add(london);
        //}


        //public List<double> Randomize(Random rnd)
        //{
        //    var ret = new List<double>();

        //    for (int i = 0; i < 12; i++)
        //    {
        //        ret.Add(rnd.Next(-5, 30));
        //    }
        //    return ret;
        //}
        public override Guid UniqueId
        {
            get { throw new NotImplementedException(); }
        }

        public override string Title
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override int IntervalInMinutes
        {
            get { throw new NotImplementedException(); }
        }

        public override string Description
        {
            get { throw new NotImplementedException(); }
        }

        public override string DashboardData
        {
            get { throw new NotImplementedException(); }
        }
    }
}
