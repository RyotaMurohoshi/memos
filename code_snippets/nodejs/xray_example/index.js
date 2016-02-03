'use strict';
let Xray = require('x-ray');
let x = Xray();

let url = 'http://qiita.com/RyotaMurohoshi/items';

function show(error, result) {
    if (error) {
        console.log(error);
    } else {
        console.log(result);
    }
}

function simpleExample() {
    let selector = 'div.publicItem_body > h1 > a@href';
    x(url, selector)(show);
}

function arrayExample() {
    let selector = ['div.publicItem_body > h1 > a@href'];
    x(url, selector)(show);
}

function creatorExample() {
    let selector = 'div.publicItem_body > h1'
    let creator = { url: 'a@href', title: 'a' };
    x(url, selector, creator)(show);
}

function creatorArrayExample() {
    let selector = 'div.publicItem_body > h1'
    let creator = [{ url: 'a@href', title: 'a' }];
    x(url, selector, creator)(show);
}

function paginateExample() {
    let selector = 'div.publicItem_body > h1'
    let creator = [{ url: 'a@href', title: 'a' }];
    x(url, selector, creator)
        .paginate('a[rel=next]@href')
        (show);
}

paginateExample();