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

            $scope.editLibraryItem = function (item) {
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
        }
]);