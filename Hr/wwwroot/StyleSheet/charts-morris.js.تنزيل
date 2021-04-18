$( document ).ready(function() {
    Morris.Area({
        element: 'morris1',
        data: [
            { period: '2016-01-01', emps: 10000, Persent: 2666, Late: 300, Execues: 47, Vacation: 10, Absent: 30 },
            { period: '2016-01-02', emps: 10000, Persent: 66, Late: null, Execues: 1027, Vacation: 10, Absent: 30 },
            { period: '2016-01-03', emps: 10000, Persent: 196, Late: 66, Execues: null, Vacation: null, Absent: 200 },
            { period: '2016-01-04', emps: 10000, Persent: 966, Late: null, Execues: 200, Vacation: 150, Absent: 30 },
            { period: '2016-01-05', emps: 10000, Persent: 1200, Late: 20, Execues: 27, Vacation: 20, Absent: 300 },
            { period: '2016-01-06', emps: 10000, Persent: 2000, Late: null, Execues: 10, Vacation: null, Absent: 150 },
            { period: '2016-01-07', emps: 10000, Persent: 6, Late: 122, Execues: 2647, Vacation: 10, Absent: null }
             
        ],
        xkey: 'period',
        ykeys: [ 'Persent', 'Late', 'Execues', 'Vacation', 'Absent'],
        labels: ['الحضور', 'التاخير', 'الاستاذانات', 'المجازين', 'الغياب'],
        hideHover: 'auto',
        lineColors: ['#8ce5f7', '#74d1e4', '#22a1ba','#721e4', '#12a1ba'],
        resize: false
    });
    
    Morris.Bar({
        element: 'morris2',
        data: [
            { year: '2006', a: 25, b: 15 },
            { year: '2007', a: 50, b: 40 },
            { year: '2008', a: 75, b: 65 },
            { year: '2009', a: 100, b: 90 },
            { year: '2010', a: 60, b: 50 },
            { year: '2011', a: 75, b: 65 },
            { year: '2012', a: 100, b: 90 } 
        ],
        xkey: 'year',
        ykeys: ['a', 'b'],
        labels: ['a', 'b'],
        barRatio: 0.4,
        xLabelAngle: 35,
        hideHover: 'auto',
        barColors: ['#44b4cb', '#74d1e4'],
        resize: true
    });
    
    //Morris.Line({
    //    element: 'morris3',
    //    data: [
    //           { period: '2016-01-01', emps: 10000, Persent: 2900, Late: 20, Execues: 50, Vacation: 10, Absent: 20 },
    //        { period: '2016-01-02', emps: 10000, Persent: 2500, Late: 100, Execues: 250, Vacation: 50, Absent: 100 },
    //        { period: '2016-01-03', emps: 10000, Persent: 2950, Late: 10, Execues: 1, Vacation: 2, Absent: 37 },
    //        { period: '2016-01-04', emps: 10000, Persent: 2800, Late: 0, Execues: 20, Vacation: 30, Absent: 150 },
    //        { period: '2016-01-05', emps: 10000, Persent: 2000, Late: 500, Execues: 27, Vacation: 20, Absent: 300 },
    //        { period: '2016-01-06', emps: 10000, Persent: 2000, Late: null, Execues: 10, Vacation: null, Absent: 150 },
    //        { period: '2016-01-07', emps: 10000, Persent: 6, Late: 122, Execues: 2647, Vacation: 10, Absent: null }
    //    ],
    //    xkey: 'period',
    //    ykeys: ['Persent', 'Late', 'Execues', 'Vacation', 'Absent'],
    //    labels: ['الحضور', 'التاخير', 'الاستاذانات', 'المجازين', 'الغياب'],
    //    hideHover: 'auto',
    //    lineColors: ['#8ce5f7', '#74d1e4', '#22a1ba', '#721e4', '#12a1ba'],
    //    resize: true
    //});
    
    Morris.Donut({
        element: 'morris4',
        data: [
            { label: 'التكليفات', value: 35},
            { label: 'الاستئذان', value: 45 },
            { label: 'التقصير', value: 30 },
            {label: 'الحضور', value: 20 }
        ],
        resize: true,
        formatter: function (y, data) { return  y+'%' },
        colors: ['#44b4cb', '#22a1ba', '#11869d', '#74d1e4'],
        
        
    });
});