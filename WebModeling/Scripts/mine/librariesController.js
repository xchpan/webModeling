libraries.controller("librariesController", [
        '$scope', '$timeout', 'librariesService', function ($scope, $timeout, librariesService) {
            librariesService.getAllLibraries().success(function (data) {
                $scope.libraries = data;
                $timeout(function () {
                    $("#libraryList").accordion();
                });
            });

            librariesService.getAllVariableTypes().success(function (data) {
                $scope.variableTypes = data;
            });

            $scope.currentFluid = {
                Name: "",
                Description: ""
            };
            $scope.currentPort = {
                Name: "",
                Description: ""
            };
            $scope.currentModel = {
                Name: "",
                Description: ""
            };

            $scope.deleteLibrary = function (libraryId) {
                librariesService.deleteLibrary(libraryId).success(function () {
                    var index = findIndex($scope.libraries, libraryId);
                    $scope.libraries.splice(index, 1);
                    $timeout(function () {
                        $("#libraryList").accordion('refresh');
                    });
                }).error(function (data, status, headers, config) {
                    alert("error: " + data);
                });
            };

            $scope.createLibrary = function () {
                librariesService.createLibrary().success(function (data) {
                    $scope.libraries.push(data);
                    $timeout(function () {
                        $("#libraryList").accordion('refresh');
                        $(".dropdown-toggle").dropdown();
                    });
                });
            };

            $scope.addFluid = function (libraryId) {
                var index = findIndex($scope.libraries, libraryId);
                librariesService.createFluid(libraryId).success(function (data) {
                    $scope.libraries[index].Items.push(data);
                    $scope.currentFluid = data;
                    $scope.showFluidEditor();
                }).error(function (data, status, headers, config) {
                    alert("Failed to create a fluid.");
                });
            };

            $scope.addPort = function (libraryId) {
                var index = findIndex($scope.libraries, libraryId);
                librariesService.createPort(libraryId).success(function (data) {
                    $scope.libraries[index].Items.push(data);
                    $scope.currentPort = data;
                    $scope.currentLibrary = $scope.libraries[index];
                    $scope.showPortEditor();
                }).error(function (data, status, headers, config) {
                    alert("Failed to create a port.");
                });
            };

            $scope.addModel = function (libraryId) {
                var index = findIndex($scope.libraries, libraryId);
                librariesService.createModel(libraryId).success(function (data) {
                    $scope.libraries[index].Items.push(data);
                    $scope.currentModel = data;
                    $scope.showModelEditor();
                }).error(function (data, status, headers, config) {
                    alert("Failed to create a model.");
                });
            };

            $scope.editLibraryItem = function (library, item) {
                $scope.currentLibrary = library;
                switch (item.Type) {
                    case "Fluid":
                        $scope.currentFluid = item;
                        $scope.showFluidEditor();
                        break;
                    case "Port":
                        $scope.currentPort = item;
                        $scope.showPortEditor();
                        break;
                    case "Model":
                        $scope.currentModel = item;
                        $scope.showModelEditor();
                        break;
                }
            };

            $scope.showFluidEditor = function () {
                $("#portEditor").modal('hide');
                $("#modelEditor").modal('hide');
                $("#fluidEditor").modal('show');
            };

            $scope.showPortEditor = function () {
                $("#modelEditor").modal('hide');
                $("#fluidEditor").modal('hide');
                $("#portEditor").modal('show');
            };

            $scope.showModelEditor = function () {
                $("#fluidEditor").modal('hide');
                $("#portEditor").modal('hide');
                $("#modelEditor").modal('show');
            };

            $scope.addPortVariable = function (port) {
                var variable = {
                    IsFixedValue: false,
                    Name: "Variable " + port.Variables.length,
                    OverridenDefaultValue: null,
                    OverridenMax: null,
                    OverridenMin: null,
                    RequireUserToProvideInitialValue: false,
                    VariableTypeName: "Real"
                };
                port.Variables.push(variable);
            };

            $scope.deletePortVariable = function (port, index) {
                port.Variables.splice(index, 1);
            };

            $('#portEditor').on('hide.bs.modal', function (e) {
                var errors = librariesService.validatePort($scope.currentPort);
                if (errors != null) {
                    alert("This port template is invalid, please fix it!\n\n" + errors);
                    e.preventDefault();
                    e.stopImmediatePropagation();
                    return false;
                }

                librariesService.savePort($scope.currentLibrary, $scope.currentPort).error(function (data, status, headers, config) {
                    alert("Failed to save the port template, open and close it later to try to save another time.");
                });

                return true;
            });

            $scope.updatePortVariableType = function(variable, variableTypeName) {
                variable.VariableTypeName = variableTypeName;
            }
        }
]);