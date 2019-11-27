var filter = function(e) {
    if (this.length == 2)
        return e[this[0]] == this[1];
};

//Object.prototype.add = function(id) {
//    var clength = this.push(new { ID: id, View: false, Insert: false, Update: false, Delete: false });
//    return this[clength - 1];
//};

//Object.prototype.removeByKey = function(key, val) {
//    var foundData = this.filter(filter, [key, val]);
//    if (foundData.length > 0) {
//        var itemIndex = this.indexOf(foundData[0]);
//        return this.splice(itemIndex, 1);
//    }
//    return [];
//};