allSimulationService.factory('allSimulationService', ['$http',
  function ($http) {
      var uri = 'api/simulations/';

      var doGetSimulations = function() {
          return $http.get(uri);
      }

      var doDeleteSimulation = function(simulationId) {
          var deleteUri = uri + simulationId;
          return $http.delete(deleteUri);
      }

      var doCreateSimulation = function() {
          return $http.post(uri);
      }

      var doUpdateSimulation = function(simulation) {
          var putUri = uri + simulation.Id;
          return $http.put(putUri, simulation);
      }

      return {
          getAllSimulations: function() { return doGetSimulations(); },
          deleteSimulation: function (simulationId) { return doDeleteSimulation(simulationId); },
          createSimulation: function () { return doCreateSimulation(); },
          updateSimulation: function (simulation) { return doUpdateSimulation(simulation); }
      };
  }]);