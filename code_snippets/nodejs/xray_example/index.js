'use strict';
let Xray = require('x-ray');
let x = Xray();

let url = 'http://qiita.com/RyotaMurohoshi/items';

{
    let selector = '#main > div > div > div.col-md-3.col-sm-3.col-xs-12.newUserPageProfile > div > div.col-xs-8.col-sm-12 > h3';

    x(url, selector)((error, result) => {
        if (error) {
            console.log(error);
        } else {
            console.log(result);
        }
    });
}
