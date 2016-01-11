var Xray = require('x-ray');

var url = "http://qiita.com/advent-calendar/2015/unity";
var x = Xray();

x(url, ".adventCalendarCalendar_day",
    [{
        day: ".adventCalendarCalendar_date",
        item_url: ".adventCalendarCalendar_comment a@href"
    }])
    (function (error, result) {
        console.log(result);
    })