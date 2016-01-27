'use strict'
var Ix = require('ix');

var source = Ix.Enumerable.fromArray([1, 2, 3]);

let array0 = source
    .where(it => it % 2 != 0)
    .select(it => it * 2)
    .toArray();
console.log(array0);

let array1 = source
    .repeat()
    .take(10)
    .toArray();
console.log(array1);

