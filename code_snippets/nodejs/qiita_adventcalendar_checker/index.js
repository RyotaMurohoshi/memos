var Xray = require('x-ray');
var Promise = require("bluebird");
var _ = require('underscore');

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
            });
    });
}

function convertStatistics(crawlingResult) {
    return {
        postedCount: _.filter(crawlingResult, isPosted).length,
        qiitaItemCount: _.filter(crawlingResult, isQiitaItem).length,
    };

    function isPosted(aDay) { return !!(aDay.item_url); }
    function isQiitaUrl(itemUrl) { return itemUrl.indexOf("http://qiita.com") == 0; }
    function isQiitaItem(aDay) { return isPosted(aDay) && isQiitaUrl(aDay.item_url); }
}

crawlTargetCalendar(url).then(convertStatistics).then(console.log);