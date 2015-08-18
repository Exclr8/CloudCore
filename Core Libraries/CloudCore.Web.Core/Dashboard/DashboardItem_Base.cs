using System;
using System.Collections.Generic;
using System.Drawing;

namespace CloudCore.Web.Core.Dashboard
{
    public interface IDashboardItem
    {
        string Title { get; }
        string Description { get; }
        string[] Categories { get; }
        ChartType DashboardChartType { get; }
        List<DashboardItemSeries> Series { get; }

    }

    public enum ChartType
    {
        Pie,
        Column,
        Line
    }

    public class DashboardItemSeries
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<SeriesData> Data { get; set; }
    }

    public class SeriesData
    {
        public string Value { get; set; }
    }

    public abstract class DashboardItem_Base : IDashboardItem
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract string[] Categories { get; }
        public abstract ChartType DashboardChartType { get; }
        public abstract List<DashboardItemSeries> Series { get; }

        public DashboardItem_Base() { }

        public string GenerateItemJScript_Small(string RenderToContainer)
        {
            try
            {
                string ReturnJScript = "";
                if (DashboardChartType == ChartType.Pie)
                {
                    string _SeriesData = ""; //Example ['Firefox',   45.0],['IE', 26.8]

                    foreach (DashboardItemSeries itm in Series)
                    {
                        _SeriesData = _SeriesData + "['" + itm.Name + "'," + itm.Data[0].Value + "],";
                    }

                    ReturnJScript = "var chart1_sml;$(document).ready(function() {chart1_sml = new Highcharts.Chart({chart: {renderTo: '" + RenderToContainer + "',plotBackgroundColor: 'transparent',plotBorderWidth: null,plotShadow: false},title: {text: '" + Title.Trim() + "'},tooltip: {formatter: function() {return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';}},plotOptions: {pie: {allowPointSelect: true,cursor: 'pointer',dataLabels: {enabled: false,color: '#000000',connectorColor: '#000000',formatter: function() {return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';}}}},series: [{type: 'pie',name: '',data: [" + _SeriesData + "]}]});});";
                }
                else
                {
                    if (DashboardChartType == ChartType.Line)
                    {
                        string _Categories = ""; //Example ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

                        foreach (string cat in Categories)
                        {
                            _Categories = _Categories + "'" + cat.Trim() + "',";
                        }

                        string _SeriesData = ""; //Example {name: 'Tokyo',data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]}, {name: 'New York',data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]}, 

                        foreach (DashboardItemSeries itm in Series)
                        {
                            _SeriesData = _SeriesData + "{name:'" + itm.Name + "',data: [";
                            foreach (SeriesData sd in itm.Data)
                            {
                                _SeriesData = _SeriesData + sd.Value + ",";
                            }
                            _SeriesData = _SeriesData + "]},";
                        }
                        ReturnJScript = "var chart2_sml;$(document).ready(function() {chart2_sml = new Highcharts.Chart({chart: {renderTo: '" + RenderToContainer + "',defaultSeriesType: 'line',marginRight: 130,marginBottom: 25},title: {text: '" + Title.Trim() + "'},subtitle: {text: ''},xAxis: {categories: [" + _Categories + "]},yAxis: {title: {text: ''},plotLines: [{value: 0,width: 1,color: '#808080'}]},tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.x +': '+ this.y +'Â°C';}},legend: {layout: 'vertical',align: 'right',verticalAlign: 'top',x: -10,y: 100,borderWidth: 0},series: [" + _SeriesData + "]});});";
                    }
                    else
                    {
                        if (DashboardChartType == ChartType.Column)
                        {
                            string _Categories = ""; //Example ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

                            foreach (string cat in Categories)
                            {
                                _Categories = _Categories + "'" + cat.Trim() + "',";
                            }

                            string _SeriesData = ""; //Example {name: 'Tokyo',data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]}, {name: 'New York',data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]}, 

                            foreach (DashboardItemSeries itm in Series)
                            {
                                _SeriesData = _SeriesData + "{name:'" + itm.Name + "',data: [";
                                foreach (SeriesData sd in itm.Data)
                                {
                                    _SeriesData = _SeriesData + sd.Value + ",";
                                }
                                _SeriesData = _SeriesData + "]},";
                            }
                            ReturnJScript = "var chart3_sml;$(document).ready(function() {chart3_sml = new Highcharts.Chart({chart: {renderTo: '" + RenderToContainer + "',defaultSeriesType: 'column'},title: {text: '" + Title.Trim() + "'},subtitle: {text: ''},xAxis: {categories: [" + _Categories + "]},yAxis: {min: 0,title: {text: ''}},legend: {layout: 'vertical',backgroundColor: '#FFFFFF',align: 'left',verticalAlign: 'top',x: 100,y: 70,floating: true,shadow: true},tooltip: {formatter: function() {return ''+this.x +': '+ this.y +' mm';}},plotOptions: {column: {pointPadding: 0.2,borderWidth: 0}},series: [" + _SeriesData + "]});});";
                        }
                    }
                }
                return ReturnJScript;
            }
            catch (Exception)
            {
                return "Error Occured While Generating Dashboard Item";
            }
        }

        public string GenerateItemJScript_Big(string RenderToContainer)
        {
            try
            {
                string ReturnJScript = "";
                if (DashboardChartType == ChartType.Pie)
                {
                    string _SeriesData = ""; //Example ['Firefox',   45.0],['IE', 26.8]

                    foreach (DashboardItemSeries itm in Series)
                    {
                        _SeriesData = _SeriesData + "['" + itm.Name + "'," + itm.Data[0].Value + "],";
                    }

                    ReturnJScript = "var chart1_big;$(document).ready(function() {chart1_big = new Highcharts.Chart({chart: {renderTo: '" + RenderToContainer + "',plotBackgroundColor: 'transparent',plotBorderWidth: null,plotShadow: false},title: {text: '" + Title.Trim() + "'},tooltip: {formatter: function() {return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';}},plotOptions: {pie: {allowPointSelect: true,cursor: 'pointer',dataLabels: {enabled: true,color: '#000000',connectorColor: '#000000',formatter: function() {return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';}}}},series: [{type: 'pie',name: '',data: [" + _SeriesData + "]}]});});";
                }
                else
                {
                    if (DashboardChartType == ChartType.Line)
                    {
                        string _Categories = ""; //Example ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

                        foreach (string cat in Categories)
                        {
                            _Categories = _Categories + "'" + cat.Trim() + "',";
                        }

                        string _SeriesData = ""; //Example {name: 'Tokyo',data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]}, {name: 'New York',data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]}, 

                        foreach (DashboardItemSeries itm in Series)
                        {
                            _SeriesData = _SeriesData + "{name:'" + itm.Name + "',data: [";
                            foreach (SeriesData sd in itm.Data)
                            {
                                _SeriesData = _SeriesData + sd.Value + ",";
                            }
                            _SeriesData = _SeriesData + "]},";
                        }
                        ReturnJScript = "var chart2_sml;$(document).ready(function() {chart2_sml = new Highcharts.Chart({chart: {renderTo: '" + RenderToContainer + "',defaultSeriesType: 'line',marginRight: 130,marginBottom: 25},title: {text: '" + Title.Trim() + "'},subtitle: {text: ''},xAxis: {categories: [" + _Categories + "]},yAxis: {title: {text: ''},plotLines: [{value: 0,width: 1,color: '#808080'}]},tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.x +': '+ this.y +'Â°C';}},legend: {layout: 'vertical',align: 'right',verticalAlign: 'top',x: -10,y: 100,borderWidth: 0},series: [" + _SeriesData + "]});});";
                    }
                    else
                    {
                        if (DashboardChartType == ChartType.Column)
                        {
                            string _Categories = ""; //Example ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

                            foreach (string cat in Categories)
                            {
                                _Categories = _Categories + "'" + cat.Trim() + "',";
                            }

                            string _SeriesData = ""; //Example {name: 'Tokyo',data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]}, {name: 'New York',data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]}, 

                            foreach (DashboardItemSeries itm in Series)
                            {
                                _SeriesData = _SeriesData + "{name:'" + itm.Name + "',data: [";
                                foreach (SeriesData sd in itm.Data)
                                {
                                    _SeriesData = _SeriesData + sd.Value + ",";
                                }
                                _SeriesData = _SeriesData + "]},";
                            }
                            ReturnJScript = "var chart3_big;$(document).ready(function() {chart3_big = new Highcharts.Chart({chart: {renderTo: '" + RenderToContainer + "',defaultSeriesType: 'column'},title: {text: '" + Title.Trim() + "'},subtitle: {text: ''},xAxis: {categories: [" + _Categories + "]},yAxis: {min: 0,title: {text: ''}},legend: {layout: 'vertical',backgroundColor: '#FFFFFF',align: 'left',verticalAlign: 'top',x: 100,y: 70,floating: true,shadow: true},tooltip: {formatter: function() {return ''+this.x +': '+ this.y +' mm';}},plotOptions: {column: {pointPadding: 0.2,borderWidth: 0}},series: [" + _SeriesData + "]});});";
                        }
                    }
                }
                return ReturnJScript;
            }
            catch (Exception)
            {
                return "Error Occured While Generating Dashboard Item";
            }
        }
    }
   
}
