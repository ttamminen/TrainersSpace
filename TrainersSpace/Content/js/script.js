(function() {
    // represent a single client item
    var Client = function (name) {
        this.name = ko.observable(name);
    };

    // our main view model
    var ViewModel = function (clients) {
        var self = this;

        self.clients = ko.observableArray(ko.utils.arrayMap(clients, function (client) {
            return new Client(client.name);
        }));
    };

    // check local storage for todos
    var clients = [{ name: "Tatu" }, { name: "Tamminen" }];

        // bind a new instance of our view model to the page
    ko.applyBindings(new ViewModel(clients || []));
})();