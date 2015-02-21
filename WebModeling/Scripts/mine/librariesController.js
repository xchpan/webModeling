libraries.filter('getPorts', function () {
    return function (libraries) {
        var result = [];
        libraries.forEach(function (library) {
            var lib = { name: library.Name, ports: [] };
            library.Items.forEach(function (item) {
                if (item.Type == "Port") {
                    lib.ports.push(item.Name);
                }
            });
            result.push(lib);
        });
        return result;
    };
}).controller("librariesController", [
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

            librariesService.getAllFluidComponentTypes().success(function (data) {
                $scope.fluidComponentTypes = data;
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
                if ($("#portEditor").data('bs.modal') != null && $("#portEditor").data('bs.modal').isShown) {
                    $("#portEditor").modal('hide');
                }
                if ($("#modelEditor").data('bs.modal') != null && $("#modelEditor").data('bs.modal').isShown) {
                    $("#modelEditor").modal('hide');
                }
                $("#fluidEditor").modal('show');
            };

            $scope.showPortEditor = function () {
                if ($("#fluidEditor").data('bs.modal') != null && $("#fluidEditor").data('bs.modal').isShown) {
                    $("#fluidEditor").modal('hide');
                }
                if ($("#modelEditor").data('bs.modal') != null && $("#modelEditor").data('bs.modal').isShown) {
                    $("#modelEditor").modal('hide');
                }
                $("#portEditor").modal('show');
            };

            $scope.showModelEditor = function () {
                if ($("#portEditor").data('bs.modal') != null && $("#portEditor").data('bs.modal').isShown) {
                    $("#portEditor").modal('hide');
                }
                if ($("#fluidEditor").data('bs.modal') != null && $("#fluidEditor").data('bs.modal').isShown) {
                    $("#fluidEditor").modal('hide');
                }
                $("#modelEditor").modal('show');
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


            $scope.updatePortVariableType = function (variable, variableTypeName) {
                variable.VariableTypeName = variableTypeName;
            }

            $scope.addPortParameter = function (port) {
                var parameter = {
                    Name: "Parameter " + port.Parameters.length,
                    OverridenDefaultValue: null,
                    OverridenMax: null,
                    OverridenMin: null,
                    RequireUserToProvideInitialValue: false,
                    ParameterTypeName: "Real"
                };
                port.Parameters.push(parameter);
            };

            $scope.deletePortParameter = function (port, index) {
                port.Parameters.splice(index, 1);
            };


            $scope.updatePortParameterType = function (parameter, parameterTypeName) {
                parameter.ParameterTypeName = parameterTypeName;
            };

            $scope.addFluidComponent = function (fluid) {
                var component = {
                    ShortName: "H2O",
                    FullName: "Water",
                    StartingPercentage: 1.0
                };
                fluid.FluidComponents.push(component);
            };

            $scope.deleteFluidComponent = function (fluid, index) {
                fluid.FluidComponents.splice(index, 1);
            };

            $scope.setFluidComponentType = function (component, shortName, fullName) {
                component.ShortName = shortName;
                component.FullName = fullName;
            }

            $scope.addCondition = function (model) {
                var condition = {
                    Name: "Conditioin " + model.Conditions.length,
                    Formula: "1 = 1"
                };
                model.Conditions.push(condition);
            }

            $scope.deleteCondition = function (model, index) {
                model.Conditions.splice(index, 1);
            }

            $scope.addModelVariable = function (model) {
                var variable = {
                    IsFixedValue: false,
                    Name: "Variable " + model.Variables.length,
                    Condition: "",
                    OverridenDefaultValue: null,
                    OverridenMax: null,
                    OverridenMin: null,
                    RequireUserToProvideInitialValue: false,
                    VariableTypeName: "Real"
                };
                model.Variables.push(variable);
            }

            $scope.updateVariableCondition = function (variable, conditionName) {
                variable.Condition = conditionName;
            }

            $scope.addPortToModel = function(model) {
                var port = {
                    Name: "Port " + model.Ports.length,
                    Direction: "In",
                    PortTemplateName: ""
                };
                model.Ports.push(port);
            }

            $scope.deletePortFromModel = function(model, index) {
                model.Ports.splice(index, 1);
            }

            $scope.updatePortSource = function(port, portType) {
                port.PortTemplateName = portType;
            }
        }
]);