allSimulations.controller("AllSimulationController", ['$scope', 'allSimulationService', function ($scope, allSimulationService) {
    $(document).ready(function() {
        $('#showsimulations').click(function() {
            allSimulationService.getAllSimulations().success(function (data) {
                $scope.simulations = data;
                $('#all-simulation-form').dialog("open");
            });
        });

        $('#all-simulation-form').dialog({ autoOpen: false, modal: true, width: 'auto' });
    });

    $scope.deleteSimulation = function (simulationId) {
        allSimulationService.deleteSimulation(simulationId).success(function () {
            var index = findIndex($scope.simulations, simulationId);
            $scope.simulations.splice(index, 1);
        }).error(function (data, status, headers, config) {
            alert("error: " + data);
        });
    };

    $scope.createSimulation = function() {
        allSimulationService.createSimulation().success(function (data) {
            $scope.simulations.push(data);
        });
    };

    $scope.updateSimlation = function(simulationId) {
        var simulation = findSimulation($scope.simulations, simulationId);
        allSimulationService.updateSimulation(simulation).fail(function () {
            alert("Fail to update on server");
        });
    }
}]);

function findIndex(simulations, id) {
    for (var i = 0; i < simulations.length; i++) {

        if (simulations[i].Id == id) {
            return i;
        }
    }

    return -1;
}

function findSimulation(simulations, id) {
    for (var i = 0; i < simulations.length; i++) {

        if (simulations[i].Id == id) {
            return simulations[i];
        }
    }

    return null;
}