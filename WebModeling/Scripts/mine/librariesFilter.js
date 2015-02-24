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
}).filter('getSinkParameters', function() {
    return function(model, libraries) {
        var parameters = [];
        model.Parameters.forEach(function(parameter) {
            parameters.push(parameter.Name);
        });

        return parameters;
    };
}).filter('getSourceParameters', function() {
    return function(model, libraries) {
        var parameters = {TopLevel: [], ChildLevel: []};
        model.Parameters.forEach(function (parameter) {
            parameters.TopLevel.push(parameter.Name);
        });
        model.Ports.forEach(function(port) {
            if (port.Direction == "In") {
                var portInstance = { Name: port.Name, Parameters: [] };
                var templateName = port.PortTemplateName.split("/");
                var library = null;
                for (var i = 0; i < libraries.length; i++) {
                    if (libraries[i].Name == templateName[0]) {
                        library = libraries[i];
                        break;
                    }
                };
                var portTemplate = null;
                for (i = 0; i < library.Items.length; i++) {
                    if (library.Items[i].Type == "Port" && library.Items[i].Name == templateName[1]) {
                        portTemplate = library.Items[i];
                        break;
                    }
                }
                portTemplate.Parameters.forEach(function(p) {
                    portInstance.Parameters.push(p.Name);
                });
                parameters.ChildLevel.push(portInstance);
            }
        });

        return parameters;
    };
}).filter('topLevel', function() {
    return function(parameters) {
        return parameters.TopLevel;
    }
}).filter('childLevel', function () {
    return function (parameters) {
        return parameters.ChildLevel;
    }
});