librariesFilter.filter('getPorts', function () {
    return function (libraries) {
        var result = [];
        libraries.forEach(function (library) {
            var lib = { name: library.Name, ports: [] };
            library.Items.forEach(function (item) {
                if (item.Type == "Port") {
                    lib.ports.push(item.Name);
                }
            });
            if (lib.ports.length > 0) {
                result.push(lib);
            }
        });
        return result;
    };
}).filter('getModels', function () {
    return function (libraries) {
        var result = [];
        libraries.forEach(function (library) {
            var lib = { name: library.Name, models: [] };
            library.Items.forEach(function (item) {
                if (item.Type == "Model") {
                    lib.models.push(item.Name);
                }
            });
            if (lib.models.length > 0) {
                result.push(lib);
            }
        });
        return result;
    };
}).filter('getSourceParameters', function() {
    return function(model, libraries) {
        var parameters = [];
        model.Parameters.forEach(function(parameter) {
            parameters.push(parameter.Name);
        });

        return parameters;
    };
}).filter('getSinkParameters', function() {
    return function(model, libraries) {
        var parameters = [];
        model.Parameters.forEach(function (parameter) {
            parameters.push(parameter.Name);
        });

        return parameters;
    };
});