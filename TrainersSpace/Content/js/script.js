(function() {
    // represent a single client item
    var Client = function (name) {
        this.name = ko.observable(name);
    };

    // our main view model
    var ViewModel = function (clients) {
        var self = this;

        self.clientName = ko.observable("");

        self.clients = ko.observableArray(ko.utils.arrayMap(clients, function (client) {
            return new Client(client.name);
        }));

        self.validName = ko.computed(function () {
            if (self.clientName().length > 0)
                return true;

            return false;
        });

        self.addClient = function () {            
            self.clients.push(new Client(self.clientName()));
            self.clientName("");
        };
    };

    var clients = [];

    // bind a new instance of our view model to the page
    ko.applyBindings(new ViewModel(clients || []));
})();