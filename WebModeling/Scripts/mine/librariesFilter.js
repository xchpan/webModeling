librariesFilter.factory('libraryFilterUtilities', [function() {
    var doFillChildren = function(type, name, typeName, libraries) {
        var instance = { Name: name, Parameters: [] };
        var templateName = typeName.split("/");
        var library = null;
        for (var i = 0; i < libraries.length; i++) {
            if (libraries[i].Name == templateName[0]) {
                library = libraries[i];
                break;
            }
        };
        var childTemplate = null;
        for (i = 0; i < library.Items.length; i++) {
            if (library.Items[i].Type == type && library.Items[i].Name == templateName[1]) {
                childTemplate = library.Items[i];
                break;
            }
        }
        childTemplate.Parameters.forEach(function(p) {
            instance.Parameters.push(p.Name);
        });

        return instance;
    };

    var doGetHierarchy = function(type, libraries) {
        var result = [];
        libraries.forEach(function (library) {
            var lib = { name: library.Name, children: [] };
            library.Items.forEach(function (item) {
                if (item.Type == type) {
                    lib.children.push(item.Name);
                }
            });
            if (lib.children.length > 0) {
                result.push(lib);
            }
        });
        return result;
    }

    return {
        fillChildren: function (type, name, typeName, libraries) { return doFillChildren(type, name, typeName, libraries); },
        getHierarchy: function (type, libraries) { return doGetHierarchy(type, libraries); }
    };
}]).filter('getPorts', function (libraryFilterUtilities) {
    return function (libraries) {
        return libraryFilterUtilities.getHierarchy("Port", libraries);
    };
}).filter('getModels', function (libraryFilterUtilities) {
    return function (libraries) {
        return libraryFilterUtilities.getHierarchy("Model", libraries);
    };
}).filter('getSinkParameters', function (libraryFilterUtilities) {
    return function (model, libraries) {
        var parameters = { TopLevel: [], ChildLevel: [] };
        model.Parameters.forEach(function (parameter) {
            parameters.TopLevel.push(parameter.Name);
        });
        model.Ports.forEach(function (port) {
            if (port.Direction == "Out") {
                var portInstance = libraryFilterUtilities.fillChildren("Port", port.Name, port.PortTemplateName, libraries);
                parameters.ChildLevel.push(portInstance);
            }
        });
        model.Submodels.forEach(function (child) {
            var portInstance = libraryFilterUtilities.fillChildren("Model", child.Name, child.ModelTypeName, libraries);
            parameters.ChildLevel.push(portInstance);
        });

        return parameters;
    };
}).filter('getSourceParameters', function (libraryFilterUtilities) {
    return function(model, libraries) {
        var parameters = {TopLevel: [], ChildLevel: []};
        model.Parameters.forEach(function (parameter) {
            parameters.TopLevel.push(parameter.Name);
        });
        model.Ports.forEach(function(port) {
            if (port.Direction == "In") {
                var portInstance = libraryFilterUtilities.fillChildren("Port", port.Name, port.PortTemplateName, libraries);
                parameters.ChildLevel.push(portInstance);
            }
        });
        model.Submodels.forEach(function (child) {
            var portInstance = libraryFilterUtilities.fillChildren("Model", child.Name, child.ModelTypeName, libraries);
                parameters.ChildLevel.push(portInstance);
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