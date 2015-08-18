var localStorageCache = localStorageCache || {};

localStorageCache = function (storageType) {
    var self = this;
    var storage = storageType;

    function Init() {
        if (typeof (Storage) == "undefined")
            throw "Storage does not exist";
    }

    Init();

    self.setItem = function (key, jsonObject) {
        storage.setItem(key, JSON.stringify(jsonObject));

        return self;
    }
    self.getItem = function (key) {
        var item = storage.getItem(key);

        if (item == null)
            return ((typeof (defaultValue) != "undefined") ?
                defaultValue : null
                   );

        return JSON.parse(item);
    }

    self.removeItem = function (key) {
        storage.removeItem(key);

        return self;
    }

    self.hasItem = function (key) {
        return (this.storage.getItem(key) != null);
    }

    self.clear = function () {
        return storage.clear();

        return self;
    }


    return self;
}