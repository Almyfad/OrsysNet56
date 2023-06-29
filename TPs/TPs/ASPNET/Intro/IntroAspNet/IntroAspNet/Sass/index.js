"use strict";

const fs = require('fs');
const YAML = require('yaml')



console.log("🚀🚀🚀")
let a = { mail: 5, contact: 6, test: true }
a[0] = 6
a[100] = 5
a[1000] = true
console.log(a)


fs.readFile('y.yml', 'utf8', (err, data) => {
    if (err) {
        console.error(err);
        return;
    }
    console.log(data);
    let y = YAML.parse(data)
    console.log(y);

    let j = JSON.stringify(y)
    console.log(j);

});





