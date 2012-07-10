(function () {
    // represent a single client item
    var Client = function (name) {
        this.id = "";
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
            var clientName = self.clientName();

            $.ajax({
                url: "/api/client",
                data: { 'name': clientName, 'age': 16 },
                type: 'POST',
                statusCode: {
                    201: function (data) {
                        self.clients.push(new Client(clientName));
                        self.clientName('');
                    }
                }
            });
        };

        self.removeClient = function (client) {           
            $.ajax({
                url: '/api/client/' + client.name(),
                type: 'DELETE',
                cache: false,
                statusCode: {
                    200: function (data) {
                        self.clients.remove(client);
                    }
                }
            });
        };
    };

    var initialClients = [];

    // bind a new instance of our view model to the page
    var viewModel = new ViewModel(initialClients || []);
    ko.applyBindings(viewModel);

    $.get('/api/client', function (data) {
        $.each(data, function (idx, client) {
            viewModel.clients.push(new Client(client.name));
        });
    }, 'json');
})();