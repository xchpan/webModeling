librariesService.factory('librariesService', ['$http',
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
            for (i = 0; i < port.Variables.length; i++) {
                variableNames.push(port.Variables[i].Name);
            }
            var result = doCheckDuplicate(variableNames);
            if (result.length == 0) {
                return null;
            } else {
                return "The following array name(s) are duplicated: ".concat(result.join());
            }
        }

        return {
            getAllLibraries: function () { return doGetLibraries(); },
            deleteLibrary: function (libraryId) { return doDeleteLibrary(libraryId); },
            createLibrary: function () { return doCreateLibrary(); },
            createFluid: function (libraryId) { return doCreateFluid(libraryId); },
            createPort: function (libraryId) { return doCreatePort(libraryId); },
            createModel: function (libraryId) { return doCreateModel(libraryId); },
            getAllVariableTypes: function () { return doGetAllVariableTypes(); },
            validatePort : function (port) { return doValidatePort(port); }
        };
    }]);