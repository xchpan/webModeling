libraries.controller("librariesController", ['$scope', 'librariesService', function ($scope, librariesService) {
    $(document).ready(function () {
        //librariesService.getAllLibraries().success(function (data) {
        //    $scope.libraries = data;
        //    //$("#libraryList").accordion();
        //});
    });

    $scope.deleteLibrary = function (libraryId) {
        librariesService.deleteLibrary(libraryId).success(function () {
            var index = findIndex($scope.libraries, libraryId);
            $scope.libraries.splice(index, 1);
        }).error(function (data, status, headers, config) {
            alert("error: " + data);
        });
    };

    $scope.createLibrary = function () {
        librariesService.createLibrary().success(function (data) {
            $scope.libraries.push(data);
        });
    };
}]);