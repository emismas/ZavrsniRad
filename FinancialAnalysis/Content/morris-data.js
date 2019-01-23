$(function() {

    //Morris.Area({
    //    element: 'morris-area-chart',
    //    data: [{
    //        period: '2019 Q1',
    //        iphone: 1000
    //    }, {
    //        period: '2019 Q2',
    //        iphone: 2000
    //    }, {
    //        period: '2019 Q3',
    //        iphone: 3000
    //    }, {
    //        period: '2019 Q4',
    //        iphone: 4000
    //    }, {
    //        period: '2020 Q1',
    //        iphone: 5000
    //    }, {
    //        period: '2020 Q2',
    //        iphone: 6000
    //    }, {
    //        period: '2020 Q3',
    //        iphone: 7000
    //    }],
    //    xkey: 'period',
    //    ykeys: ['iphone'],
    //    labels: ['iPhone'],
    //    pointSize: 2,
    //    hideHover: 'auto',
    //    resize: true
    //});

    //Morris.Donut({
    //    element: 'morris-donut-chart',
    //    colors: ["#00ff00","#ff0000"],
    //    data: [{
    //        label: "Money earned",
    //        value: 111
    //    }, {
    //        label: "Money spent",
    //        value: 7000
    //    }],
    //    resize: true
    //});

    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            y: '2006',
            a: 100,
            b: 90
        }, {
            y: '2007',
            a: 75,
            b: 65
        }, {
            y: '2008',
            a: 50,
            b: 40
        }, {
            y: '2009',
            a: 75,
            b: 65
        }, {
            y: '2010',
            a: 50,
            b: 40
        }, {
            y: '2011',
            a: 75,
            b: 65
        }, {
            y: '2012',
            a: 100,
            b: 90
        }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B'],
        hideHover: 'auto',
        resize: true
    });
    
});
