﻿librariesService.factory('librariesService', ['$http',
    function ($http) {
        var uri = 'api/libraries/';

        var doGetLibraries = function () {
            return $http.get(uri);
        }

        var doDeleteLibrary = function (libraryId) {
            var deleteUri = uri + libraryId;
            return $http.delete(deleteUri);
        }

        var doCreateLibrary = function () {
            return $http.post(uri);
        }

        var doCreateFluid = function (libraryId) {
            var creaetUri = uri + libraryId + "/fluid";
            return $http.post(creaetUri);
        }

        var doCreatePort = function (libraryId) {
            var creaetUri = uri + libraryId + "/port";
            return $http.post(creaetUri);
        }

        var doCreateModel = function (libraryId) {
            var creaetUri = uri + libraryId + "/model";
            return $http.post(creaetUri);
        }

        var doGetAllVariableTypes = function () {
            var variableTypesUri = uri + "variableTypes";
            return $http.get(variableTypesUri);
        }

        var doGetAllFluidComponentTypes = function() {
            var fluidComponentTypesUri = uri + "fluidComponentTypes";
            return $http.get(fluidComponentTypesUri);
        }

        var doCheckDuplicate = function (arr) {
            var sorted_arr = arr.sort();
            var results = [];
            for (var i = 0; i < arr.length - 1; i++) {
                if (sorted_arr[i + 1] == sorted_arr[i]) {
                    results.push(sorted_arr[i]);
                }
            }
            return results;
        }

        var doValidatePort = function (port) {
            var variableNames = [];
            for (var i = 0; i < port.Variables.length; i++) {
                variableNames.push(port.Variables[i].Name);
            }
            var variableNamesResult = doCheckDuplicate(variableNames);

            var parameterNames = [];
            for (i = 0; i < port.Parameters.length; i++) {
                parameterNames.push(port.Parameters[i].Name);
            }
            var parameterNamesResult = doCheckDuplicate(parameterNames);

            if (variableNamesResult.length == 0 && parameterNamesResult.length == 0) {
                return null;
            } else {
                var result = "The following name(s) are duplicated: ";
                if (parameterNamesResult.length != 0) {
                    result = result.concat("\nParameters: ").concat(parameterNamesResult.join());
                };
                if (variableNamesResult.length != 0) {
                    result = result.concat("\Variables: ").concat(variableNamesResult.join());
                };

                return result;
            }
        }

        var doSavePort = function(library, port) {
            var portUri = uri + library.Id + "/port";
            return $http.put(portUri, port);
        }

        return {
            getAllLibraries: function () { return doGetLibraries(); },
            deleteLibrary: function (libraryId) { return doDeleteLibrary(libraryId); },
            createLibrary: function () { return doCreateLibrary(); },
            createFluid: function (libraryId) { return doCreateFluid(libraryId); },
            createPort: function (libraryId) { return doCreatePort(libraryId); },
            createModel: function (libraryId) { return doCreateModel(libraryId); },
            getAllVariableTypes: function () { return doGetAllVariableTypes(); },
            validatePort: function (port) { return doValidatePort(port); },
            savePort: function (library, port) { return doSavePort(library, port); },
            getAllFluidComponentTypes: function () { return doGetAllFluidComponentTypes(); }
        };
    }]);