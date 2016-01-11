var Xray = require('x-ray');
var Promise = require("bluebird");

var url = "http://qiita.com/advent-calendar/2015/unity";
var x = Xray();

function crawlTargetCalendar(calendarUrl) {
    return new Promise(function (resolve, reject) {
        x(calendarUrl, ".adventCalendarCalendar_day",
            [{
                day: ".adventCalendarCalendar_date",
                item_url: ".adventCalendarCalendar_comment a@href"
            }])
            (function (error, result) {
                if (error) {
                    reject(error);
                } else {
                    resolve(result);
                }
            })
    });
}

crawlTargetCalendar(url).then(console.log);