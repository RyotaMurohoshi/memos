'use strict'
var Ix = require('ix');

var source = Ix.Enumerable.range(0, 10);

console.log(source
    .where(it => it % 2 != 0)
    .select(it => it * 2)
    .toArray());

console.log(source
    .repeat()
    .take(15)
    .toArray());

console.log(source
    .bufferWithCount(3)
    .map(it => it.toArray())
    .toArray());

let dict = source.toDictionary(it => it, it => it * 10);
console.log(dict.tryGetValue(1));


let lookup = source.toLookup(it => it % 2);
console.log(lookup.get(0).toArray());
console.log(lookup.get(1).toArray());
