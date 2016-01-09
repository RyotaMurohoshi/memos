var Xray = require('x-ray');

var url = "http://qiita.com/RyotaMurohoshi/items";
var x = Xray();

x(url, 
    ".tableList article.publicItem",
    [{
        title: 'h1 a'
    }])
    .paginate('ul.pagination a.js-next-page-link@href')
    .write('results.json');
