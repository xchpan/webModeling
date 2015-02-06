libraries.controller("librariesController", [
        '$scope', '$timeout', 'librariesService', function ($scope, $timeout, librariesService) {
            librariesService.getAllLibraries().success(function (data) {
                $scope.libraries = data;
                $timeout(function () {
                    $("#libraryList").accordion();
                });
            });

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
                }).error(function (data, status, headers, config) {
                    alert("Failed to create a fluid.");
                });
            };

            $scope.addPort = function (libraryId) {
                var index = findIndex($scope.libraries, libraryId);
                librariesService.createPort(libraryId).success(function (data) {
                    $scope.libraries[index].Items.push(data);
                }).error(function (data, status, headers, config) {
                    alert("Failed to create a port.");
                });
            };

            $scope.addModel = function (libraryId) {
                var index = findIndex($scope.libraries, libraryId);
                librariesService.createModel(libraryId).success(function (data) {
                    $scope.libraries[index].Items.push(data);
                }).error(function (data, status, headers, config) {
                    alert("Failed to create a model.");
                });
            };
        }
]);