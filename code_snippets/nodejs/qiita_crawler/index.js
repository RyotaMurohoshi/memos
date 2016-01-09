var Xray = require('x-ray');

var url = "http://qiita.com/RyotaMurohoshi/items";
var x = Xray();

x(url, 
    ".tableList article.publicItem",
    [{
        title: 'h1 a'
    }])
    .write('results.json');
