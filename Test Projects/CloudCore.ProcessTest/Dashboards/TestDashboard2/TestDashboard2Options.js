{
    chart: {
            type: 'bar'
    },
    title: {
            text: 'Test Dashboard 2'
    },
    subtitle: {
            text: 'This is the second test'
    },
    xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            title: {
            text: ''
            }
    },
    yAxis: {
            min: 0,
            title: {
            text: '',
            align: 'high'
            },
        labels: {
                overflow: 'justify'
        }
    },
    tooltip: {
            valueSuffix: ''
    },
    plotOptions: {
            bar: {
                dataLabels: {
                        enabled: true
                }
            }
    },
    legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            floating: true,
            borderWidth: 1,
            shadow: true
    },
    credits: {
            enabled: false
    },
    series: //*seriesData*//
}