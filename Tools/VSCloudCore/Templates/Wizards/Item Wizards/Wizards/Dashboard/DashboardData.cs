using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class DashboardData : TemplateData
    {
        public string DashboardTitle { get; set; }
        public string DashboardSubTitle { get; set; }
        public Guid DashboardGuid { get; set; }
        public DashboardTypeEnum Type { get; set; }
        public DashboardData()
        {
            DashboardGuid = Guid.NewGuid();

            DashboardTypeInfo = new List<DashboardType>
            {
                new DashboardType { ClassType = "BarChartSeries", ReturnType = "List<double>", Type = DashboardTypeEnum.BarChart },
                new DashboardType { ClassType = "LineChartSeries", ReturnType = "List<double>", Type = DashboardTypeEnum.LineChart },
                new DashboardType { ClassType = "ColumnChartSeries", ReturnType = "List<double>", Type = DashboardTypeEnum.ColumnChart },
                new DashboardType { ClassType = "PieChartSeries", ReturnType = "double", Type = DashboardTypeEnum.PieChart }
            };
        }

        private List<DashboardType> DashboardTypeInfo { get; set; }

        public string GetDashboardClassType
        {
            get { return DashboardTypeInfo.Single(x => x.Type == Type).ClassType; }
        }
        public string GetDashboardReturnType
        {
            get { return DashboardTypeInfo.Single(x => x.Type == Type).ReturnType; }
        }
    }

    [Serializable]
    public class DashboardType
    {
        public DashboardTypeEnum Type { get; set; }
        public string ClassType { get; set; }
        public string ReturnType { get; set; }
    }
}
