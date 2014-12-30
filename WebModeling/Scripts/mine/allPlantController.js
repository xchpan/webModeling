allPlants.controller("AllPlantController", ['$scope', 'allPlantService', function ($scope, allPlantService) {
    $(document).ready(function() {
        $('#showplants').click(function () {
            allPlantService.getAllPlants().success(function (data) {
                $scope.plants = data;
                $('#all-plants-form').dialog("open");
            });
        });

        $('#all-plants-form').dialog({ autoOpen: false, modal: true, width: 'auto' });
    });

    $scope.deletePlant = function (plantId) {
        allPlantService.deletePlant(plantId).success(function () {
            var index = findIndex($scope.plants, plantId);
            $scope.plants.splice(index, 1);
        }).error(function (data, status, headers, config) {
            alert("error: " + data);
        });
    };

    $scope.createPlant = function() {
        allPlantService.createPlant().success(function (data) {
            $scope.plants.push(data);
        });
    };

    $scope.updatePlant = function (plantId) {
        var plant = findPlant($scope.plants, plantId);
        allPlantService.updatePlant(plant).fail(function () {
            alert("Fail to update on server");
        });
    }
}]);

function findIndex(plants, id) {
    for (var i = 0; i < plants.length; i++) {

        if (plants[i].Id == id) {
            return i;
        }
    }

    return -1;
}

function findPlant(plants, id) {
    for (var i = 0; i < plants.length; i++) {

        if (plants[i].Id == id) {
            return plants[i];
        }
    }

    return null;
}